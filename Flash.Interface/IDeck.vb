Public Interface IDeck
    Property Cards As List(Of ICard)
    Property Players As List(Of IPlayer)

    Property NoOfCardsToDistribute As Integer
    ReadOnly Property NoOfCardsLeft As Integer
    Property NoOfPlayer As Integer

    Sub Shuffle(showCard As Boolean)
    Function Distribute() As List(Of ICard)

End Interface
