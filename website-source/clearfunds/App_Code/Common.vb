Imports Microsoft.VisualBasic
Imports System.Threading
Imports System.Globalization
Imports System.Data
Imports System.Text
Imports System.Resources

Public Class Common

#Region "DECLARATIONS"
    Public Shared FR As String = "fr-CA" 'Culture French Canada
    Public Shared EN As String = "en-US" 'Culture English USA
    Public Shared LANGUAGE As String = "Language" 'Session variable for culture settings
    Public Shared CART As String = "CART" 'Session variable for culture settings
   Public Shared RETURNURL As String = "ReturnUrl"
    Public Shared PRODID As String = "prodid"
    Public Shared ClientID As String = "clientid"
    Public Shared UseSandbox As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("UseSandbox"))
    Public Shared PAYPALURLPROD As String = System.Configuration.ConfigurationManager.AppSettings("PAYPALURLPROD")
    Public Shared PAYPALURLQA As String = System.Configuration.ConfigurationManager.AppSettings("PAYPALURLQA")
    Public Shared PAGENOTACCESS As String = System.Configuration.ConfigurationManager.AppSettings("PAGENOTACCESS")
    Public Shared PAGENOTLOGGEDIN As String = System.Configuration.ConfigurationManager.AppSettings("PAGENOTLOGGEDIN")
    Public Shared PAGEERRORTRAPPED As String = System.Configuration.ConfigurationManager.AppSettings("PAGEERRORTRAPPED")
    Public Shared PAGENOTSUBSCRIBER As String = System.Configuration.ConfigurationManager.AppSettings("PAGENOTSUBSCRIBER")

    Public Shared Sub WriteError(ByVal str As Exception)
        Dim objWriter As System.IO.StreamWriter = Nothing
        Dim mail As CEmail = Nothing

        Try
            If CBool(System.Configuration.ConfigurationManager.AppSettings("ERROREMAILENABLED")) Then
                mail = New CEmail
                mail.EmailError(str.ToString)
            End If

            If CBool(System.Configuration.ConfigurationManager.AppSettings("ERRORFILETEXTENABLED")) Then
                If Not System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings("ERRORFILETEXT")) Then
                    System.IO.File.Create(System.Configuration.ConfigurationManager.AppSettings("ERRORFILETEXT"))
                End If

                objWriter = New System.IO.StreamWriter(System.Configuration.ConfigurationManager.AppSettings("ERRORFILETEXT"), True)
                objWriter.WriteLine(Now & " " & str.ToString)
                objWriter.Close()
            End If
        Catch ex As Exception
            Throw
        Finally
            If Not objWriter Is Nothing Then objWriter.Dispose()
            If Not mail Is Nothing Then objWriter.Dispose()
        End Try
    End Sub
    Public Shared Function ReturnCurrencyToShow(ByVal dbl As Double) As String
        Return dbl.ToString("0.##")
    End Function

    Public Enum PRIORITE
        NON = 0
        OUI = 1
    End Enum
    Public Enum ADRESSESOPTIONS
        CLIENT = 0
        PROS = 1
        NONE = 3
    End Enum

    Public Enum MESSAGESTATUS
        READ = 1
        UNREAD = 2
        DELETED = 3
    End Enum

    Public Enum MESSAGETYPE
        INBOX = 1
        OUTBOX = 2
        DELETED = 3
    End Enum

    Public Enum TRANSACTSTATUS
        SUCCESS = 1
        FAILED = 2
        PENDING = 3
    End Enum

   
#End Region

#Region "Reusables Methods"
    ''' <summary>
    ''' function that returns product level
    ''' </summary>
    ''' <returns>ArrayList</returns>
    ''' <remarks></remarks>
    'Public Shared Function GetForfaitLevel() As ArrayList
    '    Dim tablang As New ArrayList
    '    tablang.Add(Global.Resources.Resource.ResourceManager.GetString("Access5"))
    '    tablang.Add(Global.Resources.Resource.ResourceManager.GetString("Access1"))
    '    tablang.Add(Global.Resources.Resource.ResourceManager.GetString("Access2"))
    '    tablang.Add(Global.Resources.Resource.ResourceManager.GetString("Access3"))
    '    tablang.Add(Global.Resources.Resource.ResourceManager.GetString("Access4"))

    '    Return tablang


    ''' <summary>
    ''' Function that returns currency to show on screen
    ''' </summary>
    ''' <param name="dbl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    

    ''' <summary>
    ''' Sets the current thread culture info
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetCultureInfo(ByRef Str As String)
        Dim lang As String = String.Empty

        If Str Is Nothing Then
            Dim Request As HttpRequest = HttpContext.Current.Request

            If (Request.UserLanguages Is Nothing) Then
                lang = EN
            Else
                lang = Request.UserLanguages(0)
            End If
        Else
            lang = Str
        End If
        
        System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(lang.ToString)
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(lang.ToString)
    End Sub

    ''' <summary>
    ''' Returns the user type in string
    ''' </summary>
    ''' <param name="pUserType"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    'Public Shared Function UserTypeToString(ByVal pUserType As USERTYPE) As String
    '    If pUserType = USERTYPE.ADMIN Then
    '        Return Global.Resources.Resource.ResourceManager.GetString("ADMIN")
    '    ElseIf pUserType = USERTYPE.CLIENT Then
    '        Return Global.Resources.Resource.ResourceManager.GetString("CLIENT")
    '    ElseIf pUserType = USERTYPE.PRO Then
    '        Return Global.Resources.Resource.ResourceManager.GetString("PRO")
    '    End If

    '    Return Nothing
  '
    ''' <summary>
    ''' Returns if current user is logged
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsUserLoggedIn() As Boolean
        Return (Not IsNothing(Membership.GetUser))
    End Function

    ''' <summary>
    ''' Returns if pro is subcriber
    ''' </summary>
    ''' <returns></returns>
   

    ''' <summary>
    ''' Returns current user type
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
   

    ''' <summary>
    ''' Returns current user type
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>


    
   

    ''' <summary>
    ''' Returns current user type
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
   

    ''' <summary>
    ''' Checks if querystring has parameters, if not then redirect
    ''' </summary>
    ''' <param name="parameter"></param>
    ''' <param name="Page"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryString(ByVal parameter As String, ByVal Page As System.Web.UI.Page) As String
        Dim parameterValue As String = Page.Request.QueryString(parameter)

        If ((parameterValue Is Nothing) OrElse (parameterValue = String.Empty)) Then
            Page.Response.Redirect("default.aspx", True)
            Return String.Empty
        Else
            Return parameterValue
        End If
    End Function
#End Region
    Public Shared Function MonthsShorts(ByVal idmonth As Integer, ByVal lang As String) As String
        Select Case idmonth
            Case 0 : Return (IIf(lang = "en-US", "JAN", "JAN"))
            Case 1 : Return (IIf(lang = "en-US", "FEB", "FEV"))
            Case 2 : Return (IIf(lang = "en-US", "MAR", "MAR"))
            Case 3 : Return (IIf(lang = "en-US", "APR", "AVR"))
            Case 4 : Return (IIf(lang = "en-US", "MAY", "MAI"))
            Case 5 : Return (IIf(lang = "en-US", "JUN", "JUIN"))
            Case 6 : Return (IIf(lang = "en-US", "JUL", "JUIL"))
            Case 7 : Return (IIf(lang = "en-US", "AUG", "AOU"))
            Case 8 : Return (IIf(lang = "en-US", "SEPT", "SEPT"))
            Case 9 : Return (IIf(lang = "en-US", "OCT", "OCT"))
            Case 10 : Return (IIf(lang = "en-US", "NOV", "NOV"))
            Case 11 : Return (IIf(lang = "en-US", "DEC", "DEC"))
        End Select
        Return Nothing
    End Function

    ''' <summary>
    ''' Function that returns currency format for database purposes
    ''' </summary>
    ''' <param name="dbl"></param>
    ''' <returns>String format for Datatabase</returns>
    ''' <remarks></remarks>
    Public Shared Function ReturnCurrency(ByVal dbl As Double) As String
        Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings("CULTURETOUSE"))
        Dim NumberFormatInfo As New System.Globalization.NumberFormatInfo

        NumberFormatInfo = ci.NumberFormat
        NumberFormatInfo.NumberDecimalDigits = 2

        Return dbl.ToString("N", NumberFormatInfo)
    End Function

    ''' <summary>
    ''' Function that returns encrypted string for querystrings
    ''' </summary>
    ''' <param name="stringToEncrypt"></param>
    ''' <returns>Encrypted String</returns>
    ''' <remarks></remarks>
    Public Shared Function Encrypt(ByVal stringToEncrypt As String) As String
        Dim ret As String = ""
        Dim key As String = "g43rd"
        Dim i As Integer
        Dim tmp2 As Integer
        Dim tmp1 As String = ""
        Dim tmp3 As String = ""
        Dim newLen As Integer
        Dim newKey As String = ""
        Dim j As Integer
        Dim bytes() As Byte

        Try
            'Verif de la longueur de la clé
            If Not ((stringToEncrypt Is Nothing) Or (stringToEncrypt = "")) Then
                If Len(stringToEncrypt) > Len(key) Then
                    newLen = CombienDeFoisMettreDedans(stringToEncrypt, key)

                    For j = 1 To newLen
                        newKey = newKey & key
                    Next j

                    key = newKey
                End If

                For i = 1 To Len(stringToEncrypt)
                    tmp1 = Asc(Mid(stringToEncrypt, i, 1))
                    tmp2 = Asc(Mid(key, i, 1))

                    If Not tmp1 + tmp2 > 255 Then
                        tmp3 = tmp3 & (Chr(tmp1 + tmp2))
                    Else
                        tmp3 = tmp3 & (("{?}"))
                    End If
                Next i

                bytes = Encoding.Default.GetBytes(tmp3)

                For Each b As Byte In bytes
                    ret &= b.ToString("x").ToUpper & " "
                Next

                Return ret.Replace(" ", "")
            End If

            Return Nothing
        Catch ex As Exception
            Encrypt = Nothing
            Common.WriteError(ex)
            Throw
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Function that returns decrypted string and parsed to int
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Shared Function DecryptInt(ByVal stringToDecrypt As String) As Integer
        Dim tmp3 As String = ""

        Try
            If Not ((stringToDecrypt Is Nothing) Or (stringToDecrypt = "")) Then
                Dim a As String = stringToDecrypt
                Dim b As String = ""
                Dim i As Integer

                For i = 0 To a.Length - 2 Step 2
                    b = b & Chr(CInt("&H" & a.Substring(i, 2)))
                Next

                stringToDecrypt = b
                Dim key As String = "g43rd"

                If Len(stringToDecrypt) > Len(key) Then
                    Dim newLen As Integer
                    Dim newKey As String = ""
                    Dim j As Integer
                    newLen = CombienDeFoisMettreDedans(stringToDecrypt, key)
                    For j = 1 To newLen
                        newKey = newKey & key
                    Next j
                    key = newKey
                End If

                stringToDecrypt = Replace(stringToDecrypt, "{?}", "")

                Dim tmp2 As Integer
                Dim tmp1 As String = ""

                For i = 1 To Len(stringToDecrypt)
                    tmp1 = Asc(Mid(stringToDecrypt, i, 1))
                    tmp2 = Asc(Mid(key, i, 1))
                    If tmp1 < tmp2 Then
                        tmp3 = tmp3 & "{?}"
                    Else
                        tmp3 = tmp3 & Chr(tmp1 - tmp2)
                    End If
                Next i

                Return (CInt(tmp3))
            End If

            Return Nothing
        Catch ex As Exception
            DecryptInt = Nothing
            Common.WriteError(ex)
            Throw
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Function that returns decrypted string and parsed to guid
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns>Guid</returns>
    ''' <remarks></remarks>
    Public Shared Function DecryptGuid(ByVal stringToDecrypt As String) As Guid
        Dim tmp3 As String = ""

        Try
            If Not ((stringToDecrypt Is Nothing) Or (stringToDecrypt = "")) Then
                Dim a As String = stringToDecrypt
                Dim b As String = ""
                Dim i As Integer

                For i = 0 To a.Length - 2 Step 2
                    b = b & Chr(CInt("&H" & a.Substring(i, 2)))
                Next

                stringToDecrypt = b
                Dim key As String = "g43rd"

                If Len(stringToDecrypt) > Len(key) Then
                    Dim newLen As Integer
                    Dim newKey As String = ""
                    Dim j As Integer
                    newLen = CombienDeFoisMettreDedans(stringToDecrypt, key)
                    For j = 1 To newLen
                        newKey = newKey & key
                    Next j
                    key = newKey
                End If

                stringToDecrypt = Replace(stringToDecrypt, "{?}", "")

                Dim tmp2 As Integer
                Dim tmp1 As String = ""

                For i = 1 To Len(stringToDecrypt)
                    tmp1 = Asc(Mid(stringToDecrypt, i, 1))
                    tmp2 = Asc(Mid(key, i, 1))
                    If tmp1 < tmp2 Then
                        tmp3 = tmp3 & "{?}"
                    Else
                        tmp3 = tmp3 & Chr(tmp1 - tmp2)
                    End If
                Next i

                Return (Guid.Parse(tmp3))
            End If

            Return Nothing
        Catch ex As Exception
            DecryptGuid = Nothing
            Common.WriteError(ex)
            Throw
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Function that returns decrypted string and parsed to String
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Shared Function DecryptStr(ByVal stringToDecrypt As String) As String
        Dim tmp3 As String = ""

        Try
            If Not ((stringToDecrypt Is Nothing) Or (stringToDecrypt = "")) Then
                Dim a As String = stringToDecrypt
                Dim b As String = ""
                Dim i As Integer

                For i = 0 To a.Length - 2 Step 2
                    b = b & Chr(CInt("&H" & a.Substring(i, 2)))
                Next

                stringToDecrypt = b

                Dim key As String = "g43rd"

                If Len(stringToDecrypt) > Len(key) Then
                    Dim newLen As Integer
                    Dim newKey As String = ""
                    Dim j As Integer
                    newLen = CombienDeFoisMettreDedans(stringToDecrypt, key)
                    For j = 1 To newLen
                        newKey = newKey & key
                    Next j
                    key = newKey
                End If

                stringToDecrypt = Replace(stringToDecrypt, "{?}", "")

                Dim tmp2 As Integer
                Dim tmp1 As String = ""

                For i = 1 To Len(stringToDecrypt)
                    tmp1 = Asc(Mid(stringToDecrypt, i, 1))
                    tmp2 = Asc(Mid(key, i, 1))
                    If tmp1 < tmp2 Then
                        tmp3 = tmp3 & "{?}"
                    Else
                        tmp3 = tmp3 & Chr(tmp1 - tmp2)
                    End If
                Next i

                Return tmp3
            End If

            Return Nothing
        Catch ex As Exception
            DecryptStr = Nothing
            Common.WriteError(ex)
            Throw
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Function that returns decrypted string and parsed to datetime
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns>Datetime</returns>
    ''' <remarks></remarks>
    Public Shared Function DecryptDat(ByVal stringToDecrypt As String) As Date
        Dim tmp3 As String = ""

        Try
            If Not ((stringToDecrypt Is Nothing) Or (stringToDecrypt = "")) Then
                Dim a As String = stringToDecrypt
                Dim b As String = ""
                Dim i As Integer

                For i = 0 To a.Length - 2 Step 2
                    b = b & Chr(CInt("&H" & a.Substring(i, 2)))
                Next

                stringToDecrypt = b
                Dim key As String = "g43rd"

                If Len(stringToDecrypt) > Len(key) Then
                    Dim newLen As Integer
                    Dim newKey As String = ""
                    Dim j As Integer
                    newLen = CombienDeFoisMettreDedans(stringToDecrypt, key)
                    For j = 1 To newLen
                        newKey = newKey & key
                    Next j
                    key = newKey
                End If

                stringToDecrypt = Replace(stringToDecrypt, "{?}", "")

                Dim tmp2 As Integer
                Dim tmp1 As String = ""

                For i = 1 To Len(stringToDecrypt)
                    tmp1 = Asc(Mid(stringToDecrypt, i, 1))
                    tmp2 = Asc(Mid(key, i, 1))
                    If tmp1 < tmp2 Then
                        tmp3 = tmp3 & "{?}"
                    Else
                        tmp3 = tmp3 & Chr(tmp1 - tmp2)
                    End If
                Next i

                Return CDate(tmp3)
            End If

            Return Nothing
        Catch ex As Exception
            DecryptDat = Nothing
            Common.WriteError(ex)
            Throw
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Function used for Encrypt and decrypt functions
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="key"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Shared Function CombienDeFoisMettreDedans(ByVal s As String, ByVal key As String) As Integer
        'Verif de la longueur de la clé
        If Len(s) > Len(key) Then
            Dim newLen As Integer
            newLen = Len(key) * (Len(s) / Len(key))
            CombienDeFoisMettreDedans = newLen
        Else
            CombienDeFoisMettreDedans = 1
        End If
    End Function

End Class


