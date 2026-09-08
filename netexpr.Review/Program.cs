using System.Globalization;

var originalOut = Console.Out;
var originalError = Console.Error;
var originalInput = Console.In;
var originalCulture = CultureInfo.CurrentCulture;
var count = 0;
try
{
    // Formula syntax, parameter numbers and results remain invariant on a Swedish host.
    CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
    Check(["2^3^2"], "", 512, "512");
    Check(["-2^2"], "", -4, "-4");
    Check(["1", "+", "2", "*", "3"], "", 7, "7");
    Check(["atan2(0, 1)"], "", 0, "0");
    Check([".5 x"], "X=4\n", 2, "2");
    Check(["b+a+B"], "\nz=1\nb=wrong\nb=2\nB=3\na=4\n", 10, "10",
        "Parameter z not part of expression.", "Invalid parameter value b=wrong", prompt: "b, a");
    Check(["a+b"], "a=3\n", -1, null, "Input ended before all parameter values were supplied.");
    Check(["sin(1,2)"], "", -1, null, "MATH300");
    Check(["1 << 10"], "", -1, null, "MATH");
    Check(["(1+2"], "", -1, null, "MATH");
    Check(["2.5"], "", 2, "2.5");
    Check(["sqrt(-1)"], "", -1, "NaN");
    Check([], "", -1, null, "Syntax:");
    originalOut.WriteLine($"PASS: {count} CLI scenarios, invariant culture, variables, diagnostics and numeric exit codes.");
    return 0;
}
finally
{
    Console.SetOut(originalOut);
    Console.SetError(originalError);
    Console.SetIn(originalInput);
    CultureInfo.CurrentCulture = originalCulture;
}

void Check(string[] arguments, string input, int exitCode, string? lastLine,
    string? error = null, string? secondError = null, string? prompt = null)
{
    using var output = new StringWriter(CultureInfo.InvariantCulture);
    using var errors = new StringWriter(CultureInfo.InvariantCulture);
    using var reader = new StringReader(input);
    Console.SetOut(output);
    Console.SetError(errors);
    Console.SetIn(reader);
    var actual = netexpr.Program.Main(arguments);
    if (actual != exitCode) throw new Exception($"Exit code for {string.Join(' ', arguments)}: expected {exitCode}, got {actual}. {errors}");
    if (lastLine is not null && output.ToString().TrimEnd().Split('\n')[^1].TrimEnd('\r') != lastLine)
        throw new Exception($"Unexpected output: {output}");
    foreach (var expected in new[] { error, secondError })
        if (expected is not null && !errors.ToString().Contains(expected, StringComparison.Ordinal))
            throw new Exception($"Missing diagnostic {expected}: {errors}");
    if (error is null && errors.GetStringBuilder().Length != 0) throw new Exception(errors.ToString());
    if (prompt is not null && !output.ToString().Contains("Enter values for parameters: " + prompt + Environment.NewLine))
        throw new Exception($"Unexpected variable order or duplicate variable: {output}");
    count++;
}
