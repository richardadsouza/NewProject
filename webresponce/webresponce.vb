Imports System.Net.HttpWebResponse
Imports System.Net.HttpWebRequest
Imports System.Net
Imports System.Text
Imports System.IO


Namespace groceryguys

    Public Class authorizenet
        Public mode As Integer
        Public arr_ccauthresponse As New Hashtable
        Public PostData As String
        'Public postdata As Stream

        Public arr_ccauthfields(19) As String
        Public strStatus As Integer
        Public strRetval As String
        Public strArrayVal() As String
        Dim Tid, tidGet As String
        Dim strsendinfo() As String

        'Public XMLReq = New MSXML.XMLHTTPRequest

        Public Sub New()
            mode = 0
            'Dim arr_ccauthresponse As New Hashtable
        End Sub
        Public Sub Dispose()
            arr_ccauthresponse = Nothing
        End Sub
        Public Function Initialize(ByVal param As String)
            GenPostdata(param)
            'Return GenPostdata(param)
        End Function
        Public Function GenPostdata(ByVal param1 As String)
            Dim i, j As Integer

            ' Dim strsendinfo() As String
            strsendinfo = Split(param1, ",", -1)


            ' Set these static fields based on current debugging mode
            If mode = 0 Then
                '******** This is for groomeez ********


                ' arr_ccauthfields(0) = "x_Login=groomeez1"


                'arr_ccauthfields(0) = "x_Login=cnp100222" 'test account
                'arr_ccauthfields(0) = "x_Login=2A9zZb349" 'test account
                'arr_ccauthfields(0) = "x_Login=7j3qT9Eb" 'LIVE account

                arr_ccauthfields(0) = "x_Login=" & strsendinfo(0) 'test account"
                arr_ccauthfields(1) = "&x_Version=3.1"   ' Our request message version
                arr_ccauthfields(2) = "&x_Test_Request=FALSE"  ' Set test flag for this transaction
                arr_ccauthfields(3) = "&x_ADC_Delim_Data=TRUE"  ' Request reply in comma delimited format
                arr_ccauthfields(4) = "&x_ADC_URL=FALSE"  ' Do not redirect since we are sending post from backend
                arr_ccauthfields(5) = "&x_type=" & strsendinfo(1) ' Do not redirect since we are sending post from backend
                ' arr_ccauthfields(6) = "&x_method=CC"  ' Do not redirect since we are sending post from backend
                ' arr_ccauthfields.Add("x_type", "AUTH_CAPTURE");
                'post_values.Add("x_method", "CC");

            Else
                '******** This is for groomeez AUTH_ONLY ********

                ' arr_ccauthfields(0) = "&x_Login=groomeez1"

                'arr_ccauthfields(0) = "x_Login=cnp100222" 'test account
                'arr_ccauthfields(0) = "x_Login=2A9zZb349" 'test account
                'arr_ccauthfields(0) = "x_Login=7j3qT9Eb" 'Live account

                arr_ccauthfields(0) = "x_Login=" & strsendinfo(0) 'test account"
                arr_ccauthfields(1) = "&x_Version=3.1"   ' Our request message version stays the same
                arr_ccauthfields(2) = "&x_Test_Request=FALSE"  ' Set prod flag for this transaction
                arr_ccauthfields(3) = "&x_ADC_Delim_Data=TRUE"  ' Request reply in comma delimited format
                arr_ccauthfields(4) = "&x_ADC_URL=FALSE"  ' Do not redirect since we are sending post from backend
                arr_ccauthfields(5) = "&x_type=" & strsendinfo(1)
                '********		End			   ********



            End If

            PostData = Join(arr_ccauthfields, "")

            arr_ccauthfields(6) = "x_Card_Num"
            arr_ccauthfields(7) = "x_Exp_Date"
            arr_ccauthfields(8) = "x_Description"
            arr_ccauthfields(9) = "x_Amount"
            arr_ccauthfields(10) = "x_First_Name"
            arr_ccauthfields(11) = "x_Last_Name"
            arr_ccauthfields(12) = "x_company"
            arr_ccauthfields(13) = "x_Address"
            arr_ccauthfields(14) = "x_City"
            arr_ccauthfields(15) = "x_State"
            arr_ccauthfields(16) = "x_ZIP"
            arr_ccauthfields(17) = "x_Phone"
            arr_ccauthfields(18) = "x_Email"
            arr_ccauthfields(19) = "x_country"


            j = 4
            For i = 6 To UBound(arr_ccauthfields)
                ' inputname = arr_ccauthfields(i)
                Dim s = arr_ccauthfields(i)
                Dim v = strsendinfo(j)
                PostData = PostData & "&" & arr_ccauthfields(i) & "=" & strsendinfo(j)
                j = j + 1
            Next i
            GenPostdata = PostData
            Return GenPostdata
        End Function
        Public Function transmit() As Boolean

            'PostData = PostData & "&x_Password=jvette1"
            'PostData = PostData & "&x_Password=authnet001" 'test account password
            'PostData = PostData & "&x_Password=2nZbS229Jx3B95uB" 'test account password
            'PostData = PostData & "&x_Password=2qxb537qS7k3X8Bp" ' LIVE Account
            PostData = PostData & "&x_Password=" & strsendinfo(2) 'test account password
            ' Dim newUri As New Uri("http://64.202.165.130:3128")
            'Dim myProxy As New WebProxy(newUri)
            'Dim myWebRequest As HttpWebRequest = WebRequest.Create("https://secure.authorize.net/gateway/transact.dll")
            ' Dim myWebRequest As HttpWebRequest = WebRequest.Create("https://test.authorize.net/gateway/transact.dll")


            Dim myWebRequest As HttpWebRequest = WebRequest.Create(strsendinfo(3).ToString())
            ' myWebRequest.Proxy = myProxy
            myWebRequest.Method = "Post"
            Dim postarray As Byte()
            postarray = Encoding.ASCII.GetBytes(PostData)

            myWebRequest.ContentLength = postarray.Length
            myWebRequest.ContentType = "application/x-www-form-urlencoded"

            Dim requeststream As Stream = myWebRequest.GetRequestStream
            requeststream.Write(postarray, 0, postarray.Length)
            requeststream.Close()
            Dim myWebResponse As HttpWebResponse = myWebRequest.GetResponse()
            strStatus = myWebResponse.StatusCode
            requeststream = myWebResponse.GetResponseStream()
            Dim readstream As StreamReader = New StreamReader(requeststream, True)
            strRetval = readstream.ReadToEnd
            strArrayVal = Split(strRetval, ",", -1)
            genresponseFields()

            If (strStatus <> 200) Then
                Return False
                'response.Write("An error occured during processing.  " & "Please try again later." & strStatus)
            Else
                If arr_ccauthresponse("x_response_code").Equals("1") Then
                    tidGet = arr_ccauthresponse("x_trans_id")
                    get_Tid = tidGet
                    Return True

                    'Response.Write("Thank you for your purchase.(Transaction has been approved)")
                ElseIf arr_ccauthresponse("x_response_code").Equals("2") Then
                    Return False
                    ' Response.Write("Transaction has been declined")
                Else
                    Return False
                    'Response.Write("There has been error while processing this transaction." & "Please try again later." & x_response_code)
                End If
            End If

        End Function
        Public Property get_Tid() As String
            Get
                Return Tid
            End Get
            Set(ByVal value As String)
                Tid = value
            End Set
        End Property
        Public Function genresponseFields()
            arr_ccauthresponse.Add("x_response_code", strArrayVal(0))
            Dim str As String = strArrayVal(0)
            'Response Code:
            '1 = This transaction has been approved.
            '2 = This transaction has been declined.
            '3 = There has been an error processing this transaction.

            arr_ccauthresponse.Add("x_response_subcode", strArrayVal(1))
            arr_ccauthresponse.Add("x_response_reason_code", strArrayVal(2))
            arr_ccauthresponse.Add("x_response_reason_text", strArrayVal(3))
            arr_ccauthresponse.Add("x_auth_code", strArrayVal(4)) '6 digit approval code
            arr_ccauthresponse.Add("x_avs_code", strArrayVal(5))
            'Address Verification system:
            'A = Address (street) matches, Zip does not
            'E = AVS error
            'N = No match on address or zip
            'P = AVS Not Applicable
            'R = Retry, system unavailable or timed out
            'S = service not supported by issuer
            'U = address information is unavailable
            'W = 9 digit Zip matches, address does not
            'X = exact AVS match
            'Y = address and 5 digit zip match
            'Z = 5 digit zip matches, address does not

            arr_ccauthresponse.Add("x_trans_id", strArrayVal(6)) 'transaction id
            arr_ccauthresponse.Add("x_invoice_num", strArrayVal(7))
            arr_ccauthresponse.Add("x_description", strArrayVal(8))
            arr_ccauthresponse.Add("x_amount", strArrayVal(9))
            arr_ccauthresponse.Add("x_method", strArrayVal(10))
            arr_ccauthresponse.Add("x_type", strArrayVal(11))
            arr_ccauthresponse.Add("x_cust_id", strArrayVal(12))
            arr_ccauthresponse.Add("x_first_name", strArrayVal(13))
            arr_ccauthresponse.Add("x_last_name", strArrayVal(14))
            arr_ccauthresponse.Add("x_company", strArrayVal(15))
            arr_ccauthresponse.Add("x_address", strArrayVal(16))
            arr_ccauthresponse.Add("x_city", strArrayVal(17))
            arr_ccauthresponse.Add("x_state", strArrayVal(18))
            arr_ccauthresponse.Add("x_zip", strArrayVal(19))
            arr_ccauthresponse.Add("x_country", strArrayVal(20))
            arr_ccauthresponse.Add("x_phone", strArrayVal(21))
            arr_ccauthresponse.Add("x_email", strArrayVal(23))
            arr_ccauthresponse.Add("x_fax", strArrayVal(22))

            arr_ccauthresponse.Add("x_ship_to_first_name", strArrayVal(24))
            arr_ccauthresponse.Add("x_ship_to_last_name", strArrayVal(25))
            arr_ccauthresponse.Add("x_ship_to_company", strArrayVal(26))
            arr_ccauthresponse.Add("x_ship_to_address", strArrayVal(27))
            arr_ccauthresponse.Add("x_ship_to_city", strArrayVal(28))
            arr_ccauthresponse.Add("x_ship_to_state", strArrayVal(29))
            arr_ccauthresponse.Add("x_ship_to_zip", strArrayVal(30))
            arr_ccauthresponse.Add("x_ship_to_country", strArrayVal(31))
            arr_ccauthresponse.Add("x_tax", strArrayVal(32))
            arr_ccauthresponse.Add("x_duty", strArrayVal(33))
            arr_ccauthresponse.Add("x_freight", strArrayVal(34))
            arr_ccauthresponse.Add("x_tax_exempt", strArrayVal(35))
            arr_ccauthresponse.Add("x_po_num", strArrayVal(36))
            arr_ccauthresponse.Add("x_md5_hash", strArrayVal(37))
        End Function




    End Class

End Namespace

