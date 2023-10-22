Imports System.Globalization
Imports System.Linq.Expressions
Imports LTRData.Extensions.Formatting
Imports LTRLib.MathExpression

Public Module Program

    Public Function Main(args As String()) As Integer

        Try
            Return UnsafeMain(args)

        Catch ex As Exception
            Console.Error.WriteLine(ex.JoinMessages())

            Return -1

        End Try

    End Function

    Public Function UnsafeMain(args As String()) As Integer

        If args Is Nothing OrElse args.Length < 1 Then
            Console.Error.WriteLine("Syntax:")
            Console.Error.WriteLine("netexpr mathexpression ...")
            Return -1
        End If

        Dim exprParser As New MathExpressionParser(CultureInfo.InvariantCulture)
        Dim parameters As ParameterExpression() = Nothing

        Dim expr = exprParser.ParseExpression(String.Join(" ", args), parameters)

        If parameters.Length > 0 Then
            Console.WriteLine($"Enter values for parameters: {parameters.Select(Function(p) p.Name).Join(", ")}")
        End If

        Dim paramValues As New Dictionary(Of String, KeyValuePair(Of ParameterExpression, Double))

        While Not parameters.All(Function(p) paramValues.ContainsKey(p.Name))

            Dim line = Console.ReadLine().Split({" "c, "="c}, StringSplitOptions.RemoveEmptyEntries)
            Dim param = parameters.FirstOrDefault(Function(p) p.Name = line(0))
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

            paramValues.Add(param.Name, New KeyValuePair(Of ParameterExpression, Double)(param, value))

        End While

#If NETFRAMEWORK AndAlso Not NET40_OR_GREATER Then
        Dim lambda = Expression.Lambda(expr, paramValues.Values.Select(Function(v) v.Key).ToArray()).Compile()
#Else
        Dim lambda = Expression.Lambda(expr, paramValues.Values.Select(Function(v) v.Key)).Compile()
#End If

        Dim values = paramValues.Values.Select(Function(v) CObj(v.Value)).ToArray()
        Dim returnValue = CDbl(lambda.DynamicInvoke(values))

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

End Module
