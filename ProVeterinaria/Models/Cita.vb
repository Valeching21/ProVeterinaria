Option Strict On
Option Explicit On

Public Class Cita
    Private _CITA_ID As Integer
    Private _FECHA As DateTime
    Private _MOTIVO As String
    Private _CLIENTE_ID As Integer
    Private _MASCOTA_ID As Integer
    Private _DOCTOR_ID As Integer ' 0 -> se inserta como NULL

    Public Property CITA_ID1 As Integer
        Get
            Return _CITA_ID
        End Get
        Set(value As Integer)
            _CITA_ID = value
        End Set
    End Property

    Public Property FECHA1 As DateTime
        Get
            Return _FECHA
        End Get
        Set(value As DateTime)
            _FECHA = value
        End Set
    End Property

    Public Property MOTIVO1 As String
        Get
            Return _MOTIVO
        End Get
        Set(value As String)
            _MOTIVO = value
        End Set
    End Property

    Public Property CLIENTE_ID1 As Integer
        Get
            Return _CLIENTE_ID
        End Get
        Set(value As Integer)
            _CLIENTE_ID = value
        End Set
    End Property

    Public Property MASCOTA_ID1 As Integer
        Get
            Return _MASCOTA_ID
        End Get
        Set(value As Integer)
            _MASCOTA_ID = value
        End Set
    End Property

    Public Property DOCTOR_ID1 As Integer
        Get
            Return _DOCTOR_ID
        End Get
        Set(value As Integer)
            _DOCTOR_ID = value
        End Set
    End Property
End Class