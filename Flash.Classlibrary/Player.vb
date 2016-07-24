Imports System.Text
Imports System.Collections.Generic
Imports Flash.Interface


Public Class Player
    Implements IPlayer

    Private _name As String
    Private _cards As List(Of ICard)

    Sub New(name As String, cards As List(Of ICard))
        ' TODO: Complete member initialization 
        _name = name
        _cards = cards
    End Sub


    Public Property Cards As System.Collections.Generic.List(Of ICard) Implements IPlayer.Cards
        Get
            Return _cards
        End Get
        Set(value As System.Collections.Generic.List(Of ICard))
            _cards = value
        End Set
    End Property

    Public Property Name As String Implements IPlayer.Name
        Get
            Return _name
        End Get
        Set(value As String)
            _name = Trim$(value)
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim card As ICard
        Dim sb As New StringBuilder

        For Each card In _cards
            sb.AppendFormat("{0} => {1}.{2}", Me.Name, card.ToString(), Environment.NewLine)
        Next
        Return sb.ToString()
    End Function
End Class
