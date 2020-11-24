'------------------------------------------------------------------------------
' Clase de tipo Exception para la biblioteca de compresión          (28/Jun/06)
'
' ©Guillermo 'guille' Som, 2006
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports Microsoft.VisualBasic
Imports System

Public Class FormatoIncorrectoException
    Inherits Exception

    Public Sub New()
        MyBase.New("El archivo no tiene un formato comprimido correcto.")
    End Sub
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
End Class
