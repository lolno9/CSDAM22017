Imports System.Data.SqlClient

Public Class InputArticles
    Dim article, quantitat, idusu As Integer
    Dim usuari, targeta, pin As String
    Dim preu As Decimal
    Public Property idu As Integer
        Get
            Return idusu
        End Get
        Set(ByVal value As Integer)
            idusu = value
        End Set
    End Property
    'Public Property quant As Integer
    '    Get
    '        Return quantitat
    '    End Get
    '    Set(ByVal value As Integer)
    '        quantitat = value
    '    End Set
    'End Property
    'Public Property user As String
    '    Get
    '        Return usuari
    '    End Get
    '    Set(ByVal value As String)
    '        usuari = value
    '    End Set
    'End Property
    'Public Property targ As String
    '    Get
    '        Return targeta
    '    End Get
    '    Set(ByVal value As String)
    '        targeta = value
    '    End Set
    'End Property
    'Public Property pn As String
    '    Get
    '        Return pin
    '    End Get
    '    Set(ByVal value As String)
    '        pin = value
    '    End Set
    'End Property
    'Public Property pru As Decimal
    '    Get
    '        Return preu
    '    End Get
    '    Set(ByVal value As Decimal)
    '        preu = value
    '    End Set
    'End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        usuari = TextBox1.Text
        quantitat = TextBox2.Text
        targeta = TextBox3.Text
        pin = TextBox4.Text

        Dim stringconec As String = ("Data Source=BEGO\SQLEXPRESS;Initial Catalog=Gasolinera;Integrated Security=True")
        Dim conuser As String = ("SELECT idusuari FROM usuaris WHERE usuari = @usuari")
        Dim conexion = New SqlConnection(stringconec)
        Dim comando = New SqlCommand(conuser)
        comando.Parameters.AddWithValue("@usuari", usuari)
        comando.Connection = conexion
        conexion.Open()
        Dim myReader As SqlDataReader = comando.ExecuteReader()
        While myReader.Read()
            idu = myReader("idusuari")
        End While
        conexion.Close()
        comando = New SqlCommand("SELECT preu from articles WHERE idarticle = @arti")
        comando.Parameters.AddWithValue("@arti", article)
        comando.Connection = conexion
        conexion.Open()
        myReader = comando.ExecuteReader()
        While myReader.Read
            preu = myReader("preu")
        End While
        conexion.Close()
        Dim total As Decimal
        total = preu * quantitat
        comando = New SqlCommand("INSERT INTO tickets_articles(idusuari, data, article, quantitat, total) VALUES(@idusuari, @data, @article, @quantitat, @total)")
        comando.Parameters.AddWithValue("@idusuari", idu)
        comando.Parameters.AddWithValue("@data", Date.Today)
        comando.Parameters.AddWithValue("@article", article)
        comando.Parameters.AddWithValue("@quantitat", quantitat)
        comando.Parameters.AddWithValue("@total", total)
        comando.Connection = conexion
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
        Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Label4.Text = "Oli"
        article = 1
        NextStep()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Label4.Text = "Anti-congelant"
        article = 2
        NextStep()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Label4.Text = "Abrillantador"
        article = 3
        NextStep()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Label4.Text = "Llimpia parabrises"
        article = 4
        NextStep()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        Button1.Visible = False
        Label5.Visible = False
        Label6.Visible = False
    End Sub
    Private Sub NextStep()
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True
        Button1.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
    End Sub
End Class