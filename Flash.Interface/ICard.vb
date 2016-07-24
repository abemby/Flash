Public Enum CardSign
    CLUB = 9827
    DIAMOND = 9826
    HEART = 9825
    SPADE = 9824
End Enum

Public Interface ICard
    Property Value As Integer
    Property Sign As CardSign
End Interface
