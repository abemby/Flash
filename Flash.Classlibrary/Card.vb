Imports Flash.Interface

Public Class Card
    Implements ICard

    Private _value As Integer
    Private _sign As CardSign

    Public Property Sign As CardSign Implements ICard.Sign
        Get
            Return _sign
        End Get
        Set(value As CardSign)
            _sign = value
        End Set
    End Property

    Public Property Value As Integer Implements ICard.Value
        Get
            Return _value
        End Get
        Set(value As Integer)
            _value = value
        End Set
    End Property

    Public Sub New(sign As CardSign, value As Integer)
        _value = value
        _sign = sign
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0} of {1}", _value, _sign)
    End Function

End Class
