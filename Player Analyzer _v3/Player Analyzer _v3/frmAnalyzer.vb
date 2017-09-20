Imports System.Data.Odbc

Public Class frmAnalyzer
    Public pubMeta As clsMeta
    Public cCompare As clsCompare
    Public tCompare As clsCompare

    Private Sub frmAnalyzer_Load(sender As Object, e As EventArgs) Handles Me.Load
        pubMeta = New clsMeta
        cCompare = New clsCompare
        tCompare = New clsCompare

        dgvQBset()
        dgvRBset()
        dgvWRset()
        dgvTEset()

        getMeta()
        getStandings()
        loadCompareYear()


    End Sub
    Private Sub loadCompareYear()
        Dim thisTable As DataTable

        thisTable = sqlQueryFunction("select distinct season_year from game order by season_year")

        cmbSeasonTo.DataSource = thisTable
        cmbSeasonTo.DisplayMember = "season_year"
        cmbSeasonTo.ValueMember = "season_year"
    End Sub

    Private Sub getMeta()
        Dim thisTable As DataTable

        thisTable = sqlQueryFunction("select season_type, season_year, week from meta")
        pubMeta.CurrentSeason = thisTable.Rows(0).Item("season_year").ToString
        pubMeta.CurrentGameType = thisTable.Rows(0).Item("season_type").ToString
        pubMeta.CurrentWeek = thisTable.Rows(0).Item("week").ToString
        tsLabelMeta.Text = pubMeta.CurrentGameType + " Season: " + pubMeta.CurrentSeason + " Week: " + pubMeta.CurrentWeek
    End Sub

    Private Sub getStandings()
        Dim thisTable As DataTable
        Dim sqlQuery As String
        Dim sRecord As String

        sqlQuery = "select t.team_id, " &
        "sum(case when t.team_id=g.home_team then home_score end)+sum(case when t.team_id=g.away_team then away_score end) as ""pointsfor""," &
        "sum(Case When t.team_id=g.home_team Then away_score End)+sum(Case When t.team_id=g.away_team Then home_score End) As ""pointsagainst""," &
        "sum(case when t.team_id=g.home_team and g.home_score > g.away_score then 1 else 0 end)+sum(case when t.team_id=g.away_team and g.away_score > g.home_score then 1 else 0 end) as ""wins""," &
        "sum(case when t.team_id=g.home_team And g.home_score < g.away_score then 1 else 0 end)+sum(case when t.team_id=g.away_team And g.away_score < g.home_score then 1 else 0 end) as ""loses""," &
        "sum(case when t.team_id=g.home_team and g.home_score = g.away_score then 1 else 0 end)+sum(case when t.team_id=g.away_team and g.away_score = g.home_score then 1 else 0 end) as ""ties""," &
        "sum(case when t.team_id=g.home_team And g.home_score > g.away_score then 1 else 0 end) as ""winhome""," &
        "sum(case when t.team_id=g.home_team and g.home_score < g.away_score then 1 else 0 end) as ""losehome""," &
        "sum(case when t.team_id=g.home_team And g.home_score = g.away_score then 1 else 0 end) as ""tiehome""," &
        "sum(case when t.team_id=g.away_team and g.away_score > g.home_score then 1 else 0 end) as ""winaway""," &
        "sum(case when t.team_id=g.away_team And g.away_score < g.home_score then 1 else 0 end) as ""loseaway""," &
        "sum(case when t.team_id=g.away_team and g.away_score = g.home_score then 1 else 0 end) as ""tieaway""" &
        "from team t " &
        "inner join game g on (t.team_id=g.home_team or t.team_id=g.away_team) " &
        "where finished='t' and season_year=" + pubMeta.CurrentSeason + " And season_type ='" + pubMeta.CurrentGameType + "' " &
        "group by t.team_id " &
        "order by t.team_id"

        thisTable = sqlQueryFunction(sqlQuery)
        cmbStandings.Text = pubMeta.CurrentGameType
        cmbStandings.SelectedValue = pubMeta.CurrentGameType

        For i = 0 To thisTable.Rows.Count - 1
            sRecord = thisTable.Rows(i).Item("wins").ToString + "/" + thisTable.Rows(i).Item("loses").ToString + "/" + thisTable.Rows(i).Item("ties").ToString
            dgvStandings.Rows.Add(thisTable.Rows(i).Item("team_id").ToString,
                                    sRecord)
        Next

    End Sub

    Private Sub cmbStandings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStandings.SelectedIndexChanged

    End Sub

    Private Sub cmbTypeComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeComp.SelectedIndexChanged


    End Sub

    Private Sub loadSeasonTypeComp(ByVal sYear As Integer)
        Dim thisTable As New DataTable
        thisTable = sqlQueryFunction("select distinct season_type from game where season_year=" + sYear.ToString)
        cmbTypeComp.DataSource = thisTable
        cmbTypeComp.DisplayMember = "season_type"
        cmbTypeComp.ValueMember = "season_type"
    End Sub
    Private Sub loadWeekStartComp(ByVal sYear As Integer, ByVal sType As String)
        Dim thisTable As New DataTable
        thisTable = sqlQueryFunction("select distinct week from game where season_year=" + sYear.ToString + " and season_type='" + sType + "' order by week")
        cmbStartComp.DataSource = thisTable
        cmbStartComp.DisplayMember = "week"
        cmbStartComp.ValueMember = "week"
    End Sub
    Private Sub loadWeekEndComp(ByVal sYear As Integer, ByVal sType As String)
        Dim thisTable As New DataTable
        thisTable = sqlQueryFunction("select distinct week from game where season_year=" + sYear.ToString + " and season_type='" + sType + "' order by week desc")
        cmbEndComp.DataSource = thisTable
        cmbEndComp.DisplayMember = "week"
        cmbEndComp.ValueMember = "week"
    End Sub

    Private Sub loadSeasonTypeTo(ByVal sYear As Integer)
        Dim thisTable As New DataTable
        thisTable = sqlQueryFunction("select distinct season_type from game where season_year=" + sYear.ToString)
        cmbTypeTo.DataSource = thisTable
        cmbTypeTo.DisplayMember = "season_type"
        cmbTypeTo.ValueMember = "season_type"
    End Sub
    Private Sub loadWeekStartTo(ByVal sYear As Integer, ByVal sType As String)
        Dim thisTable As New DataTable
        thisTable = sqlQueryFunction("select distinct week from game where season_year=" + sYear.ToString + " and season_type='" + sType + "' order by week")
        cmbStartTo.DataSource = thisTable
        cmbStartTo.DisplayMember = "week"
        cmbStartTo.ValueMember = "week"
    End Sub
    Private Sub loadWeekEndTo(ByVal sYear As Integer, ByVal sType As String)
        Dim thisTable As New DataTable
        thisTable = sqlQueryFunction("select distinct week from game where season_year=" + sYear.ToString + " and season_type='" + sType + "' order by week desc")
        cmbEndTo.DataSource = thisTable
        cmbEndTo.DisplayMember = "week"
        cmbEndTo.ValueMember = "week"
    End Sub

    Private Sub cmbSeasonComp_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSeasonComp.SelectionChangeCommitted
        cCompare.compSeason = Int(cmbSeasonComp.SelectedItem.ToString)
        'loadSeasonTypeComp(Int(cmbSeasonComp.SelectedValue))
    End Sub

    Private Sub cmbTypeComp_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTypeComp.SelectionChangeCommitted
        'MsgBox(cmbTypeComp.SelectedItem.ToString)
        cCompare.compType = cmbTypeComp.SelectedItem.ToString
        'loadWeekStartComp(Int(cmbSeasonComp.SelectedValue), cmbTypeComp.SelectedValue)
    End Sub

    Private Sub cmbStartComp_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbStartComp.SelectionChangeCommitted

        cCompare.compStart = Int(cmbStartComp.SelectedItem.ToString)
        'loadWeekEndComp(Int(cmbSeasonComp.SelectedValue), cmbTypeComp.SelectedValue)
    End Sub

    Private Sub cmbSeasonTo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSeasonTo.SelectionChangeCommitted
        loadSeasonTypeTo(Int(cmbSeasonTo.SelectedValue))
        tCompare.compSeason = Int(cmbSeasonTo.SelectedValue)
    End Sub

    Private Sub cmbTypeTo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTypeTo.SelectionChangeCommitted
        loadWeekStartTo(Int(cmbSeasonTo.SelectedValue), cmbTypeTo.SelectedValue)
        tCompare.compType = cmbTypeTo.SelectedValue
    End Sub

    Private Sub cmbStartTo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbStartTo.SelectionChangeCommitted
        loadWeekEndTo(Int(cmbSeasonTo.SelectedValue), cmbTypeTo.SelectedValue)
        tCompare.compStart = Int(cmbStartTo.SelectedValue)
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click

        tsAnalyzing.Text = "Analyzing QB"
        analyzeQB_allSeason()
        analyzeRB_allSeason()
        analyzeWR_allSeason()
        analyzeTE_allSeason()
        pbAnalyzing.Value = 0


    End Sub

    Private Sub cmbEndComp_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbEndComp.SelectionChangeCommitted
        cCompare.compEnd = Int(cmbEndComp.SelectedItem.ToString)
    End Sub

    Private Sub cmbEndTo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbEndTo.SelectionChangeCommitted
        tCompare.compEnd = Int(cmbEndTo.SelectedValue)
    End Sub
    Private Sub analyzeTE_allSeason()
        Dim tblTE As New DataTable
        Dim row, rowCNT, iColor As Integer
        Dim cellColor As Color
        Dim dPlayerValue, dffPoints, davgPoints, dffDefPoints, davgDefPoints As Double
        Dim intGetSOS(4), iDef, iOff, iStuff As Integer

        tblTE = qryAnalyzer("TE", cCompare.compSeason, tCompare.compSeason, cCompare.compType, tCompare.compType, cCompare.compStart, tCompare.compStart, cCompare.compEnd, tCompare.compEnd)
        rowCNT = tblTE.Rows.Count
        tsAnalyzing.Text = "Analyzing: TE"
        pbAnalyzing.Value = 0
        pbAnalyzing.Minimum = 0
        pbAnalyzing.Maximum = rowCNT

        tsNumPlayers.Text = "# Players: " + rowCNT.ToString
        TabControl1.TabPages.Item(3).Text = "TE (" + rowCNT.ToString + ")"

        If rowCNT > 0 Then
            For row = 0 To rowCNT - 1
                pbAnalyzing.Value = row
                dPlayerValue = 0.0
                If IsDBNull(tblTE.Rows(row).Item(32)) Then dffPoints = 0 Else dffPoints = CDbl(Format(tblTE.Rows(row).Item(32), "0.00"))
                If IsDBNull(tblTE.Rows(row).Item(33)) Then davgPoints = 0 Else davgPoints = CDbl(Format(tblTE.Rows(row).Item(33), "0.00"))
                If IsDBNull(tblTE.Rows(row).Item(35)) Then dffDefPoints = 0 Else dffDefPoints = CDbl(Format(tblTE.Rows(row).Item(35), "0.00"))
                If IsDBNull(tblTE.Rows(row).Item(36)) Then davgDefPoints = 0 Else davgDefPoints = CDbl(Format(tblTE.Rows(row).Item(36), "0.00"))
                For iColor = 6 To 27 Step 2
                    If IsDBNull(tblTE.Rows(row).Item(iColor + 1)) Then iDef = 0 Else iDef = Int(tblTE.Rows(row).Item(iColor + 1))
                    If IsDBNull(tblTE.Rows(row).Item(iColor)) Then iOff = 0 Else iOff = Int(tblTE.Rows(row).Item(iColor))
                    dPlayerValue = dPlayerValue + calcPlayerValue(iOff, iDef, rowCNT)
                Next
                dgvTE.Rows.Add(tblTE.Rows(row).Item(0), 'tblTE.Rows(row).Item(1),
                               dffPoints,
                               davgPoints,
                               tblTE.Rows(row).Item(2),
                               tblTE.Rows(row).Item(3),
                               dffDefPoints,
                               davgDefPoints,
                               CDbl(Format(dPlayerValue, "0.00")),
                               tblTE.Rows(row).Item(4),
                               tblTE.Rows(row).Item(5),
                               tblTE.Rows(row).Item(6),
                               tblTE.Rows(row).Item(7),
                               tblTE.Rows(row).Item(8),
                               tblTE.Rows(row).Item(9),
                               tblTE.Rows(row).Item(10),
                               tblTE.Rows(row).Item(11),
                               tblTE.Rows(row).Item(12),
                               tblTE.Rows(row).Item(13),
                               tblTE.Rows(row).Item(14),
                               tblTE.Rows(row).Item(15),
                               tblTE.Rows(row).Item(16),
                               tblTE.Rows(row).Item(17),
                               tblTE.Rows(row).Item(18),
                               tblTE.Rows(row).Item(19),
                               tblTE.Rows(row).Item(20),
                               tblTE.Rows(row).Item(21),
                               tblTE.Rows(row).Item(22),
                               tblTE.Rows(row).Item(23),
                               tblTE.Rows(row).Item(24),
                               tblTE.Rows(row).Item(25),
                               tblTE.Rows(row).Item(26),
                               tblTE.Rows(row).Item(27),
                               tblTE.Rows(row).Item(28),
                               tblTE.Rows(row).Item(29),
                               tblTE.Rows(row).Item(30),
                               tblTE.Rows(row).Item(31)
                                   )
                For iColor = 6 To 27
                    If IsDBNull(dgvTE.Rows(row).Cells(iColor).Value) Then iStuff = 0 Else iStuff = dgvTE.Rows(row).Cells(iColor).Value
                    cellColor = setCellColor(iStuff, dgvTE.Rows(row).Cells(iColor).OwningColumn.Name, rowCNT)
                    dgvTE.Rows(row).Cells(iColor).Style.BackColor = cellColor
                Next
            Next
        End If
    End Sub
    Private Sub analyzeWR_allSeason()
        Dim tblWR As New DataTable
        Dim row, rowCNT, iColor As Integer
        Dim cellColor As Color
        Dim dPlayerValue, dffPoints, davgPoint, dffDefPoints, davgDefPoints As Double
        Dim intGetSOS(4), iDef, iOff, iStuff As Integer

        tblWR = qryAnalyzer("WR", cCompare.compSeason, tCompare.compSeason, cCompare.compType, tCompare.compType, cCompare.compStart, tCompare.compStart, cCompare.compEnd, tCompare.compEnd)
        rowCNT = tblWR.Rows.Count
        tsAnalyzing.Text = "Analyzing: WR"
        pbAnalyzing.Value = 0
        pbAnalyzing.Minimum = 0
        pbAnalyzing.Maximum = rowCNT

        tsNumPlayers.Text = "# Players: " + rowCNT.ToString
        TabControl1.TabPages.Item(2).Text = "WR (" + rowCNT.ToString + ")"

        If rowCNT > 0 Then
            For row = 0 To rowCNT - 1
                pbAnalyzing.Value = row
                dPlayerValue = 0.0
                If IsDBNull(tblWR.Rows(row).Item(32)) Then dffPoints = 0 Else dffPoints = CDbl(Format(tblWR.Rows(row).Item(32), "0.00"))
                If IsDBNull(tblWR.Rows(row).Item(33)) Then davgPoint = 0 Else davgPoint = CDbl(Format(tblWR.Rows(row).Item(33), "0.00"))
                If IsDBNull(tblWR.Rows(row).Item(35)) Then dffDefPoints = 0 Else dffDefPoints = CDbl(Format(tblWR.Rows(row).Item(35), "0.00"))
                If IsDBNull(tblWR.Rows(row).Item(36)) Then davgDefPoints = 0 Else davgDefPoints = CDbl(Format(tblWR.Rows(row).Item(36), "0.00"))
                For iColor = 6 To 27 Step 2
                    If IsDBNull(tblWR.Rows(row).Item(iColor + 1)) Then iDef = 0 Else iDef = Int(tblWR.Rows(row).Item(iColor + 1))
                    If IsDBNull(tblWR.Rows(row).Item(iColor)) Then iOff = 0 Else iOff = Int(tblWR.Rows(row).Item(iColor))
                    dPlayerValue = dPlayerValue + calcPlayerValue(iOff, iDef, rowCNT)
                Next
                dgvWR.Rows.Add(tblWR.Rows(row).Item(0), 'tblQB.Rows(row).Item(1),
                               dffPoints,
                               davgPoint,
                               tblWR.Rows(row).Item(2),
                               tblWR.Rows(row).Item(3),
                               dffDefPoints,
                               davgDefPoints,
                               CDbl(Format(dPlayerValue, "0.00")),
                               tblWR.Rows(row).Item(4),
                               tblWR.Rows(row).Item(5),
                               tblWR.Rows(row).Item(6),
                               tblWR.Rows(row).Item(7),
                               tblWR.Rows(row).Item(8),
                               tblWR.Rows(row).Item(9),
                               tblWR.Rows(row).Item(10),
                               tblWR.Rows(row).Item(11),
                               tblWR.Rows(row).Item(12),
                               tblWR.Rows(row).Item(13),
                               tblWR.Rows(row).Item(14),
                               tblWR.Rows(row).Item(15),
                               tblWR.Rows(row).Item(16),
                               tblWR.Rows(row).Item(17),
                               tblWR.Rows(row).Item(18),
                               tblWR.Rows(row).Item(19),
                               tblWR.Rows(row).Item(20),
                               tblWR.Rows(row).Item(21),
                               tblWR.Rows(row).Item(22),
                               tblWR.Rows(row).Item(23),
                               tblWR.Rows(row).Item(24),
                               tblWR.Rows(row).Item(25),
                               tblWR.Rows(row).Item(26),
                               tblWR.Rows(row).Item(27),
                               tblWR.Rows(row).Item(28),
                               tblWR.Rows(row).Item(29),
                               tblWR.Rows(row).Item(30),
                               tblWR.Rows(row).Item(31)
                                   )
                For iColor = 6 To 27
                    If IsDBNull(dgvWR.Rows(row).Cells(iColor).Value) Then iStuff = 0 Else iStuff = dgvWR.Rows(row).Cells(iColor).Value
                    cellColor = setCellColor(iStuff, dgvWR.Rows(row).Cells(iColor).OwningColumn.Name, rowCNT)
                    dgvWR.Rows(row).Cells(iColor).Style.BackColor = cellColor
                Next
            Next
        End If
    End Sub
    Private Sub analyzeRB_allSeason()
        Dim tblRB As New DataTable
        Dim row, rowCNT, iColor As Integer
        Dim cellColor As Color
        Dim dPlayerValue, dffPoints, davgPoint, dffDefPoints, davgDefPoints As Double
        Dim intGetSOS(4), iDef, iOff, iStuff As Integer

        tblRB = qryAnalyzer("RB", cCompare.compSeason, tCompare.compSeason, cCompare.compType, tCompare.compType, cCompare.compStart, tCompare.compStart, cCompare.compEnd, tCompare.compEnd)
        rowCNT = tblRB.Rows.Count
        tsAnalyzing.Text = "Analyzing: RB"
        pbAnalyzing.Value = 0
        pbAnalyzing.Minimum = 0
        pbAnalyzing.Maximum = rowCNT

        tsNumPlayers.Text = "# Players: " + rowCNT.ToString
        TabControl1.TabPages.Item(1).Text = "RB (" + rowCNT.ToString + ")"

        If rowCNT > 0 Then
            For row = 0 To rowCNT - 1
                pbAnalyzing.Value = row
                dPlayerValue = 0.0
                If IsDBNull(tblRB.Rows(row).Item(26)) Then dffPoints = 0 Else dffPoints = CDbl(Format(tblRB.Rows(row).Item(26), "0.00"))
                If IsDBNull(tblRB.Rows(row).Item(27)) Then davgPoint = 0 Else davgPoint = CDbl(Format(tblRB.Rows(row).Item(27), "0.00"))
                If IsDBNull(tblRB.Rows(row).Item(29)) Then dffDefPoints = 0 Else dffDefPoints = CDbl(Format(tblRB.Rows(row).Item(29), "0.00"))
                If IsDBNull(tblRB.Rows(row).Item(30)) Then davgDefPoints = 0 Else davgDefPoints = CDbl(Format(tblRB.Rows(row).Item(30), "0.00"))
                For iColor = 6 To 19 Step 2
                    If IsDBNull(tblRB.Rows(row).Item(iColor + 1)) Then iDef = 0 Else iDef = Int(tblRB.Rows(row).Item(iColor + 1))
                    If IsDBNull(tblRB.Rows(row).Item(iColor)) Then iOff = 0 Else iOff = Int(tblRB.Rows(row).Item(iColor))
                    dPlayerValue = dPlayerValue + calcPlayerValue(iOff, iDef, rowCNT)
                Next
                dgvRB.Rows.Add(tblRB.Rows(row).Item(0), 'tblQB.Rows(row).Item(1),
                               dffPoints,
                               davgPoint,
                               tblRB.Rows(row).Item(2),
                               tblRB.Rows(row).Item(3),
                               dffDefPoints,
                               davgDefPoints,
                               CDbl(Format(dPlayerValue, "0.00")),
                               tblRB.Rows(row).Item(4),
                               tblRB.Rows(row).Item(5),
                               tblRB.Rows(row).Item(6),
                               tblRB.Rows(row).Item(7),
                               tblRB.Rows(row).Item(8),
                               tblRB.Rows(row).Item(9),
                               tblRB.Rows(row).Item(10),
                               tblRB.Rows(row).Item(11),
                               tblRB.Rows(row).Item(12),
                               tblRB.Rows(row).Item(13),
                               tblRB.Rows(row).Item(14),
                               tblRB.Rows(row).Item(15),
                               tblRB.Rows(row).Item(16),
                               tblRB.Rows(row).Item(17),
                               tblRB.Rows(row).Item(18),
                               tblRB.Rows(row).Item(19),
                               tblRB.Rows(row).Item(20),
                               tblRB.Rows(row).Item(21),
                               tblRB.Rows(row).Item(22),
                               tblRB.Rows(row).Item(23),
                               tblRB.Rows(row).Item(24),
                               tblRB.Rows(row).Item(25)
                                   )
                For iColor = 6 To 19
                    If IsDBNull(dgvRB.Rows(row).Cells(iColor).Value) Then iStuff = 0 Else iStuff = dgvRB.Rows(row).Cells(iColor).Value
                    cellColor = setCellColor(iStuff, dgvRB.Rows(row).Cells(iColor).OwningColumn.Name, rowCNT)
                    dgvRB.Rows(row).Cells(iColor).Style.BackColor = cellColor
                Next
            Next
        End If

    End Sub
    Private Sub analyzeQB_allSeason()
        Dim tblQB As New DataTable
        Dim row, rowCNT, col, iColor As Integer
        Dim cellColor As Color
        Dim dPlayerValue, dMyModifier, dMyPoints, decSOScalc, dffPoints, davgPoint, dffDefPoints, davgDefPoints, dProjPoints As Double
        Dim intGetSOS(4), iDef, iOff, iStuff As Integer
        Dim iQBa, iQBb, iQBc, iQBd, iQBrating As Decimal
        Dim sMyPoints As String

        tblQB = qryAnalyzer("QB", cCompare.compSeason, tCompare.compSeason, cCompare.compType, tCompare.compType, cCompare.compStart, tCompare.compStart, cCompare.compEnd, tCompare.compEnd)
        rowCNT = tblQB.Rows.Count
        tsAnalyzing.Text = "Analyzing: QB"
        pbAnalyzing.Value = 0
        pbAnalyzing.Minimum = 0
        pbAnalyzing.Maximum = rowCNT

        tsNumPlayers.Text = "# Players: " + rowCNT.ToString
        TabControl1.TabPages.Item(0).Text = "QB (" + rowCNT.ToString + ")"

        If rowCNT > 0 Then
            For row = 0 To rowCNT - 1
                pbAnalyzing.Value = row
                dPlayerValue = 0.0
                If IsDBNull(tblQB.Rows(row).Item(41)) Then dffPoints = 0 Else dffPoints = CDbl(Format(tblQB.Rows(row).Item(41), "0.00"))
                If IsDBNull(tblQB.Rows(row).Item(42)) Then davgPoint = 0 Else davgPoint = CDbl(Format(tblQB.Rows(row).Item(42), "0.00"))
                If IsDBNull(tblQB.Rows(row).Item(44)) Then dffDefPoints = 0 Else dffDefPoints = CDbl(Format(tblQB.Rows(row).Item(44), "0.00"))
                If IsDBNull(tblQB.Rows(row).Item(45)) Then davgDefPoints = 0 Else davgDefPoints = CDbl(Format(tblQB.Rows(row).Item(45), "0.00"))
                If IsDBNull(tblQB.Rows(row).Item(46)) Then dProjPoints = 0 Else dProjPoints = CDbl(Format(tblQB.Rows(row).Item(46), "0.00"))
                intGetSOS = getSOS(tblQB.Rows(row).Item(2).ToString)
                decSOScalc = intGetSOS(0) / (intGetSOS(0) + intGetSOS(1))

                If CInt(tblQB.Rows(row).Item("passingCMP").ToString) > 0 And CInt(tblQB.Rows(row).Item("passingATT").ToString) > 0 Then
                    iQBa = ((CInt(tblQB.Rows(row).Item("passingCMP").ToString)) / CInt(tblQB.Rows(row).Item("passingATT").ToString) - 0.3) * 5
                Else
                    iQBa = 0
                End If

                If CInt(tblQB.Rows(row).Item("passingYDS").ToString) > 0 And CInt(tblQB.Rows(row).Item("passingATT").ToString) Then
                    iQBb = ((CInt(tblQB.Rows(row).Item("passingYDS").ToString)) / CInt(tblQB.Rows(row).Item("passingATT").ToString) - 3) * 0.25
                Else
                    iQBb = 0
                End If

                If CInt(tblQB.Rows(row).Item("passingTDs").ToString) > 0 And CInt(tblQB.Rows(row).Item("passingATT").ToString) > 0 Then
                    iQBc = (CInt(tblQB.Rows(row).Item("passingTDs").ToString) / CInt(tblQB.Rows(row).Item("passingATT").ToString)) * 20
                Else
                    iQBc = 0
                End If

                If CInt(tblQB.Rows(row).Item("passingINT").ToString) > 0 And CInt(tblQB.Rows(row).Item("passingATT").ToString) > 0 Then
                    iQBd = 2.375 - (((CInt(tblQB.Rows(row).Item("passingINT").ToString)) / CInt(tblQB.Rows(row).Item("passingATT").ToString)) * 25)
                Else
                    iQBd = 0
                End If

                iQBrating = ((iQBa + iQBb + iQBc + iQBd) / 6) * 100

                For iColor = 14 To 38 Step 2
                    If IsDBNull(tblQB.Rows(row).Item(iColor + 1)) Then iDef = 0 Else iDef = Int(tblQB.Rows(row).Item(iColor + 1))
                    If IsDBNull(tblQB.Rows(row).Item(iColor)) Then iOff = 0 Else iOff = Int(tblQB.Rows(row).Item(iColor))
                    dPlayerValue = dPlayerValue + calcPlayerValue(iOff, iDef, rowCNT)
                Next

                If IsDBNull(tblQB.Rows(row).Item(50)) Then
                    dMyModifier = 0 + dPlayerValue
                Else
                    dMyModifier = Int(tblQB.Rows(row).Item(50)) + dPlayerValue
                End If

                If IsDBNull(tblQB.Rows(row).Item(47)) Then
                    sMyPoints = "0"
                Else
                    sMyPoints = tblQB.Rows(row).Item(47).ToString.Replace("$", "").Replace(",", "")
                End If

                dMyPoints = (dMyModifier / 1000) * CDbl(sMyPoints)

                dgvQB.Rows.Add(tblQB.Rows(row).Item(0), 'tblQB.Rows(row).Item(1),
                               tblQB.Rows(row).Item(2),
                               dProjPoints,
                               tblQB.Rows(row).Item(47),
                               tblQB.Rows(row).Item(50),
                               CDbl(Format(iQBrating, "0.00")),
                               dffPoints,
                               davgPoint,
                               tblQB.Rows(row).Item(48),
                               tblQB.Rows(row).Item(49),
                               tblQB.Rows(row).Item(51),
                               tblQB.Rows(row).Item(3),
                               dffDefPoints,
                               davgDefPoints,
                               CDbl(Format(decSOScalc, "0.00")),
                               CDbl(Format(dPlayerValue, "0.00")),
                               CDbl(Format(dMyModifier, "0.00")),
                               CDbl(Format(dMyPoints, "0.00")),
                               tblQB.Rows(row).Item(4),
                               tblQB.Rows(row).Item(5),
                               tblQB.Rows(row).Item(6),
                               tblQB.Rows(row).Item(7),
                               tblQB.Rows(row).Item(8),
                               tblQB.Rows(row).Item(9),
                               tblQB.Rows(row).Item(10),
                               tblQB.Rows(row).Item(11),
                               tblQB.Rows(row).Item(12),
                               tblQB.Rows(row).Item(13),
                               tblQB.Rows(row).Item(14),
                               tblQB.Rows(row).Item(15),
                               tblQB.Rows(row).Item(16),
                               tblQB.Rows(row).Item(17),
                               tblQB.Rows(row).Item(18),
                               tblQB.Rows(row).Item(19),
                               tblQB.Rows(row).Item(20),
                               tblQB.Rows(row).Item(21),
                               tblQB.Rows(row).Item(22),
                               tblQB.Rows(row).Item(23),
                               tblQB.Rows(row).Item(24),
                               tblQB.Rows(row).Item(25),
                               tblQB.Rows(row).Item(26),
                               tblQB.Rows(row).Item(27),
                               tblQB.Rows(row).Item(28),
                               tblQB.Rows(row).Item(29),
                               tblQB.Rows(row).Item(30), '
                               tblQB.Rows(row).Item(31),
                               tblQB.Rows(row).Item(32),
                               tblQB.Rows(row).Item(33),
                               tblQB.Rows(row).Item(34),
                               tblQB.Rows(row).Item(40)
                                   )
                For iColor = 18 To 44
                    If IsDBNull(dgvQB.Rows(row).Cells(iColor).Value) Then iStuff = 0 Else iStuff = dgvQB.Rows(row).Cells(iColor).Value
                    cellColor = setCellColor(iStuff, dgvQB.Rows(row).Cells(iColor).OwningColumn.Name, rowCNT)
                    dgvQB.Rows(row).Cells(iColor).Style.BackColor = cellColor
                Next


                'calculate value

            Next
        End If

    End Sub

    Private Sub dgvQBset()
        dgvQB.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvQB.EnableHeadersVisualStyles = False
        dgvQB.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        dgvQB.Columns.Add("player", "Player")
        dgvQB.Columns.Item(0).Width = 100
        dgvQB.Columns(0).Frozen = True
        'dgvQB.Columns.Add("position", "Position")
        dgvQB.Columns.Add("team", "Team")
        dgvQB.Columns.Add("pyprjpt", "Projected Points")
        dgvQB.Columns.Add("pyplysal", "Player Salary")
        dgvQB.Columns.Add("pyplyval", "Projected Value")
        dgvQB.Columns.Add("pyqbrate", "Player QB Rating")
        dgvQB.Columns.Add("pyffpoints", "Tot Fantasy Points")
        dgvQB.Columns.Add("pyffavgpts", "Avg Fantasy Points")
        dgvQB.Columns.Add("tmspread", "Spread")
        dgvQB.Columns.Add("tmovund", "Over Under")
        dgvQB.Columns.Add("tmhomawy", "Player Home/Away")
        dgvQB.Columns.Add("nextopp", "Next Opponent")
        dgvQB.Columns.Add("opppoin", "Next Opp Points")
        dgvQB.Columns.Add("oppavgp", "Next Avg Points")
        dgvQB.Columns.Add("pysos", "Player SOS")
        dgvQB.Columns.Add("pyvalue", "My Value")
        dgvQB.Columns.Add("pymodify", "My Modifier")
        dgvQB.Columns.Add("pymypoint", "My Points")
        dgvQB.Columns.Add("plrankyd", "Player Pass Yard")
        dgvQB.Columns.Add("dfrankyd", "Defense Pass Yard")
        dgvQB.Columns.Add("plrankcmp", "Player Pass Cmp")
        dgvQB.Columns.Add("dfrankcmp", "Defense  Pass Cmp")
        dgvQB.Columns.Add("plranktds", "Player Pass TDs")
        dgvQB.Columns.Add("dfranktds", "Defense Pass TDs")
        dgvQB.Columns.Add("plrankint", "Player Pass INT")
        dgvQB.Columns.Add("dfrankint", "Defense Pass INT")
        dgvQB.Columns.Add("plrushyds", "Player Rush Yards")
        dgvQB.Columns.Add("dfrushyds", "Defense Rush Yards")
        dgvQB.Columns.Add("plrushtds", "Player Rushing TDs")
        dgvQB.Columns.Add("dfrushtds", "Defense Rushing TDs")
        dgvQB.Columns.Add("plrankatt", "Player Pass Att")
        dgvQB.Columns.Add("dfrankatt", "Defense Pass Att")
        dgvQB.Columns.Add("plranku15", "Player Pass Under15")
        dgvQB.Columns.Add("dfranku15", "Defense Pass Under15")
        dgvQB.Columns.Add("plrankmidq", "Player Pass Mid")
        dgvQB.Columns.Add("dfrankmidq", "Defense Pass Mid")
        dgvQB.Columns.Add("plranko25", "Player Pass Over25")
        dgvQB.Columns.Add("dfranko25", "Defense Pass Over25")
        dgvQB.Columns.Add("plranksak", "Player Pass Sack")
        dgvQB.Columns.Add("dfranksak", "Defense Pass Sack")
        dgvQB.Columns.Add("plfumbtot", "Player Fumbles Total")
        dgvQB.Columns.Add("dffumbtot", "Defense Fumbles Total")
        dgvQB.Columns.Add("plfumblst", "Player Fumbles Lost")
        dgvQB.Columns.Add("dffumblst", "Defense Fumbles Lost")
        dgvQB.Columns.Add("tmpntsfor", "Team Points For")
        dgvQB.Columns.Add("tmpntsagt", "Team Points Against")
        dgvQB.Columns.Add("tmrecdwin", "Team Record Wins")
        dgvQB.Columns.Add("tmrecdlst", "Team Record Loses")
        dgvQB.Columns.Add("tmrecdtie", "Team Record Ties")
        dgvQB.Columns.Add("pygmsplayq", "Player Games Played")

        For i = 1 To 45
            dgvQB.Columns.Item(i).Width = 60
        Next
    End Sub

    Private Sub dgvRBset()
        dgvRB.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvRB.EnableHeadersVisualStyles = False
        dgvRB.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        dgvRB.Columns.Add("player", "Player")
        dgvRB.Columns.Item(0).Width = 100
        dgvRB.Columns(0).Frozen = True
        'dgvRB.Columns.Add("position", "Position")
        dgvRB.Columns.Add("pyprjpt", "Projected Points")
        dgvRB.Columns.Add("pyplysal", "Player Salary")
        dgvRB.Columns.Add("tmspread", "Spread")
        dgvRB.Columns.Add("tmovund", "Over Under")
        dgvRB.Columns.Add("pyffpoints", "Tot Fantasy Points")
        dgvRB.Columns.Add("pyffavgpts", "Avg Fantasy Points")
        dgvRB.Columns.Add("team", "Team")
        dgvRB.Columns.Add("nextopp", "Next Opponent")
        dgvRB.Columns.Add("opppoin", "Next Opp Points")
        dgvRB.Columns.Add("oppavgp", "Next Avg Points")
        dgvRB.Columns.Add("pyvalue", "Player Value")
        dgvRB.Columns.Add("plrushatt", "Player Rushing Att")
        dgvRB.Columns.Add("dfrushatt", "Defense Rushing Att")
        dgvRB.Columns.Add("plrushyds", "Player Rush Yards")
        dgvRB.Columns.Add("dfrushyds", "Defense Rush Yards")
        dgvRB.Columns.Add("plrushtds", "Player Rushing TDs")
        dgvRB.Columns.Add("dfrushtds", "Defense Rushing TDs")
        dgvRB.Columns.Add("plranku15", "Player Rush Under10")
        dgvRB.Columns.Add("dfranku15", "Defense Rush Under10")
        dgvRB.Columns.Add("plrankmidr", "Player Rush Mid")
        dgvRB.Columns.Add("dfrankmidr", "Defense Rush Mid")
        dgvRB.Columns.Add("plranko25", "Player Rush Over20")
        dgvRB.Columns.Add("dfranko25", "Defense Rush Over20")
        dgvRB.Columns.Add("plfumbtot", "Player Fumbles Total")
        dgvRB.Columns.Add("dffumbtot", "Defense Fumbles Total")
        dgvRB.Columns.Add("plfumblst", "Player Fumbles Lost")
        dgvRB.Columns.Add("dffumblst", "Defense Fumbles Lost")
        dgvRB.Columns.Add("tmpntsfor", "Team Points For")
        dgvRB.Columns.Add("tmpntsagt", "Team Points Against")
        dgvRB.Columns.Add("tmrecdwin", "Team Record Wins")
        dgvRB.Columns.Add("tmrecdlst", "Team Record Loses")
        dgvRB.Columns.Add("tmrecdtie", "Team Record Ties")
        dgvRB.Columns.Add("pygmsplayr", "Player Games Played")

        For i = 1 To 33
            dgvRB.Columns.Item(i).Width = 60
        Next
    End Sub

    Private Sub dgvTEset()
        dgvTE.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvTE.EnableHeadersVisualStyles = False
        dgvTE.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        dgvTE.Columns.Add("playerw", "Player")
        dgvTE.Columns.Item(0).Width = 100
        dgvTE.Columns(0).Frozen = True
        'dgvTE.Columns.Add("position", "Position")
        dgvTE.Columns.Add("pyprjpt", "Projected Points")
        dgvTE.Columns.Add("pyplysal", "Player Salary")
        dgvTE.Columns.Add("tmspread", "Spread")
        dgvTE.Columns.Add("tmovund", "Over Under")
        dgvTE.Columns.Add("pyffpoints", "Tot Fantasy Points")
        dgvTE.Columns.Add("pyffavgpts", "Avg Fantasy Points")
        dgvTE.Columns.Add("teamw", "Team")
        dgvTE.Columns.Add("nextoppw", "Next Opponent")
        dgvTE.Columns.Add("opppoin", "Next Opp Points")
        dgvTE.Columns.Add("oppavgp", "Next Avg Points")
        dgvTE.Columns.Add("pyvaluew", "Player Value")
        dgvTE.Columns.Add("plrushattw", "Player Reception Targets")
        dgvTE.Columns.Add("dfrushattw", "Defense Reception Targets")
        dgvTE.Columns.Add("plreccmpw", "Player Receptions")
        dgvTE.Columns.Add("dfreccmpw", "Defense Receptions")
        dgvTE.Columns.Add("plrectdsw", "Player Reception TDs")
        dgvTE.Columns.Add("dfrectdsw", "Defense Reception TDs")
        dgvTE.Columns.Add("plrecydsw", "Player Reception Yards")
        dgvTE.Columns.Add("dfrecydsw", "Defense Reception Yards")
        dgvTE.Columns.Add("plrecu15w", "Player Reception Under10")
        dgvTE.Columns.Add("dfrecu15w", "Defense Reception Under10")
        dgvTE.Columns.Add("plrecmidrw", "Player Reception Mid")
        dgvTE.Columns.Add("dfrecmidrw", "Defense Reception Mid")
        dgvTE.Columns.Add("plreco25w", "Player Reception Over20")
        dgvTE.Columns.Add("dfreco25w", "Defense Reception Over20")
        dgvTE.Columns.Add("plyacydsw", "Player YAC Yards")
        dgvTE.Columns.Add("dfyacydsw", "Defense YAC Yards")
        dgvTE.Columns.Add("plyacu10w", "Player YAC Under10")
        dgvTE.Columns.Add("dfyacu10w", "Defense YAC Under10")
        dgvTE.Columns.Add("plyacmidw", "Player YAC Mid")
        dgvTE.Columns.Add("dfyacmidw", "Defense YAC Mid")
        dgvTE.Columns.Add("plyaco20w", "Player YAC Over20")
        dgvTE.Columns.Add("dfyaco20w", "Defense YAC Over20")
        dgvTE.Columns.Add("plfumbtotw", "Player Fumbles Total")
        dgvTE.Columns.Add("dffumbtotw", "Defense Fumbles Total")
        dgvTE.Columns.Add("plfumblstw", "Player Fumbles Lost")
        dgvTE.Columns.Add("dffumblstw", "Defense Fumbles Lost")
        dgvTE.Columns.Add("tmpntsforw", "Team Points For")
        dgvTE.Columns.Add("tmpntsagtw", "Team Points Against")
        dgvTE.Columns.Add("tmrecdwinw", "Team Record Wins")
        dgvTE.Columns.Add("tmrecdlstw", "Team Record Loses")
        dgvTE.Columns.Add("tmrecdtiew", "Team Record Ties")
        dgvTE.Columns.Add("pygmsplayt", "Player Games Played")

        For i = 1 To 39
            dgvTE.Columns.Item(i).Width = 60
        Next
    End Sub

    Private Sub dgvWRset()
        dgvWR.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvWR.EnableHeadersVisualStyles = False
        dgvWR.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        dgvWR.Columns.Add("playerw", "Player")
        dgvWR.Columns.Item(0).Width = 100
        dgvWR.Columns(0).Frozen = True
        'dgvWR.Columns.Add("position", "Position")
        dgvWR.Columns.Add("pyprjpt", "Projected Points")
        dgvWR.Columns.Add("pyplysal", "Player Salary")
        dgvWR.Columns.Add("tmspread", "Spread")
        dgvWR.Columns.Add("tmovund", "Over Under")
        dgvWR.Columns.Add("pyffpoints", "Tot Fantasy Points")
        dgvWR.Columns.Add("pyffavgpts", "Avg Fantasy Points")
        dgvWR.Columns.Add("teamw", "Team")
        dgvWR.Columns.Add("nextoppw", "Next Opponent")
        dgvWR.Columns.Add("opppoin", "Next Opp Points")
        dgvWR.Columns.Add("oppavgp", "Next Avg Points")
        dgvWR.Columns.Add("pyvaluew", "Player Value")
        dgvWR.Columns.Add("plrushattw", "Player Reception Targets")
        dgvWR.Columns.Add("dfrushattw", "Defense Reception Targets")
        dgvWR.Columns.Add("plreccmpw", "Player Receptions")
        dgvWR.Columns.Add("dfreccmpw", "Defense Receptions")
        dgvWR.Columns.Add("plrectdsw", "Player Reception TDs")
        dgvWR.Columns.Add("dfrectdsw", "Defense Reception TDs")
        dgvWR.Columns.Add("plrecydsw", "Player Reception Yards")
        dgvWR.Columns.Add("dfrecydsw", "Defense Reception Yards")
        dgvWR.Columns.Add("plrecu15w", "Player Reception Under10")
        dgvWR.Columns.Add("dfrecu15w", "Defense Reception Under10")
        dgvWR.Columns.Add("plrecmidrw", "Player Reception Mid")
        dgvWR.Columns.Add("dfrecmidrw", "Defense Reception Mid")
        dgvWR.Columns.Add("plreco25w", "Player Reception Over20")
        dgvWR.Columns.Add("dfreco25w", "Defense Reception Over20")
        dgvWR.Columns.Add("plyacydsw", "Player YAC Yards")
        dgvWR.Columns.Add("dfyacydsw", "Defense YAC Yards")
        dgvWR.Columns.Add("plyacu10w", "Player YAC Under10")
        dgvWR.Columns.Add("dfyacu10w", "Defense YAC Under10")
        dgvWR.Columns.Add("plyacmidw", "Player YAC Mid")
        dgvWR.Columns.Add("dfyacmidw", "Defense YAC Mid")
        dgvWR.Columns.Add("plyaco20w", "Player YAC Over20")
        dgvWR.Columns.Add("dfyaco20w", "Defense YAC Over20")
        dgvWR.Columns.Add("plfumbtotw", "Player Fumbles Total")
        dgvWR.Columns.Add("dffumbtotw", "Defense Fumbles Total")
        dgvWR.Columns.Add("plfumblstw", "Player Fumbles Lost")
        dgvWR.Columns.Add("dffumblstw", "Defense Fumbles Lost")
        dgvWR.Columns.Add("tmpntsforw", "Team Points For")
        dgvWR.Columns.Add("tmpntsagtw", "Team Points Against")
        dgvWR.Columns.Add("tmrecdwinw", "Team Record Wins")
        dgvWR.Columns.Add("tmrecdlstw", "Team Record Loses")
        dgvWR.Columns.Add("tmrecdtiew", "Team Record Ties")
        dgvWR.Columns.Add("pygmsplayw", "Player Games Played")

        For i = 1 To 39
            dgvWR.Columns.Item(i).Width = 60
        Next
    End Sub

    Private Function setCellColor(ByVal sRank As String, sOffDef As String, ByVal iRowCount As Integer) As Color
        Dim iRank As Integer
        Dim dRank As Double
        Dim iDefRank As Integer
        Dim cColor As Color

        iRank = Int(sRank)
        'iDefRank = Int(sDefRank)
        If Mid(sOffDef, 1, 2) = "df" Then
            If iRank <= 5 Then
                cColor = Color.Green
            ElseIf iRank > 5 And iRank <= 10 Then
                cColor = Color.GreenYellow
            ElseIf iRank >= 20 And iRank < 25 Then
                cColor = Color.LightPink
            ElseIf iRank >= 25 Then
                cColor = Color.Red
            Else
                cColor = Color.White
            End If
        ElseIf Mid(sOffDef, 1, 2) = "pl" Then
            dRank = ((iRowCount + 1) - sRank) / iRowCount
            If dRank >= 0.9 Then
                cColor = Color.Green
            ElseIf dRank >= 0.8 And dRank < 0.9 Then
                cColor = Color.GreenYellow
            ElseIf dRank >= 0.1 And dRank < 0.2 Then
                cColor = Color.LightPink
            ElseIf dRank <= 0.1 Then
                cColor = Color.Red
            Else
                cColor = Color.White
            End If
        End If

        Return cColor
    End Function

    Private Function calcPlayerValue(ByVal iPlayerRank As Integer, ByVal iDefenseRank As Integer, ByVal iRowCount As Integer) As Double
        Dim dPlayerValue, dDefenseValue, dCombValue As Double

        dPlayerValue = ((iRowCount + 1) - iPlayerRank) / iRowCount
        dDefenseValue = (33 - iDefenseRank) / 32
        dCombValue = dPlayerValue - dDefenseValue

        'If dPlayerValue > dDefenseValue Then
        'dCombValue = dPlayerValue + dDefenseValue
        'Else
        'dCombValue = dPlayerValue - dDefenseValue
        'End If

        Return dCombValue
    End Function
End Class
