Imports System.Text
Imports System.Security
Imports System.Security.Permissions
Imports System.IO
Imports System.Reflection
Imports LTRLib.MathExpression
Imports LinqExpression = System.Linq.Expressions.Expression
Imports System.Linq.Expressions
Imports System.Linq
Imports System.Threading
Imports System.Globalization

Public Class ScriptControl

    Protected Delegate Function ExpressionMethodDelegate(X As Double, Y As Double) As Double

    Protected ExpressionMethod As ExpressionMethodDelegate

    Protected ReadOnly MathExpressionParser As MathExpressionParser

    Protected ReadOnly CurrentCulture As CultureInfo

    Public Sub New(CultureInfo As CultureInfo)
        MathExpressionParser = New MathExpressionParser(CultureInfo.NumberFormat)
        CurrentCulture = CultureInfo
    End Sub

    Protected m_Expression As String

    Public Property Expression As String
        Get
            Return m_Expression
        End Get
        Set
            If Value = m_Expression Then
                Return
            End If

            Dim parameters As ParameterExpression() = Nothing

            Dim expr = MathExpressionParser.ParseExpression(Value, parameters)

            Dim params As ParameterExpression() = {
                parameters.SingleOrDefault(Function(p) "x".Equals(p.Name)),
                parameters.SingleOrDefault(Function(p) "y".Equals(p.Name))
            }
            If params(0) Is Nothing Then
                params(0) = LinqExpression.Parameter(GetType(Double), "x")
            End If
            If params(1) Is Nothing Then
                params(1) = LinqExpression.Parameter(GetType(Double), "y")
            End If

            ExpressionMethod = LinqExpression.
                Lambda(Of ExpressionMethodDelegate)(expr, params).
                Compile()

            Dim currentThCulture = Thread.CurrentThread.CurrentCulture
            Dim currentUICulture = Thread.CurrentThread.CurrentUICulture

            Thread.CurrentThread.CurrentCulture = CurrentCulture
            Thread.CurrentThread.CurrentUICulture = CurrentCulture

            m_Expression = expr.ToString().ToLowerInvariant()

            Thread.CurrentThread.CurrentCulture = currentThCulture
            Thread.CurrentThread.CurrentUICulture = currentUICulture
        End Set
    End Property

    Public Function Eval(X As Double, Y As Double) As Double?
        If ExpressionMethod Is Nothing Then
            Return Nothing
        End If

        Try
            Return ExpressionMethod(X, Y)

        Catch
            Return Nothing

        End Try
    End Function

End Class
