Imports System.Globalization
Imports LTRData.Extensions.Formatting
Imports LTRData.MathExpression

Public Module Program

    Public Function Main(args As String()) As Integer

        Try
            Return UnsafeMain(args)

        Catch ex As Exception
            Console.Error.WriteLine(ex.JoinMessages())

            Return -1

        End Try

    End Function

    Private ReadOnly separator As Char() = {" "c, "="c}

    Public Function UnsafeMain(args As String()) As Integer

        If args Is Nothing OrElse args.Length < 1 Then
            Console.Error.WriteLine("Syntax:")
            Console.Error.WriteLine("netexpr mathexpression ...")
            Return -1
        End If

        Dim parse = MathParser.Default.Parse(String.Join(" ", args))
        If Not parse.Success Then
            Return ReportDiagnostics(parse.Diagnostics)
        End If

        Dim binding = MathBinder.Bind(parse.Root, MathSymbolCatalog.Standard)
        If Not binding.Success Then
            Return ReportDiagnostics(binding.Diagnostics)
        End If

        Dim expression = binding.Expression
        Dim parameters = expression.Variables
        Dim values(parameters.Count - 1) As Double
        Dim supplied(parameters.Count - 1) As Boolean
        Dim remaining = parameters.Count

        If remaining > 0 Then
            Console.WriteLine($"Enter values for parameters: {parameters.Select(Function(p) p.Name).Join(", ")}")
        End If

        While remaining > 0
            Dim input = Console.ReadLine()
            If input Is Nothing Then
                Console.Error.WriteLine("Input ended before all parameter values were supplied.")
                Return -1
            End If

            Dim line = input.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            If line.Length = 0 Then
                Continue While
            End If

            Dim param = parameters.FirstOrDefault(Function(p) String.Equals(p.Name, line(0), StringComparison.OrdinalIgnoreCase))
            If param Is Nothing Then
                Console.Error.WriteLine($"Parameter {line(0)} not part of expression.")
                Continue While
            End If

            If line.Length <> 2 Then
                Console.Error.WriteLine($"Expected value for parameter {line(0)}")
                Console.Error.WriteLine($"Syntax example: {line(0)}=2.5")
                Continue While
            End If

            Dim value As Double = Nothing

            If Not Double.TryParse(line(1), NumberStyles.Float, NumberFormatInfo.InvariantInfo, value) Then
                Console.Error.WriteLine($"Invalid parameter value {line(0)}={line(1)}")
                Continue While
            End If

            values(param.Slot) = value
            If Not supplied(param.Slot) Then
                supplied(param.Slot) = True
                remaining -= 1
            End If

        End While

        Dim returnValue = expression.Evaluate(values)

        Console.WriteLine(returnValue.ToString(NumberFormatInfo.InvariantInfo))

        Try
            Return CInt(returnValue)

        Catch
            Return -1

        Finally
            If Debugger.IsAttached Then
                Console.ReadKey()
            End If

        End Try

    End Function

    Private Function ReportDiagnostics(diagnostics As IEnumerable(Of MathDiagnostic)) As Integer
        For Each diagnostic In diagnostics
            Console.Error.WriteLine(diagnostic.ToString())
        Next
        Return -1
    End Function

End Module
