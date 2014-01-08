Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.Regex
Imports System.Configuration
Imports System.ComponentModel

Public Class ClassFunctions
    Dim ctrlNames(500) As String
    Dim ctrlCnt As Integer


    Public g_StrConnectionString As String = Nothing
    Public g_DataBaseName As String = Nothing
    Public g_username As String = ""
    Public g_UserCode As String = ""
    Public g_CompanyCode As String = ""
    Public Const g_StrTitle As String = "ClearFunds.com"
    Public g_StartDate As Date
    Public g_Enddate As Date
    Public g_userid As Integer
    Public Add_Flag As Boolean = True
    Public View_Flag As Boolean
    Public Modify_Flag As Boolean
    Public Delete_Flag As Boolean
    Public Print_Flag As Boolean
    Public g_Mode As String = ""
    Public frmCalledby As String = ""
    Public globalFontName As String = "Arial"
    Public BConn As Boolean
    Public g_access As Boolean
    Public g_series As String
    Public DtPrinter As New DataTable
    Public loginid As String
    Public g_FinacYear As String
    Public strMode As String = ""
    Public Function ConnectionString() As String
        Dim sqlConnection As String = ""
        'Dim serverName As String = System.Configuration.ConfigurationManager.AppSettings("ServerName")
        'Dim dbName As String = System.Configuration.ConfigurationManager.AppSettings("DBName")
        'Dim Authentication As String = System.Configuration.ConfigurationManager.AppSettings("Authentication")
        'Dim UserName As String = System.Configuration.ConfigurationManager.AppSettings("UserName")
        'Dim Password As String = System.Configuration.ConfigurationManager.AppSettings("Password")
        'If UCase(Authentication) = "WINDOWS" Then
        '    sqlConnection = "Data source=" & serverName & ";"
        '    sqlConnection = sqlConnection & "Initial Catalog=" & dbName & ";"
        '    sqlConnection = sqlConnection & "Integrated security = true;Connect timeout=200;Max Pool Size=200;Pooling=True"
        'ElseIf UCase(Authentication) = "SQL" Then
        '    sqlConnection = "Data source=" & serverName & ";"
        '    sqlConnection = sqlConnection & "Initial Catalog=" & dbName & ";"
        '    sqlConnection = sqlConnection & "User ID=" & UserName & ";"
        '    sqlConnection = sqlConnection & "Password=" & Password & ";"
        'Else
        '    MsgBox("Please Provide Connection String or else Contact Your System Administration.")
        'End If
        sqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings("ApplicationServices").ToString
        Return sqlConnection
    End Function

    Public Function G_AccountsConnectionString() As String
        Dim sqlConnection As String = ""
        Dim serverName As String = System.Configuration.ConfigurationManager.AppSettings("ServerName")
        Dim dbName As String = System.Configuration.ConfigurationManager.AppSettings("DBName1")
        Dim Authentication As String = System.Configuration.ConfigurationManager.AppSettings("Authentication")
        Dim UserName As String = System.Configuration.ConfigurationManager.AppSettings("UserName")
        Dim Password As String = System.Configuration.ConfigurationManager.AppSettings("Password")
        If UCase(Authentication) = "WINDOWS" Then
            sqlConnection = "Data source=" & serverName & ";"
            sqlConnection = sqlConnection & "Initial Catalog=" & dbName & ";"
            sqlConnection = sqlConnection & "Integrated security = true;Connect timeout=200;Max Pool Size=200;Pooling=True"
        ElseIf UCase(Authentication) = "SQL" Then
            sqlConnection = "Data source=" & serverName & ";"
            sqlConnection = sqlConnection & "Initial Catalog=" & dbName & ";"
            sqlConnection = sqlConnection & "User ID=" & UserName & ";"
            sqlConnection = sqlConnection & "Password=" & Password & ";"
        Else
            ' MsgBox("Please Provide Connection String or else Contact Your System Administration.")
        End If

        Return sqlConnection
    End Function
    Public Function IsAlreadyPresent(ByVal StrQry As String) As Boolean
        Dim sqlcon As New SqlConnection(ConnectionString())
        Dim sqlCmd As New SqlCommand(StrQry, sqlcon)
        Try
            ' Declare Command Variable
            sqlcon.Open()                                                                         ' Opens Connection 
            sqlCmd.CommandType = Data.CommandType.Text                                            ' Set Command Type 
            IsAlreadyPresent = sqlCmd.ExecuteScalar()                                             ' To Execute the command
        Catch ex As Exception
            IsAlreadyPresent = False                                                              ' if Exception comes return False
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            sqlCmd.Dispose()                                                                      ' Dispose command object
            sqlcon.Close()                                                                        ' Dispose connection Object
            sqlCmd = Nothing
            sqlcon = Nothing
        End Try
    End Function

    Function IsValidAlphaText(ByVal strAlpha As String) As Boolean
        ' Allows one or more alphabetical characters. This is a more generic validation function.
        Dim regExPattern As String = "^[A-Za-z]+$"
        Return MatchString(strAlpha, regExPattern)
    End Function 'IsValidAlphaText
    Function IsValidPhoneNumber(ByVal strPhone As String) As Boolean
        ' Allows phone number of the format: NPA = [2-9][0-8][0-9] Nxx = [2-9][0-9][0-9] Station = [0-9][0-9][0-9][0-9]
        Dim regExPattern As String = "^[0-9-)(\.,\s]{2,128}$"
        Return MatchString(strPhone, regExPattern)
    End Function 'IsValidUSPhoneNumber
    Function IsValidpinCode(ByVal strZIP As String) As Boolean
        ' Allows 6 digit pin code
        Dim regExPattern As String = "^(\d{6})$"
        Return MatchString(strZIP, regExPattern)
    End Function 'IsValidZIPCode
    Function IsValidNumericText(ByVal strNumeric As String) As Boolean
        Dim regExPattern As String = "^[0-9]+$"
        Return MatchString(strNumeric, regExPattern)
    End Function 'IsValidNumericText
    Function IsValidDecimalNumericText(ByVal strNumeric As String) As Boolean
        Dim regExPattern As String = "^[0-9.]+$"
        Return MatchString(strNumeric, regExPattern)
    End Function 'IsValidNumericText
    Function IsValidName(ByVal strName As String) As Boolean
        Dim regExPattern As String = "^[a-zA-Z]{2,128}$"
        Return MatchString(strName, regExPattern)
    End Function 'IsValidName
    Function MatchString(ByVal str As String, ByVal regexstr As String) As Boolean
        str = str.Trim()
        Dim pattern As New System.Text.RegularExpressions.Regex(regexstr)
        Return pattern.IsMatch(str)
    End Function 'MatchString
    Function IsValidEmailAddress(ByVal strEmail As String) As Boolean
        ' Allows common email address that can start with a alphanumeric char and contain word, dash and period characters
        ' followed by a domain name meeting the same criteria followed by a alpha suffix between 2 and 9 character lone
        Dim regExPattern As String = "\w+([-+.]\w+)*@\w+([-.]w+)*\.\w+([-.]\w+)*"
        Return MatchString(strEmail, regExPattern)
    End Function 'IsValidEmailAddress
    Function IsValidAmountText(ByVal strNumeric As String) As Boolean
        Dim regExPattern As String = "^[0-9.]+$"
        Return MatchString(strNumeric, regExPattern)
    End Function 'IsValidNumericText
    Public Sub Fill_Grid(ByVal Qry As String, ByRef GV As GridView)
        Dim Con As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand()
        Dim DS As New DataSet
        Dim SqlDa As New SqlDataAdapter
        Dim dt As Data.DataTable
        Try
            Con.Open()
            Cmd.Connection = Con
            Cmd.CommandText = Qry
            Cmd.CommandType = CommandType.Text
            SqlDa.SelectCommand = Cmd
            SqlDa.Fill(DS, "TableName")
            dt = DS.Tables("TableName")
            GV.DataSource = dt
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
            Cmd.Dispose()
            Con.Dispose()
            Cmd = Nothing
            Con = Nothing
        End Try
    End Sub

    Public Function GetCurrentDate() As Date
        Dim Con As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand("select cast(getdate()as datetime)", Con)
        Try
            Con.Open()
            GetCurrentDate = Cmd.ExecuteScalar

        Catch ex As Exception
            Return Nothing
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
            Cmd.Dispose()
            Con.Dispose()
            Cmd = Nothing
            Con = Nothing
        End Try

    End Function
    Public Function convertDataReaderToDataSet(ByVal reader As SqlDataReader) As DataSet
        Dim dataSet As DataSet = New DataSet
        Dim dataRow As DataRow
        Dim columnName As String
        Dim column As DataColumn
        Dim schemaTable As DataTable
        Dim dataTable As DataTable
        Do
            ' Create new data table
            schemaTable = reader.GetSchemaTable
            dataTable = New DataTable
            If Not IsDBNull(schemaTable) Then
                ' A query returning records was executed
                Dim i As Integer
                For i = 0 To schemaTable.Rows.Count - 1
                    dataRow = schemaTable.Rows(i)
                    ' Create a column name that is unique in the data table
                    columnName = dataRow("ColumnName")
                    'Add the column definition to the data table
                    column = New DataColumn(columnName, CType(dataRow("DataType"), Type))
                    dataTable.Columns.Add(column)
                Next
                dataSet.Tables.Add(dataTable)
                'Fill the data table we just created
                While reader.Read()
                    dataRow = dataTable.NewRow()
                    For i = 0 To reader.FieldCount - 1
                        dataRow(i) = reader(i)
                    Next
                    dataTable.Rows.Add(dataRow)
                End While
            Else
                'No records were returned
                column = New DataColumn("RowsAffected")
                dataTable.Columns.Add(column)
                dataSet.Tables.Add(dataTable)
                dataRow = dataTable.NewRow()
                dataRow(0) = reader.RecordsAffected
                dataTable.Rows.Add(dataRow)
            End If
        Loop While reader.NextResult()
        Return dataSet
    End Function

    Public Function returndatatable(ByVal qry As String, ByRef dt As Data.DataTable) As Data.DataTable
        Dim sqlcon As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand()
        Dim DS As New DataSet
        Dim SqlDa As New SqlDataAdapter
        returndatatable = Nothing
        Try
            sqlcon.Open()
            Cmd.Connection = sqlcon
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            SqlDa.SelectCommand = Cmd
            SqlDa.Fill(DS, "TableName")
            dt = DS.Tables("TableName")
            Return dt
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            Cmd.Dispose()
            sqlcon.Dispose()
            Cmd = Nothing
            sqlcon = Nothing
        End Try
    End Function

    Public Function returnSPdatatable(ByVal qry As String, ByRef dt As Data.DataTable, ByVal selection As String) As Data.DataTable
        Dim sqlcon As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand()
        Dim DS As New DataSet
        Dim SqlDa As New SqlDataAdapter
        returnSPdatatable = Nothing
        Try
            sqlcon.Open()
            Cmd.Connection = sqlcon
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.StoredProcedure
            Dim param As SqlParameter
            param = New SqlParameter("@List", selection)
            param.Direction = ParameterDirection.Input
            param.DbType = DbType.String
            Cmd.Parameters.Add(param)
            SqlDa.SelectCommand = Cmd
            SqlDa.Fill(DS, "TableName")
            dt = DS.Tables("TableName")
            Return dt
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            Cmd.Dispose()
            sqlcon.Dispose()
            Cmd = Nothing
            sqlcon = Nothing
        End Try
    End Function
    Public Sub SetGridProperty(ByVal Grid As GridView)
        'Try
        '    With Grid.ColumnHeadersDefaultCellStyle
        '        .BackColor = Color.Navy
        '        .ForeColor = Color.White
        '        .Font = New Font("Arial", 8, FontStyle.Bold)
        '        .Alignment = DataGridViewContentAlignment.MiddleCenter
        '    End With

        '    With Grid.RowHeadersDefaultCellStyle
        '        .BackColor = Color.Navy
        '        .ForeColor = Color.White
        '        .Font = New Font(Grid.Font, FontStyle.Bold)
        '    End With
        '    With Grid
        '        .CellBorderStyle = DataGridViewCellBorderStyle.Single
        '        .GridColor = SystemColors.ActiveBorder
        '        .RowHeadersVisible = False
        '        .BackgroundColor = Color.Honeydew
        '        .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
        '        '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        '    End With
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Public Sub ClearGroupBoxControl(ByVal grpBox As Panel)
        Dim ct As Object
        Try
            For Each ct In grpBox.Controls
                If TypeOf ct Is TextBox Then
                    Dim txt As TextBox = CType(ct, TextBox)
                    'txt.DataBindings.Clear()
                    'txt.Clear()
                    txt.Text = ""
                End If

                If TypeOf ct Is DropDownList Then
                    Dim cbo As DropDownList = CType(ct, DropDownList)
                    cbo.SelectedIndex = -1
                End If

                If TypeOf ct Is CheckBox Then
                    Dim chk As CheckBox = CType(ct, CheckBox)
                    chk.Checked = False
                End If

            Next
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Fill_ComboBox(ByVal strqry As String, ByVal strColumn As String, ByVal cmbBox As DropDownList)
        Dim sqlCon As New SqlConnection(ConnectionString())
        Dim sqlAdp As New SqlDataAdapter
        Dim sqlDs As New Data.DataSet
        Dim sqlCmd As New SqlCommand(strqry, sqlCon)
        Dim sqlDataTable As New Data.DataTable
        Try
            ' create objects
            sqlCon.Open()
            sqlAdp.SelectCommand = sqlCmd
            sqlAdp.Fill(sqlDs, "TableName")

            sqlDataTable = sqlDs.Tables("TableName")
            cmbBox.Items.Clear()
            If sqlDataTable.Rows.Count <> Nothing Then
                For i As Integer = 0 To sqlDataTable.Rows.Count - 1
                    cmbBox.Items.Add(sqlDataTable.Rows(i).Item(strColumn))
                Next
            End If

            'sqlCmd.ExecuteNonQuery()
            sqlCon.Close()

            ' free objects


        Catch ex As Exception

        Finally

            sqlCon = Nothing
            sqlAdp = Nothing
            sqlDs = Nothing
            sqlCmd = Nothing
            sqlDataTable.Dispose()
            sqlDataTable = Nothing
        End Try
    End Sub

    Public Sub Fill_AccountsComboBox(ByVal strqry As String, ByVal strColumn As String, ByVal cmbBox As DropDownList)
        Dim sqlCon As New SqlConnection(G_AccountsConnectionString())
        Dim sqlAdp As New SqlDataAdapter
        Dim sqlDs As New Data.DataSet
        Dim sqlCmd As New SqlCommand(strqry, sqlCon)
        Dim sqlDataTable As New Data.DataTable
        Try
            ' create objects
            sqlCon.Open()
            sqlAdp.SelectCommand = sqlCmd
            sqlAdp.Fill(sqlDs, "TableName")

            sqlDataTable = sqlDs.Tables("TableName")
            cmbBox.Items.Clear()
            If sqlDataTable.Rows.Count <> Nothing Then
                For i As Integer = 0 To sqlDataTable.Rows.Count - 1
                    cmbBox.Items.Add(sqlDataTable.Rows(i).Item(strColumn))
                Next
            End If

            'sqlCmd.ExecuteNonQuery()
            sqlCon.Close()

            ' free objects


        Catch ex As Exception

        Finally

            sqlCon = Nothing
            sqlAdp = Nothing
            sqlDs = Nothing
            sqlCmd = Nothing
            sqlDataTable.Dispose()
            sqlDataTable = Nothing
        End Try
    End Sub

    Public Function Returnsinglevalue(ByVal qry As String) As String
        Dim sqlcon As New SqlConnection(ConnectionString())
        Dim sqlcmd As New SqlCommand(qry, sqlcon)
        Returnsinglevalue = ""

        Try

            sqlcon.Open()
            If IsDBNull(sqlcmd.ExecuteScalar) Then
                Return 0
            Else
                Returnsinglevalue = sqlcmd.ExecuteScalar
                If Returnsinglevalue = Nothing Then
                    Return 0
                Else
                    Return Returnsinglevalue
                End If
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            sqlcon.Dispose()
            sqlcmd.Dispose()
            sqlcon = Nothing
            sqlcmd = Nothing
        End Try
    End Function
    Public Function ReturnsingleGuid(ByVal qry As String) As Guid
        Dim sqlcon As New SqlConnection(ConnectionString())
        Dim sqlcmd As New SqlCommand(qry, sqlcon)


        Try

            sqlcon.Open()
            If IsDBNull(sqlcmd.ExecuteScalar) Then
                Return Guid.Parse(0)
            Else
                ReturnsingleGuid = sqlcmd.ExecuteScalar
                If ReturnsingleGuid = Nothing Then
                    Return Guid.Parse(0)
                Else
                    Return ReturnsingleGuid
                End If
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            sqlcon.Dispose()
            sqlcmd.Dispose()
            sqlcon = Nothing
            sqlcmd = Nothing
        End Try
    End Function
    Public Function GetDbName(ByVal ConStr As String) As String
        Try
            Dim SqlCon As New SqlConnection(ConStr)
            If SqlCon.State = ConnectionState.Open Then SqlCon.Close()
            SqlCon.Open()
            GetDbName = SqlCon.Database
            If SqlCon.State = ConnectionState.Open Then SqlCon.Close()
            SqlCon = Nothing
        Catch ex As Exception
            GetDbName = ""
        End Try
    End Function
    Public Sub Fill_List(ByVal qry As String, ByRef Lst As ListBox)
        Dim Con As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand()
        Dim DS As New DataSet
        Dim SqlDa As New SqlDataAdapter
        Try
            Con.Open()
            Cmd.Connection = Con
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            SqlDa.SelectCommand = Cmd
            SqlDa.Fill(DS, "TableName")
            Lst.DataSource = DS.Tables("TableName").DefaultView


            Lst.DataTextField = DS.Tables("TableName").Columns(0).Caption
            Lst.DataValueField = DS.Tables("TableName").Columns(1).Caption
            'Lst.ValueMember = DS.Tables("TableName").Columns(0).Caption
            'Lst.DisplayMember = DS.Tables("TableName").Columns(1).Caption
            Lst.SelectedIndex = -1
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
            Cmd.Dispose()
            Con.Dispose()
            Cmd = Nothing
            Con = Nothing
        End Try
    End Sub
    Public Sub Fill_DropDown(ByVal qry As String, ByRef cmb As DropDownList)
        Dim Con As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand()
        Dim DS As New DataSet
        Dim SqlDa As New SqlDataAdapter
        Try
            Con.Open()
            Cmd.Connection = Con
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            SqlDa.SelectCommand = Cmd
            SqlDa.Fill(DS, "TableName")
            cmb.DataSource = DS.Tables("TableName").DefaultView
            'cmb.DisplayMember = DS.Tables("TableName").Columns(0).Caption
            cmb.DataTextField = DS.Tables("TableName").Columns(0).Caption
            cmb.DataValueField = DS.Tables("TableName").Columns(1).Caption
            cmb.DataBind()
            cmb.SelectedIndex = -1
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
            Cmd.Dispose()
            Con.Dispose()
            Cmd = Nothing
            Con = Nothing
        End Try
    End Sub
    'Public Sub Fill_GridComboBox(ByVal strqry As String, ByVal strColumn As String, ByVal cmbBox As DataGridViewComboBoxColumn)
    '    Dim sqlCon As New SqlConnection(ConnectionString())
    '    Dim sqlAdp As New SqlDataAdapter
    '    Dim sqlDs As New Data.DataSet
    '    Dim sqlCmd As New SqlCommand(strqry, sqlCon)
    '    sqlCmd.CommandTimeout = 100
    '    Dim sqlDataTable As New Data.DataTable
    '    Try
    '        ' create objects
    '        sqlCon.Open()
    '        sqlAdp.SelectCommand = sqlCmd
    '        sqlAdp.Fill(sqlDs, "TableName")

    '        sqlDataTable = sqlDs.Tables("TableName")

    '        cmbBox.Items.Clear()
    '        'cmbBox.DataSource = sqlDataTable

    '        If sqlDataTable.Rows.Count <> Nothing Then
    '            For i As Integer = 0 To sqlDataTable.Rows.Count - 1
    '                cmbBox.Items.Add(sqlDataTable.Rows(i).Item(strColumn))
    '            Next
    '        End If

    '        'sqlCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        sqlCon.Dispose()
    '        sqlAdp.Dispose()
    '        sqlDs.Dispose()
    '        sqlCmd.Dispose()
    '        sqlDataTable.Dispose()
    '    Finally
    '        sqlCon.Close()

    '        ' free objects
    '        sqlCon.Dispose()
    '        sqlAdp.Dispose()
    '        sqlDs.Dispose()
    '        sqlCmd.Dispose()
    '        sqlDataTable.Dispose()
    '        sqlCon = Nothing
    '        sqlAdp = Nothing
    '        sqlDs = Nothing
    '        sqlCmd = Nothing
    '        sqlDataTable = Nothing
    '    End Try
    'End Sub

    'Public Function DateValidate(ByVal pres_date As String) As Boolean
    '    Dim s As String
    '    Dim splited_date(3) As String
    '    Dim Day As String
    '    Dim month As String
    '    Dim year As String
    '    If (Len(Trim(pres_date))) = 0 Or pres_date.Length > 10 Then
    '        Return False 'Display_Error(db.Fetch_Error_Description(7))
    '        Exit Function
    '    Else
    '        Try
    '            s = Trim(pres_date)
    '            splited_date = s.Split("/")
    '            Day = splited_date(0)
    '            month = splited_date(1)
    '            year = splited_date(2)
    '            If Day <> Format(CInt(Day), "00") Or month <> Format(CInt(month), "00") Or year <> Format(CInt(year), "0000") Then
    '                MsgBox("Date Format Is Wrong, It Should be DD/MM/YYYY Format", MsgBoxStyle.OkOnly, g_StrTitle)
    '                Return False
    '            End If
    '            If Val(Day) < 0 Then
    '                MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
    '                Return False
    '            End If
    '            If month <> 2 Then
    '                If Day = 31 Then
    '                    If month = 2 Or month = 4 Or month = 6 Or month = 9 Or month = 11 Then
    '                        MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
    '                        Return False
    '                    End If
    '                End If
    '            End If
    '            If month = 2 Then
    '                If year / 4 = 0 Then
    '                    If Day > 29 Then
    '                        MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
    '                        Return False
    '                    End If
    '                ElseIf Day > 28 Then
    '                    MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
    '                    Return False
    '                End If
    '            End If
    '            'If NumCheck(Day) = False Or Day >= 31 Then
    '            '    Return False
    '            'End If
    '            If Val(month) > 12 Or Val(month) <= 0 Then
    '                MsgBox("InValid Month,Month Should be 01 To 12", MsgBoxStyle.OkOnly, g_StrTitle)
    '                Return False
    '            End If
    '            If Val(year) <= 0 Then
    '                MsgBox("InValid Year", MsgBoxStyle.OkOnly, g_StrTitle)
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            pres_date = ""
    '            Return False
    '            Exit Function
    '            'Display_Error(db.Fetch_Error_Description(7))
    '        End Try
    '    End If
    '    Return True
    'End Function
    'Public Sub Fill_GridComboCell(ByVal strqry As String, ByVal strColumn As String, ByVal cmbBox As DataGridViewComboBoxCell)
    '    Dim sqlCon As New SqlConnection(ConnectionString())
    '    Dim sqlAdp As New SqlDataAdapter
    '    Dim sqlDs As New Data.DataSet
    '    Dim sqlCmd As New SqlCommand(strqry, sqlCon)
    '    sqlCmd.CommandTimeout = 1000
    '    Dim sqlDataTable As New Data.DataTable
    '    Try
    '        ' create objects
    '        sqlCon.Open()
    '        sqlAdp.SelectCommand = sqlCmd
    '        sqlAdp.Fill(sqlDs, "TableName")

    '        sqlDataTable = sqlDs.Tables("TableName")

    '        cmbBox.Items.Clear()
    '        'cmbBox.DataSource = sqlDataTable

    '        If sqlDataTable.Rows.Count <> Nothing Then
    '            For i As Integer = 0 To sqlDataTable.Rows.Count - 1
    '                cmbBox.Items.Add(sqlDataTable.Rows(i).Item(strColumn))
    '            Next
    '        End If

    '        'sqlCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        sqlCon.Dispose()
    '        sqlAdp.Dispose()
    '        sqlDs.Dispose()
    '        sqlCmd.Dispose()
    '        sqlDataTable.Dispose()
    '    Finally

    '        sqlCon.Close()

    '        ' free objects
    '        sqlCon.Dispose()
    '        sqlAdp.Dispose()
    '        sqlDs.Dispose()
    '        sqlCmd.Dispose()
    '        sqlDataTable.Dispose()

    '        sqlCon = Nothing
    '        sqlAdp = Nothing
    '        sqlDs = Nothing
    '        sqlCmd = Nothing
    '        sqlDataTable = Nothing
    '    End Try
    'End Sub

    Function IsValidmobile(ByVal strZIP As String) As Boolean
        ' Allows 6 digit pin code
        Dim regExPattern As String = "^(\d{11})$"
        Return MatchString(strZIP, regExPattern)
    End Function


    Public Function ReturnDataSet(ByVal query As String) As DataSet
        Dim sqlcon As New SqlConnection(ConnectionString())
        Dim SqlCmd As New SqlCommand()
        Dim Ds As New DataSet
        Dim SqlAda As New SqlDataAdapter
        ReturnDataSet = Nothing
        Try
            sqlcon.Open()
            SqlCmd.Connection = sqlcon
            SqlCmd.CommandText = query
            SqlCmd.CommandType = CommandType.Text
            SqlAda.SelectCommand = SqlCmd
            SqlAda.Fill(Ds, "TableName")
            Return Ds
        Catch ex As Exception
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            SqlCmd.Dispose()
            sqlcon.Dispose()
            SqlCmd = Nothing
            sqlcon = Nothing
        End Try
    End Function

    Public Function ReturnAccountDataSet(ByVal query As String) As DataSet
        Dim sqlcon As New SqlConnection(G_AccountsConnectionString)
        Dim SqlCmd As New SqlCommand()
        Dim Ds As New DataSet
        Dim SqlAda As New SqlDataAdapter
        ReturnAccountDataSet = Nothing
        Try
            sqlcon.Open()
            SqlCmd.Connection = sqlcon
            SqlCmd.CommandText = query
            SqlCmd.CommandType = CommandType.Text
            SqlAda.SelectCommand = SqlCmd
            SqlAda.Fill(Ds, "TableName")
            Return Ds
        Catch ex As Exception
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            SqlCmd.Dispose()
            sqlcon.Dispose()
            SqlCmd = Nothing
            sqlcon = Nothing
        End Try
    End Function
    Public Function Accounts_combo_returnDataTable(ByVal strQuery As String) As Data.DataTable
        Dim SqlCon As New SqlConnection(G_AccountsConnectionString())
        Dim SqlAdapter As New SqlDataAdapter
        Dim SqlDataSet As New Data.DataSet
        Dim sqlDataTable As New Data.DataTable
        Dim sqlCmd As New SqlCommand(strQuery, SqlCon)
        sqlCmd.CommandTimeout = 500
        Try
            SqlCon.Open()
            SqlAdapter.SelectCommand = sqlCmd
            SqlAdapter.Fill(SqlDataSet, "TableName")
            sqlDataTable = SqlDataSet.Tables("TableName")
            sqlCmd.ExecuteNonQuery()

            Return sqlDataTable

        Catch ex As Exception
            MsgBox(ex.Message)
            SqlCon.Close()
            SqlCon.Dispose()
            sqlCmd.Dispose()
            SqlAdapter.Dispose()
            SqlDataSet.Dispose()
            sqlDataTable.Dispose()

            sqlCmd = Nothing
            SqlAdapter = Nothing
            SqlDataSet = Nothing
            sqlDataTable = Nothing
        Finally

            SqlCon.Close()
            SqlCon.Dispose()
            sqlCmd.Dispose()
            SqlAdapter.Dispose()
            SqlDataSet.Dispose()
            sqlDataTable.Dispose()

            sqlCmd = Nothing
            SqlAdapter = Nothing
            SqlDataSet = Nothing
            sqlDataTable = Nothing
        End Try
        Return sqlDataTable
    End Function
    Public Function combo_returnDataTable(ByVal strQuery As String) As Data.DataTable
        Dim SqlCon As New SqlConnection(ConnectionString())
        Dim SqlAdapter As New SqlDataAdapter
        Dim SqlDataSet As New Data.DataSet
        Dim sqlDataTable As New Data.DataTable
        Dim sqlCmd As New SqlCommand(strQuery, SqlCon)
        sqlCmd.CommandTimeout = 500
        Try
            SqlCon.Open()
            SqlAdapter.SelectCommand = sqlCmd
            SqlAdapter.Fill(SqlDataSet, "TableName")
            sqlDataTable = SqlDataSet.Tables("TableName")
            sqlCmd.ExecuteNonQuery()

            Return sqlDataTable

        Catch ex As Exception
            MsgBox(ex.Message)
            SqlCon.Close()
            SqlCon.Dispose()
            sqlCmd.Dispose()
            SqlAdapter.Dispose()
            SqlDataSet.Dispose()
            sqlDataTable.Dispose()

            sqlCmd = Nothing
            SqlAdapter = Nothing
            SqlDataSet = Nothing
            sqlDataTable = Nothing
        Finally

            SqlCon.Close()
            SqlCon.Dispose()
            sqlCmd.Dispose()
            SqlAdapter.Dispose()
            SqlDataSet.Dispose()
            sqlDataTable.Dispose()

            sqlCmd = Nothing
            SqlAdapter = Nothing
            SqlDataSet = Nothing
            sqlDataTable = Nothing
        End Try
        Return sqlDataTable
    End Function


    Function IsValidAlphaNumeric(ByVal strName As String) As Boolean
        Dim regExPattern As String = "^[a-zA-Z0-9-./\s]+$"
        Return MatchString(strName, regExPattern)
    End Function
    Function NumCheck(ByVal str As String)
        Dim good As String = "0123456789/-"
        Dim i As Integer
        For i = 0 To str.Length - 1 Step 1
            If good.IndexOf(str.Chars(i)) = True Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function DateValidate(ByVal pres_date As String) As Boolean
        Dim s As String
        Dim splited_date(3) As String
        Dim Day As String
        Dim month As String
        Dim year As String
        If (Len(Trim(pres_date))) = 0 Or pres_date.Length > 10 Then
            Return False 'Display_Error(db.Fetch_Error_Description(7))
            Exit Function
        Else
            Try
                s = Trim(pres_date)
                splited_date = s.Split("/")
                Day = splited_date(0)
                month = splited_date(1)
                year = splited_date(2)
                If Day <> Format(CInt(Day), "00") Or month <> Format(CInt(month), "00") Or year <> Format(CInt(year), "0000") Then
                    MsgBox("Date Format Is Wrong, It Should be DD/MM/YYYY Format", MsgBoxStyle.OkOnly, g_StrTitle)
                    Return False
                End If
                If Val(Day) < 0 Or Val(Day) > 31 Then
                    MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
                    Return False
                End If
                If month <> 2 Then
                    If Day = 31 Then
                        If month = 2 Or month = 4 Or month = 6 Or month = 9 Or month = 11 Then
                            MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
                            Return False
                        End If
                    End If
                End If
                If month = 2 Then
                    If year / 4 = 0 Then
                        If Day > 29 Then
                            MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
                            Return False
                        End If
                    ElseIf Day > 28 Then
                        MsgBox("InValid Date", MsgBoxStyle.OkOnly, g_StrTitle)
                        Return False
                    End If
                End If
                'If NumCheck(Day) = False Or Day >= 31 Then
                '    Return False
                'End If
                If Val(month) > 12 Or Val(month) <= 0 Then
                    MsgBox("InValid Month,Month Should be 01 To 12", MsgBoxStyle.OkOnly, g_StrTitle)
                    Return False
                End If
                If Val(year) <= 0 Then
                    MsgBox("InValid Year", MsgBoxStyle.OkOnly, g_StrTitle)
                    Return False
                End If
            Catch ex As Exception
                pres_date = ""
                Return False
                Exit Function
                'Display_Error(db.Fetch_Error_Description(7))
            End Try
        End If
        Return True
    End Function

    Public Function isvalidgriddate(ByVal strdate As String) As Boolean
        Dim regExPattern As String = "^[0-9 /]+$"
        Return MatchString(strdate, regExPattern)
    End Function

    Public Sub ExecuteQuery(ByVal qry As String)
        Dim Con As New SqlConnection(ConnectionString())
        Dim Cmd As New SqlCommand()
        Try

            Con.Open()
            Cmd.Connection = Con
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
            Cmd.Dispose()
            Con.Dispose()
            Cmd = Nothing
            Con = Nothing
        End Try
    End Sub

    Public Function IsValidAlphaspecialchar(ByVal strName As String) As Boolean
        Dim regExPattern As String = "^[A-Za-z/]+$"
        Return MatchString(strName, regExPattern)
    End Function

    Public Sub CheckRights(ByVal Formid As String)

        Dim con As New SqlConnection(ConnectionString())
        Dim cmd As New SqlCommand("select * from admin_accessright where menuid='" & Formid & "' and userid='" & g_userid & "'", con)
        Dim sqlda As New SqlDataAdapter
        Dim ds As New Data.DataSet
        Dim dt As Data.DataTable
        Add_Flag = False
        Modify_Flag = False
        Delete_Flag = False
        View_Flag = False
        Print_Flag = False
        Try

            con.Open()
            cmd.Connection = con

            cmd.CommandType = CommandType.Text
            sqlda.SelectCommand = cmd
            sqlda.Fill(ds, "TableName")
            dt = ds.Tables("TableName")

            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("Add_Flag") = 1 Or dt.Rows(0).Item("Add_Flag") = True Then
                    Add_Flag = True
                End If
                If dt.Rows(0).Item("Modify_Flag") = 1 Or dt.Rows(0).Item("Modify_Flag") = True Then
                    Modify_Flag = True
                End If
                If dt.Rows(0).Item("Delete_Flag") = 1 Or dt.Rows(0).Item("Delete_Flag") = True Then
                    Delete_Flag = True
                End If
                If dt.Rows(0).Item("View_Flag") = 1 Or dt.Rows(0).Item("View_Flag") = True Then
                    View_Flag = True
                End If
                If dt.Rows(0).Item("Print_Flag") = 1 Or dt.Rows(0).Item("Print_Flag") = True Then
                    Print_Flag = True
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
            con.Dispose()
            cmd.Dispose()
            con = Nothing
            cmd = Nothing
        End Try
    End Sub
    Function IsValidWebSite(ByVal strIn As String) As Boolean
        'Return Regex.IsMatch(strIn, "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        If (Regex.IsMatch(strIn, "www.+\S+\.\S+") Or strIn = "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub Fill_DataGridView(ByVal strQuery As String, ByVal _DataGridView As GridView)

        '  Dim sqlCon = New SqlConnection(g_StrConnectionString)
        Dim sqlCon As New SqlConnection(ConnectionString())
        Dim sqlDs As New Data.DataSet
        Dim sqlAdp As New SqlDataAdapter
        Dim sqlCmd As New SqlCommand(strQuery, sqlCon)
        Try
            sqlCon.Open()

            sqlAdp.SelectCommand = sqlCmd
            sqlAdp.Fill(sqlDs, "TableName")
            _DataGridView.DataSource = sqlDs.Tables("TableName")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlCon.Close()
            sqlCmd.Dispose()
            sqlDs.Dispose()
            sqlAdp.Dispose()

            sqlCon = Nothing
            sqlCmd = Nothing
            sqlDs = Nothing
            sqlAdp = Nothing
        End Try
    End Sub
    Public Function getNewID(ByVal strQuery As String) As Integer
        Dim sqlCon As New SqlConnection(ConnectionString())
        Dim sqlcmd As New SqlCommand(strQuery, SqlCon)
        Try
            SqlCon.Open()
            sqlcmd.CommandType = CommandType.Text
            sqlcmd.ExecuteScalar()
            If IsDBNull(sqlcmd.ExecuteScalar) Then
                Return 1
            Else
                Return sqlcmd.ExecuteScalar + Val(1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            SqlCon.Close()
            SqlCon.Dispose()

            sqlcmd.Dispose()
            sqlcmd = Nothing
            sqlCon = Nothing
            Return Nothing
        Finally

            sqlCon.Close()
            sqlCon.Dispose()

            sqlcmd.Dispose()
            sqlcmd = Nothing
            sqlCon = Nothing
        End Try
    End Function
    Public Function CheckExistense(ByVal strqry As String) As Boolean

        Dim sqlCon As New SqlConnection(ConnectionString())
        Dim sqlCmd As New SqlCommand(strqry, SqlCon)
        Try
            SqlCon.Open()
            sqlCmd.CommandType = Data.CommandType.Text

            Return sqlCmd.ExecuteScalar()


        Catch ex As Exception
            MsgBox(ex.Message)
            sqlCmd.Dispose()
            SqlCon.Close()

            sqlCmd = Nothing
            sqlCon = Nothing
            Return Nothing
        Finally
            sqlCmd.Dispose()
            sqlCon.Close()

            sqlCmd = Nothing
            sqlCon = Nothing
        End Try
    End Function

    Public Function ReturnFieldName(ByVal strName As String) As String
        Dim sqlCon As New SqlConnection(ConnectionString())
        Dim sqlcmd As New SqlCommand(strName, sqlCon)
        Try
            sqlCon.Open()
            sqlcmd.CommandType = Data.CommandType.Text

            If IsDBNull(sqlcmd.ExecuteScalar) Then
                Return ""
            Else
                Return sqlcmd.ExecuteScalar()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            sqlcmd.Dispose()
            sqlCon.Close()

            sqlCon = Nothing
            sqlcmd = Nothing
            Return Nothing
        Finally

            sqlcmd.Dispose()
            sqlCon.Close()

            sqlCon = Nothing
            sqlcmd = Nothing
        End Try
    End Function


    'Public Function convertPicBoxImageToByte(ByVal pbimage As PictureBox) As Byte()
    '    On Error Resume Next
    '    Dim ms As New System.IO.MemoryStream
    '    pbimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    Return ms.ToArray()
    'End Function

    Public Function convertPicBoxImageToByte(ByVal pbimage As Image) As Byte()
        On Error Resume Next
        Dim ms As New System.IO.MemoryStream
        pbimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Sub showimage(ByVal imageval As Byte(), ByVal pbimage As Image)
        '        On Error GoTo Err
        '        Dim imageData As Byte() = imageval
        '        If imageData.Length = 0 Then
        '            pbimage.Image = Nothing
        '            Exit Sub
        '        End If

        '        'Read image data into a memory stream
        '        Dim ms As New System.IO.MemoryStream(imageData)
        '        pbimage.Image = New Bitmap(ms)
        'Err:
        '        If Err.Number <> 0 Then
        '            pbimage.Image = Nothing
        '        End If
    End Sub
    Public Function validateValue(ByVal value As String, ByVal condtion As String, Optional ByVal length As Integer = 0) As Boolean

        If value = "" Then
            Return False
        End If
        Select Case condtion
            Case "None"
                Return True
            Case ""
                If Len(value) = 0 Then
                    Return False
                Else
                    Return True
                End If
            Case "AlphaNumeric"
                Return IsValidAlphaNumeric(value)
            Case "AlphaSpecialChr"
                Return IsValidAlphaspecialchar(value)
            Case "AlhpaText"
                Return IsValidAlphaText(value)
            Case "AmountText"
                Return IsValidAmountText(value)
            Case "Decimal Numeric Text"
                Return IsValidDecimalNumericText(value)
            Case "Email Address"
                Return IsValidEmailAddress(value)
            Case "Mobile Number"
                Return IsValidmobile(value)
            Case "Text Only"
                Return IsValidName(value)
            Case "Numeric Text"
                Return IsValidNumericText(value)
            Case "Phone Number"
                Return IsValidPhoneNumber(value)
            Case "PinCode"
                Return IsValidpinCode(value)
            Case "Website"
                Return IsValidWebSite(value)
            Case "Length"
                If Len(value) > length Then
                    Return False
                Else
                    Return True
                End If
        End Select

    End Function
    Public Sub ShowErrorMessage(ByVal value As String, ByVal type As Integer, Optional ByVal length As Integer = 0, Optional ByVal validationtype As String = "")
        Dim errMsg As String = ""

        If type = 1 Then
            If validationtype <> "" Then
                errMsg = "Please Check " & value & " Field. Check it is an valid " & validationtype
            Else
                errMsg = "Please Check " & value & " Field. It is an Mandatory Field"
            End If
        ElseIf type = 2 Then
            errMsg = "Please check Length of " & value & ". Length Can't be more than " & length
        End If

        MsgBox(errMsg, MsgBoxStyle.Information, g_StrTitle)
    End Sub



    'Private Function LoadSubCtrlNames(ByVal ctrl As Control) As Boolean
    '    Dim childCtrl As Control
    '    For Each childCtrl In ctrl.Controls
    '        If TypeOf childCtrl Is GroupBox Then
    '            LoadSubCtrlNames(childCtrl)
    '        End If
    '        If TypeOf childCtrl Is TabControl Then
    '            LoadSubCtrlNames(childCtrl)
    '        End If
    '        If TypeOf childCtrl Is TabPage Then
    '            LoadSubCtrlNames(childCtrl)
    '        End If
    '        If TypeOf childCtrl Is TextBox Then
    '            ctrlCnt = ctrlCnt + 1
    '            ctrlNames(ctrlCnt) = childCtrl.Text
    '        End If
    '        If TypeOf childCtrl Is ComboBox Then
    '            ctrlCnt = ctrlCnt + 1
    '            ctrlNames(ctrlCnt) = childCtrl.Text
    '        End If
    '        If TypeOf childCtrl Is CheckBox Then
    '            ctrlCnt = ctrlCnt + 1
    '            ctrlNames(ctrlCnt) = childCtrl.Text
    '        End If
    '    Next
    '    Return True
    'End Function

    Public Function getIndexKey() As String
        On Error GoTo Err
        Dim ssql As String
        Dim sKey
        Dim LoChar, HiChar, cpos, CurDigit, nRow
        LoChar = 48
        HiChar = 125
        ssql = "SELECT  COUNT(*) FROM Index_key"
        nRow = Returnsinglevalue(ssql)
        'If (nRow = 0) Then
        'sKey = "0000009"
        'ssql = "INSERT INTO h_key (key_id) VALUES ('" & Replace(CStr(sKey), "'", "''") & "')    "
        'ExecuteQuery(ssql)
        'g_objCon.Execute(ssql)
        'Else
        ssql = "SELECT key_id FROM Index_key "
        sKey = Returnsinglevalue(ssql)
Rep:
        cpos = 8
        Do While 1 > 0
            CurDigit = Asc(Mid(sKey, cpos, 1))
            CurDigit = CurDigit + 1
            If (CurDigit < HiChar) Then
                If (CurDigit >= 96 And CurDigit <= 122) Then
                    CurDigit = CurDigit + ((122 - CurDigit) + 1)
                End If
                Mid(sKey, cpos, 1) = Chr(CurDigit)
                Exit Do
            Else
                Mid(sKey, cpos, 1) = Chr(LoChar)
                cpos = cpos - 1
                If (cpos = 0) Then
                    sKey = Chr(LoChar) + sKey
                    Exit Do
                End If
            End If
        Loop
        If IsNumeric(sKey) Then
            If CDbl(sKey) >= 1 And CDbl(sKey) <= 9999 Then GoTo Rep
        End If
        ssql = "UPDATE Index_key SET key_id ='" & Replace(CStr(sKey), "'", "''") & "'"
        ExecuteQuery(ssql)
        'g_objCon.Execute(ssql)
        'End If
        Return Replace(CStr(sKey), "'", "''")

Err:
        If Err.Number <> 0 Then
            Resume Next
        End If
    End Function


    'Private Sub setFont(ByVal ctrl As Control)
    '    Dim childCtrl As Control
    '    For Each childCtrl In ctrl.Controls
    '        If TypeOf childCtrl Is GroupBox Then
    '            setFont(childCtrl)
    '        End If
    '        If TypeOf childCtrl Is TabControl Then
    '            setFont(childCtrl)
    '        End If
    '        If TypeOf childCtrl Is TabPage Then
    '            setFont(childCtrl)
    '        End If
    '        If TypeOf childCtrl Is TextBox Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is ComboBox Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is ListBox Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is CheckBox Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is RadioButton Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is Label Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is Button Then
    '            childCtrl.Font = New Font(globalFontName, 9, FontStyle.Regular)
    '        End If
    '        If TypeOf childCtrl Is DataGridView Then
    '            CType(childCtrl, DataGridView).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Regular)
    '            'CType(childCtrl, DataGridView).ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
    '            'CType(childCtrl, DataGridView).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
    '            SetGridProperty(CType(childCtrl, DataGridView))
    '        End If
    '    Next
    'End Sub
    Public Function AccessRights(ByVal mode As String, ByVal form As String)
        Dim objClass As New ClassFunctions
        Dim frmid As String = objClass.ReturnFieldName("select MenuId from Mas_menu where FormName='" & form & "'")
        If frmid Is Nothing Then MsgBox("You Do Not Have Rights To Save Record!", MsgBoxStyle.Information) : Return Nothing : Exit Function
        objClass.CheckRights(frmid)
        frmid = Nothing

        If mode = "View" Then
            If View_Flag = False Then
                MsgBox("You Do Not Have Rights To View !", MsgBoxStyle.Information)
                Return 0
            Else
                Return 1
            End If
        ElseIf mode = "Add" Then
            If Add_Flag = False Then
                MsgBox("You Do Not Have Rights To Add New Record !", MsgBoxStyle.Information)
                Return 0
            Else
                Return 1
            End If
        ElseIf mode = "Modify" Then

            If Modify_Flag = False Then
                MsgBox("You Do Not Have Rights To Modify Record !", MsgBoxStyle.Information)
                Return 0
            Else
                Return 1
            End If
        ElseIf mode = "Delete" Then
            If Delete_Flag = False Then
                MsgBox("You Do Not Have Rights To Delete Record !", MsgBoxStyle.Information)
                Return 0
            Else
                Return 1
            End If
        Else
            Return 0
        End If
    End Function

    Public Sub ExecuteStoredProcedure(ByVal StrSp As String, ByVal HTable As Hashtable, ByVal strMode As String)

        Dim SqlConn As New SqlConnection
        Dim Cmd As SqlCommand = Nothing
        Dim comm As New SqlCommand
        Dim str As XmlReader
        Try
            SqlConn = New SqlConnection(ConnectionString)
            comm = New SqlCommand("Select XMLStoreProcedure from SP where StoreProcedureName='" & StrSp & "'", SqlConn)

            comm.Connection.Open()
            str = comm.ExecuteXmlReader()
            comm.Connection.Close()

            Cmd = New SqlCommand(StrSp, SqlConn)
            SqlConn.Open()

            Cmd.CommandType = CommandType.StoredProcedure

            Dim spParamXml As String = Nothing

            Dim _spParamXmlDoc As XmlDocument = Nothing
            Dim xmlPath As String = "/StoredProcedures/StoredProcedure/Parameters/Parameter"
            _spParamXmlDoc = New XmlDocument
            _spParamXmlDoc.Load(str)

            Dim ParameterNodes As XmlNodeList = _spParamXmlDoc.SelectNodes(xmlPath)

            If ParameterNodes.Count = 0 Then
                MsgBox("XML not Found")
                Exit Sub
            End If

            Dim ParameterNode As XmlElement
            Dim i As Integer
            Dim strTemp As String


            Dim parameterName As String
            Dim dbType As SqlDbType
            Dim size As Integer
            Dim direction As ParameterDirection
            Dim isNullable As Boolean
            Dim value As Object
            Dim j As Integer = 0

            i = HTable.Count

            For Each ParameterNode In ParameterNodes
                parameterName = Nothing
                dbType = Nothing
                size = Nothing
                direction = Nothing
                isNullable = Nothing
                value = Nothing

                parameterName = ParameterNode.GetAttribute("name")

                Select Case ParameterNode.GetAttribute("datatype")

                    Case "VarChar"
                        dbType = SqlDbType.VarChar
                        size = ParameterNode.GetAttribute("size")
                    Case "Integer"
                        dbType = SqlDbType.Int
                        size = ParameterNode.GetAttribute("size")
                    Case "DateTime"
                        dbType = SqlDbType.DateTime
                    Case "Char"
                        dbType = SqlDbType.Char
                    Case "Money"
                        dbType = SqlDbType.Money
                    Case "Decimal"
                        dbType = SqlDbType.Decimal
                    Case "Bit"
                        dbType = SqlDbType.Bit
                End Select

                If ParameterNode.GetAttribute("direction") = "Input" Then
                    direction = ParameterDirection.Input

                    Dim a As Date
                    Select Case ParameterNode.GetAttribute("name")

                        Case "@Mode"
                            value = strMode
                        Case "@ModifyDate"
                            value = Now
                        Case "@UserCode"
                            value = g_UserName
                            'Case "@UserName"
                            '   value = g_username
                        Case Else

                            If i = 0 Then
                                MsgBox("Parameters Can not be null", MsgBoxStyle.Information)
                                Exit Sub
                            Else
                                If IsDBNull(HTable.Item(j)) Or IsNothing(HTable.Item(j)) Then
                                    value = DBNull.Value
                                Else
                                    strTemp = HTable.Item(j).ToString


                                    If strTemp = "" Then
                                        value = DBNull.Value
                                    Else
                                        If ParameterNode.GetAttribute("datatype") = "DateTime" Then
                                            If ParameterNode.GetAttribute("name") <> "ModifyDate" Then
                                                a = CDate(strTemp)
                                                value = a
                                            End If
                                        Else
                                            value = Trim(strTemp)

                                        End If
                                    End If
                                End If
                            End If
                    End Select
                Else
                    direction = ParameterDirection.Output
                End If

                isNullable = ParameterNode.GetAttribute("isNullable")

                Cmd.Parameters.Add(parameterName, dbType, size)
                If Cmd.Parameters(parameterName).Direction = ParameterDirection.Input Then
                    Cmd.Parameters(parameterName).Value = value
                End If
                Cmd.Parameters(parameterName).Direction = direction
                Cmd.Parameters(parameterName).IsNullable = isNullable
                j = j + 1
            Next
            Cmd.ExecuteNonQuery()

            'sp_Deal_Sponsorship_Det
            Dim Msg As String
            Msg = Cmd.Parameters("@Msg").Value
            If Msg <> "" Then
                MsgBox(Msg, MsgBoxStyle.Information)
            End If

            'Free(Objects)
            Msg = Nothing
            Cmd.Dispose()
            SqlConn.Dispose()
            Cmd = Nothing
            SqlConn = Nothing

        Catch ex As Exception
            SqlConn.Dispose()
            SqlConn = Nothing
            MsgBox(ex.Message)
            'Finally
            '    'SqlConn.Dispose()
            'SqlConn = Nothing
        End Try

    End Sub
    Public Function returnMaxRow(ByVal rows() As DataRow) As DataRow

        Dim cnt As Integer
        Dim maxdate As Date
        Dim rowno As Integer
        If rows.GetUpperBound(0) = -1 Then Return Nothing
        maxdate = rows(0).Item(1)
        rowno = 0
        For cnt = 1 To rows.GetUpperBound(0)
            If maxdate < rows(cnt).Item(1) Then
                maxdate = rows(cnt).Item(1)
                rowno = cnt
            End If
        Next
        Return rows(rowno)
    End Function
    Public Function returnMinRow(ByVal rows() As DataRow) As DataRow

        Dim cnt As Integer
        Dim maxdate As Date
        Dim rowno As Integer
        If rows.GetUpperBound(0) = -1 Then Return Nothing
        maxdate = rows(0).Item(1)
        rowno = 0
        For cnt = 1 To rows.GetUpperBound(0)
            If maxdate > rows(cnt).Item(1) Then
                maxdate = rows(cnt).Item(1)
                rowno = cnt
            End If
        Next
        Return rows(rowno)
    End Function

    Public Function DigitsToWords(ByVal Number As Decimal) As String
        Try
            Dim objClass As New classFunctions
            Dim IntegerNo As Decimal = System.Decimal.Truncate(Number)
            Dim DecimalNo As Decimal = Number - IntegerNo
            Dim ConvertedStr As String = ""
            Dim Str As String = ""
            Dim Len As Integer = IntegerNo.ToString.Length
            Dim tmp As String = IntegerNo.ToString
            Dim val As String = ""
            Dim StrDec As String = ""
            Select Case Len
                Case 1 To 2
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", IntegerNo))
                    ConvertedStr = Str
                Case 3
                    val = Mid(tmp, Len - 1, 2)
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str & ConvertedStr
                    val = Mid(tmp, Len - 2, 1)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Hundred " & ConvertedStr
                    End If
                Case 4 To 5
                    val = Mid(tmp, Len - 1, 2)
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str + ConvertedStr
                    val = Mid(tmp, Len - 2, 1)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Hundred " & ConvertedStr
                    End If
                    If Len - 4 = 0 Then
                        val = Mid(tmp, Len - 3, 1)
                    Else
                        val = Mid(tmp, Len - 4, 2)
                    End If
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str & " Thousand " & ConvertedStr

                Case 6 To 7
                    val = Mid(tmp, Len - 1, 2)
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str + ConvertedStr
                    val = Mid(tmp, Len - 2, 1)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Hundred " & ConvertedStr
                    End If
                    val = Mid(tmp, Len - 4, 2)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Thousand " & ConvertedStr
                    End If
                    If Len - 6 = 0 Then
                        val = Mid(tmp, Len - 5, 1)
                    Else
                        val = Mid(tmp, Len - 6, 2)
                    End If
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str & " Lakhs " & ConvertedStr

                Case 8 To 9
                    val = Mid(tmp, Len - 1, 2)
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str + ConvertedStr
                    val = Mid(tmp, Len - 2, 1)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Hundred " & ConvertedStr
                    End If
                    val = Mid(tmp, Len - 4, 2)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Thousand " & ConvertedStr
                    End If
                    val = Mid(tmp, Len - 6, 2)
                    If CType(val, Integer) > 0 Then
                        Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                        ConvertedStr = Str & " Lakhs " & ConvertedStr
                    End If
                    If Len - 8 = 0 Then
                        val = Mid(tmp, Len - 7, 1)
                    Else
                        val = Mid(tmp, Len - 8, 2)
                    End If
                    Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(val, Integer)))
                    ConvertedStr = Str & " Crores " & ConvertedStr

            End Select

            If ConvertedStr <> "" Then
                ConvertedStr = ConvertedStr & " Rupees"
            End If

            If DecimalNo <> 0 Then
                Dim Concat As String = Nothing
                Dim StrDecimal As String = DecimalNo.ToString
                Dim StrSplit As String = Mid(StrDecimal, 3, 2)
                'If StrSplit(1).Length = 1 Then
                'Concat = StrSplit(1) & "0"
                'Else
                '   Concat = StrSplit(1)
                'End If

                Str = objClass.ReturnFieldName(String.Format("Select Description from Number where NumberId={0}", CType(StrSplit, Integer)))
                ConvertedStr = ConvertedStr & " And " & Str & " Paisa "
            End If
            ConvertedStr = ConvertedStr + " Only"
            Return ConvertedStr

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ReturnAccountsFieldName(ByVal strName As String) As String
        Dim SqlCon As New SqlConnection(G_AccountsConnectionString)
        Dim sqlcmd As New SqlCommand(strName, SqlCon)
        Try
            SqlCon.Open()
            sqlcmd.CommandType = Data.CommandType.Text

            If IsDBNull(sqlcmd.ExecuteScalar) Then
                Return ""
            Else
                Return sqlcmd.ExecuteScalar()
            End If
        Catch ex As Exception
            sqlcmd.Dispose()
            SqlCon.Close()
            SqlCon = Nothing
            sqlcmd = Nothing
            Return Nothing
        Finally
            sqlcmd.Dispose()
            SqlCon.Close()
            SqlCon = Nothing
            sqlcmd = Nothing
        End Try

    End Function

    Public Sub Fill_AccountsDataGridView(ByVal strQuery As String, ByVal _DataGridView As GridView)

        '  Dim sqlCon = New SqlConnection(g_StrConnectionString)
        Dim sqlCon As New SqlConnection(G_AccountsConnectionString())
        Dim sqlDs As New Data.DataSet
        Dim sqlAdp As New SqlDataAdapter
        Dim sqlCmd As New SqlCommand(strQuery, sqlCon)
        Try
            sqlCon.Open()

            sqlAdp.SelectCommand = sqlCmd
            sqlAdp.Fill(sqlDs, "TableName")
            _DataGridView.DataSource = sqlDs.Tables("TableName")

            sqlCon.Close()
            sqlCmd.Dispose()
            sqlDs.Dispose()
            sqlAdp.Dispose()

            sqlCon = Nothing
            sqlCmd = Nothing
            sqlDs = Nothing
            sqlAdp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ExecuteAccountQuery(ByVal qry As String)
        Dim Con As New SqlConnection(G_AccountsConnectionString())
        Dim Cmd As New SqlCommand()
        Try

            Con.Open()
            Cmd.Connection = Con
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
            Cmd.Dispose()
            Con.Dispose()
            Cmd = Nothing
            Con = Nothing
        End Try
    End Sub

    Public Function returnaccountsdatatable(ByVal qry As String, ByRef dt As Data.DataTable) As Data.DataTable
        Dim sqlcon As New SqlConnection(G_AccountsConnectionString())
        Dim Cmd As New SqlCommand()
        Dim DS As New DataSet
        Dim SqlDa As New SqlDataAdapter
        returnaccountsdatatable = Nothing
        Try
            sqlcon.Open()
            Cmd.Connection = sqlcon
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            SqlDa.SelectCommand = Cmd
            SqlDa.Fill(DS, "TableName")
            dt = DS.Tables("TableName")
            Return dt
        Catch ex As Exception
            'MessageBox.Show(ex.Message, g_StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, g_StrTitle)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            Cmd.Dispose()
            sqlcon.Dispose()
            sqlcon.Close()
            Cmd = Nothing
            sqlcon = Nothing
        End Try
    End Function

    Public Sub ExecuteAccountsStoredProcedure(ByVal StrSp As String, ByVal HTable As Hashtable, ByVal strMode As String)

        Dim SqlConn As New SqlConnection
        Dim Cmd As SqlCommand = Nothing
        Dim comm As New SqlCommand
        Dim str As XmlReader
        'Cmd.CommandTimeout = 100
        Try
            SqlConn = New SqlConnection(G_AccountsConnectionString)
            comm = New SqlCommand("Select XMLStoredProcedure from SP where StoredProcedureName='" & StrSp & "'", SqlConn)
            ' comm.Connection.Close()
            comm.Connection.Open()
            str = comm.ExecuteXmlReader()
            comm.Connection.Close()

            Cmd = New SqlCommand(StrSp, SqlConn)
            SqlConn.Open()

            Cmd.CommandType = CommandType.StoredProcedure

            Dim spParamXml As String = Nothing

            Dim _spParamXmlDoc As XmlDocument = Nothing
            Dim xmlPath As String = "/StoredProcedures/StoredProcedure/Parameters/Parameter"
            _spParamXmlDoc = New XmlDocument
            _spParamXmlDoc.Load(str)

            Dim ParameterNodes As XmlNodeList = _spParamXmlDoc.SelectNodes(xmlPath)

            If ParameterNodes.Count = 0 Then
                MsgBox("XML not Found")
                Exit Sub
            End If

            Dim ParameterNode As XmlElement
            Dim i As Integer
            Dim strTemp As String


            Dim parameterName As String
            Dim dbType As SqlDbType
            Dim size As Integer
            Dim direction As ParameterDirection
            Dim isNullable As Boolean
            Dim value As Object
            Dim j As Integer = 0

            i = HTable.Count

            For Each ParameterNode In ParameterNodes
                parameterName = Nothing
                dbType = Nothing
                size = Nothing
                direction = Nothing
                isNullable = Nothing
                value = Nothing

                parameterName = ParameterNode.GetAttribute("name")

                Select Case ParameterNode.GetAttribute("datatype")

                    Case "VarChar"
                        dbType = SqlDbType.VarChar
                        size = ParameterNode.GetAttribute("size")
                    Case "Integer"
                        dbType = SqlDbType.Int
                        size = ParameterNode.GetAttribute("size")
                    Case "DateTime"
                        dbType = SqlDbType.DateTime
                    Case "Char"
                        dbType = SqlDbType.Char
                    Case "Money"
                        dbType = SqlDbType.Money
                    Case "Decimal"
                        dbType = SqlDbType.Decimal

                End Select

                If ParameterNode.GetAttribute("direction") = "Input" Then
                    direction = ParameterDirection.Input

                    Dim a As Date
                    Select Case ParameterNode.GetAttribute("name")

                        Case "@Mode"
                            value = strMode
                        Case "@ModifyDate"
                            value = Now
                        Case "@UserCode"
                            value = g_UserName
                        Case "@UserName"
                            value = g_UserName
                        Case Else

                            If i = 0 Then
                                MsgBox("Parameters Can not be null", MsgBoxStyle.Information)
                                Exit Sub
                            Else
                                If IsDBNull(HTable.Item(j)) Or IsNothing(HTable.Item(j)) Then
                                    value = DBNull.Value
                                Else
                                    strTemp = HTable.Item(j).ToString


                                    If strTemp = "" Then
                                        value = DBNull.Value
                                    Else
                                        If ParameterNode.GetAttribute("datatype") = "DateTime" Then
                                            If ParameterNode.GetAttribute("name") <> "ModifyDate" Then
                                                a = CDate(strTemp)
                                                value = a
                                            End If
                                        Else
                                            value = Trim(strTemp)

                                        End If
                                    End If
                                End If
                            End If
                    End Select
                Else
                    direction = ParameterDirection.Output
                End If

                isNullable = ParameterNode.GetAttribute("isNullable")

                Cmd.Parameters.Add(parameterName, dbType, size)
                If Cmd.Parameters(parameterName).Direction = ParameterDirection.Input Then
                    Cmd.Parameters(parameterName).Value = value
                End If
                Cmd.Parameters(parameterName).Direction = direction
                Cmd.Parameters(parameterName).IsNullable = isNullable
                j = j + 1
            Next
            Cmd.ExecuteNonQuery()


            'Dim Msg As String
            'Msg = Cmd.Parameters("@Msg").Value
            'MsgBox(Msg, MsgBoxStyle.Information)

            '' Free Objects
            'Msg = Nothing
            Cmd.Dispose()
            SqlConn.Dispose()
            SqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cmd = Nothing
        SqlConn = Nothing

    End Sub
    'Public Function SetPrinter(ByVal prtName As String) As Boolean
    '    Dim s As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
    '    Dim m As Microsoft.Win32.RegistryKey

    '    m = s.OpenSubKey("Software")
    '    m = m.OpenSubKey("Microsoft")
    '    m = m.OpenSubKey("Windows NT")
    '    m = m.OpenSubKey("CurrentVersion")
    '    m = m.OpenSubKey("Windows", True)
    '    m.SetValue("Device", prtName & ",winspool,FILE:")
    '    m.Flush()
    '    m.Close()
    '    s.Close()

    'End Function

End Class

