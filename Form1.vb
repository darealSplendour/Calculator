'加減乘除可使用，只能使用一個運算子，尚未做防呆


Public Class Form1

    Public P_Result As Double = 0, cal As Double = 0, flag As Boolean, oper As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = ""
        TextBox1.Text = "0"
        AddHandler Button0.Click, AddressOf BtnClick
        AddHandler Button1.Click, AddressOf BtnClick
        AddHandler Button2.Click, AddressOf BtnClick
        AddHandler Button3.Click, AddressOf BtnClick
        AddHandler Button4.Click, AddressOf BtnClick
        AddHandler Button5.Click, AddressOf BtnClick
        AddHandler Button6.Click, AddressOf BtnClick
        AddHandler Button7.Click, AddressOf BtnClick
        AddHandler Button8.Click, AddressOf BtnClick
        AddHandler Button9.Click, AddressOf BtnClick
        AddHandler Button10.Click, AddressOf BtnClick '+
        AddHandler Button11.Click, AddressOf BtnClick '-
        AddHandler Button12.Click, AddressOf BtnClick '*
        AddHandler Button13.Click, AddressOf BtnClick '/
        AddHandler Button14.Click, AddressOf BtnClick '=
        AddHandler Button15.Click, AddressOf BtnClick '←
        AddHandler Button16.Click, AddressOf BtnClick 'C
        AddHandler Button17.Click, AddressOf BtnClick 'CE
        AddHandler btnDot.Click, AddressOf BtnClick '.

    End Sub



    Private Sub BtnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim Btn As Button = CType(sender, Button)

        If (TextBox1.Text = "0") Then
            Label1.Text = ""
            TextBox1.Text = ""
        End If

        If (flag) Then
            TextBox1.Text = ""
            flag = False
            If (oper = "=") Then
                Label1.Text = ""
            End If
        End If



        Select Case Btn.Text
            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                'Label1.Text &= Btn.Text
                TextBox1.Text &= Btn.Text

            Case "C" '歸零
                Label1.Text = ""
                TextBox1.Text = "0"
                cal = 0
                P_Result = 0
                Label2.Text = ""

            Case "CE"
                TextBox1.Text = ""

            Case "←" '減少一位數
                Dim length As Integer = TextBox1.TextLength

                If (length <= 1) Then
                    Label1.Text = ""
                    TextBox1.Text = "0"
                Else
                    Label1.Text = Mid(TextBox1.Text, 1, length - 1)
                    TextBox1.Text = Mid(TextBox1.Text, 1, length - 1)
                End If


            Case "+", "-", "*", "/"
                Dim length As Integer = TextBox1.Text.Length() '如果沒輸入數字，長度為0
                If (length > 0) Then
                    Label1.Text = TextBox1.Text
                    Dim last_ksy As Char = Mid(Label1.Text, length, 1)

                    If (last_ksy = "+" Or last_ksy = "-" Or last_ksy = "*" Or last_ksy = "/") Then '檢查是否重複輸入運算子
                        Label1.Text = Mid(Label1.Text, 1, length - 1) + Btn.Text
                        'Label2.Text = "re"
                    Else
                        'Label2.Text = "none"
                        Label1.Text &= Btn.Text
                    End If
                    cal = CDbl(TextBox1.Text)
                    oper = Btn.Text
                    flag = True
                End If

            Case "="
                If (TextBox1.Text <> "") Then
                    Label1.Text = Label1.Text + TextBox1.Text + "="
                    Select Case oper
                        Case "+"
                            P_Result = cal + CDbl(TextBox1.Text)
                        Case "-"
                            P_Result = cal - CDbl(TextBox1.Text)
                        Case "*"
                            P_Result = cal * CDbl(TextBox1.Text)
                        Case "/"
                            P_Result = cal / CDbl(TextBox1.Text)
                    End Select
                    TextBox1.Text = P_Result
                    oper = Btn.Text
                    flag = True
                End If
        End Select
        Label2.Text = flag
    End Sub

End Class
