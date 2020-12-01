'------------------------------------------------------------------------------
' Clase para clasificar las columnas de un ListView                 (23/Jun/02)
'
' Añado la constante Moneda                                         (26/Jul/08)
'   Es como número pero por si se le da un trato especial
'
' Cambios menores y detectar error en el índice de las columnas     (15/May/19)
'
' ©Guillermo 'guille' Som, 2002, 2008, 2019, 2020
'
' Para usarla
'Private lvColumnSort As New List(Of SortOrder)

'Private Sub lvDatos_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvDatos.ColumnClick
'Dim lvDatos = TryCast(sender, ListView)
'    If lvDatos.Items.Count = 0 Then Return

'    ' Crear una instancia de la clase que realizará la comparación
'    Dim oCompare As New ListViewColumnSort()

'    ' Asignar el orden de clasificación

'    If lvColumnSort.Count = 0 Then
'        For i = 0 To lvDatos.Columns.Count - 1
'            lvColumnSort.Add(SortOrder.Ascending)
'        Next
'    End If
'    If lvColumnSort(e.Column) = SortOrder.Ascending Then
'        lvColumnSort(e.Column) = SortOrder.Descending
'        oCompare.Sorting = SortOrder.Descending
'    Else
'        lvColumnSort(e.Column) = SortOrder.Ascending
'        oCompare.Sorting = SortOrder.Ascending
'    End If
'    lvDatos.Sorting = oCompare.Sorting

'    ' La columna en la que se ha pulsado
'    oCompare.ColumnIndex = e.Column
'    If e.Column = 0 Then
'        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
'    Else
'        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
'    End If


'    ' Asignar la clase que implementa IComparer
'    ' y que se usará para realizar la comparación de cada elemento
'    lvDatos.ListViewItemSorter = oCompare
'End Sub

'Private lvCliColumnSort As New List(Of SortOrder)

'Private columnCli As String() = (
'    "Telefono, Nombre, Telefono2, NombreWasap, " &
'    "EsEmpresa, Empresa, Comision, EsDistribuidor, idDistribuidor, " &
'    "Nif, Email, Contactos, Domicilio, CuentaBanco, Notas, " &
'    "PrimeraReserva, UltimaReserva, Activo, Modificado, " &
'    "idOriginal, ID ").Split(", ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)

'Private Sub lvCli_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvCli.ColumnClick
'    Dim lvDatos = TryCast(sender, ListView)

'    If lvDatos.Items.Count = 0 Then Return

'    ' Crear una instancia de la clase que realizará la comparación
'    Dim oCompare As New ListViewColumnSort()

'    ' Asignar el orden de clasificación

'    If lvCliColumnSort.Count = 0 Then
'        For i = 0 To lvDatos.Columns.Count - 1
'            lvCliColumnSort.Add(SortOrder.Ascending)
'        Next
'    End If
'    If lvCliColumnSort(e.Column) = SortOrder.Ascending Then
'        lvCliColumnSort(e.Column) = SortOrder.Descending
'        oCompare.Sorting = SortOrder.Descending
'    Else
'        lvCliColumnSort(e.Column) = SortOrder.Ascending
'        oCompare.Sorting = SortOrder.Ascending
'    End If
'    lvDatos.Sorting = oCompare.Sorting

'    ' La columna en la que se ha pulsado
'    oCompare.ColumnIndex = e.Column
'    Select Case columnCli(e.Column)
'        Case "Comision", "idDistribuidor", "ID", "idOriginal"
'            oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
'        Case "PrimeraReserva", "UltimaReserva"
'            oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
'        Case Else
'            oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
'    End Select
'    'If e.Column = 0 Then
'    '    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
'    'Else
'    '    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
'    'End If


'    ' Asignar la clase que implementa IComparer
'    ' y que se usará para realizar la comparación de cada elemento
'    lvDatos.ListViewItemSorter = oCompare

'End Sub

'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports System
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic

Public Class ListViewColumnSort
    Implements IComparer
    '
    Public Enum TipoCompare
        Cadena
        Numero
        Fecha
        Moneda
        'Ninguno = -1
    End Enum

    Public CompararPor As TipoCompare
    Public ColumnIndex As Integer = 0
    Public Sorting As SortOrder = SortOrder.Ascending

    ' Constructores
    Sub New()
        ' no es necesario indicar nada,
        ' ya que implíctamente se llama a MyBase.New
    End Sub

    Private ReadOnly FilasNoComparar As HashSet(Of String)
    Private CompararFilas As Boolean = False

    ''' <summary>
    ''' Constructor que recibe las filas a no comparar
    ''' </summary>
    ''' <param name="noCompararFilas">Lista con los índices a no comparar</param>
    ''' <remarks>Normalmente solo se dejará de compararar las primeras filas</remarks>
    Sub New(noCompararFilas As HashSet(Of String))
        FilasNoComparar = noCompararFilas
        CompararFilas = True
    End Sub

    Sub New(columna As Integer)
        ColumnIndex = columna
    End Sub

    Public Overridable Function Compare(a As Object, b As Object) As Integer _
                                        Implements IComparer.Compare
        ' Esta función devolverá:
        '   -1 si el primer elemento es menor que el segundo
        '    0 si los dos son iguales
        '    1 si el primero es mayor que el segundo
        '
        Dim menor As Integer = -1, mayor As Integer = 1
        Dim s1, s2 As String

        'If Sorting = SortOrder.None OrElse CompararPor = TipoCompare.Ninguno Then
        If Sorting = SortOrder.None Then
            Return 0
        End If

        Dim alvi = TryCast(a, ListViewItem)
        If alvi Is Nothing Then Return 0
        Dim blvi = TryCast(b, ListViewItem)
        If blvi Is Nothing Then Return 0

        ' si se indican las filas no clasificar, 
        If CompararFilas Then
            If FilasNoComparar.Contains(alvi.Text) OrElse FilasNoComparar.Contains(blvi.Text) Then
                Return 0
            End If
        End If

        Try
            ' Convertir el texto en el formato adecuado
            ' y tomar el texto de la columna en la que se ha pulsado
            s1 = alvi.SubItems(ColumnIndex).Text
            s2 = blvi.SubItems(ColumnIndex).Text

        Catch 'ex As Exception
            Return 0
        End Try

        ' Asignar cuando es menor o mayor,
        ' dependiendo del orden de clasificación
        If Sorting = SortOrder.Descending Then
            menor = 1
            mayor = -1
        End If

        Select Case CompararPor
            Case TipoCompare.Fecha
                ' Si da error, se comparan como cadenas
                Try
                    Dim f1 As Date = DateTime.Parse(s1)
                    Dim f2 As Date = DateTime.Parse(s2)
                    If f1 < f2 Then
                        Return menor
                    ElseIf f1 = f2 Then
                        Return 0
                    Else
                        Return mayor
                    End If
                Catch
                    ''Return s1.CompareTo(s2) * mayor
                    'Return System.String.Compare(s1, s2, True) * mayor
                End Try
            Case TipoCompare.Numero, TipoCompare.Moneda
                ' Si da error, se comparan como cadenas
                Try
                    Dim n1 As Decimal = Decimal.Parse(s1)
                    Dim n2 As Decimal = Decimal.Parse(s2)
                    If n1 < n2 Then
                        Return menor
                    ElseIf n1 = n2 Then
                        Return 0
                    Else
                        Return mayor
                    End If
                Catch
                    'Return System.String.Compare(s1, s2, True) * mayor
                End Try
                'Case Else
                '    'Case TipoCompare.Cadena
                '    Return System.String.Compare(s1, s2, True) * mayor
        End Select
        Return System.String.Compare(s1, s2, True) * mayor
    End Function
End Class
