Imports Flash.Interface
Imports System.Text

Public Class Deck
    Implements IDeck

    Private _logger As ILogger
    Private _cards As List(Of ICard)
    Private _players As List(Of IPlayer)

    Private _noOfPlayer As Integer
    Private _noOfCardsToDistribute As Integer

    Public Sub New(logger As ILogger)
        _logger = logger
        '_logger.WriteLog(LogLevels.INFO, "Deck.Construtor...")

        Initialise()
    End Sub

    Sub New(playerCount As Integer, cardCount As Integer, logger As ILogger)
        _logger = logger
        '_logger.WriteLog(LogLevels.INFO, "Deck.Construtor...")

        _noOfPlayer = playerCount
        _noOfCardsToDistribute = cardCount


        Initialise()
    End Sub

    Public ReadOnly Property NoOfCardsLeft As Integer Implements IDeck.NoOfCardsLeft
        Get
            Return _cards.Count
        End Get
    End Property

    Public Property NoOfCardsToDistribute As Integer Implements IDeck.NoOfCardsToDistribute
        Get
            Return _noOfCardsToDistribute
        End Get
        Set(value As Integer)
            _noOfCardsToDistribute = value
        End Set
    End Property

    Public Property NoOfPlayer As Integer Implements IDeck.NoOfPlayer
        Get
            Return _noOfPlayer
        End Get
        Set(value As Integer)
            _noOfPlayer = value
        End Set
    End Property


    Public Property Cards As System.Collections.Generic.List(Of ICard) Implements IDeck.Cards
        Get
            Return _cards
        End Get
        Set(value As System.Collections.Generic.List(Of ICard))
            _cards = value
        End Set
    End Property

    Public Property Players As System.Collections.Generic.List(Of IPlayer) Implements IDeck.Players
        Get
            Return _players
        End Get
        Set(value As System.Collections.Generic.List(Of IPlayer))
            _players = value
        End Set
    End Property

    Private Sub Initialise()
        Dim signCtr As Integer
        Dim cardCtr As Integer

        '_logger.WriteLog(LogLevels.INFO, "Deck.Initialise...")

        _cards = New List(Of ICard)
        For signCtr = 9824 To 9827
            For cardCtr = 1 To 13
                _cards.Add(New Card(DirectCast(signCtr, CardSign), cardCtr))
            Next
        Next

    End Sub

    Public Sub Deal()
        '_logger.WriteLog(LogLevels.INFO, "Deck.Deal...")

        Dim counter As Integer
        _players = New List(Of IPlayer)

        For counter = 1 To _noOfPlayer
            _players.Add(New Player("p" + counter.ToString(), Distribute()))
        Next

    End Sub

    Public Function Distribute() As System.Collections.Generic.List(Of ICard) Implements IDeck.Distribute
        _logger.WriteLog(LogLevels.INFO, "Deck.Distribute...")

        Dim randomIndexes As List(Of Integer)

        randomIndexes = FetchRandomCards(NoOfCardsToDistribute)
        Return DistributedCards(randomIndexes)
    End Function

    Private Function DistributedCards(randomIndexes As List(Of Integer))
        Dim dCards As New List(Of ICard)

        Try

            For Each index As Integer In randomIndexes
                dCards.Add(_cards.Item(index))
            Next

            For Each card As ICard In dCards
                _cards.Remove(card)
            Next

        Catch ex As Exception

        End Try

        Return dCards
    End Function


    Private Function FetchRandomCards(maxCtr As Integer) As List(Of Integer)
        Dim counter As Integer
        Dim random As New Random()
        Dim randomNext As Integer
        Dim indexes As New List(Of Integer)

        counter = 0
        While (counter < maxCtr)
            randomNext = random.Next(0, NoOfCardsLeft)

            If indexes.Contains(randomNext) Then
                Continue While
            End If

            indexes.Add(randomNext)
            counter += 1
        End While

        Return indexes
    End Function

    Public Sub Shuffle(showCards As Boolean) Implements IDeck.Shuffle
        _logger.WriteLog(LogLevels.INFO, "Deck.Shuffle...")

        Dim randomIndexes As List(Of Integer)
        randomIndexes = FetchRandomCards(52)

        _cards = DistributedCards(randomIndexes)

        If showCards Then
            _logger.WriteLog(LogLevels.WARN, String.Format("{0}", Me.ToString()))
        End If
    End Sub

    Public Sub Reset(showCards As Boolean)
        _logger.WriteLog(LogLevels.INFO, "Deck.Reset...")
        _cards = _cards.OrderBy(Function(x) x.Sign).ThenBy(Function(y) y.Value).ToList()
        If showCards Then
            _logger.WriteLog(LogLevels.WARN, String.Format("{0}", Me.ToString()))
        End If
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        For Each card As ICard In _cards
            sb.AppendFormat("{0}{1}", card.ToString(), vbNewLine)
        Next
        Return sb.ToString()
    End Function

    Public Sub Show()
        '_logger.WriteLog(LogLevels.INFO, "Deck.Show...")
        For Each player In _players
            _logger.WriteLog(String.Format("{0}", player.ToString()))
        Next
    End Sub

End Class
