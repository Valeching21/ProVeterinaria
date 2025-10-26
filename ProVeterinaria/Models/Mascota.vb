Public Class Mascota

    Private _MASCOTA_ID As Integer
    Private _NOMBRE As String
    Private _ESPECIE As String
    Private _RAZA As String
    Private _EDAD As Integer
    Private _PESO As Integer

    Public Property MASCOTA_ID1 As Integer
        Get
            Return _MASCOTA_ID
        End Get
        Set(value As Integer)
            _MASCOTA_ID = value
        End Set
    End Property
    Public Property NOMBRE1 As String
        Get
            Return _NOMBRE
        End Get
        Set(value As String)
            _NOMBRE = value
        End Set
    End Property
    Public Property ESPECIE1 As String
        Get
            Return _ESPECIE
        End Get
        Set(value As String)
            _ESPECIE = value
        End Set
    End Property
    Public Property RAZA1 As String
        Get
            Return _RAZA
        End Get
        Set(value As String)
            _RAZA = value
        End Set
    End Property
    Public Property EDAD1 As Integer
        Get
            Return _EDAD
        End Get
        Set(value As Integer)
            _EDAD = value
        End Set
    End Property

    Public Property PESO As Integer
        Get
            Return _PESO
        End Get
        Set(value As Integer)
            _PESO = value
        End Set
    End Property

    Public Sub New(mascota_ID As Integer, nombre As String, especie As String, raza As String, edad As Integer, peso As Integer)
        Me.MASCOTA_ID1 = mascota_ID
        Me.NOMBRE1 = nombre
        Me.ESPECIE1 = especie
        Me.RAZA1 = raza
        Me.EDAD1 = edad
        Me.PESO = peso
    End Sub

    Public Sub New()

    End Sub

End Class
