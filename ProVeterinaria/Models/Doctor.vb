Public Class Doctor
    Private DOCTOR_ID As Integer
    Private NOMBRE As String
    Private APELLIDO As String
    Private ESPECIALIDAD As String
    Private TELEFONO As Integer
    Private CORREO As String

    Public Property DOCTOR_ID1 As Integer
        Get
            Return DOCTOR_ID
        End Get
        Set(value As Integer)
            DOCTOR_ID = value
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

    Public Property ESPECIALIDAD1 As String
        Get
            Return ESPECIALIDAD
        End Get
        Set(value As String)
            ESPECIALIDAD = value
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

    Public Sub New(doctor_ID1 As Integer, nombre1 As String, apellido1 As String, especialidad1 As String, telefono1 As Integer, correo1 As String)
        Me.DOCTOR_ID1 = doctor_ID1
        Me.NOMBRE1 = nombre1
        Me.APELLIDO1 = apellido1
        Me.ESPECIALIDAD1 = especialidad1
        Me.TELEFONO1 = telefono1
        Me.CORREO1 = correo1
    End Sub

    Public Sub New()

    End Sub

End Class
