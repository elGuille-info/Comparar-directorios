Option Strict On
Option Infer On

'Imports System
'Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Linq
Imports System.Xml


Public Class Class1
    Private Sub AlgoPruebaIL()
        '' Las dos formas usan la misma cantidad de código IL

        '' Actualizar las listas de directorios
        '' Aunque se añade en MostrarContenidoDirectorio
        '' añadirlo aquí y reasignar las listas
        'If UltimosDirs.Contains(sIL) = False Then
        '    UltimosDirs.Add(sIL)
        '    ' Ajustar el menú de la lista de últimos directorios
        '    ' Asignar los ultimos directorios a los menús
        '    AsignarMenuUltimosDir(BtnAbrirDirIzqDropDown)
        '    AsignarMenuUltimosDir(BtnAbrirDirDerDropDown)
        'End If

        '' Para comprobar cuál tiene menos código IL
        'If Not UltimosDirs.Contains(sIL) Then
        '    UltimosDirs.Add(sIL)
        '    ' Ajustar el menú de la lista de últimos directorios
        '    ' Asignar los ultimos directorios a los menús
        '    AsignarMenuUltimosDir(BtnAbrirDirIzqDropDown)
        '    AsignarMenuUltimosDir(BtnAbrirDirDerDropDown)
        'End If

        Dim s As String
        Dim sIL As String = "Prueba IL"

        ' Este ocupa 9 instrucciones
        s = "If sIL.Any Then"
        If sIL.Any Then
            s = "1"
        End If

        ' Este ocupa 11 instrucciones
        s = "If Not String.IsNullOrEmpty(sIL) Then"
        If Not String.IsNullOrEmpty(sIL) Then
            s = "2"
        End If

        ' Este ocupa 11 instrucciones
        s = "If Not sIL.Any Then"
        If Not sIL.Any Then
            s = "3"
        End If

        ' Este ocupa 9 instrucciones
        s = "If String.IsNullOrEmpty(sIL) Then"
        If String.IsNullOrEmpty(sIL) Then
            s = "4"
        End If


        ' Este ocupa 11 instrucciones
        s = "If sIL.Any = False Then"
        If sIL.Any = False Then
            s = "5"
        End If

        ' Este ocupa 11 instrucciones
        s = "If String.IsNullOrEmpty(sIL) = False Then"
        If String.IsNullOrEmpty(sIL) = False Then
            s = "6"
        End If

        '
        ' Resumiendo, los que usan el Not o = False tienen 2 instrucciones más
        '

        Debug.Write(s)
    End Sub

    Private Sub PruebaCódigoCS()

        Dim códigoCS = <body>#define DEBUG
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyVersion("0.0.0.0")]
public class Class1
{
    private void AlgoPruebaIL()
    {
        string text = "Prueba IL";
        string text2 = "If sIL.Any Then";
        if (Enumerable.Any(text))
        {
            text2 = "1";
        }
        text2 = "If Not String.IsNullOrEmpty(sIL) Then";
        if (!string.IsNullOrEmpty(text))
        {
            text2 = "2";
        }
        text2 = "If Not sIL.Any Then";
        if (!Enumerable.Any(text))
        {
            text2 = "3";
        }
        text2 = "If String.IsNullOrEmpty(sIL) Then";
        if (string.IsNullOrEmpty(text))
        {
            text2 = "4";
        }
        Debug.Write(text2);
    }

    private void PruebaCódigoCS()
    {
        XElement xElement = new XElement(XName.Get("body", ""));
        xElement.Add("#define DEBUG\nusing System.Diagnostics;\nusing System.Linq;\nusing System.Reflection;\nusing System.Runtime.CompilerServices;\n\n[assembly: CompilationRelaxations(8)]\n[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]\n[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]\n[assembly: AssemblyVersion(\"0.0.0.0\")]\npublic class Class1\n{\n    private void AlgoPruebaIL()\n    {\n        string text = \"Prueba IL\";\n        string text2 = \"If sIL.Any Then\";\n        if (Enumerable.Any(text))\n        {\n            text2 = \"1\";\n        }\n        text2 = \"If Not String.IsNullOrEmpty(sIL) Then\";\n        if (!string.IsNullOrEmpty(text))\n        {\n            text2 = \"2\";\n        }\n        text2 = \"If Not sIL.Any Then\";\n        if (!Enumerable.Any(text))\n        {\n            text2 = \"3\";\n        }\n        text2 = \"If String.IsNullOrEmpty(sIL) Then\";\n        if (string.IsNullOrEmpty(text))\n        {\n            text2 = \"4\";\n        }\n        Debug.Write(text2);\n    }\n}\n");
        XElement xElement2 = xElement;
    }
}
</body>
    End Sub

End Class
