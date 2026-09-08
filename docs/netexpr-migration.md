# netexpr modern expression API review

The migration uses `MathParser`, `MathBinder`, the standard symbol catalog and
interpreted evaluation from `LTRData.MathExpression` 1.1.0. All existing
targets remain: net35, net40, net8.0, net9.0 and net10.0.

Formula arguments are joined as before. Variables are prompted in first-use order,
with case-insensitive `name=value` assignments and invariant numeric syntax.
Repeated names share a slot; reassignment updates it while other values are pending.
Blank input is ignored; EOF with missing values returns a useful error. Parse and
binding errors include diagnostic codes and source spans.

The modern language has right-associative power (`2^3^2` = 512), with power before
unary sign (`-2^2` = -4). `^` and `**` both mean power. Shift/bitwise syntax and the
old parser's accidental precedence rules are not retained. The authoritative
[language specification](https://github.com/LTRData/Library/blob/experimental/math-expression-redesign/docs/math-expression-redesign/language-specification.md)
describes functions, constants and implicit multiplication.

Output and the historical numeric exit code are retained. The printed result is
invariant; the exit code uses VB `CInt` rounding (ties to even), or -1 for errors,
non-finite values or conversion overflow. A nonzero result is therefore not a
conventional process-success code, and a shell may truncate it.

## Build through the local feed

Set `LocalNuGetPath` to a shared package directory. In the Library experimental
checkout, build these projects in Release, which produces their NuGet packages:

```sh
dotnet build LTRData.Extensions/LTRData.Extensions.csproj -c Release
dotnet build LTRData.MathExpression/LTRData.MathExpression.csproj -c Release
```

Configure this repository's local NuGet.Config to include the shared directory,
then build and run the review executable:

```sh
dotnet restore netexpr/netexpr.vbproj --force-evaluate
dotnet build netexpr/netexpr.vbproj -c Release --no-restore
dotnet run --project netexpr.Review/netexpr.Review.csproj -c Release
```

The review executable calls the real command-line entry point with redirected
streams under Swedish culture, checking 13 scenarios. It returns zero on success,
independently of the calculator's numeric exit-code convention. The only
ProjectReference is between projects in this repository; Library is consumed
through packages. `Directory.Build.props` now has the standard filename casing so
Unix builds apply the same common settings.

The focused `netexpr package review` workflow repeats the chain on Linux and
Windows. It uses a pinned Library commit, a shared output feed, package source
mapping and a fresh cache. Nothing is published to a NuGet server. For equivalent
local configuration, see Library's
[local package workflow](https://github.com/LTRData/Library/blob/experimental/math-expression-redesign/docs/local-package-workflow.md).

The application owner has built and tested this migration successfully. Saved
formulas and shell scripts remain useful review cases, particularly any that use
old operator syntax or assume a conventional zero-on-success exit code.
