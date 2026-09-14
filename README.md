# MathTools

Small .NET command-line utilities from LTR Data for evaluating mathematical
expressions, converting coordinates, appending check digits, and converting
Base64 data.

## Projects

| Project | Purpose | Declared target frameworks |
| --- | --- | --- |
| [netexpr](netexpr) | Evaluate a mathematical expression, prompting for values of any variables. | .NET 8/9/10; .NET Framework 3.5 and 4.0 |
| [coordtool](coordtool) | Convert coordinates between WGS84, RT90, SWEREF99, and Maidenhead representations; display distance and bearing information relative to the first position. | .NET 8/9/10; .NET Framework 3.5 and 4.0 |
| [luhn](luhn) | Append a Luhn check digit to input lines, with an optional PlusGirot counted OCR mode. | .NET 8/9/10; .NET Framework 3.5 and 4.0 |
| [base64](base64) | Encode bytes or UTF-8 command-line strings as Base64, or decode Base64 to bytes. | .NET 8/9/10; .NET Framework 2.0 and 4.0 |
| [netexpr.Review](netexpr.Review) | Developer checks for expression syntax, variables, diagnostics, culture handling, and numeric exit codes. | .NET 10 |

The GraphViewer desktop application has moved to
[LTRData/WindowsTools](https://github.com/LTRData/WindowsTools).

## Build and run

Use a .NET 10 SDK for the current .NET 10 targets. Build the individual tool you
need, for example:

```sh
git clone https://github.com/LTRData/MathTools.git
cd MathTools
dotnet build netexpr/netexpr.vbproj -c Release -f net10.0
dotnet Release/net10.0/netexpr.dll "1 + 2 * 3"
```

This prints `7` and returns exit code `7`; see the numeric exit-code convention
below.

[MathTools.slnx](MathTools.slnx) contains all five projects and needs an
IDE/MSBuild version that supports `.slnx`.
[Directory.Build.props](Directory.Build.props) places outputs under the root
`Release/<framework>/` or `Debug/<framework>/` directory.
Building the older .NET Framework targets requires their reference assemblies.

The utilities use managed console APIs. The focused netexpr review workflow
covers Linux and Windows; it does not establish platform coverage for every
tool and target.

NuGet restore supplies the dependencies from
[LTRData/Library](https://github.com/LTRData/Library). netexpr references
`LTRData.MathExpression` 1.1.0 and a floating `LTRData.Extensions` version.
coordtool uses floating versions of `LTRData.Geodesy` and `LTRData.Extensions`.
base64 and luhn have no package references.

## Usage

The examples below assume the corresponding projects have been built for
`net10.0`, using the same `dotnet build ... -c Release -f net10.0` pattern.

### netexpr

Quote the formula so the shell preserves operators and parentheses:

```sh
dotnet Release/net10.0/netexpr.dll "2^3^2"
dotnet Release/net10.0/netexpr.dll "-2^2"
dotnet Release/net10.0/netexpr.dll "a + 2*b"
```

The first two expressions print `512` and `-4`. For the third, enter `a=3`
and `b=4` on separate input lines to obtain `11`. Parameters are prompted in
first-use order, and names are case-insensitive. Numeric input and output use
a decimal point regardless of the system locale.

The current implementation uses parsing, binding, and interpreted evaluation
from `LTRData.MathExpression`. Both `^` and `**` mean exponentiation; powers
associate to the right and bind more strongly than a leading sign. The modern
language does not retain the old shift/bitwise syntax. See the
[migration notes](docs/netexpr-migration.md) and
[expression language specification](https://github.com/LTRData/Library/blob/master/docs/math-expression-redesign/language-specification.md)
for more detail.

**Exit codes carry the calculated result:** netexpr returns the result rounded
to an integer using VB `CInt` (ties to even). Errors, non-finite results, or
integer-conversion overflow return `-1`; a calculated result can also be
negative. Shells may truncate exit codes. Use the printed result for the full
numeric value, and do not interpret every nonzero exit code as a failed
calculation.

### coordtool

Pass each complete position as one argument. For example, with WGS84 latitude
and longitude in decimal degrees:

```sh
dotnet Release/net10.0/coordtool.dll "57.7,11.97" "59.33,18.07"
```

The tool prints WGS84 decimal and degrees/minutes/seconds forms, SWEREF99,
Maidenhead, and RT90 coordinates. Later positions are compared with the first
successfully parsed position. RT90 input uses `"x=6580000,y=1620000"`;
SWEREF99 input uses `"SWEREF99:6580000,674000"` (northing, easting).
The tool uses the library's default projections: RT90 2.5 gon V and SWEREF99 TM.

### luhn

Read numeric strings from standard input, one per line. A blank line or EOF
ends processing. This POSIX-shell example prints `79927398713`:

```sh
printf '%s\n' 7992739871 | dotnet Release/net10.0/luhn.dll
```

Use `luhn /PG` to append a length-counter digit before calculating the Luhn
digit for PlusGirot counted OCR strings. The tool appends digits; it does not
provide a check-digit validation mode.

### base64

```sh
dotnet Release/net10.0/base64.dll -e "Hello"
dotnet Release/net10.0/base64.dll -d "SGVsbG8="
```

Encoding prints `SGVsbG8=` followed by a newline. Decoding writes the bytes for
`Hello` without adding a newline. With no string arguments, input comes from
standard input; no options selects encoding. Command-line strings are literal
data, not file names.

## netexpr developer review

```sh
dotnet run --project netexpr.Review/netexpr.Review.csproj -c Release -f net10.0
```

The review calls the real command-line entry point with redirected streams and
checks 13 scenarios under Swedish culture. It returns zero when the checks pass,
independently of netexpr's numeric-result exit convention.

The [package review workflow](.github/workflows/netexpr-review.yml) builds Library
packages from a pinned revision into a local feed, builds all netexpr targets,
and runs the review on Linux and Windows. For local dependency changes, see the
[netexpr migration notes](docs/netexpr-migration.md) and Library's
[local package workflow](https://github.com/LTRData/Library/blob/master/docs/local-package-workflow.md).
