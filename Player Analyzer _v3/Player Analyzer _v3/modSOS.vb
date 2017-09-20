Module modSOS
    Public Function getSOS(ByVal strTeam As String)
        Dim sqlStatement As String
        Dim strTeams(16) As String
        Dim intWins, intLosses, intPF, intPA As Integer
        Dim intSOSdata(4) As Integer
        Dim thisTable As DataTable

        sqlStatement = "select season_week, hometeam, awayteam " &
            "from games " &
            "where season_year=2017 and (hometeam='" + strTeam + "' or awayteam='" + strTeam + "') " &
            "order by season_week"

        thisTable = sqlQueryFunction(sqlStatement)

        For iT As Integer = 0 To thisTable.Rows.Count - 1
            If strTeam.Equals(thisTable.Rows(iT).Item("hometeam").ToString.Replace(" ", "")) Then
                strTeams(iT) = thisTable.Rows(iT).Item("awayteam").ToString.Replace(" ", "")
            Else
                strTeams(iT) = thisTable.Rows(iT).Item("hometeam").ToString.Replace(" ", "")
            End If

        Next
        thisTable = Nothing

        'strTeams(0) = "NYG"
        'strTeams(1) = "WAS"
        'strTeams(2) = "CHI"
        'strTeams(3) = "SF"
        'strTeams(4) = "CIN"
        'strTeams(5) = "GB"
        'strTeams(6) = "PHI"
        'strTeams(7) = "CLE"
        'strTeams(8) = "PIT"
        'strTeams(9) = "BAL"
        'strTeams(10) = "WAS"
        'strTeams(11) = "MIN"
        'strTeams(12) = "NYG"
        'strTeams(13) = "TB"
        'strTeams(14) = "DET"
        'strTeams(15) = "PHI"

        sqlStatement = "select gsis_id, week, home_team, home_score, away_team, away_score " &
            "from game " &
            "where season_year=2016 And season_type='Regular' and " &
            "(home_team in ('" + strTeams(0) + "','" + strTeams(1) + "','" + strTeams(2) + "','" + strTeams(3) + "','" + strTeams(4) + "','" + strTeams(5) + "','" + strTeams(6) + "','" + strTeams(7) + "','" + strTeams(8) + "','" + strTeams(9) + "','" + strTeams(10) + "','" + strTeams(11) + "','" + strTeams(12) + "','" + strTeams(13) + "','" + strTeams(14) + "','" + strTeams(15) + "') or " &
            "(away_team in ('" + strTeams(0) + "','" + strTeams(1) + "','" + strTeams(2) + "','" + strTeams(3) + "','" + strTeams(4) + "','" + strTeams(5) + "','" + strTeams(6) + "','" + strTeams(7) + "','" + strTeams(8) + "','" + strTeams(9) + "','" + strTeams(10) + "','" + strTeams(11) + "','" + strTeams(12) + "','" + strTeams(13) + "','" + strTeams(14) + "','" + strTeams(15) + "'))) " &
            "order by gsis_id "
        thisTable = sqlQueryFunction(sqlStatement)

        If thisTable.Rows.Count > 0 Then
            For iI As Integer = 0 To thisTable.Rows.Count - 1
                For iJ As Integer = 0 To 15
                    If thisTable.Rows(iI).Item("home_team").ToString.Equals(strTeams(iJ).ToString) Then
                        If CInt(thisTable.Rows(iI).Item("home_score").ToString) > CInt(thisTable.Rows(iI).Item("away_score").ToString) Then
                            intWins += 1
                            intPF += CInt(thisTable.Rows(iI).Item("home_score").ToString)
                            intPA += CInt(thisTable.Rows(iI).Item("away_score").ToString)
                        Else
                            intLosses += 1
                            intPF += CInt(thisTable.Rows(iI).Item("home_score").ToString)
                            intPA += CInt(thisTable.Rows(iI).Item("away_score").ToString)
                        End If
                    End If
                    If thisTable.Rows(iI).Item("away_team").ToString.Equals(strTeams(iJ).ToString) Then
                        If CInt(thisTable.Rows(iI).Item("away_score").ToString) > CInt(thisTable.Rows(iI).Item("home_score").ToString) Then
                            intWins += 1
                            intPF += CInt(thisTable.Rows(iI).Item("away_score").ToString)
                            intPA += CInt(thisTable.Rows(iI).Item("home_score").ToString)
                        Else
                            intLosses += 1
                            intPF += CInt(thisTable.Rows(iI).Item("away_score").ToString)
                            intPA += CInt(thisTable.Rows(iI).Item("home_score").ToString)
                        End If
                    End If
                Next
            Next

        End If

        intSOSdata(0) = intWins
        intSOSdata(1) = intLosses
        intSOSdata(2) = intPF
        intSOSdata(3) = intPA

        Return intSOSdata
    End Function
End Module
