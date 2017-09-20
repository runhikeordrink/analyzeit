Module modQuery
    Public Function qryAnalyzer(ByVal sPosition As String, ByVal sSeasonComp As Integer, ByVal sSeasonTo As Integer, ByVal sTypeComp As String, ByVal sTypeTo As String, sStartComp As Integer, sStartTo As Integer, sEndComp As Integer, sEndTo As Integer)
        Dim sqlQuery As String
        Dim thisTable As New DataTable
        Dim sWeekComp, sWeekComp2, sWeekTo, sSelect, sByeQuery, sByeQueryIn, sByeQuery2 As String
        Dim iByeCount As Integer

        iByeCount = getBYE(sSeasonTo, sStartTo, sEndTo, sTypeTo)

        If iByeCount > 0 And (sStartTo <> 1 And sEndTo <> 17) Then
            sqlQuery = "select team from bye where season_year=" & sSeasonTo & " and season_type='" + sTypeTo + "' and (season_week>=" & sStartTo & " and season_week<=" & sEndTo & ") "
            thisTable = sqlQueryFunction(sqlQuery)
            sByeQuery = " or (g.season_year=" & sSeasonTo & " and g.season_type='" & sTypeTo + "' and (g.week>=" & sStartTo - 1 & " and g.week<=" & sEndTo & ")  and p.team in ("
            sByeQuery2 = " or (g.season_year=" & sSeasonTo & " and g.season_type='" & sTypeTo + "' and (g.week>=" & sStartTo - 1 & " and g.week<=" & sEndTo & ")  and (g.home_team in ("

            For i = 0 To thisTable.Rows.Count - 1
                If thisTable.Rows.Count > 1 And i <> 0 Then sByeQueryIn = sByeQueryIn + ","
                sByeQueryIn = sByeQueryIn + "'" + thisTable.Rows(i).Item(0) + "'"
            Next
            sByeQuery = sByeQuery + sByeQueryIn + "))) "
            sByeQuery2 = sByeQuery2 + sByeQueryIn + ") or (g.away_team in (" + sByeQueryIn + "))))"
        Else
            sByeQuery = " "
            sByeQuery2 = ""
        End If

        sSelect = ""

        If sSeasonComp = 2017 And sTypeComp = "Regular" Then
            If sStartComp = sEndComp Then
                sWeekComp = "gn.season_week=" + sStartComp.ToString
                sWeekComp2 = "gn.season_week=" + sStartComp.ToString
            Else
                sWeekComp = "(gn.season_week>=" + sStartComp.ToString + " and gn.season_week<=" + sEndComp.ToString + ")"
                sWeekComp2 = "(gn.season_week>=" + sStartComp.ToString + " and gn.season_week<=" + sEndComp.ToString + ")"
            End If
        Else
            If sStartComp = sEndComp Then
                sWeekComp = "g.week=" + sStartComp.ToString
                sWeekComp2 = "gn.season_week=" + sStartComp.ToString
            Else
                sWeekComp = "(g.week>=" + sStartComp.ToString + "and g.week<=" + sEndComp.ToString + ")"
                sWeekComp2 = "(gn.season_week>=" + sStartComp.ToString + " and gn.season_week<=" + sEndComp.ToString + ")"
            End If
        End If

        If sSeasonTo = 2017 And sTypeTo = "Regular" Then
            If sStartTo = sEndTo Then
                sWeekTo = "g.week=" + sStartTo.ToString
            Else
                sWeekTo = "(g.week>=" + sStartTo.ToString + " and g.week<=" + sEndTo.ToString + ")"
            End If
        Else
            If sStartTo = sEndTo Then
                sWeekTo = "g.week=" + sStartTo.ToString
            Else
                sWeekTo = "(g.week>=" + sStartTo.ToString + " and g.week<=" + sEndTo.ToString + ")"
            End If
        End If

        sSelect = "p1.full_name, p1.position, p1.team, p1.nextopponent, "

        Select Case sPosition
            Case "QB"
                sSelect = sSelect + "p1.rankyds, p2.rankpassyards, p1.rankcmp, p2.rankpasscmp, p1.ranktds, p2.rankpasstds, p1.rankint, p2.rankpassint, " &
                "p1.rankrushyds, p2.rankdefrushyds, p1.rankrushtds, p2.rankdefrushtds, p1.rankatt, p2.rankpassatt, " &
                "p1.rankqunder15, p2.rankqunder15, p1.rankqmidqb, p2.rankqmidqb, p1.rankqover25, p2.rankqover25, p1.ranksack, p2.rankdefsack, " &
                "p1.rankfumblestot, p2.rankdeffumblestot, p1.rankfumbleslost, p2.rankdeffumbleslost, " &
                "p0.pointsfor, p0.pointsagainst, p0.wins, p0.loses, p0.ties "
            Case "RB"
                sSelect = sSelect + "p1.rankrushatt, p2.rankdefrushatt, p1.rankrushyds, p2.rankdefrushyds, p1.rankrushtds, p2.rankdefrushtds, " &
                "p1.rankrunder10, p2.rankdefrunder15, p1.rankrmidrb, p2.rankdefrmidrb, p1.rankrover20, p2.rankdefrover20,p1.rankfumblestot, p2.rankdeffumblestot, " &
                "p1.rankfumbleslost, p2.rankdeffumbleslost "
            Case "WR"
                sSelect = sSelect + "p1.ranktar, p2.rankdeftar, p1.rankrec, p2.rankdefrec, p1.rankrectds, p2.rankdefrectds, p1.rankrecyds, p2.rankdefrecyds, " &
                "p1.rankcunder15, p2.rankdefcunder15, p1.rankcmidwr, p2.rankdefcmidrec, p1.rankcover25, p2.rankdefcover25, p1.rankrecyacyds, p2.rankdefrecyacyds, " &
                "p1.rankyunder15, p2.rankdefyunder15, p1.rankymidwr, p2.rankdefymidrec, p1.rankyover25, p2.rankdefyover25 "
            Case "TE"
                sSelect = sSelect + "p1.ranktar, p2.rankdeftar, p1.rankrec, p2.rankdefrec, p1.rankrectds, p2.rankdefrectds, p1.rankrecyds, p2.rankdefrecyds, " &
                "p1.rankcunder15, p2.rankdefcunder15, p1.rankcmidwr, p2.rankdefcmidrec, p1.rankcover25, p2.rankdefcover25, p1.rankrecyacyds, p2.rankdefrecyacyds, " &
                "p1.rankyunder15, p2.rankdefyunder15, p1.rankymidwr, p2.rankdefymidrec, p1.rankyover25, p2.rankdefyover25 "
        End Select

        sSelect = sSelect + ", p1.passingCMP, p1.passingATT, p1.passingYDS, p1.passingTDs, p1.passingINT, p3.gamesplayed, p4.ffpoints, p4.avgpoints, p1.homeaway, p5.defpoints, p5.defavgpts, " &
            "p6.projected_points, p6.salary, p6.spread, p6.overunder, p6.value, p1.homeaway "

        sqlQuery = "Select " + sSelect +
            "from (" &
            "Select p.player_id, p.full_name, p.position, p.team, " &
            "Case When p.team=gn.hometeam Then gn.awayteam " &
                "Else gn.hometeam " &
                "End As nextopponent, " &
            "case when p.team=gn.hometeam then 'Home' else 'Away' end as homeaway, " &
            "sum(passing_cmp) As passingCMP, " &
            "row_number() OVER (ORDER BY sum(pl.passing_cmp) DESC NULLS LAST) As rankcmp, " &
            "sum(passing_att) As passingATT, " &
            "row_number() OVER (ORDER BY sum(pl.passing_att) DESC NULLS LAST) As rankatt, " &
            "round(nullif(sum(passing_cmp),0)/cast(nullif(sum(passing_att),0) As Decimal),2) As passingPCT, " &
            "sum(passing_int) As passingINT, " &
            "row_number() OVER (ORDER BY sum(pl.passing_int) DESC NULLS LAST) As rankint, " &
            "sum(passing_tds) As passingTDS, " &
            "row_number() OVER (ORDER BY sum(pl.passing_tds) DESC NULLS LAST) As ranktds, " &
            "sum(passing_twoptm) As passingTWOptm, " &
            "sum(passing_yds)+sum(passing_sk_yds) As passingYDS, " &
            "row_number() OVER (ORDER BY sum(pl.passing_yds)+sum(passing_sk_yds) DESC NULLS LAST) As rankyds, " &
            "nullif(sum(passing_yds),0)/nullif(sum(passing_cmp),0) As YardCompletion, " &
            "sum(Case " &
                "When (pl.passing_yds > 0 And pl.passing_yds < 15) Then 1 " &
                "Else 0 " &
                "End) As qunder15, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.passing_yds > 0 And pl.passing_yds < 15) Then 1 Else 0 End) DESC NULLS LAST) As rankqunder15, " &
            "sum(Case " &
                "When (pl.passing_yds > 14 And pl.passing_yds < 26) Then 1 " &
                "Else 0 " &
                "End) As qmidQB, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.passing_yds > 14 And pl.passing_yds < 26) Then 1 Else 0 End) DESC NULLS LAST) As rankqmidqb, " &
            "sum(Case " &
                "When pl.passing_yds > 25 Then 1 " &
                "Else 0 " &
                "End) As qover25, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.passing_yds > 25) Then 1 Else 0 End) DESC NULLS LAST) As rankqover25, " &
            "sum(passing_sk) As passingSACK, " &
            "row_number() OVER (ORDER BY sum(pl.passing_sk) DESC NULLS LAST) As ranksack, " &
            "sum(passing_sk_yds) As passingSACKyds, " &
            "sum(receiving_tar) As receivingTAR, " &
            "row_number() OVER (ORDER BY sum(pl.receiving_tar) DESC NULLS LAST) As ranktar, " &
            "sum(receiving_rec) As receivingREC, " &
            "row_number() OVER (ORDER BY sum(pl.receiving_rec) DESC NULLS LAST) As rankrec, " &
            "round(nullif(sum(receiving_rec),0)/cast(nullif(sum(receiving_tar),0) As Decimal),2) As receivingPCT, " &
            "sum(receiving_tds) As receivingTDS, " &
            "row_number() OVER (ORDER BY sum(pl.receiving_tds) DESC NULLS LAST) As rankrectds, " &
            "sum(receiving_twoptm) As receivingTWOptm, " &
            "sum(receiving_yds) As receivingYDS, " &
            "row_number() OVER (ORDER BY sum(pl.receiving_yds) DESC NULLS LAST) As rankrecyds, " &
            "sum(Case " &
                "When (pl.receiving_yds > 0 And pl.receiving_yds < 15) Then 1 " &
                "Else 0 " &
                "End) As cunder15, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.receiving_yds > 0 And pl.receiving_yds < 15) Then 1 Else 0 End) DESC NULLS LAST) As rankcunder15, " &
            "sum(Case " &
                "When (pl.receiving_yds > 15 And pl.receiving_yds < 26) Then 1 " &
                "Else 0 " &
                "End) As cmidWR, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.receiving_yds > 15 And pl.receiving_yds < 26) Then 1 Else 0 End) DESC NULLS LAST) As rankcmidwr, " &
            "sum(Case " &
                "When pl.receiving_yds > 25 Then 1 " &
                "Else 0 " &
                "End) As cover25, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.receiving_yds > 25) Then 1 Else 0 End) DESC NULLS LAST) As rankcover25, " &
            "sum(receiving_yac_yds) As receivingYAC, " &
            "row_number() OVER (ORDER BY sum(pl.receiving_yac_yds) DESC NULLS LAST) As rankrecyacyds, " &
            "sum(Case " &
                "When (pl.receiving_yac_yds > 0 And pl.receiving_yac_yds < 15) Then 1 " &
                "Else 0 " &
                "End) As yunder15, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.receiving_yac_yds > 0 And pl.receiving_yac_yds < 15) Then 1 Else 0 End) DESC NULLS LAST) As rankyunder15, " &
            "sum(Case " &
                "When (pl.receiving_yac_yds > 15 And pl.receiving_yac_yds < 26) Then 1 " &
                "Else 0 " &
                "End) As ymidWR, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.receiving_yac_yds > 15 And pl.receiving_yac_yds < 26) Then 1 Else 0 End) DESC NULLS LAST) As rankymidwr, " &
            "sum(Case " &
                "When pl.receiving_yac_yds > 25 Then 1 " &
                "Else 0 " &
                "End) As yover25, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.receiving_yac_yds > 25) Then 1 Else 0 End) DESC NULLS LAST) As rankyover25, " &
            "sum(rushing_att) As rushingATT, " &
            "row_number() OVER (ORDER BY sum(pl.rushing_att) DESC NULLS LAST) As rankrushatt, " &
            "round(nullif(sum(Case When pl.rushing_yds > 0 Then 1 Else 0 End),0)/cast(nullif(sum(rushing_att),0) As Decimal),2) As rushingPCT, " &
            "sum(rushing_tds) As rushingTDS, " &
            "row_number() OVER (ORDER BY sum(pl.rushing_tds) DESC NULLS LAST) As rankrushtds, " &
            "sum(rushing_twoptm) As rushingTWOptm, " &
            "sum(rushing_yds) As rushingYDS, " &
            "row_number() OVER (ORDER BY sum(pl.rushing_yds) DESC NULLS LAST) As rankrushyds, " &
            "sum(Case " &
                "When (pl.rushing_yds > 0 And pl.rushing_yds < 15) Then 1 " &
                "Else 0 " &
                "End) As runder15, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.rushing_yds > 0 And pl.rushing_yds < 15) Then 1 Else 0 End) DESC NULLS LAST) As rankrunder10, " &
            "sum(Case " &
                "When (pl.rushing_yds > 14 And pl.rushing_yds < 21) Then 1 " &
                "Else 0 " &
                "End) As rmidRB, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.rushing_yds > 14 And pl.receiving_yac_yds < 21) Then 1 Else 0 End) DESC NULLS LAST) As rankrmidrb, " &
            "sum(Case " &
                "When pl.rushing_yds > 20 Then 1 " &
                "Else 0 " &
                "End) As rover25, " &
            "row_number() OVER (ORDER BY sum(Case When (pl.rushing_yds > 21) Then 1 Else 0 End) DESC NULLS LAST) As rankrover20, " &
            "sum(fumbles_tot) As fumblesTOT, " &
            "row_number() OVER (ORDER BY sum(pl.fumbles_tot) DESC NULLS LAST) As rankfumblestot, " &
            "sum(fumbles_lost) As fumblesLOST, " &
            "row_number() OVER (ORDER BY sum(pl.fumbles_lost) DESC NULLS LAST) As rankfumbleslost " &
            "from play_player pl " &
            "inner join player p On (pl.player_id = p.player_id) " &
            "inner join game g On (pl.gsis_id = g.gsis_id) " &
        "inner join games gn On ((p.team=gn.hometeam Or p.team=gn.awayteam) And gn.season_year=" + sSeasonComp.ToString + " And " + sWeekComp2 + " And gn.season_type='" + Mid(sTypeComp, 1, 1) + "' ) " & 'compare/upcoming options here
        "where p.position='" + sPosition + "' and (g.season_year =" + sSeasonTo.ToString + " And g.season_type='" + sTypeTo + "' and (g.week>=" + sStartTo.ToString + " and g.week<=" + sEndTo.ToString + ")) " & 'compare to and position options here
        " " + sByeQuery + " " &
        "group by p.player_id, p.full_name, p.position, p.team, Case When p.team=gn.hometeam Then gn.awayteam Else gn.hometeam End, case when p.team=gn.hometeam then 'Home' else 'Away' end " &
        "order by p.position, p.full_name " &
            ") p1 " &
        "left join (" &
         "select case when pl.team=g.home_team then g.away_team  " &
        "Else g.home_team  " &
        "End As defense, " &
        "(sum(passing_yds)+sum(rushing_yds))+sum(passing_sk_yds) as totalyards, " &
        "row_number() OVER (ORDER BY sum(passing_yds)+sum(rushing_yds)+sum(passing_sk_yds) NULLS LAST) AS ranktotyards, " &
        "sum(passing_yds)+sum(passing_sk_yds) as passyards, " &
        "row_number() OVER (ORDER BY sum(passing_yds)+sum(passing_sk_yds) NULLS LAST) AS rankpassyards, " &
        "sum(rushing_yds) as rushyards, " &
        "row_number() OVER (ORDER BY sum(rushing_yds) NULLS LAST) AS rankrushyards, " &
        "sum(passing_cmp) as passingCMP, " &
        "row_number() OVER (ORDER BY sum(passing_cmp) NULLS LAST) AS rankpasscmp, " &
        "sum(passing_att) as passingATT, " &
        "row_number() OVER (ORDER BY sum(passing_att) NULLS LAST) AS rankpassatt, " &
        "round(nullif(sum(passing_cmp),0)/cast(nullif(sum(passing_att),0) as decimal),2) as passingPCT, " &
        "sum(passing_int) as passingINT, " &
        "row_number() OVER (ORDER BY sum(passing_int) desc NULLS LAST) AS rankpassint, " &
        "sum(passing_tds) as passingTDS, " &
        "row_number() OVER (ORDER BY sum(passing_tds) NULLS LAST) AS rankpasstds, " &
        "sum(passing_twoptm) as passingTWOptm, " &
        "sum(passing_yds) as passingYDS, " &
        "nullif(sum(passing_yds),0)/nullif(sum(passing_cmp),0) as YardCompletion, " &
        "sum(case " &
            "when (pl.passing_yds > 0 And pl.passing_yds < 15) then 1 " &
            "Else 0 " &
            "End) As qunder15, " &
        "row_number() OVER (ORDER BY sum(case when (pl.passing_yds > 0 And pl.passing_yds < 15) then 1 else 0 end) NULLS LAST) AS rankqunder15, " &
        "sum(case " &
            "when (pl.passing_yds > 14 And pl.passing_yds < 26) then 1 " &
            "Else 0 " &
            "End) As qmidQB, " &
        "row_number() OVER (ORDER BY sum(case when (pl.passing_yds > 14 And pl.passing_yds < 26) then 1 else 0 end) NULLS LAST) AS rankqmidqb, " &
        "sum(case " &
            "when pl.passing_yds > 25 then 1 " &
            "Else 0 " &
            "End) As qover25, " &
        "row_number() OVER (ORDER BY sum(case when (pl.passing_yds > 25) then 1 else 0 end) NULLS LAST) AS rankqover25, " &
        "sum(passing_sk) as passingSACK, " &
        "row_number() OVER (ORDER BY sum(passing_sk) desc NULLS LAST) AS rankdefsack, " &
        "sum(passing_sk_yds) as passingSACKyds, " &
        "sum(receiving_tar) as receivingTAR, " &
        "row_number() OVER (ORDER BY sum(receiving_tar) NULLS LAST) AS rankdeftar, " &
        "sum(receiving_rec) as receivingREC, " &
        "row_number() OVER (ORDER BY sum(receiving_rec) NULLS LAST) AS rankdefrec, " &
        "round(nullif(sum(receiving_rec),0)/cast(nullif(sum(receiving_tar),0) as decimal),2) as receivingPCT, " &
        "sum(receiving_tds) as receivingTDS, " &
        "row_number() OVER (ORDER BY sum(receiving_tds) NULLS LAST) AS rankdefrectds, " &
        "sum(receiving_twoptm) as receivingTWOptm, " &
        "sum(receiving_yds) as receivingYDS, " &
        "row_number() OVER (ORDER BY sum(receiving_yds) NULLS LAST) AS rankdefrecyds, " &
        "sum(case " &
            "when (pl.receiving_yds > 0 And pl.receiving_yds < 15) then 1 " &
            "Else 0 " &
            "End) As cunder15, " &
        "row_number() OVER (ORDER BY sum(case when (pl.receiving_yds > 0 And pl.receiving_yds < 15) then 1 else 0 end) NULLS LAST) AS rankdefcunder15, " &
        "sum(case " &
            "when (pl.receiving_yds > 15 And pl.receiving_yds < 26) then 1 " &
            "Else 0 " &
            "End) As cmidrec, " &
        "row_number() OVER (ORDER BY sum(case when (pl.receiving_yds > 15 And pl.receiving_yds < 26) then 1 else 0 end) NULLS LAST) AS rankdefcmidrec, " &
        "sum(case " &
            "when pl.receiving_yds > 25 then 1 " &
            "Else 0 " &
            "End) As cover25, " &
        "row_number() OVER (ORDER BY sum(case when (pl.receiving_yds > 25) then 1 else 0 end) NULLS LAST) AS rankdefcover25, " &
        "sum(receiving_yac_yds) as receivingYAC, " &
        "row_number() OVER (ORDER BY sum(receiving_yac_yds) NULLS LAST) AS rankdefrecyacyds, " &
        "sum(case " &
            "when (pl.receiving_yac_yds > 0 And pl.receiving_yac_yds < 15) then 1 " &
            "Else 0 " &
            "End) As yunder15, " &
        "row_number() OVER (ORDER BY sum(case when (pl.receiving_yac_yds > 0 And pl.receiving_yac_yds < 15) then 1 else 0 end) NULLS LAST) AS rankdefyunder15, " &
        "sum(case " &
            "when (pl.receiving_yac_yds > 15 And pl.receiving_yac_yds < 26) then 1 " &
            "Else 0 " &
            "End) As ymidrec, " &
        "row_number() OVER (ORDER BY sum(case when (pl.receiving_yac_yds > 15 And pl.receiving_yac_yds < 26) then 1 else 0 end) NULLS LAST) AS rankdefymidrec, " &
        "sum(case " &
            "when pl.receiving_yac_yds > 25 then 1 " &
            "Else 0 " &
            "End) As yover25, " &
        "row_number() OVER (ORDER BY sum(case when (pl.receiving_yds > 25) then 1 else 0 end) NULLS LAST) AS rankdefyover25, " &
        "sum(rushing_att) as rushingATT, " &
        "row_number() OVER (ORDER BY sum(rushing_att) NULLS LAST) AS rankdefrushatt, " &
        "round(nullif(sum(case when pl.rushing_yds > 0 then 1 else 0 end),0)/cast(nullif(sum(rushing_att),0) as decimal),2) as rushingPCT, " &
        "sum(rushing_tds) as rushingTDS, " &
        "row_number() OVER (ORDER BY sum(rushing_tds) NULLS LAST) AS rankdefrushtds, " &
        "sum(rushing_twoptm) as rushingTWOptm, " &
        "sum(rushing_yds) as rushingYDS, " &
        "row_number() OVER (ORDER BY sum(rushing_yds) NULLS LAST) AS rankdefrushyds, " &
        "sum(case " &
            "when (pl.rushing_yds > 0 And pl.rushing_yds < 11) then 1 " &
            "Else 0 " &
            "End) As runder15, " &
        "row_number() OVER (ORDER BY sum(case when (pl.rushing_yds > 0 And pl.rushing_yds < 11) then 1 else 0 end) NULLS LAST) AS rankdefrunder15, " &
        "sum(case " &
            "when (pl.rushing_yds > 10 And pl.rushing_yds < 21) then 1 " &
            "Else 0 " &
            "End) As rmidRB, " &
        "row_number() OVER (ORDER BY sum(case when (pl.rushing_yds > 10 And pl.rushing_yds < 21) then 1 else 0 end) NULLS LAST) AS rankdefrmidrb, " &
        "sum(case " &
            "when pl.rushing_yds > 20 then 1 " &
            "Else 0 " &
            "End) As rover25, " &
        "row_number() OVER (ORDER BY sum(case when (pl.rushing_yds > 21) then 1 else 0 end) NULLS LAST) AS rankdefrover20, " &
        "sum(fumbles_tot) as fumblesTOT, " &
        "row_number() OVER (ORDER BY sum(fumbles_tot) desc NULLS LAST) AS rankdeffumblestot, " &
        "sum(fumbles_lost) as fumblesLOST, " &
        "row_number() OVER (ORDER BY sum(fumbles_lost) desc NULLS LAST) AS rankdeffumbleslost " &
        "from play_player pl " &
        "inner join player p On (pl.player_id = p.player_id) " &
        "inner join game g On (pl.gsis_id = g.gsis_id) " &
        "where p.position='" + sPosition + "' and (g.season_year = " + sSeasonTo.ToString + " And g.season_type='" + sTypeTo + "' and " + sWeekTo + ") " & 'compare to and position options here
        " " + sByeQuery2 + " " &
        "group by Case When pl.team=g.home_team Then g.away_team Else g.home_team End " &
            ") p2 on (p1.nextopponent=p2.defense) " &
        "left join( " &
            "select t.team_id As team, " &
            "sum(case when t.team_id=g.home_team then home_score end)+sum(Case When t.team_id= g.away_team Then away_score End) As pointsfor, " &
            "sum(case when t.team_id=g.home_team then away_score end)+sum(case when t.team_id=g.away_team then home_score end) as pointsagainst, " &
            "sum(case when t.team_id=g.home_team And g.home_score > g.away_score then 1 else 0 end)+sum(case when t.team_id=g.away_team And g.away_score > g.home_score then 1 else 0 end) as wins, " &
            "sum(case when t.team_id=g.home_team And g.home_score < g.away_score then 1 else 0 end)+sum(case when t.team_id=g.away_team And g.away_score < g.home_score then 1 else 0 end) as loses, " &
            "sum(case when t.team_id=g.home_team And g.home_score = g.away_score then 1 else 0 end)+sum(case when t.team_id=g.away_team And g.away_score = g.home_score then 1 else 0 end) as ties, " &
            "sum(case when t.team_id=g.home_team And g.home_score > g.away_score then 1 else 0 end) as winhome, " &
            "sum(case when t.team_id=g.home_team And g.home_score < g.away_score then 1 else 0 end) as losehome, " &
            "sum(case when t.team_id=g.home_team And g.home_score = g.away_score then 1 else 0 end) as tiehome, " &
            "sum(case when t.team_id=g.away_team And g.away_score > g.home_score then 1 else 0 end) as winaway, " &
            "sum(case when t.team_id=g.away_team And g.away_score < g.home_score then 1 else 0 end) as loseaway, " &
            "sum(case when t.team_id=g.away_team And g.away_score = g.home_score then 1 else 0 end) as tieaway " &
        "from team t " &
        "inner join game g On (t.team_id=g.home_team Or t.team_id=g.away_team) " &
        "where season_year = " + sSeasonTo.ToString + " And season_type ='" + sTypeTo + "' " & 'compare to options here
        "group by t.team_id " &
        "order by t.team_id " &
            ") p0 on (p1.team=p0.team) " &
        "left join ( " &
            "select pl.player_id, p.full_name, count(distinct g.gsis_id) as gamesplayed " &
            "from play_player pl " &
            "inner join player p on (pl.player_id = p.player_id) " &
            "inner join game g on (pl.gsis_id = g.gsis_id)" &
            "where p.position='" + sPosition + "' and g.season_year=" + sSeasonTo.ToString + " and (g.week>=" + sStartTo.ToString + " and g.week<=" + sEndTo.ToString + ") and g.season_type='" + sTypeTo + "' " &
            "group by pl.player_id, p.full_name " &
            "order by p.full_name " &
            ") p3 on (p1.player_id=p3.player_id) " &
        "left join " &
            "(select concat(split_part(player_name,', ',2),' ',split_part(player_name,', ',1)) as full_name, player_name, player_position, player_team, sum(player_points) as ffpoints, avg(player_points) as avgpoints " &
            "from weeklypoints " &
            "where season_year=" + sSeasonTo.ToString + " and player_position='" + sPosition + "' " &
            "group by concat(split_part(player_name,', ',2),' ',split_part(player_name,', ',1)), player_name, player_position, player_team " &
            "order by concat(split_part(player_name,', ',2),' ',split_part(player_name,', ',1)) " &
            ")  p4 on (p1.full_name=p4.full_name)  " &
        "left join " &
            "(select player_team, sum(player_points) as defpoints, avg(player_points) as defavgpts " &
            "from weeklypoints " &
            "where season_year=" + sSeasonTo.ToString + " and player_position='Def' " &
            "group by player_team " &
            ") p5 on (p1.nextopponent=upper(p5.player_team))  " &
        "left join " &
            "(select split_part(player_name,' (',1) as full_name, projected_points, salary, spread, overunder, value " &
            "from weeklyprojections " &
            "where season_year=" + sSeasonComp.ToString + " and season_week=" + sEndComp.ToString + " and player_name like '%" + sPosition + "%' " &
            ") p6 on (p1.full_name=p6.full_name)" &
        "order by p4.avgpoints desc "

        thisTable = sqlQueryFunction(sqlQuery)
        Return thisTable
    End Function

    Private Function getBYE(ByVal iYear As Integer, ByVal iWeekStart As Integer, ByVal iWeekEnd As Integer, ByVal sType As String) As Integer
        Dim thisTable As DataTable
        Dim sqlQuery As String

        sqlQuery = "select count(season_week) as wcount " &
            "from bye " &
            "where season_year=" & iYear & " And season_type='" + sType + "' and (season_week>=" & iWeekStart & " and season_week<=" & iWeekEnd & ") " &
            "group by season_week"

        thisTable = sqlQueryFunction(sqlQuery)
        If thisTable.Rows.Count > 0 Then
            Return Int(thisTable.Rows(0).Item(0).ToString)
        Else
            Return 0
        End If
        'Return thisTable.Rows.Count

    End Function

End Module
