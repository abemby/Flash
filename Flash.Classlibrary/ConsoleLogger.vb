Imports Flash.Interface

Public Class ConsoleLogger
    Implements ILogger

    Public Sub WriteLog(value As String) Implements ILogger.WriteLog
        Console.WriteLine(String.Format("{0}", value))
        Console.ReadKey()
    End Sub

    Public Sub WriteLog(level As [Interface].LogLevels, value As String) Implements ILogger.WriteLog
        Console.WriteLine(String.Format("{0}\t{1}\n{2}", level, Date.Now, value))
        Console.ReadKey()
    End Sub

End Class
