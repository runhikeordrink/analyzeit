<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnalyzer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsLabelMeta = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsAnalyzing = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbAnalyzing = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsNumPlayers = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabQB = New System.Windows.Forms.TabPage()
        Me.dgvQB = New System.Windows.Forms.DataGridView()
        Me.tabRB = New System.Windows.Forms.TabPage()
        Me.dgvRB = New System.Windows.Forms.DataGridView()
        Me.tabWR = New System.Windows.Forms.TabPage()
        Me.dgvWR = New System.Windows.Forms.DataGridView()
        Me.tabTE = New System.Windows.Forms.TabPage()
        Me.dgvTE = New System.Windows.Forms.DataGridView()
        Me.tabDEF = New System.Windows.Forms.TabPage()
        Me.dgvDEF = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvStandings = New System.Windows.Forms.DataGridView()
        Me.sTeam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sStandings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbEndComp = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbStartComp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTypeComp = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSeasonComp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbEndTo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbStartTo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTypeTo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSeasonTo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.cmbStandings = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabQB.SuspendLayout()
        CType(Me.dgvQB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRB.SuspendLayout()
        CType(Me.dgvRB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWR.SuspendLayout()
        CType(Me.dgvWR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTE.SuspendLayout()
        CType(Me.dgvTE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDEF.SuspendLayout()
        CType(Me.dgvDEF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvStandings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLabelMeta, Me.ToolStripStatusLabel2, Me.tsAnalyzing, Me.pbAnalyzing, Me.tsNumPlayers})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 920)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1846, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsLabelMeta
        '
        Me.tsLabelMeta.Name = "tsLabelMeta"
        Me.tsLabelMeta.Size = New System.Drawing.Size(47, 17)
        Me.tsLabelMeta.Text = "Season:"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = " "
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsAnalyzing
        '
        Me.tsAnalyzing.Name = "tsAnalyzing"
        Me.tsAnalyzing.Size = New System.Drawing.Size(79, 17)
        Me.tsAnalyzing.Text = "Analyzing: XX"
        Me.tsAnalyzing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbAnalyzing
        '
        Me.pbAnalyzing.Name = "pbAnalyzing"
        Me.pbAnalyzing.Size = New System.Drawing.Size(200, 16)
        Me.pbAnalyzing.Step = 1
        '
        'tsNumPlayers
        '
        Me.tsNumPlayers.Name = "tsNumPlayers"
        Me.tsNumPlayers.Size = New System.Drawing.Size(71, 17)
        Me.tsNumPlayers.Text = "Players: XXX"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.tabQB)
        Me.TabControl1.Controls.Add(Me.tabRB)
        Me.TabControl1.Controls.Add(Me.tabWR)
        Me.TabControl1.Controls.Add(Me.tabTE)
        Me.TabControl1.Controls.Add(Me.tabDEF)
        Me.TabControl1.Location = New System.Drawing.Point(12, 87)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1638, 830)
        Me.TabControl1.TabIndex = 1
        '
        'tabQB
        '
        Me.tabQB.Controls.Add(Me.dgvQB)
        Me.tabQB.Location = New System.Drawing.Point(4, 4)
        Me.tabQB.Name = "tabQB"
        Me.tabQB.Padding = New System.Windows.Forms.Padding(3)
        Me.tabQB.Size = New System.Drawing.Size(1630, 804)
        Me.tabQB.TabIndex = 0
        Me.tabQB.Text = "QB"
        Me.tabQB.UseVisualStyleBackColor = True
        '
        'dgvQB
        '
        Me.dgvQB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQB.Location = New System.Drawing.Point(0, 0)
        Me.dgvQB.Name = "dgvQB"
        Me.dgvQB.RowHeadersVisible = False
        Me.dgvQB.Size = New System.Drawing.Size(1630, 804)
        Me.dgvQB.TabIndex = 0
        '
        'tabRB
        '
        Me.tabRB.Controls.Add(Me.dgvRB)
        Me.tabRB.Location = New System.Drawing.Point(4, 4)
        Me.tabRB.Name = "tabRB"
        Me.tabRB.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRB.Size = New System.Drawing.Size(1630, 804)
        Me.tabRB.TabIndex = 1
        Me.tabRB.Text = "RB"
        Me.tabRB.UseVisualStyleBackColor = True
        '
        'dgvRB
        '
        Me.dgvRB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRB.Location = New System.Drawing.Point(0, 0)
        Me.dgvRB.Name = "dgvRB"
        Me.dgvRB.Size = New System.Drawing.Size(1630, 804)
        Me.dgvRB.TabIndex = 0
        '
        'tabWR
        '
        Me.tabWR.Controls.Add(Me.dgvWR)
        Me.tabWR.Location = New System.Drawing.Point(4, 4)
        Me.tabWR.Name = "tabWR"
        Me.tabWR.Size = New System.Drawing.Size(1630, 804)
        Me.tabWR.TabIndex = 2
        Me.tabWR.Text = "WR"
        Me.tabWR.UseVisualStyleBackColor = True
        '
        'dgvWR
        '
        Me.dgvWR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWR.Location = New System.Drawing.Point(0, 3)
        Me.dgvWR.Name = "dgvWR"
        Me.dgvWR.Size = New System.Drawing.Size(1630, 801)
        Me.dgvWR.TabIndex = 0
        '
        'tabTE
        '
        Me.tabTE.Controls.Add(Me.dgvTE)
        Me.tabTE.Location = New System.Drawing.Point(4, 4)
        Me.tabTE.Name = "tabTE"
        Me.tabTE.Size = New System.Drawing.Size(1630, 804)
        Me.tabTE.TabIndex = 3
        Me.tabTE.Text = "TE"
        Me.tabTE.UseVisualStyleBackColor = True
        '
        'dgvTE
        '
        Me.dgvTE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTE.Location = New System.Drawing.Point(0, 0)
        Me.dgvTE.Name = "dgvTE"
        Me.dgvTE.Size = New System.Drawing.Size(1634, 804)
        Me.dgvTE.TabIndex = 0
        '
        'tabDEF
        '
        Me.tabDEF.Controls.Add(Me.dgvDEF)
        Me.tabDEF.Location = New System.Drawing.Point(4, 4)
        Me.tabDEF.Name = "tabDEF"
        Me.tabDEF.Size = New System.Drawing.Size(1630, 804)
        Me.tabDEF.TabIndex = 4
        Me.tabDEF.Text = "DEF"
        Me.tabDEF.UseVisualStyleBackColor = True
        '
        'dgvDEF
        '
        Me.dgvDEF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDEF.Location = New System.Drawing.Point(0, 0)
        Me.dgvDEF.Name = "dgvDEF"
        Me.dgvDEF.Size = New System.Drawing.Size(1310, 536)
        Me.dgvDEF.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvStandings)
        Me.GroupBox1.Location = New System.Drawing.Point(1656, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(181, 797)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Standings"
        '
        'dgvStandings
        '
        Me.dgvStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStandings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sTeam, Me.sStandings})
        Me.dgvStandings.Location = New System.Drawing.Point(6, 19)
        Me.dgvStandings.Name = "dgvStandings"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStandings.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvStandings.RowHeadersVisible = False
        Me.dgvStandings.Size = New System.Drawing.Size(169, 757)
        Me.dgvStandings.TabIndex = 0
        '
        'sTeam
        '
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sTeam.DefaultCellStyle = DataGridViewCellStyle16
        Me.sTeam.HeaderText = "Team"
        Me.sTeam.Name = "sTeam"
        Me.sTeam.Width = 70
        '
        'sStandings
        '
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sStandings.DefaultCellStyle = DataGridViewCellStyle17
        Me.sStandings.HeaderText = "Standings"
        Me.sStandings.Name = "sStandings"
        Me.sStandings.Width = 95
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbEndComp)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbStartComp)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmbTypeComp)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbSeasonComp)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 51)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Compare/Upcoming"
        '
        'cmbEndComp
        '
        Me.cmbEndComp.FormattingEnabled = True
        Me.cmbEndComp.Items.AddRange(New Object() {"17", "16", "15", "14", "13", "12", "11", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1"})
        Me.cmbEndComp.Location = New System.Drawing.Point(456, 20)
        Me.cmbEndComp.Name = "cmbEndComp"
        Me.cmbEndComp.Size = New System.Drawing.Size(69, 21)
        Me.cmbEndComp.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(392, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Week End"
        '
        'cmbStartComp
        '
        Me.cmbStartComp.FormattingEnabled = True
        Me.cmbStartComp.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17"})
        Me.cmbStartComp.Location = New System.Drawing.Point(317, 19)
        Me.cmbStartComp.Name = "cmbStartComp"
        Me.cmbStartComp.Size = New System.Drawing.Size(69, 21)
        Me.cmbStartComp.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Week Start"
        '
        'cmbTypeComp
        '
        Me.cmbTypeComp.FormattingEnabled = True
        Me.cmbTypeComp.Items.AddRange(New Object() {"Preseason", "Regular"})
        Me.cmbTypeComp.Location = New System.Drawing.Point(175, 20)
        Me.cmbTypeComp.Name = "cmbTypeComp"
        Me.cmbTypeComp.Size = New System.Drawing.Size(69, 21)
        Me.cmbTypeComp.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type"
        '
        'cmbSeasonComp
        '
        Me.cmbSeasonComp.FormattingEnabled = True
        Me.cmbSeasonComp.Items.AddRange(New Object() {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009"})
        Me.cmbSeasonComp.Location = New System.Drawing.Point(63, 19)
        Me.cmbSeasonComp.Name = "cmbSeasonComp"
        Me.cmbSeasonComp.Size = New System.Drawing.Size(69, 21)
        Me.cmbSeasonComp.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Season"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbEndTo)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbStartTo)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cmbTypeTo)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmbSeasonTo)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(583, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(544, 51)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Compare To"
        '
        'cmbEndTo
        '
        Me.cmbEndTo.FormattingEnabled = True
        Me.cmbEndTo.Location = New System.Drawing.Point(456, 20)
        Me.cmbEndTo.Name = "cmbEndTo"
        Me.cmbEndTo.Size = New System.Drawing.Size(69, 21)
        Me.cmbEndTo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(392, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Week End"
        '
        'cmbStartTo
        '
        Me.cmbStartTo.FormattingEnabled = True
        Me.cmbStartTo.Location = New System.Drawing.Point(317, 19)
        Me.cmbStartTo.Name = "cmbStartTo"
        Me.cmbStartTo.Size = New System.Drawing.Size(69, 21)
        Me.cmbStartTo.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(250, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Week Start"
        '
        'cmbTypeTo
        '
        Me.cmbTypeTo.FormattingEnabled = True
        Me.cmbTypeTo.Location = New System.Drawing.Point(175, 20)
        Me.cmbTypeTo.Name = "cmbTypeTo"
        Me.cmbTypeTo.Size = New System.Drawing.Size(69, 21)
        Me.cmbTypeTo.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Type"
        '
        'cmbSeasonTo
        '
        Me.cmbSeasonTo.FormattingEnabled = True
        Me.cmbSeasonTo.Location = New System.Drawing.Point(63, 19)
        Me.cmbSeasonTo.Name = "cmbSeasonTo"
        Me.cmbSeasonTo.Size = New System.Drawing.Size(69, 21)
        Me.cmbSeasonTo.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Season"
        '
        'btnCompare
        '
        Me.btnCompare.Location = New System.Drawing.Point(1153, 48)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(75, 23)
        Me.btnCompare.TabIndex = 9
        Me.btnCompare.Text = "Compare"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'cmbStandings
        '
        Me.cmbStandings.FormattingEnabled = True
        Me.cmbStandings.Items.AddRange(New Object() {"Preseason", "Regular"})
        Me.cmbStandings.Location = New System.Drawing.Point(1687, 60)
        Me.cmbStandings.Name = "cmbStandings"
        Me.cmbStandings.Size = New System.Drawing.Size(121, 21)
        Me.cmbStandings.TabIndex = 10
        '
        'frmAnalyzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(1846, 942)
        Me.Controls.Add(Me.cmbStandings)
        Me.Controls.Add(Me.btnCompare)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmAnalyzer"
        Me.Text = "Player Analyzer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabQB.ResumeLayout(False)
        CType(Me.dgvQB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRB.ResumeLayout(False)
        CType(Me.dgvRB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWR.ResumeLayout(False)
        CType(Me.dgvWR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTE.ResumeLayout(False)
        CType(Me.dgvTE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDEF.ResumeLayout(False)
        CType(Me.dgvDEF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvStandings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsAnalyzing As ToolStripStatusLabel
    Friend WithEvents pbAnalyzing As ToolStripProgressBar
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabQB As TabPage
    Friend WithEvents tabRB As TabPage
    Friend WithEvents tabWR As TabPage
    Friend WithEvents tabTE As TabPage
    Friend WithEvents tabDEF As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbEndComp As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbStartComp As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTypeComp As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSeasonComp As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbEndTo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbStartTo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbTypeTo As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSeasonTo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnCompare As Button
    Friend WithEvents dgvStandings As DataGridView
    Friend WithEvents tsLabelMeta As ToolStripStatusLabel
    Friend WithEvents cmbStandings As ComboBox
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents dgvQB As DataGridView
    Friend WithEvents dgvRB As DataGridView
    Friend WithEvents dgvWR As DataGridView
    Friend WithEvents dgvTE As DataGridView
    Friend WithEvents dgvDEF As DataGridView
    Friend WithEvents sTeam As DataGridViewTextBoxColumn
    Friend WithEvents sStandings As DataGridViewTextBoxColumn
    Friend WithEvents tsNumPlayers As ToolStripStatusLabel
End Class
