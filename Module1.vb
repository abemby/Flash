
Imports Flash.Interface
Imports Flash.Classlibrary

Module Module1

    Sub Main()
        Dim logger As New ConsoleLogger()

        Console.WriteLine("Hello world in Console")

        Try

            PlayFlash(7, 3, logger)

        Catch ex As Exception
            logger.WriteLog(LogLevels.LERROR, ex.Message)
        End Try

        Console.ReadKey()

    End Sub

    Private Sub PlayFlash(playerCount As Integer, cardCount As Integer, logger As ConsoleLogger)
        Dim deck As New Deck(playerCount, cardCount, logger)

        logger.WriteLog(String.Format("Press any key to distribute {0} cards to {1} players.", cardCount, playerCount))

        deck.Deal()

        logger.WriteLog(String.Format("Remaining Cards = {0}{1}Press any key to show cards...", deck.NoOfCardsLeft.ToString(), vbNewLine))
        

        deck.Show()

    End Sub

End Module
