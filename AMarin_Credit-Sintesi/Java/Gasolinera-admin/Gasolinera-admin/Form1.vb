Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Form1
    Dim data As New Date
    Dim stringconec As String = ("Data Source=BEGO\SQLEXPRESS;Initial Catalog=Gasolinera;Integrated Security=True")
    Dim diari As Boolean
    Dim contador As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

        Button1.Enabled = False
        Button2.Enabled = False

        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub


    Private Sub ComprovarGasolinera()
        Dim tank1, tank2, tank3, tank4 As Decimal
        Dim estat1, estat2, estat3, estat4 As Integer
        Dim consulta1 As String = ("SELECT d.capacitat FROM deposits d WHERE idcarburant=1")
        Dim consulta2 As String = ("SELECT d.capacitat FROM deposits d WHERE idcarburant=2")
        Dim consulta3 As String = ("SELECT d.capacitat FROM deposits d WHERE idcarburant=3")
        Dim consulta4 As String = ("SELECT d.capacitat FROM deposits d WHERE idcarburant=4")

        Dim conestat1 As String = ("SELECT estat FROM sortidor WHERE idsortidor=1")
        Dim conestat2 As String = ("SELECT estat FROM sortidor WHERE idsortidor=2")
        Dim conestat3 As String = ("SELECT estat FROM sortidor WHERE idsortidor=3")
        Dim conestat4 As String = ("SELECT estat FROM sortidor WHERE idsortidor=4")

        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(consulta1)
        comando.Connection = conexion
        conexion.Open()
        Dim myReades As SqlDataReader = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                tank1 = myReades("capacitat")
            End While
        Else
            tank1 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(consulta2)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                tank2 = myReades("capacitat")
            End While
        Else
            tank2 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(consulta3)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                tank3 = myReades("capacitat")
            End While
        Else
            tank3 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(consulta4)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                tank4 = myReades("capacitat")
            End While
        Else
            tank4 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(conestat1)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                estat1 = myReades("estat")
            End While
        Else
            estat1 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(conestat2)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                estat2 = myReades("estat")
            End While
        Else
            estat2 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(conestat3)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                estat3 = myReades("estat")
            End While
        Else
            estat3 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(conestat4)
        comando.Connection = conexion
        conexion.Open()
        myReades = comando.ExecuteReader()
        If comando.Connection IsNot DBNull.Value Then
            While myReades.Read()
                estat4 = myReades("estat")
            End While
        Else
            estat4 = 0
        End If
        conexion.Close()

        Dim tott1 As Integer = (tank1 * 100) / 10000
        Dim tott2 As Integer = (tank2 * 100) / 10000
        Dim tott3 As Integer = (tank3 * 100) / 10000
        Dim tott4 As Integer = (tank4 * 100) / 10000
        ProgressBar1.Value = tott1
        ProgressBar2.Value = tott2
        ProgressBar3.Value = tott3
        ProgressBar4.Value = tott4

        If estat1 = 1 Then
            PictureBox5.BackColor = Color.Green
        ElseIf estat1 = 2 Then
            PictureBox5.BackColor = Color.Orange
        ElseIf estat1 = 3 Then
            PictureBox5.BackColor = Color.Red
        End If

        If estat2 = 1 Then
            PictureBox6.BackColor = Color.Green
        ElseIf estat2 = 2 Then
            PictureBox6.BackColor = Color.Orange
        ElseIf estat2 = 3 Then
            PictureBox6.BackColor = Color.Red
        End If

        If estat3 = 1 Then
            PictureBox7.BackColor = Color.Green
        ElseIf estat3 = 2 Then
            PictureBox7.BackColor = Color.Orange
        ElseIf estat3 = 3 Then
            PictureBox7.BackColor = Color.Red
        End If

        If estat4 = 1 Then
            PictureBox8.BackColor = Color.Green
        ElseIf estat4 = 2 Then
            PictureBox8.BackColor = Color.Orange
        ElseIf estat4 = 3 Then
            PictureBox8.BackColor = Color.Red
        End If
    End Sub
    Private Sub Get_Articles()
        Dim _consultes As String()
        ReDim _consultes(10)
        _consultes = Consultes_Articles()
        dades_articles(_consultes)
    End Sub
    Private Sub Get_Sortidors()
        Dim _consultes As String()
        ReDim _consultes(10)
        _consultes = Consultes_Sortidors()
        dades_sortidors(_consultes)
    End Sub
    Private Sub Get_Carburants()
        Dim _consultes As String()
        ReDim _consultes(10)
        _consultes = Consultes_Carburants()
        dades_carburants(_consultes)
    End Sub
    Private Sub dades_carburants(ByVal _consultes As String())
        Dim totcarb1, totcarb2, totcarb3, totcarb4, carbtot, preucarb1, preucarb2, preucarb3, preucarb4, totpreu As Decimal
        Dim numticketcarb As Integer
        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(_consultes(0))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.Connection IsNot DBNull.Value Then
            numticketcarb = comando.ExecuteScalar
        Else
            numticketcarb = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(1))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totcarb1 = comando.ExecuteScalar
        Else
            totcarb1 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(_consultes(2))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totcarb2 = comando.ExecuteScalar
        Else
            totcarb2 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(_consultes(3))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totcarb3 = comando.ExecuteScalar
        Else
            totcarb3 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(_consultes(4))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totcarb4 = comando.ExecuteScalar
        Else
            totcarb4 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(5))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            preucarb1 = comando.ExecuteScalar
        Else
            preucarb1 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(6))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            preucarb2 = comando.ExecuteScalar
        Else
            preucarb2 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(7))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            preucarb3 = comando.ExecuteScalar
        Else
            preucarb3 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(8))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            preucarb4 = comando.ExecuteScalar
        Else
            preucarb4 = 0
        End If
        conexion.Close()
        totpreu = preucarb1 + preucarb2 + preucarb3 + preucarb4
        carbtot = totcarb1 + totcarb2 + totcarb3 + totcarb4
        If diari Then
            TextBox3.Text = ("DIARI" + Environment.NewLine)
            TextBox3.AppendText("CARBURANTS" + Environment.NewLine)
            TextBox3.AppendText("Vendes: " + numticketcarb.ToString + Environment.NewLine)
            TextBox3.AppendText("Gasolina 95 Litres: " + totcarb1.ToString + "  Total: " + preucarb1.ToString + Environment.NewLine)
            TextBox3.AppendText("Gasolina 98 Litres: " + totcarb2.ToString + "  Total: " + preucarb2.ToString + Environment.NewLine)
            TextBox3.AppendText("Biodiesel Litres: " + totcarb3.ToString + "  Total: " + preucarb3.ToString + Environment.NewLine)
            TextBox3.AppendText("Diesel Litres: " + totcarb4.ToString + "  Total: " + preucarb4.ToString + Environment.NewLine)
            TextBox3.AppendText("Total Vendes: " + totpreu.ToString + "   Total Litres:" + Environment.NewLine)
        ElseIf diari = False Then
            TextBox4.Text = ("DIARI" + Environment.NewLine)
            TextBox4.AppendText("CARBURANTS" + Environment.NewLine)
            TextBox4.AppendText("Vendes: " + numticketcarb.ToString + Environment.NewLine)
            TextBox4.AppendText("Gasolina 95 Litres: " + totcarb1.ToString + "  Total: " + preucarb1.ToString + Environment.NewLine)
            TextBox4.AppendText("Gasolina 98 Litres: " + totcarb2.ToString + "  Total: " + preucarb2.ToString + Environment.NewLine)
            TextBox4.AppendText("Biodiesel Litres: " + totcarb3.ToString + "  Total: " + preucarb3.ToString + Environment.NewLine)
            TextBox4.AppendText("Diesel Litres: " + totcarb4.ToString + "  Total: " + preucarb4.ToString + Environment.NewLine)
            TextBox4.AppendText("Total Vendes: " + totpreu.ToString + "   Total Litres:" + Environment.NewLine)
        End If
    End Sub
    Private Sub dades_sortidors(ByVal _consultes As String())
        Try
            Dim totsort1, totsort2, totsort3, totsort4, sorttot, preusort1, preusort2, preusort3, preusort4, totpreu As Decimal
            Dim numticketsort As Integer
            Dim conexion = New SqlConnection(stringconec)
            Dim comando = New SqlCommand(_consultes(0))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.Connection IsNot DBNull.Value Then
                numticketsort = comando.ExecuteScalar
            Else
                numticketsort = 0
            End If
            conexion.Close()
            comando = New SqlCommand(_consultes(1))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                totsort1 = comando.ExecuteScalar
            Else
                totsort1 = 0
            End If
            conexion.Close()

            comando = New SqlCommand(_consultes(2))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                totsort2 = comando.ExecuteScalar
            Else
                totsort2 = 0
            End If
            conexion.Close()

            comando = New SqlCommand(_consultes(3))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                totsort3 = comando.ExecuteScalar
            Else
                totsort3 = 0
            End If
            conexion.Close()

            comando = New SqlCommand(_consultes(4))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                totsort4 = comando.ExecuteScalar
            Else
                totsort4 = 0
            End If
            conexion.Close()
            comando = New SqlCommand(_consultes(5))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                preusort1 = comando.ExecuteScalar
            Else
                preusort1 = 0
            End If
            conexion.Close()
            comando = New SqlCommand(_consultes(6))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                preusort2 = comando.ExecuteScalar
            Else
                preusort2 = 0
            End If
            conexion.Close()
            comando = New SqlCommand(_consultes(7))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                preusort3 = comando.ExecuteScalar
            Else
                preusort3 = 0
            End If
            conexion.Close()
            comando = New SqlCommand(_consultes(8))
            comando.Parameters.AddWithValue("@data", Date.Today)
            comando.Connection = conexion
            conexion.Open()
            If comando.ExecuteScalar IsNot DBNull.Value Then
                preusort4 = comando.ExecuteScalar
            Else
                preusort4 = 0
            End If
            conexion.Close()
            totpreu = preusort1 + preusort2 + preusort3 + preusort4
            sorttot = totsort1 + totsort2 + totsort3 + totsort4
            If diari Then
                TextBox5.Text = ("DIARI" + Environment.NewLine)
                TextBox5.AppendText("SORTIDORS" + Environment.NewLine)
                TextBox5.AppendText("Vendes: " + numticketsort.ToString + Environment.NewLine)
                TextBox5.AppendText("Sortidor 1 Litres: " + totsort1.ToString + "  Total: " + preusort1.ToString + Environment.NewLine)
                TextBox5.AppendText("Sortidor 2 Litres: " + totsort2.ToString + "  Total: " + preusort2.ToString + Environment.NewLine)
                TextBox5.AppendText("Sortidor 3 Litres: " + totsort3.ToString + "  Total: " + preusort3.ToString + Environment.NewLine)
                TextBox5.AppendText("Sortidor 4 Litres: " + totsort4.ToString + "  Total: " + preusort4.ToString + Environment.NewLine)
                TextBox5.AppendText("Total Vendes: " + totpreu.ToString + "   Total Litres: " + sorttot.ToString + Environment.NewLine)
            ElseIf diari = False Then
                TextBox6.Text = ("MENSUAL" + Environment.NewLine)
                TextBox6.AppendText("SORTIDORS" + Environment.NewLine)
                TextBox6.AppendText("Vendes: " + numticketsort.ToString + Environment.NewLine)
                TextBox6.AppendText("Sortidor 1 Litres: " + totsort1.ToString + "  Total: " + preusort1.ToString + Environment.NewLine)
                TextBox6.AppendText("Sortidor 2 Litres: " + totsort2.ToString + "  Total: " + preusort2.ToString + Environment.NewLine)
                TextBox6.AppendText("Sortidor 3 Litres: " + totsort3.ToString + "  Total: " + preusort3.ToString + Environment.NewLine)
                TextBox6.AppendText("Sortidor 4 Litres: " + totsort4.ToString + "  Total: " + preusort4.ToString + Environment.NewLine)
                TextBox6.AppendText("Total Vendes: " + totpreu.ToString + "   Total Litres: " + sorttot.ToString + Environment.NewLine)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dades_articles(ByVal _consultes As String())
        Dim numticketsart, artquant1, artquant2, artquant3, artquant4 As Integer
        Dim arttot, totart1, totart2, totart3, totart4 As Decimal


        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(_consultes(0))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.Connection IsNot DBNull.Value Then
            numticketsart = comando.ExecuteScalar
        Else
            numticketsart = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(1))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            artquant1 = comando.ExecuteScalar
        Else
            artquant1 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(_consultes(2))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            artquant2 = comando.ExecuteScalar
        Else
            artquant2 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(_consultes(3))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            artquant3 = comando.ExecuteScalar
        Else
            artquant3 = 0
        End If
        conexion.Close()

        comando = New SqlCommand(_consultes(4))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            artquant4 = comando.ExecuteScalar
        Else
            artquant4 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(5))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totart1 = comando.ExecuteScalar
        Else
            totart1 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(6))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totart2 = comando.ExecuteScalar
        Else
            totart2 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(7))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totart3 = comando.ExecuteScalar
        Else
            totart3 = 0
        End If
        conexion.Close()
        comando = New SqlCommand(_consultes(8))
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Connection = conexion
        conexion.Open()
        If comando.ExecuteScalar IsNot DBNull.Value Then
            totart4 = comando.ExecuteScalar
        Else
            totart4 = 0
        End If
        conexion.Close()
        arttot = totart1 + totart2 + totart3 + totart4
        If diari Then
            TextBox1.Text = ("DIARI" + Environment.NewLine)
            TextBox1.AppendText("ARTICLES" + Environment.NewLine)
            TextBox1.AppendText("Vendes: " + numticketsart.ToString + Environment.NewLine)
            TextBox1.AppendText("Oli: " + artquant1.ToString + "  Total: " + totart1.ToString + Environment.NewLine)
            TextBox1.AppendText("Anticongelant: " + artquant2.ToString + "  Total: " + totart2.ToString + Environment.NewLine)
            TextBox1.AppendText("Abrillantador: " + artquant3.ToString + "  Total: " + totart3.ToString + Environment.NewLine)
            TextBox1.AppendText("Llimpia Brises: " + artquant4.ToString + "  Total: " + totart4.ToString + Environment.NewLine)
            TextBox1.AppendText("Total Vendes: " + arttot.ToString + Environment.NewLine)
        ElseIf diari = False Then
            TextBox2.Text = ("MENSUAL" + Environment.NewLine)
            TextBox2.AppendText("ARTICLES" + Environment.NewLine)
            TextBox2.AppendText("Vendes: " + numticketsart.ToString + Environment.NewLine)
            TextBox2.AppendText("Oli: " + artquant1.ToString + "  Total: " + totart1.ToString + Environment.NewLine)
            TextBox2.AppendText("Anticongelant: " + artquant2.ToString + "  Total: " + totart2.ToString + Environment.NewLine)
            TextBox2.AppendText("Abrillantador: " + artquant3.ToString + "  Total: " + totart3.ToString + Environment.NewLine)
            TextBox2.AppendText("Llimpia Brises: " + artquant4.ToString + "  Total: " + totart4.ToString + Environment.NewLine)
            TextBox2.AppendText("Total Vendes: " + arttot.ToString + Environment.NewLine)
        End If
    End Sub
    Function Consultes_Articles() As String()
        Dim cons As String()
        If diari Then
            ReDim cons(10)
            Dim contartd As String = ("SELECT COUNT(idticketart) FROM tickets_articles WHERE data=@data")
            Dim conquant1d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE data=@data AND article=1")
            Dim conquant2d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE data=@data AND article=2")
            Dim conquant3d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE data=@data AND article=3")
            Dim conquant4d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE data=@data AND article=4")
            Dim conart1 As String = ("SELECT SUM(total) FROM tickets_articles WHERE data=@data AND article=1")
            Dim conart2 As String = ("SELECT SUM(total) FROM tickets_articles WHERE data=@data AND article=2")
            Dim conart3 As String = ("SELECT SUM(total) FROM tickets_articles WHERE data=@data AND article=3")
            Dim conart4 As String = ("SELECT SUM(total) FROM tickets_articles WHERE data=@data AND article=4")
            cons(0) = contartd
            cons(1) = conquant1d
            cons(2) = conquant2d
            cons(3) = conquant3d
            cons(4) = conquant4d
            cons(5) = conart1
            cons(6) = conart2
            cons(7) = conart3
            cons(8) = conart4
            Return cons
        Else
            ReDim cons(10)
            Dim contartd As String = ("SELECT COUNT(idticketart) FROM tickets_articles WHERE YEAR(data)=@data AND MONTH(data)=@data")
            Dim conquant1d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE YEAR(data)=@data AND MONTH(data)=@data AND article=1")
            Dim conquant2d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE YEAR(data)=@data AND MONTH(data)=@data AND article=2")
            Dim conquant3d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE YEAR(data)=@data AND MONTH(data)=@data AND article=3")
            Dim conquant4d As String = ("SELECT SUM(quantitat) FROM tickets_articles WHERE YEAR(data)=@data AND MONTH(data)=@data AND article=4")
            Dim conart1 As String = ("SELECT SUM(total) FROM tickets_articles WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND article=1")
            Dim conart2 As String = ("SELECT SUM(total) FROM tickets_articles WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND article=2")
            Dim conart3 As String = ("SELECT SUM(total) FROM tickets_articles WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND article=3")
            Dim conart4 As String = ("SELECT SUM(total) FROM tickets_articles WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND article=4")
            cons(0) = contartd
            cons(1) = conquant1d
            cons(2) = conquant2d
            cons(3) = conquant3d
            cons(4) = conquant4d
            cons(5) = conart1
            cons(6) = conart2
            cons(7) = conart3
            cons(8) = conart4
            Return cons
        End If
    End Function
    Function Consultes_Carburants() As String()
        Dim cons As String()
        If diari Then
            ReDim cons(10)
            Dim contts As String = ("SELECT COUNT(idticketsort) FROM tickets_sortidors WHERE data=@data")
            Dim conlitsc1 As String = ("SELECT litres FROM tickets_sortidors WHERE data=@data AND carburant=1")
            Dim conlitsc2 As String = ("SELECT litres FROM tickets_sortidors WHERE data=@data AND carburant=2")
            Dim conlitsc3 As String = ("SELECT litres FROM tickets_sortidors WHERE data=@data AND carburant=3")
            Dim conlitsc4 As String = ("SELECT litres FROM tickets_sortidors WHERE data=@data AND carburant=4")
            Dim conpreuc1 As String = ("SELECT total FROM tickets_sortidors WHERE data=@data AND carburant=1")
            Dim conpreuc2 As String = ("SELECT total FROM tickets_sortidors WHERE data=@data AND carburant=2")
            Dim conpreuc3 As String = ("SELECT total FROM tickets_sortidors WHERE data=@data AND carburant=3")
            Dim conpreuc4 As String = ("SELECT total FROM tickets_sortidors WHERE data=@data AND carburant=4")
            cons(0) = contts
            cons(1) = conlitsc1
            cons(2) = conlitsc2
            cons(3) = conlitsc3
            cons(4) = conlitsc4
            cons(5) = conpreuc1
            cons(6) = conpreuc2
            cons(7) = conpreuc3
            cons(8) = conpreuc4
            Return cons
        Else
            ReDim cons(10)
            Dim contts As String = ("SELECT COUNT(idticketsort) FROM tickets_sortidors WHERE data=@data")
            Dim conlitsc1 As String = ("SELECT litres FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=1")
            Dim conlitsc2 As String = ("SELECT litres FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=2")
            Dim conlitsc3 As String = ("SELECT litres FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=3")
            Dim conlitsc4 As String = ("SELECT litres FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=4")
            Dim conpreuc1 As String = ("SELECT total FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=1")
            Dim conpreuc2 As String = ("SELECT total FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=2")
            Dim conpreuc3 As String = ("SELECT total FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=3")
            Dim conpreuc4 As String = ("SELECT total FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND carburant=4")
            cons(0) = contts
            cons(1) = conlitsc1
            cons(2) = conlitsc2
            cons(3) = conlitsc3
            cons(4) = conlitsc4
            cons(5) = conpreuc1
            cons(6) = conpreuc2
            cons(7) = conpreuc3
            cons(8) = conpreuc4
            Return cons
        End If
    End Function
    Function Consultes_Sortidors() As String()
        Dim cons As String()
        If diari Then
            ReDim cons(10)
            Dim contts As String = ("SELECT COUNT(idticketsort) FROM tickets_sortidors WHERE data=@data")
            Dim conlits1 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE data=@data AND sortidor=1")
            Dim conlits2 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE data=@data AND sortidor=2")
            Dim conlits3 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE data=@data AND sortidor=3")
            Dim conlits4 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE data=@data AND sortidor=4")
            Dim conpreus1 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE data=@data AND sortidor=1")
            Dim conpreus2 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE data=@data AND sortidor=2")
            Dim conpreus3 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE data=@data AND sortidor=3")
            Dim conpreus4 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE data=@data AND sortidor=4")
            cons(0) = contts
            cons(1) = conlits1
            cons(2) = conlits2
            cons(3) = conlits3
            cons(4) = conlits4
            cons(5) = conpreus1
            cons(6) = conpreus2
            cons(7) = conpreus3
            cons(8) = conpreus4
            Return cons
        Else
            ReDim cons(10)
            Dim contts As String = ("SELECT COUNT(idticketsort) FROM tickets_sortidors WHERE YEAR(data)=@data AND MONTH(data)=@data")
            Dim conlits1 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=1")
            Dim conlits2 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=2")
            Dim conlits3 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=3")
            Dim conlits4 As String = ("SELECT SUM(litres) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=4")
            Dim conpreus1 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=1")
            Dim conpreus2 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=2")
            Dim conpreus3 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=3")
            Dim conpreus4 As String = ("SELECT SUM(total) FROM tickets_sortidors WHERE YEAR(data)=YEAR(@data) AND MONTH(data)=MONTH(@data) AND sortidor=4")
            cons(0) = contts
            cons(1) = conlits1
            cons(2) = conlits2
            cons(3) = conlits3
            cons(4) = conlits4
            cons(5) = conpreus1
            cons(6) = conpreus2
            cons(7) = conpreus3
            cons(8) = conpreus4
            Return cons
        End If
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ComprovarGasolinera()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        diari = True
        Get_Articles()
        Get_Carburants()
        Get_Sortidors()
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        diari = False
        Get_Articles()
        Get_Carburants()
        Get_Sortidors()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        ProgressBar4.PerformStep()
        If ProgressBar4.Value = 100 Then
            Timer4.Enabled = False
        End If
    End Sub
End Class
