Public Enum LogLevels
    TRACE
    DEBUG
    INFO
    WARN
    LERROR
End Enum

Public Interface ILogger
    Sub WriteLog(value As String)
    Sub WriteLog(level As LogLevels, value As String)
End Interface
