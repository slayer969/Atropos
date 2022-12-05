Imports System.Security.Cryptography
Imports System.Text

Public Class NumeriCon

    Public Shared Function hashGen(ByVal sourceText As String) As String
        ' retrieve byte array based on source text, then
        ' compute hash and convert to string
        Return Convert.ToBase64String(New MD5CryptoServiceProvider().
            ComputeHash(New UnicodeEncoding().GetBytes(sourceText)))
    End Function
    Public Shared Function hashCompare(ByVal firstHash As String, ByVal compareText As String) As Boolean
        ' generate hash for compareText
        Dim compareHash = hashGen(compareText)
        ' if lengths are different, fail
        If firstHash.Length <> compareHash.Length Then
            Return False
        Else
            ' otherwise, compare value of each character
            Dim intCount As Integer = 0
            For intCount = 0 To firstHash.Length - 1
                ' fail if different
                If firstHash(intCount) <> compareHash(intCount) Then
                    Return False
                End If
            Next
            Return True
        End If
    End Function

    Public Shared Function ConvNumberLetter(ByVal TheNo As Double, ByVal Langue As Byte) As String
        Dim dblEnt As Object, byDec As Byte
        Dim bNegatif As Boolean
        Dim strDev As String, strCentimes As String
        If TheNo = 0 Then
            ConvNumberLetter = "Zéro"
        Else
            If TheNo < 0 Then
                bNegatif = True
                TheNo = Math.Abs(TheNo)
            End If
            dblEnt = Int(TheNo)
            byDec = CInt((TheNo - dblEnt) * 100)
            If byDec = 0 Then
                If dblEnt > 999999999999999.0# Then
                    ConvNumberLetter = "#TropGrand"
                    Exit Function
                End If
            Else
                If dblEnt > 9999999999999.99 Then
                    ConvNumberLetter = "#TropGrand"
                    Exit Function
                End If
            End If
            strDev = " Dinar"
            strCentimes = " Centime"
            If byDec = 1 Then strCentimes = strCentimes & "."
            If byDec > 1 Then strCentimes = strCentimes & "s."
            If dblEnt > 1 Then strDev = strDev & "s"
            If byDec <> 0 Then
                ConvNumberLetter = ConvNumEnt(CDbl(dblEnt), Langue) & strDev & " et " &
                ConvNumDizaine(byDec, Langue) & strCentimes
            Else : ConvNumberLetter = ConvNumEnt(CDbl(dblEnt), Langue) & strDev & " Algérien."
            End If
        End If
    End Function

    Public Shared Function ConvNumEnt(ByVal TheNo As Double, ByVal Langue As Byte)
        Dim iTmp As Object, dblReste As Double
        Dim strTmp As String

        iTmp = TheNo - (Int(TheNo / 1000) * 1000)
        ConvNumEnt = ConvNumCent(CInt(iTmp), Langue)
        dblReste = Int(TheNo / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = "Mille "
            Case Else
                strTmp = strTmp & " Mille "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt
        dblReste = Int(dblReste / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = strTmp & " Million "
            Case Else
                strTmp = strTmp & " Millions "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt
        dblReste = Int(dblReste / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = strTmp & " Milliard "
            Case Else
                strTmp = strTmp & " Milliards "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt
        dblReste = Int(dblReste / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = strTmp & " Billion "
            Case Else
                strTmp = strTmp & " Billions "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt

    End Function

    Public Shared Function ConvNumDizaine(ByVal TheNo As Byte, ByVal Langue As Byte) As String
        Dim TabUnit As Object, TabDiz As Object
        Dim byUnit As Byte, byDiz As Byte
        Dim strLiaison As String
        Dim array01() As String = {"", "Un", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept",
            "Huit", "Neuf", "Dix", "Onze", "Douze", "Treize", "Quatorze", "Quinze",
            "Seize", "Dix-sept", "Dix-huit", "Dix-neuf"}
        Dim array10() As String = {"", "", "Vingt", "Trente", "Quarante", "Cinquante",
            "Soixante", "Soixante", "Quatre-vingt", "Quatre-vingt"}
        TabUnit = array01
        TabDiz = array10

        byDiz = Int(TheNo / 10)
        byUnit = TheNo - (byDiz * 10)
        strLiaison = "-"
        If byUnit = 1 Then strLiaison = " et "
        Select Case byDiz
            Case 0
                strLiaison = ""
            Case 1
                byUnit = byUnit + 10
                strLiaison = ""
            Case 7
                If Langue = 0 Then byUnit = byUnit + 10
            Case 8
                If Langue <> 2 Then strLiaison = "-"
            Case 9
                If Langue = 0 Then
                    byUnit = byUnit + 10
                    strLiaison = "-"
                End If
        End Select
        ConvNumDizaine = TabDiz(byDiz)
        If byDiz = 8 And Langue <> 2 And byUnit = 0 Then ConvNumDizaine = ConvNumDizaine & "s"
        If TabUnit(byUnit) <> "" Then
            ConvNumDizaine = ConvNumDizaine & strLiaison & TabUnit(byUnit)
        Else
            ConvNumDizaine = ConvNumDizaine
        End If
    End Function

    Public Shared Function ConvNumCent(ByVal TheNo As Integer, ByVal Langue As Byte) As String
        Dim TabUnit As Object
        Dim byCent As Byte, byReste As Byte
        Dim strReste As String
        Dim arrray() As String = {"", "Un", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", "Huit", "Neuf", "Dix"}
        TabUnit = arrray

        byCent = Int(TheNo / 100)
        byReste = TheNo - (byCent * 100)
        strReste = ConvNumDizaine(byReste, Langue)
        Select Case byCent
            Case 0
                ConvNumCent = strReste
            Case 1
                If byReste = 0 Then
                    ConvNumCent = "Cent"
                Else
                    ConvNumCent = "Cent " & strReste
                End If
            Case Else
                If byReste = 0 Then
                    ConvNumCent = TabUnit(byCent) & " Cent"
                Else
                    ConvNumCent = TabUnit(byCent) & " Cent " & strReste
                End If
        End Select
    End Function

End Class