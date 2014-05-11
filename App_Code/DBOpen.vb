Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class DBOpen

    Private DataSource As String

    Private InitialCatalog As String

    Private UserId As String

    Private Password As String

    Dim StrCon As String

    Shared Conn As SqlConnection

    Dim CmdLog As SqlCommand

    Dim CmdSel As SqlCommand

    Dim CmdSP As SqlCommand

    Dim Da As New SqlDataAdapter()

    Dim Ds As New DataSet()

    Dim Str As String


    Private Const LOGIN_TIPS As String = "没有登录，请登录"

    Function InitStrCon() As String
        DataSource = "Data Source=" & ConfigurationManager.AppSettings("DataSource")
        InitialCatalog = "Initial Catalog=" & ConfigurationManager.AppSettings("InitialCatalog")
        UserId = "User Id=" & ConfigurationManager.AppSettings("UserId")
        Password = "Password=" & ConfigurationManager.AppSettings("Password")
        StrCon = DataSource & ";" & InitialCatalog & ";" & UserId & ";" & Password
        Return StrCon
    End Function

    Function ScZc(ByVal mac As String, ByVal zcm As String) As Integer
        Conn = New SqlConnection(InitStrCon())
        Conn.Open()
        CmdLog = New SqlCommand("insert into SC_M(地址,注册码)values('" & mac & "','" & zcm & "')", Conn)
        Return CmdLog.ExecuteNonQuery()
    End Function

    Function ZcCx(ByVal mac As String) As String
        Conn = New SqlConnection(InitStrCon())
        CmdSel = New SqlCommand("ADZHW_ZCCX '" & mac & "'", Conn)
        Da.SelectCommand = CmdSel
        Da.Fill(Ds, "ZC_CX")
        Return Ds.GetXml
    End Function

    Function Login(ByVal username As String, ByVal password As String) As String
        Try
            DataSource = "Data Source=" & ConfigurationManager.AppSettings("DataSource")
            InitialCatalog = "Initial Catalog=" & ConfigurationManager.AppSettings("InitialCatalog")
            StrCon = DataSource & ";" & InitialCatalog & ";User ID=" & username & ";Password=" & password
            Conn = New SqlConnection(StrCon)
            CmdLog = New SqlCommand("select * from emma where 代码='" & username & "'", Conn)
            Da.SelectCommand = CmdLog
            Da.Fill(Ds, "login_info")
            Return Ds.Tables(0).Rows.Item(0).Item(0)
        Catch exc As Exception
            Return exc.Message
        End Try
    End Function

    Function CxKfZh(ByVal czy As String) As String

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CX_KFZH", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "KFZH")
            Return Ds.GetXml()
        End If
    End Function

    Function GetRkWdHw(ByVal cxm As String, ByVal czy As String) As String

        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RK_WDHW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RK_WDHW")
            Return Ds.GetXml()
        End If
    End Function

    Function GetKHw(ByVal dztxm As String, ByVal czy As String) As String

        Dim SqlDztxm As New SqlParameter("@dztxm", SqlDbType.VarChar)
        SqlDztxm.Value = dztxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("KHW_CX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlDztxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "KHW_CX")
            Return Ds.GetXml()
        End If
    End Function

    Function RkHwQr(ByVal rkxh As Integer, ByVal dztxm As String, ByVal czy As String) As String

        Dim SqlRkxh As New SqlParameter("@rkxh", SqlDbType.Int)
        SqlRkxh.Value = rkxh

        Dim SqlDztxm As New SqlParameter("@dztxm", SqlDbType.VarChar)
        SqlDztxm.Value = dztxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RK_HWQR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlRkxh)
            CmdSel.Parameters.Add(SqlDztxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RK_HWQR")
            Return Ds.GetXml()
        End If
    End Function

    Function RkJgmTj(ByVal rkxh As Integer, ByVal jgm As String, ByVal czy As String) As String

        Dim SqlRkxh As New SqlParameter("@rkxh", SqlDbType.Int)
        SqlRkxh.Value = rkxh

        Dim SqlJgm As New SqlParameter("@yjm", SqlDbType.VarChar)
        SqlJgm.Value = jgm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RK_JGMADD", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlRkxh)
            CmdSel.Parameters.Add(SqlJgm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RK_JGM")
            Return Ds.GetXml()
        End If
    End Function

    Function CkCxRw(ByVal rwfs As Integer, ByVal czy As String, ByVal cxm As String) As String

        Dim SqlRwfs As New SqlParameter("@rwfs", SqlDbType.Int)
        SqlRwfs.Value = rwfs

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_CXRW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlRwfs)
            CmdSel.Parameters.Add(SqlCzy)
            CmdSel.Parameters.Add(SqlCxm)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_CXRW")
            Return Ds.GetXml()
        End If
    End Function

    Function CkQrw(ByVal czy As String, ByVal ckph As String) As String

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        Dim SqlCkph As New SqlParameter("@ckph", SqlDbType.VarChar)
        SqlCkph.Value = ckph

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_QRW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCzy)
            CmdSel.Parameters.Add(SqlCkph)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_QRW")
            Return Ds.GetXml()
        End If
    End Function

    Function GetZzxZt(ByVal zzxm As String, ByVal czy As String) As String

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_ZZXZT", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "ZZXZT")
            Return Ds.GetXml()
        End If
    End Function

    Function GetZzxXx(ByVal zzxm As String, ByVal czy As String) As String

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_ZZXXX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_ZZXXX")
            Return Ds.GetXml()
        End If
    End Function

    Function CkFrw(ByVal ckxh As Integer, ByVal ph As String, ByVal zzxm As String, ByVal czy As String) As String

        Dim SqlCkxh As New SqlParameter("@ckxh", SqlDbType.Int)
        SqlCkxh.Value = ckxh

        Dim SqlPh As New SqlParameter("@ph", SqlDbType.VarChar)
        SqlPh.Value = ph

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_FRW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCkxh)
            CmdSel.Parameters.Add(SqlPh)
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlCzy)

            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_FRE")
            Return Ds.GetXml()
        End If
    End Function

    Function GetZzxSet(ByVal czy As String) As String

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_ZZX_SET", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "ZZX_SET")
            Return Ds.GetXml
        End If
    End Function

    Function GetZzxSL(ByVal zzxm As String, ByVal czy As String) As String

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_ZZXSL", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "ZZX_SL")
            Return Ds.GetXml
        End If
    End Function

    Function Ck_ZzxXxQr(ByVal zzxm As String, ByVal ckxh As Integer, ByVal czy As String, ByVal fhsl As Decimal) As String

        Dim sqlzzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        sqlzzxm.Value = zzxm

        Dim sqlckxh As New SqlParameter("@ckxh", SqlDbType.Int)
        sqlckxh.Value = ckxh

        Dim sqlczy As New SqlParameter("@czy", SqlDbType.VarChar)
        sqlczy.Value = czy

        Dim sqlfhsl As New SqlParameter("@fhsl", SqlDbType.Decimal)
        sqlfhsl.Value = fhsl

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_ZZXXXQR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(sqlzzxm)
            CmdSel.Parameters.Add(sqlckxh)
            CmdSel.Parameters.Add(sqlczy)
            CmdSel.Parameters.Add(sqlfhsl)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "ZZXXXQR")
            Return Ds.GetXml
        End If
    End Function

    

    Function ThCxRw(ByVal rwfs As Integer, ByVal czy As String, ByVal cxm As String) As String
        Dim sqlrwfs As New SqlParameter("@rwfs", SqlDbType.Int)
        sqlrwfs.Value = rwfs

        Dim sqlczy As New SqlParameter("@czy", SqlDbType.VarChar)
        sqlczy.Value = czy

        Dim sqlcxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        sqlcxm.Value = cxm

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_TH_CXRW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(sqlrwfs)
            CmdSel.Parameters.Add(sqlczy)
            CmdSel.Parameters.Add(sqlcxm)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_CX_RW")
            Return Ds.GetXml()
        End If
    End Function

    Function ThQrw(ByVal czy As String, ByVal rwfs As Integer, ByVal ph As String) As String

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        Dim SqlRwfs As New SqlParameter("@rwfs", SqlDbType.Int)
        SqlRwfs.Value = rwfs

        Dim SqlPh As New SqlParameter("@ph", SqlDbType.VarChar)
        SqlPh.Value = ph

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_TH_QRW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCzy)
            CmdSel.Parameters.Add(SqlRwfs)
            CmdSel.Parameters.Add(SqlPh)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_QRW")
            Return Ds.GetXml()
        End If

    End Function

    Function ThFrw(ByVal zzxm As String, ByVal ph As String, ByVal dhxh As Integer, ByVal czy As String) As String

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlPh As New SqlParameter("@ph", SqlDbType.VarChar)
        SqlPh.Value = ph

        Dim SqlDhXh As New SqlParameter("@dhxh", SqlDbType.Int)
        SqlDhXh.Value = dhxh

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_TH_FRW", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlPh)
            CmdSel.Parameters.Add(SqlDhXh)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_FRW")
            Return Ds.GetXml()
        End If

    End Function

    Function ThZzxXx(ByVal zzxm As String, ByVal czy As String) As String

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_TH_ZZXXX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_ZZXXX")
            Return Ds.GetXml()
        End If
    End Function

    Function ThZzxXxQr(ByVal zzxm As String, ByVal dhxh As Integer, ByVal czy As String, ByVal dhsl As Decimal) As String

        Dim SqlZzxm As New SqlParameter("@zzxm", SqlDbType.VarChar)
        SqlZzxm.Value = zzxm

        Dim SqlDhXh As New SqlParameter("@dhxh", SqlDbType.Int)
        SqlDhXh.Value = dhxh

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        Dim SqlDhsl As New SqlParameter("@dhsl", SqlDbType.Decimal)
        SqlDhsl.Value = dhsl

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_TH_ZZXXXQR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlZzxm)
            CmdSel.Parameters.Add(SqlDhXh)
            CmdSel.Parameters.Add(SqlCzy)
            CmdSel.Parameters.Add(SqlDhsl)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_ZZXXXQR")
            Return Ds.GetXml()
        End If

    End Function

    Function ThWdHwCx(ByVal cxm As String, ByVal czy As String) As String

        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_THSJ_WQR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_WDHW_CX")
            Return Ds.GetXml()
        End If
    End Function

    Function ThHwQr(ByVal dztm As String, ByVal dhxh As Integer, ByVal ph As String, ByVal czy As String) As String

        Dim SqlDztm As New SqlParameter("@dztm", SqlDbType.VarChar)
        SqlDztm.Value = dztm

        Dim SqlDhxh As New SqlParameter("@dhxh", SqlDbType.Int)
        SqlDhxh.Value = dhxh

        Dim SqlPh As New SqlParameter("@ph", SqlDbType.VarChar)
        SqlPh.Value = ph

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_THSJ_QR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlDztm)
            CmdSel.Parameters.Add(SqlDhxh)
            CmdSel.Parameters.Add(SqlPh)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "TH_HWQR")
            Return Ds.GetXml()
        End If
    End Function

    Function CkThXx(ByVal cxm As String, ByVal czy As String) As String

        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CKTH_XX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CKTHXX")
            Return Ds.GetXml()
        End If
    End Function

    Function CkThJgmAdd(ByVal yjm As String, ByVal thxh As Integer, ByVal czy As String) As String

        Dim SqlYjm As New SqlParameter("@yjm", SqlDbType.VarChar)
        SqlYjm.Value = yjm

        Dim SqlThXh As New SqlParameter("@thxh", SqlDbType.Int)
        SqlThXh.Value = thxh

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy
        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CKTH_JGMADD", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlYjm)
            CmdSel.Parameters.Add(SqlThXh)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_YJM_ADD")
            Return Ds.GetXml()
        End If
    End Function

    Function CkThQr(ByVal dztm As String, ByVal thxh As Integer, ByVal sl As Decimal, ByVal czy As String) As String

        Dim SqlDztm As New SqlParameter("@dztm", SqlDbType.VarChar)
        SqlDztm.Value = dztm

        Dim SqlThXh As New SqlParameter("@thxh", SqlDbType.Int)
        SqlThXh.Value = thxh

        Dim SqlSl As New SqlParameter("@sl", SqlDbType.Decimal)
        SqlSl.Value = sl

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CKTH_QR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlDztm)
            CmdSel.Parameters.Add(SqlThXh)
            CmdSel.Parameters.Add(SqlSl)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_TH_QR")
            Return Ds.GetXml()
        End If
    End Function

    Function RkThPh(ByVal cxm As String, ByVal czy As String) As String
        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RKTH_PH", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RKTHXX")
            Return Ds.GetXml()
        End If
    End Function

    Function RkThMx(ByVal ph As String, ByVal czy As String) As String
        Dim SqlPh As New SqlParameter("@ph", SqlDbType.VarChar)
        SqlPh.Value = ph

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RKTH_MX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlPh)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RKTHMX")
            Return Ds.GetXml()
        End If
    End Function


    Function RkThQr(ByVal dztm As String, ByVal rkthxh As Integer, ByVal sl As Decimal, ByVal czy As String) As String
        Dim SqlDztm As New SqlParameter("@dztm", SqlDbType.VarChar)
        SqlDztm.Value = dztm

        Dim SqlRkThXh As New SqlParameter("@rkthxh", SqlDbType.Int)
        SqlRkThXh.Value = rkthxh

        Dim SqlSl As New SqlParameter("@sl", SqlDbType.Decimal)
        SqlSl.Value = sl

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RKTH_QR", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlDztm)
            CmdSel.Parameters.Add(SqlRkThXh)
            CmdSel.Parameters.Add(SqlSl)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RKTHQR")
            Return Ds.GetXml()
        End If
    End Function

    Function RkThYjmAdd(ByVal yjm As String, ByVal rkthxh As Integer, ByVal czy As String) As String
        Dim SqlYjm As New SqlParameter("@yjm", SqlDbType.VarChar)
        SqlYjm.Value = yjm

        Dim SqlRkThXh As New SqlParameter("@rkthxh", SqlDbType.Int)
        SqlRkThXh.Value = rkthxh

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_RKTH_JGMADD", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlYjm)
            CmdSel.Parameters.Add(SqlRkThXh)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "RKTHYJMADD")
            Return Ds.GetXml()
        End If
    End Function

    Function CkPxmAdd(ByVal pxm As String, ByVal czy As String, ByVal jsr As String) As String
        Dim SqlPxm As New SqlParameter("@pxm", SqlDbType.VarChar)
        SqlPxm.Value = pxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        Dim SqlJsr As New SqlParameter("@jsr", SqlDbType.VarChar)
        SqlJsr.Value = jsr

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_PXMADD", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlPxm)
            CmdSel.Parameters.Add(SqlCzy)
            CmdSel.Parameters.Add(SqlJsr)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_PXM")
            Return Ds.GetXml()
        End If

    End Function

    Function GetCkJsr() As String
        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("select hz from apyhz where lb='出库经手人'", Conn)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_JSR")
            Return Ds.GetXml()
        End If
    End Function

    Function CkYjmAdd(ByVal yjm As String, ByVal ckxh As Integer, ByVal czy As String) As String
        Dim SqlYjm As New SqlParameter("@yjm", SqlDbType.VarChar)
        SqlYjm.Value = yjm

        Dim SqlCkxh As New SqlParameter("@ckxh", SqlDbType.Int)
        SqlCkxh.Value = ckxh

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CK_JGMADD", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlYjm)
            CmdSel.Parameters.Add(SqlCkxh)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CK_JGM")
            Return Ds.GetXml()
        End If
    End Function

    Function GetCpHW(ByVal cxm As String, ByVal czy As String) As String
        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_CPHW_CX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "CP_HW")
            Return Ds.GetXml()
        End If
    End Function

    Function GetKcCpMdHw(ByVal cxm As String, ByVal czy As String) As String
        Dim SqlCxm As New SqlParameter("@cxm", SqlDbType.VarChar)
        SqlCxm.Value = cxm

        Dim SqlCzy As New SqlParameter("@czy", SqlDbType.VarChar)
        SqlCzy.Value = czy

        If Conn Is Nothing Then
            Return LOGIN_TIPS
        Else
            CmdSel = New SqlCommand("ADZHW_KCCPMDHW_CX", Conn)
            CmdSel.CommandType = CommandType.StoredProcedure
            CmdSel.Parameters.Add(SqlCxm)
            CmdSel.Parameters.Add(SqlCzy)
            Da.SelectCommand = CmdSel
            Da.Fill(Ds, "KCCPMDHW")
            Return Ds.GetXml()
        End If
    End Function

End Class
