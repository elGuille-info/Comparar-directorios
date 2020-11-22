'------------------------------------------------------------------------------
' gsCommander (Comparar directorios)                                (22/Nov/20)
'
' Este método es el punto de entrada de la aplicación (método Main)
' No es necesario hacer nada especial para que sea el punto de entrada,
' solo definirlo en un módulo o una clase pública (en ese caso, declarado con Shared).
'
' Lo uso porque así puedo usar los mismos ficheros que 'Comparar directorios'
' y cambiar el título de la ventana y algunas otras opciones.
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Linq
Imports Microsoft.VisualBasic

Class Program ' Module Program

    Public Shared Sub Main()
        ' Esto es válido en .NET 5.0
        'Application.SetHighDpiMode(HighDpiMode.SystemAware)

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1 With {
                        .Text = "gsCommander - Mostrar el contenido de 2 directorios y gestionarlos",
                        .TemaActual = Form1.Temas.ComandanteNorton
                        })
    End Sub

End Class 'End Module
