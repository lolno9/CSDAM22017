Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Threading

Public Class Form1
    Dim usuari, targeta, pin, estats1, estats2, estats3, estats4 As String
    Dim litres, total, preu_litre, litres_reals, litres_actuals As Decimal
    Dim parar As Boolean
    Dim sortidor, carburant As Integer
    Dim data As Date
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Estat_Sortidors()
        data = Date.Today 'New Date(2017,05,18)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Estat_Sortidors()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sortidor = 2
        InputForm()
        Estat_Ocupat(2)
        Estat_Sortidors()
        Timer2.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sortidor = 3
        InputForm()
        Estat_Ocupat(3)
        Estat_Sortidors()
        Timer3.Enabled = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sortidor = 4
        InputForm()
        Estat_Ocupat(4)
        Estat_Sortidors()
        Timer4.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sortidor = 1
        InputForm()
        Estat_Ocupat(1)
        Estat_Sortidors()
        Timer1.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        parar = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ProgressBar2.Value >= 100 Or parar = True Then
            Timer2.Enabled = False
            parar = False
            litres_reals = Decimal.Parse((ProgressBar2.Value * litres) / 100)
            'MsgBox(litres_reals.ToString("0.00"))
            TiketSortidor(2)
            Estat_Lliure(2)
            Estat_Sortidors()
            ProgressBar2.Value = 0
        End If
        ProgressBar2.PerformStep()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If ProgressBar3.Value >= 100 Or parar = True Then
            Timer3.Enabled = False
            parar = False
            litres_reals = Decimal.Parse((ProgressBar3.Value * litres) / 100)
            'MsgBox(litres_reals.ToString("0.00"))
            TiketSortidor(3)
            Estat_Lliure(3)
            Estat_Sortidors()
            ProgressBar3.Value = 0
        End If
        ProgressBar3.PerformStep()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If ProgressBar4.Value >= 100 Or parar = True Then
            Timer4.Enabled = False
            parar = False
            litres_reals = Decimal.Parse((ProgressBar4.Value * litres) / 100)
            'MsgBox(litres_reals.ToString("0.00"))
            TiketSortidor(4)
            Estat_Lliure(4)
            Estat_Sortidors()
            ProgressBar4.Value = 0
        End If
        ProgressBar4.PerformStep()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim inputart As New InputArticles()
        inputart.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value >= 100 Or parar = True Then
            Timer1.Enabled = False
            parar = False
            litres_reals = Decimal.Parse((ProgressBar1.Value * litres) / 100)
            'MsgBox(litres_reals.ToString("0.00"))
            TiketSortidor(1)
            Estat_Lliure(1)
            Estat_Sortidors()
            ProgressBar1.Value = 0
        End If
        ProgressBar1.PerformStep()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        parar = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        parar = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        parar = True
    End Sub

    Private Sub InputForm()
        Dim inputform As New InputForm()
        inputform.ShowDialog()
        usuari = inputform.user
        targeta = inputform.tarcred
        pin = inputform.pass
        litres = inputform.lits
        carburant = inputform.combustible
        inputform.Dispose()
        'consulta update estat servidor

    End Sub
    Private Sub TiketSortidor(ByVal sortidor)     'TAMOS AKI
        'Dim carb As String
        Dim stringconec As String = ("Data Source=BEGO\SQLEXPRESS;Initial Catalog=Gasolinera;Integrated Security=True")
        Dim preulitre As String = (String.Format("SELECT preu_litre FROM carburant WHERE idcarburant = {0}", carburant))
        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(preulitre)
        comando.Connection = conexion
        conexion.Open()
        Dim myReader As SqlDataReader = comando.ExecuteReader()
        While myReader.Read()
            preu_litre = myReader("preu_litre")
        End While
        conexion.Close()
        Dim idus As Integer
        comando = New SqlCommand("SELECT idusuari FROM usuaris WHERE usuari = @user")
        comando.Parameters.AddWithValue("@user", usuari)
        comando.Connection = conexion
        conexion.Open()
        myReader = comando.ExecuteReader()
        While myReader.Read()
            idus = myReader("idusuari")
        End While
        conexion.Close()
        total = preu_litre * litres_reals
        comando = New SqlCommand("INSERT INTO tickets_sortidors (idusuari, carburant, sortidor, data, litres, total) VALUES(@iu, @car, @sort, @dat, @lit, @tot)")
        comando.Parameters.AddWithValue("@iu", idus)
        comando.Parameters.AddWithValue("@car", carburant)
        comando.Parameters.AddWithValue("@sort", sortidor)
        comando.Parameters.AddWithValue("@dat", data)
        comando.Parameters.AddWithValue("@lit", litres_reals)
        comando.Parameters.AddWithValue("@tot", total)
        comando.Connection = conexion
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
        Dim capacitat As Decimal
        comando = New SqlCommand("SELECT capacitat FROM deposits WHERE idcarburant = @car")
        comando.Parameters.AddWithValue("@car", carburant)
        comando.Connection = conexion
        conexion.Open()
        myReader = comando.ExecuteReader()
        While myReader.Read()
            capacitat = myReader("capacitat")
        End While
        conexion.Close()
        capacitat -= litres_reals
        comando = New SqlCommand("UPDATE deposits SET capacitat=@capreal WHERE idcarburant = @car ")
        comando.Parameters.AddWithValue("@capreal", capacitat)
        comando.Parameters.AddWithValue("@car", carburant)
        comando.Connection = conexion
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
        'MsgBox(String.Format("INSERT INTO tickets_sortidors (carburant, sortidor, data, litres, total) VALUES({0},{1},{2},{3})", carburant, sortidor, data, litres, total))

    End Sub
    'Private Sub Carrega_Litres()

    'End Sub
    Private Sub Estat_Sortidors()
        Dim stringconec As String = ("Data Source=BEGO\SQLEXPRESS;Initial Catalog=Gasolinera;Integrated Security=True")
        Dim sort1 As String = ("SELECT es.estat FROM estat_sortidor es INNER JOIN sortidor s ON(s.estat=es.idestat) WHERE idsortidor = 1")
        Dim sort2 As String = ("SELECT es.estat FROM estat_sortidor es INNER JOIN sortidor s ON(s.estat=es.idestat) WHERE idsortidor = 2")
        Dim sort3 As String = ("SELECT es.estat FROM estat_sortidor es INNER JOIN sortidor s ON(s.estat=es.idestat) WHERE idsortidor = 3")
        Dim sort4 As String = ("SELECT es.estat FROM estat_sortidor es INNER JOIN sortidor s ON(s.estat=es.idestat) WHERE idsortidor = 4")

        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(sort1)
        comando.Connection = conexion
        conexion.Open()
        Dim myReader As SqlDataReader = comando.ExecuteReader()
        While myReader.Read()
            estats1 = myReader("estat")
        End While
        conexion.Close()
        comando = New SqlCommand(sort2)
        comando.Connection = conexion
        conexion.Open()
        myReader = comando.ExecuteReader()
        While myReader.Read()
            estats2 = myReader("estat")
        End While
        conexion.Close()
        comando = New SqlCommand(sort3)
        comando.Connection = conexion
        conexion.Open()
        myReader = comando.ExecuteReader()
        While myReader.Read()
            estats3 = myReader("estat")
        End While
        conexion.Close()
        comando = New SqlCommand(sort4)
        comando.Connection = conexion
        conexion.Open()
        myReader = comando.ExecuteReader()
        While myReader.Read()
            estats4 = myReader("estat")
        End While
        conexion.Close()

        Label10.Text = estats1
        Label11.Text = estats2
        Label12.Text = estats3
        Label13.Text = estats4


        If estats1.Equals("No Disponible") Then
            Button1.Enabled = False
            Button6.Enabled = False
        End If
        If estats2.Equals("No Disponible") Then
            Button2.Enabled = False
            Button7.Enabled = False
        End If
        If estats3.Equals("No Disponible") Then
            Button3.Enabled = False
            Button8.Enabled = False
        End If
        If estats4.Equals("No Disponible") Then
            Button4.Enabled = False
            Button9.Enabled = False
        End If
        If estats1.Equals("Ocupat") Then
            Button1.Enabled = False
            Button6.Enabled = True
        End If
        If estats2.Equals("Ocupat") Then
            Button2.Enabled = False
            Button7.Enabled = True
        End If
        If estats3.Equals("Ocupat") Then
            Button3.Enabled = False
            Button8.Enabled = True
        End If
        If estats4.Equals("Ocupat") Then
            Button4.Enabled = False
            Button9.Enabled = True
        End If
        If estats1.Equals("Lliure") Then
            Button1.Enabled = True
            Button6.Enabled = True
        End If
        If estats2.Equals("Lliure") Then
            Button2.Enabled = True
            Button7.Enabled = True
        End If
        If estats3.Equals("Lliure") Then
            Button3.Enabled = True
            Button8.Enabled = True
        End If
        If estats4.Equals("Lliure") Then
            Button4.Enabled = True
            Button9.Enabled = True
        End If
    End Sub
    Private Sub Estat_Ocupat(ByVal sortidoractual)
        Dim stringconec As String = ("Data Source=BEGO\SQLEXPRESS;Initial Catalog=Gasolinera;Integrated Security=True")
        Dim sort1 As String = (String.Format("UPDATE sortidor SET estat=2 WHERE idsortidor = {0}", sortidoractual))
        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(sort1)
        comando.Connection = conexion
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub
    Private Sub Estat_Lliure(ByVal sortidoractual)
        Dim stringconec As String = ("Data Source=BEGO\SQLEXPRESS;Initial Catalog=Gasolinera;Integrated Security=True")
        Dim sort1 As String = (String.Format("UPDATE sortidor SET estat=1 WHERE idsortidor = {0}", sortidoractual))
        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(sort1)
        comando.Connection = conexion
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub

    Public Property sortidr As Integer
        Get
            Return sortidor
        End Get
        Set(ByVal value As Integer)
            sortidor = value
        End Set
    End Property
End Class
