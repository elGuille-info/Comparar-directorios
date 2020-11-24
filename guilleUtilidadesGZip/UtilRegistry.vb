'------------------------------------------------------------------------------
' UtilRegistry                                                      (28/Jun/06)
' Clase para manipular el registro del sistema
'
' Ejemplo para el libro Manual Imprescindible de Visual Basic 2005
'
' �Guillermo 'guille' Som, 2006
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports Microsoft.Win32

Public Class UtilRegistry

    ''' <summary>
    ''' Asocia una extensi�n con un ejecutable y una acci�n.
    ''' </summary>
    ''' <param name="ext">La extensi�n a asociar</param>
    ''' <param name="exe">El ejecutable a asociar con la extensi�n</param>
    ''' <param name="progId">El progId a asociar con la extensi�n</param>
    ''' <param name="comando">El comando con el que se asociar�, por defecto ser� open</param>
    ''' <param name="descripcion">La descripci�n del tipo de archivo relacionado con la extensi�n</param>
    ''' <returns>Devuelve un valor verdadero o falso seg�n se haya podido registrar o no la extensi�n.</returns>
    ''' <remarks>Tambi�n sirve para a�adir nuevos comandos a extensiones existentes.</remarks>
    Public Shared Function AsociarExtension(ext As String, _
                      exe As String, _
                      progId As String, _
                      Optional comando As String = "open", _
                      Optional descripcion As String = "") As Boolean
        If vb.Len(ext) = 0 Then Return False
        If vb.Len(exe) = 0 Then Return False
        If vb.Len(progId) = 0 Then Return False

        If vb.Len(comando) = 0 Then
            comando = "open"
        End If
        ' Si no se especifica el punto
        If ext.IndexOf(".") = -1 Then
            ext = "." & ext
        End If
        ' Si no se especifica la descripci�n
        If vb.Len(descripcion) = 0 Then
            descripcion = ext & " Descripci�n de " & progId
        End If

        Dim value As String
        Dim rk As RegistryKey = Nothing
        Dim rkShell As RegistryKey = Nothing

        value = getProgId(ext)
        If vb.Len(value) = 0 Then
            ' Crear la clave, etc.
            rk = Registry.ClassesRoot.CreateSubKey(ext)
            rk.SetValue("", progId)
            'rk.SetValue("PerceivedType", "compressed")

            rk = Registry.ClassesRoot.CreateSubKey(progId)
            rk.SetValue("", descripcion)

            value = "shell\" & comando & "\command"
            rkShell = rk.CreateSubKey(value)
        Else
            ' Ya existe, solo actualizar los valores
            ' pero debemos abrir la clave indicando que vamos a escribir
            ' para que nos permita crear nuevas subclaves.
            rk = Registry.ClassesRoot.OpenSubKey(progId, True)
            value = "shell\" & comando & "\command"
            rkShell = rk.OpenSubKey(value, True)
            ' Si es un comando que se a�ade, no existir�
            If rkShell Is Nothing Then
                rkShell = rk.CreateSubKey(value)
            End If
        End If

        If rkShell IsNot Nothing Then
            rkShell.SetValue("", ChrW(34) & exe & ChrW(34) & " " & ChrW(34) & "%1" & ChrW(34))
            rkShell.Close()
        End If
        If rk IsNot Nothing Then
            rk.Close()
        End If

        Return True
    End Function


    ''' <summary>
    ''' Permite quitar un comando asociado con una extensi�n.
    ''' </summary>
    ''' <param name="ext">La extensi�n de la que se quitar� el comando</param>
    ''' <param name="comando">El comando a quitar</param>
    ''' <returns>Un valor verdadero o falso seg�n todo haya ido correcto o no.</returns>
    ''' <remarks>
    ''' Este m�todo permite quitar comandos asociados previamente, sin eliminar la extensi�n.
    ''' El comando open (o el predeterminado) no se puede quitar usando este m�todo.
    ''' </remarks>
    Public Shared Function QuitarComandoExtension(ext As String, comando As String) As Boolean
        ' No permitir cadenas vac�as en el comando
        If vb.Len(comando) = 0 Then Return False

        ' No permitir quitar el comando open
        If comando.ToLower.Contains("open") Then
            Return False
        End If

        ' Si no se especifica el punto en la extensi�n
        If ext.IndexOf(".") = -1 Then
            ext = "." & ext
        End If

        ' Averiguar el progId de esta extensi�n
        Dim progId As String = getProgId(ext)
        If vb.Len(progId) > 0 Then
            Using rk As RegistryKey = Registry.ClassesRoot.OpenSubKey(progId, True)
                If rk IsNot Nothing Then
                    Dim value As String = "shell\" & comando
                    rk.DeleteSubKeyTree(value)

                    Return True
                End If
            End Using
        End If

        Return False
    End Function

    ''' <summary>
    ''' Quita la extensi�n indicada de los tipos de archivos registrados.
    ''' </summary>
    ''' <param name="ext">La extensi�n a quitar del registro</param>
    ''' <returns>Devuelve un valor verdadero o falso seg�n se haya quitado correctamente o no la extensi�n.</returns>
    ''' <remarks>ATENCI�N, este m�todo elimina totalmente la extensi�n del registro</remarks>
    Public Shared Function DesasociarExtension(ext As String) As Boolean
        ' Si no se especifica el punto
        If ext.IndexOf(".") = -1 Then
            ext = "." & ext
        End If

        Dim progId As String = getProgId(ext)
        'If Not String.IsNullOrEmpty(progId) AndAlso progId.Length > 0 Then
        'End If
        'If progId <> "" Then
        'End If
        If vb.Len(progId) > 0 Then
            ' Eliminar la clave
            Registry.ClassesRoot.DeleteSubKeyTree(ext)

            Registry.ClassesRoot.DeleteSubKeyTree(progId)

            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' Comprueba si la extensi�n indicada est� registrada.
    ''' </summary>
    ''' <param name="ext">La extensi�n a comprobar</param>
    ''' <returns>Un valor verdadero o falso seg�n est� registrada o no</returns>
    ''' <remarks></remarks>
    Public Shared Function Existe(ext As String) As Boolean
        ' Si no se especifica el punto
        If vb.InStr(ext, ".") = 0 Then
            ext = "." & ext
        End If

        Return (vb.Len(getProgId(ext)) > 0)
    End Function

    ''' <summary>
    ''' M�todo privado para obtener el progId de una extensi�n.
    ''' </summary>
    ''' <param name="ext">Extensi�n de la que se quiere obtener el progId</param>
    ''' <returns>Devuelve una cadena con el progId de la extensi�n o una cadena vac�a si no existe</returns>
    ''' <remarks></remarks>
    Private Shared Function getProgId(ext As String) As String
        Dim progId As String = ""

        Using rk As RegistryKey = Registry.ClassesRoot.OpenSubKey(ext)
            If rk IsNot Nothing Then
                progId = rk.GetValue("").ToString
                rk.Close()
            End If
        End Using

        Return progId
    End Function


    ' Iniciar con Windows

    ''' <summary>
    ''' Constante con la clave a usar para a�adir aplicaciones al inicio de Windows.
    ''' </summary>
    ''' <remarks></remarks>
    Private Const windowsRun As String = "Software\Microsoft\Windows\CurrentVersion\Run"

    ''' <summary>
    ''' A�ade al registro de Windows la aplicaci�n usando el t�tulo indicado.
    ''' </summary>
    ''' <param name="titulo">El t�tulo a asociar con la aplicaci�n</param>
    ''' <param name="exe">El path completo de la aplicaci�n</param>
    ''' <remarks></remarks>
    Public Shared Sub A�adirAlInicioDeWindows(titulo As String, exe As String)
        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(windowsRun, True)
            If rk IsNot Nothing Then
                rk.SetValue(titulo, ChrW(34) & exe & ChrW(34))
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Quita del registro de Windows la aplicaci�n relacionada con el t�tulo indicado.
    ''' </summary>
    ''' <param name="titulo">T�tulo de la aplicaci�n a quitar del inicio de Windows.</param>
    ''' <remarks></remarks>
    Public Shared Sub QuitarDelInicioDeWindows(titulo As String)
        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(windowsRun, True)
            If rk IsNot Nothing Then
                rk.DeleteValue(titulo, False)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Comprueba si una aplicaci�n con el t�tulo indicado est� en el inicio de Windows.
    ''' </summary>
    ''' <param name="titulo">El t�tulo asociado a la aplicaci�n</param>
    ''' <returns>Devuelve el nombre del ejecutable o una cadena vac�a si no est� en el inicio.</returns>
    ''' <remarks></remarks>
    Public Shared Function EstaEnInicioDeWindows(titulo As String) As String
        Dim exe As String = ""

        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(windowsRun, True)
            If rk IsNot Nothing Then
                exe = rk.GetValue(titulo).ToString
            End If
        End Using

        Return exe
    End Function


    ' El nombre del ejecutable actual:
    ' System.Reflection.Assembly.GetExecutingAssembly.Location

End Class
