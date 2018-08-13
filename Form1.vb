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

        Select Case Btn.Text
            Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
                If (TextBox1.Text = "0") Then
                    Label1.Text = ""
                    TextBox1.Text = ""
                End If

                If (flag) Then
                    TextBox1.Text = ""
                    If (oper = "=") Then
                        Label1.Text = ""
                        oper = ""
                    End If
                End If

                Label1.Text &= ""
                TextBox1.Text &= Btn.Text
                flag = False

            Case "CE"
                TextBox1.Text = ""

            Case "C" '歸零
                Label1.Text = ""
                TextBox1.Text = "0"
                cal = 0
                P_Result = 0
                oper = ""
                'Label2.Text = ""

            Case "←" '減少一位數
                Dim length As Integer = TextBox1.TextLength

                If (length <= 1) Then
                    TextBox1.Text = "0"
                Else
                    TextBox1.Text = Mid(TextBox1.Text, 1, length - 1)
                End If

            Case "+", "-", "*", "/"
                Dim length As Integer = TextBox1.TextLength '如果沒輸入數字，長度為0

                If (length > 0) Then
                    If (oper = "") Then
                        Label1.Text = TextBox1.Text
                        cal = CDbl(TextBox1.Text)
                    Else
                        If (oper = "=") Then
                            cal = CDbl(TextBox1.Text)
                            Label1.Text = P_Result
                        Else
                            cal = CDbl(Mid(Label1.Text, 1, Label1.Text.Length - 1))
                        End If

                        Select Case oper
                            Case "+"
                                P_Result = cal + CDbl(TextBox1.Text)
                                Label1.Text = P_Result
                            Case "-"
                                P_Result = cal - CDbl(TextBox1.Text)
                                Label1.Text = P_Result
                            Case "*"
                                P_Result = cal * CDbl(TextBox1.Text)
                                Label1.Text = P_Result
                            Case "/"
                                P_Result = cal / CDbl(TextBox1.Text)
                                Label1.Text = P_Result
                        End Select
                    End If
                End If

                Dim last_key As Char = Mid(Label1.Text, Label1.Text.Length, 1)

                If (last_key = "+" Or last_key = "-" Or last_key = "*" Or last_key = "/" Or last_key = ".") Then '檢查是否重複輸入運算子
                    Label1.Text = Mid(Label1.Text, 1, Label1.Text.Length - 1) + Btn.Text
                Else
                    Label1.Text &= Btn.Text
                End If

                oper = Btn.Text
                flag = True
                TextBox1.Text = ""

            Case "="
                If (Label1.Text <> "") Then
                    If (Mid(Label1.Text, Label1.Text.Length, 1) <> "=") Then
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
                        Else
                            Label1.Text = ""
                            TextBox1.Text = cal
                        End If
                    Else
                        TextBox1.Text = P_Result
                    End If
                    flag = True
                End If

            Case "."
                Dim length As Integer = TextBox1.TextLength '確認textbox1裡面是否有值

                If (length > 0) Then
                    If (TextBox1.Text.Contains(".") = False) Then
                        TextBox1.Text &= "."
                    End If
                Else
                    TextBox1.Text = "0"
                End If
        End Select

    End Sub

End Class
