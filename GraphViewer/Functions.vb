Imports System.Math

Public Class MathExtensions

  Public Shared Function Sec(X As Double) As Double
    Sec = 1 / Cos(X)
  End Function

  Public Shared Function Cosec(X As Double) As Double
    Cosec = 1 / Sin(X)
  End Function

  Public Shared Function Cotan(X As Double) As Double
    Cotan = 1 / Tan(X)
  End Function

  Public Shared Function Arcsin(X As Double) As Double
    Arcsin = Asin(X)
  End Function

  Public Shared Function Arccos(X As Double) As Double
    Arccos = Acos(X)
  End Function

  Public Shared Function Arctan(X As Double) As Double
    Arctan = Atan(X)
  End Function

  Public Shared Function Atn(X As Double) As Double
    Atn = Atan(X)
  End Function

  Public Shared Function Sqr(X As Double) As Double
    Sqr = Sqrt(X)
  End Function

  Public Shared Function Sgn(X As Double) As Double
    Sgn = Sign(X)
  End Function

  Public Shared Function Arcsec(X As Double) As Double
    Arcsec = Atan(X / Sqrt(X * X - 1)) + Sign(X - 1) * (2 * Atan(1))
  End Function

  Public Shared Function Arccosec(X As Double) As Double
    Arccosec = Atan(X / Sqrt(X * X - 1)) + (Sign(X) - 1) * (2 * Atan(1))
  End Function

  Public Shared Function Arccotan(X As Double) As Double
    Arccotan = Atan(X) + 2 * Atan(1)
  End Function

  Public Shared Function HSin(X As Double) As Double
    HSin = Sinh(X)
  End Function

  Public Shared Function HCos(X As Double) As Double
    HCos = Cosh(X)
  End Function

  Public Shared Function HTan(X As Double) As Double
    HTan = Tanh(X)
  End Function

  Public Shared Function HSec(X As Double) As Double
    HSec = 2 / (Exp(X) + Exp(-X))
  End Function

  Public Shared Function HCosec(X As Double) As Double
    HCosec = 2 / (Exp(X) - Exp(-X))
  End Function

  Public Shared Function HCotan(X As Double) As Double
    HCotan = (Exp(X) + Exp(-X)) / (Exp(X) - Exp(-X))
  End Function

  Public Shared Function HArcsin(X As Double) As Double
    HArcsin = Log(X + Sqrt(X * X + 1))
  End Function

  Public Shared Function HArccos(X As Double) As Double
    HArccos = Log(X + Sqrt(X * X - 1))
  End Function

  Public Shared Function HArctan(X As Double) As Double
    HArctan = Log((1 + X) / (1 - X)) / 2
  End Function

  Public Shared Function HArcsec(X As Double) As Double
    HArcsec = Log((Sqrt(-X * X + 1) + 1) / X)
  End Function

  Public Shared Function HArccosec(X As Double) As Double
    HArccosec = Log((Sign(X) * Sqrt(X * X + 1) + 1) / X)
  End Function

  Public Shared Function HArccotan(X As Double) As Double
    HArccotan = Log((X + 1) / (X - 1)) / 2
  End Function

  Public Shared Function LogN(X As Double, N As Double) As Double
    LogN = Log(X) / Log(N)
  End Function

  Public Shared Function Fac(X As Double) As Double

    Dim R As Double = 1
    For C As Double = 2 To X
      R = R * C
    Next
    Fac = R

  End Function

End Class