Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient

<WebService(Namespace:="http://Hutao.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Public Class Service
    Inherits System.Web.Services.WebService
    Dim db As New DBOpen()
    <WebMethod(Description:="�ֳ�ע��")> _
    Public Function SC_ZC(ByVal mac As String, ByVal zcm As String) As Boolean
        If db.ScZc(mac, zcm) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    <WebMethod(Description:="�ֳ�ע���ѯ")> _
    Public Function ZC_CX(ByVal mac As String) As String
        Return db.ZcCx(mac)
    End Function

    <WebMethod(Description:="��¼���ݿ�")> _
    Public Function Login(ByVal username As String, ByVal password As String) As Boolean
        'vb.net ���ж��ַ����Ƿ����ʱ �����ִ�Сд sys<>SYS
        If db.login(username, password).Trim().Equals(username) Then
            Return True
        Else
            Return False
        End If
    End Function

    <WebMethod(Description:="��ȡ�ⷿ���")> _
    Public Function ADZHW_CX_KFZH(ByVal czy As String) As String
        Return db.CxKfZh(czy)
    End Function

    <WebMethod(Description:="�ջ�ȷ��")> _
    Public Function ADZHW_SH_CX() As Boolean
        Return True
    End Function

    <WebMethod(Description:="���δ����λ��ѯ")> _
    Public Function ADZHW_RK_WDHW(ByVal cxm As String, ByVal czy As String) As String
        Return db.GetRkWdHw(cxm, czy)
    End Function

    <WebMethod(Description:="�ջ�λ��ѯ")> _
    Public Function KHW_CX(ByVal dztxm As String, ByVal czy As String) As String
        Return db.GetKHw(dztxm, czy)
    End Function

    <WebMethod(Description:="����λȷ��")> _
    Public Function ADZHW_RK_HWQR(ByVal rkxh As Integer, ByVal dztxm As String, ByVal czy As String) As String
        Return db.RkHwQr(rkxh, dztxm, czy)
    End Function

    <WebMethod(Description:="������ҩ�������")> _
    Public Function ADZHW_RK_JGMADD(ByVal rkxh As Integer, ByVal jgm As String, ByVal czy As String) As String
        Return db.RkJgmTj(rkxh, jgm, czy)
    End Function

    <WebMethod(Description:="�����ѯ����")> _
    Public Function ADZHW_CK_CXRW(ByVal rwfs As Integer, ByVal czy As String, ByVal cxm As String) As String
        Return db.CkCxRw(rwfs, czy, cxm)
    End Function

    <WebMethod(Description:="����ȡ����")> _
    Public Function ADZHW_CK_QRW(ByVal czy As String, ByVal ckph As String) As String
        Return db.CkQrw(czy, ckph)
    End Function

    <WebMethod(Description:="��ת��״̬")> _
    Public Function ADZHW_ZZXZT(ByVal zzxm As String, ByVal czy As String) As String
        Return db.GetZzxZt(zzxm, czy)
    End Function

    <WebMethod(Description:="��ת����Ϣ")> _
    Public Function ADZHW_CK_ZZXXX(ByVal zzxm As String, ByVal czy As String) As String
        Return db.GetZzxXx(zzxm, czy)
    End Function

    <WebMethod(Description:="���⸶����")> _
    Public Function ADZHW_CK_FRW(ByVal ckxh As Integer, ByVal ph As String, ByVal zzxm As String, ByVal czy As String) As String
        Return db.CkFrw(ckxh, ph, zzxm, czy)
    End Function

    <WebMethod(Description:="��ת������")> _
    Public Function ADZHW_ZZX_SET(ByVal czy As String, ByVal ct As String) As String
        Return db.GetZzxSet(czy)
    End Function

    <WebMethod(Description:="��ת������")> _
    Public Function ADZHW_CK_ZZXSL(ByVal zzxm As String, ByVal czy As String) As String
        Return db.GetZzxSL(zzxm, czy)
    End Function

    <WebMethod(Description:="��ת����Ϣȷ��")> _
    Public Function ADZHW_CK_ZZXXXQR(ByVal zzxm As String, ByVal ckxh As Integer, ByVal czy As String, ByVal fhsl As Decimal) As String
        Return db.Ck_ZzxXxQr(zzxm, ckxh, czy, fhsl)
    End Function

    <WebMethod(Description:="���������ѯ")> _
    Public Function ADZHW_TH_CXRW(ByVal rwfs As Integer, ByVal czy As String, ByVal cxm As String) As String
        Return db.ThCxRw(rwfs, czy, cxm)
    End Function

    <WebMethod(Description:="����ȡ����")> _
    Public Function ADZHW_TH_QRW(ByVal czy As String, ByVal rwfs As Integer, ByVal ph As String) As String
        Return db.ThQrw(czy, rwfs, ph)
    End Function

    <WebMethod(Description:="����������")> _
    Public Function ADZHW_TH_FRW(ByVal zzxm As String, ByVal ph As String, ByVal dhxh As Integer, ByVal czy As String)
        Return db.ThFrw(zzxm, ph, dhxh, czy)
    End Function

    <WebMethod(Description:="������ת����Ϣ")> _
    Public Function ADZHW_TH_ZZXXX(ByVal zzxm As String, ByVal czy As String) As String
        Return db.ThZzxXx(zzxm, czy)
    End Function

    <WebMethod(Description:="������ת����Ϣȷ��")> _
    Public Function ADZHW_TH_ZZXXXQR(ByVal zzxm As String, ByVal dhxh As Integer, ByVal czy As String, ByVal dhsl As Decimal) As String
        Return db.ThZzxXxQr(zzxm, dhxh, czy, dhsl)
    End Function

    <WebMethod(Description:="����δ����λ��ѯ")> _
    Public Function ADZHW_THSJ_WQR(ByVal cxm As String, ByVal czy As String) As String
        Return db.ThWdHwCx(cxm, czy)
    End Function

    <WebMethod(Description:="������λȷ��")> _
    Public Function ADZHW_THSJ_QR(ByVal dztm As String, ByVal dhxh As Integer, ByVal ph As String, ByVal czy As String) As String
        Return db.ThHwQr(dztm, dhxh, ph, czy)
    End Function

    <WebMethod(Description:="�����˻���Ϣ")> _
    Public Function ADZHW_CKTH_XX(ByVal cxm As String, ByVal czy As String) As String
        Return db.CkThXx(cxm, czy)
    End Function

    <WebMethod(Description:="�����˻�ҩ�������")> _
    Public Function ADZHW_CKTH_JGMADD(ByVal yjm As String, ByVal thxh As Integer, ByVal czy As String) As String
        Return db.CkThJgmAdd(yjm, thxh, czy)
    End Function

    <WebMethod(Description:="�����˻�ȷ��")> _
    Public Function ADZHW_CKTH_QR(ByVal dztm As String, ByVal thxh As Integer, ByVal sl As Decimal, ByVal czy As String) As String
        Return db.CkThQr(dztm, thxh, sl, czy)
    End Function

    <WebMethod(Description:="��ⷵ����Ϣ")> _
    Public Function ADZHW_RKTH_PH(ByVal cxm As String, ByVal czy As String) As String
        Return db.RkThPh(cxm, czy)
    End Function

    <WebMethod(Description:="��ⷵ����ϸ")> _
    Public Function ADZHW_RKTH_MX(ByVal ph As String, ByVal czy As String) As String
        Return db.RkThMx(ph, czy)
    End Function

    <WebMethod(Description:="��ⷵ��ȷ��")> _
    Public Function ADZHW_RKTH_QR(ByVal dztm As String, ByVal rkthxh As Integer, ByVal sl As Decimal, ByVal czy As String) As String
        Return db.RkThQr(dztm, rkthxh, sl, czy)
    End Function

    <WebMethod(Description:="��ⷵ��ҩ�������")> _
    Public Function ADZHW_RKTH_JGMADD(ByVal yjm As String, ByVal rkthxh As Integer, ByVal czy As String) As String
        Return db.RkThYjmAdd(yjm, rkthxh, czy)
    End Function

    <WebMethod(Description:="ƴ�������")> _
    Public Function ADZHW_CK_PXMADD(ByVal pxm As String, ByVal czy As String, ByVal jsr As String) As String
        Return db.CkPxmAdd(pxm, czy, jsr)
    End Function

    <WebMethod(Description:="���⾭���˲�ѯ")> _
    Public Function CxCkJsr() As String
        Return db.GetCkJsr()
    End Function

    <WebMethod(Description:="����ҩ�������")> _
    Public Function ADZHW_CK_JGMADD(ByVal yjm As String, ByVal ckxh As Integer, ByVal czy As String) As String
        Return db.CkYjmAdd(yjm, ckxh, czy)
    End Function

    <WebMethod(Description:="Ʒ�ֻ�λ��ѯ")> _
    Public Function ADZHW_CPHW_CX(ByVal cxm As String, ByVal czy As String) As String
        Return db.GetCpHW(cxm, czy)
    End Function

    <WebMethod(Description:="���Ʒ��δ����λ��ѯ")> _
    Public Function ADZHW_KCCPMDHW_CX(ByVal cxm As String, ByVal czy As String) As String
        Return db.GetKcCpMdHw(cxm, czy)
    End Function
End Class