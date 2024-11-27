using LTRData.Extensions.Buffers;
using LTRLib.Geodesy.Positions;
using System;
using System.Globalization;

namespace coordtool;

public static class Program
{
    public static void Main(params string[] args)
    {
        WGS84Position basepos = null;

        foreach (var arg in args)
        {
            try
            {
                WGS84Position pos;
                SWEREF99Position SW99pos;
                RT90Position RTcoord;

                if (arg.Length >= 7 &&
                    arg.Contains(',') &&
                    arg.TrimStart().Substring(0, 2).Equals("x=", StringComparison.InvariantCultureIgnoreCase) &&
                    arg.Substring(arg.IndexOf(',') + 1).TrimStart().Substring(0, 2).Equals("y=", StringComparison.InvariantCultureIgnoreCase))
                {
                    var coordstr = arg.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (coordstr.Length != 2)
                    {
                        throw new FormatException("Invalid RT90 coordinate string.");
                    }

                    var x = coordstr[0].Trim().Substring(2);
                    var y = coordstr[1].Trim().Substring(2);

                    RTcoord = new RT90Position(x, y);
                    pos = RTcoord.ToWGS84();
                    SW99pos = new SWEREF99Position(pos);
                }
                else if (arg.StartsWith("SWEREF99:", StringComparison.InvariantCultureIgnoreCase))
                {
                    SW99pos = new SWEREF99Position(arg.Substring("SWEREF99:".Length));
                    pos = SW99pos.ToWGS84();
                    RTcoord = new RT90Position(pos);
                }
                else
                {
                    pos = new WGS84Position(arg);
                    RTcoord = new RT90Position(pos);
                    SW99pos = new SWEREF99Position(pos);
                }

                Console.WriteLine("WGS84:");
                Console.WriteLine($"Degrees dec: {pos.ToString(LatLonPosition.GeoFormat.Degrees)}");
                Console.WriteLine($"Degrees dms: {pos.ToString(LatLonPosition.GeoFormat.DegreesMinutesSeconds)}");

                Console.WriteLine($"SWEREF99: {SW99pos}");

                Console.WriteLine($"Maidenhead: {pos.ToMaidenhead()}");

                Console.WriteLine($"RT90: {RTcoord}");

                if (basepos == null)
                {
                    basepos = pos;
                }
                else
                {
                    Console.WriteLine();

                    var throughdistance = basepos.GetDistanceThroughEarth(pos);
                    var surfacedistance = Position.GetSurfaceDistance(throughdistance, basepos.EarthRadius);
                    var wwldistancepoints = basepos.GetWWLDistancePoints(pos);
                    var bearing = basepos.GetBearing(pos);
                    var reversebearing = 180 + bearing;
                    if (reversebearing > 360)
                    {
                        reversebearing -= 360;
                    }

                    Console.WriteLine($"Through distance: {(throughdistance / 1000).ToString("0.00", NumberFormatInfo.InvariantInfo)} km");
                    Console.WriteLine($"Surface distance: {(surfacedistance / 1000).ToString("0.00", NumberFormatInfo.InvariantInfo)} km");
                    Console.WriteLine($"Distance points: {wwldistancepoints} km");
                    Console.WriteLine($"Bearing: {bearing.ToString("0.00", NumberFormatInfo.InvariantInfo)}°");
                    Console.WriteLine($"Reverse bearing: {reversebearing.ToString("0.00", NumberFormatInfo.InvariantInfo)}°");
                    if (pos.Equals(basepos))
                    {
                        Console.WriteLine("Position is equal to first position");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Write(" (");
                Console.Write(arg);
                Console.WriteLine(")");
            }

            Console.WriteLine();
        }
    }
}
