Public Class Mascota

    Private _MASCOTA_ID As Integer
    Private _NOMBRE As String
    Private _ESPECIE As String
    Private _RAZA As String
    Private _EDAD As Integer
    Private _PESO As Integer
    Private _CLIENTE_ID As Integer

    Public Property MASCOTA_ID1 As Integer
        Get
            Return _MASCOTA_ID
        End Get
        Set(value As Integer)
            _MASCOTA_ID = value
        End Set
    End Property

    Public Property CLIENTE_ID As Integer
        Get
            Return _CLIENTE_ID
        End Get
        Set(value As Integer)
            _CLIENTE_ID = value
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

    Public Sub New(mASCOTA_ID1 As Integer, cLIENTE_ID As Integer, nOMBRE1 As String, eSPECIE1 As String, rAZA1 As String, eDAD1 As Integer, pESO As Integer)
        Me.MASCOTA_ID1 = mASCOTA_ID1
        Me.CLIENTE_ID = cLIENTE_ID
        Me.NOMBRE1 = nOMBRE1
        Me.ESPECIE1 = eSPECIE1
        Me.RAZA1 = rAZA1
        Me.EDAD1 = eDAD1
        Me.PESO = pESO
    End Sub

    Public Sub New()
    End Sub


End Class
