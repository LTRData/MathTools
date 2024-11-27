using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luhn;

public class Program
{
    public static void Main(params string[] args)
    {
        var PG = false;
        
        if (args.Length > 0)
        {
            if (args[0].Equals("/PG", StringComparison.OrdinalIgnoreCase))
            {
                PG = true;
            }
            else
            {
                Console.WriteLine(@"Appends Luhn checksum character to input strings.

Syntax:
luhn [/PG]
                
/PG      Create PlusGirot counted OCR string with
         both counter and Luhn checksum characters.
         Without this parameter, only Luhn checksum
         character is appended.");
                return;
            }
        }

        for(; ;)
        {
            var Line = Console.ReadLine();
            if (string.IsNullOrEmpty(Line))
            {
                break;
            }

            Console.WriteLine(AppendLuhn(Line, PG));
        }
    }

    /// <summary>
    /// Calculate Luhn checksum character for numeric string. Non-numeric characters are ignored.
    /// </summary>
    /// <param name="str">String containing numeric characters.</param>
    /// <returns>Numeric characters in input string with calculated checksum character appended.</returns>
    public static string AppendLuhn(string str, bool PG)
    {
        var digitsCount = str.Count(char.IsDigit);

        var sb = new StringBuilder(str);

        if (PG)
        {
            sb.Append((digitsCount + 2) % 10);
            str = sb.ToString();
        }

        sb.Append(CalculateLuhn(str));

        return sb.ToString();
    }

    /// <summary>
    /// Calculate and returns Luhn checksum character for numeric string.
    /// </summary>
    /// <param name="str">String containing numeric characters. An exception will occur if string contains non-numeric characters.</param>
    /// <returns>Calculated Luhn checksum character.</returns>
    public static char CalculateLuhn(string str)
    {
        var checksum = 0;

        var factor = str.Length & 1;

        foreach (var chr in str)
        {
            if (chr is < '0' or > '9')
            {
                continue;
            }

            var c = (chr - '0') << factor;

            checksum += c / 10 + c % 10;

            factor ^= 1;
        }

        checksum = (10 - checksum % 10) % 10;

        return (char)(checksum + '0');
    }
}
