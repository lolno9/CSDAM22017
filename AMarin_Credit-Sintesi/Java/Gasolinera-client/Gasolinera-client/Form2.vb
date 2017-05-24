Public Class InputForm
    Private usuari, targeta, pin As String
    Private litres As Decimal
    Private carburant As Integer
    Public Property user As String
        Get
            Return usuari
        End Get
        Set(ByVal value As String)
            usuari = value
        End Set
    End Property
    Public Property tarcred As String
        Get
            Return targeta
        End Get
        Set(ByVal value As String)
            targeta = value
        End Set
    End Property
    Public Property pass As String
        Get
            Return pin
        End Get
        Set(ByVal value As String)
            pin = value
        End Set
    End Property
    Public Property combustible As Integer
        Get
            Return carburant
        End Get
        Set(ByVal value As Integer)
            carburant = value
        End Set
    End Property

    Private Sub InputForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Button1.Visible = False
        If Form1.sortidr = 1 Or Form1.sortidr = 2 Then
            Button2.Text = "Gasolina 95"
            Button3.Text = "Gasolina 98"
        ElseIf Form1.sortidr = 3 Or Form1.sortidr = 4 Then
            Button2.Text = "Biodiesel"
            Button3.Text = "Diesel"
        End If


    End Sub

    Public Property lits As Decimal
        Get
            Return litres
        End Get
        Set(ByVal value As Decimal)
            litres = value
        End Set
    End Property

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Form1.sortidr = 1 Or Form1.sortidr = 2 Then
            carburant = 2
        ElseIf Form1.sortidr = 3 Or Form1.sortidr = 4 Then
            carburant = 4
        End If
        NextStep()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Form1.sortidr = 1 Or Form1.sortidr = 2 Then
            carburant = 1
        ElseIf Form1.sortidr = 3 Or Form1.sortidr = 4 Then
            carburant = 3
        End If
        NextStep()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        user = TextBox1.Text
        tarcred = TextBox2.Text
        pass = TextBox3.Text
        lits = TextBox4.Text
        Close()
    End Sub

    Private Sub NextStep()
        Button2.Visible = False
        Button3.Visible = False
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Button1.Visible = True
    End Sub
End Class