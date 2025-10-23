Public Class Cliente

    Private CLIENTE_ID As Integer
    Private NOMBRE As String
    Private APELLIDO As String
    Private TELEFONO As Integer
    Private CORREO As String
    Private DIRECCION As String

    Public Property CLIENTE_ID1 As Integer
        Get
            Return CLIENTE_ID
        End Get
        Set(value As Integer)
            CLIENTE_ID = value
        End Set
    End Property

    Public Property NOMBRE1 As String
        Get
            Return NOMBRE
        End Get
        Set(value As String)
            NOMBRE = value
        End Set
    End Property

    Public Property APELLIDO1 As String
        Get
            Return APELLIDO
        End Get
        Set(value As String)
            APELLIDO = value
        End Set
    End Property

    Public Property TELEFONO1 As Integer
        Get
            Return TELEFONO
        End Get
        Set(value As Integer)
            TELEFONO = value
        End Set
    End Property

    Public Property CORREO1 As String
        Get
            Return CORREO
        End Get
        Set(value As String)
            CORREO = value
        End Set
    End Property

    Public Property DIRECCION1 As String
        Get
            Return DIRECCION
        End Get
        Set(value As String)
            DIRECCION = value
        End Set
    End Property

    Public Sub New(cLIENTE_ID1 As Integer, nOMBRE1 As String, aPELLIDO1 As String, tELEFONO1 As Integer, cORREO1 As String, dIRECCION1 As String)
        Me.CLIENTE_ID1 = cLIENTE_ID1
        Me.NOMBRE1 = nOMBRE1
        Me.APELLIDO1 = aPELLIDO1
        Me.TELEFONO1 = tELEFONO1
        Me.CORREO1 = cORREO1
        Me.DIRECCION1 = dIRECCION1
    End Sub

    Public Sub New()

    End Sub
End Class
