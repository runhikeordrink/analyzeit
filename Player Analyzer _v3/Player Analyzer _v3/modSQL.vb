Imports System.Data.Odbc

Module modSQL
    Public Function sqlQueryFunction(ByVal sqlSelect As String)

        Dim StrConn As String = "Dsn=PostgreSQL35W;database=nfldb;server=127.0.0.1;port=5432;uid=nfldb;pwd=nfldb;"
        Dim MyConn As New OdbcConnection(StrConn)
        Dim mySelect As String = sqlSelect
        Dim MyDataAdapter As New OdbcDataAdapter
        Dim MyTable As New DataTable

        MyConn.Open()

        MyDataAdapter.SelectCommand = New OdbcCommand(mySelect, MyConn)
        MyDataAdapter.Fill(MyTable)

        MyConn.Close()

        Return MyTable
    End Function
End Module
