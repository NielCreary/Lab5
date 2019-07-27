Option Strict On
Imports System.IO
''' <summary>
''' Name:       Niel Creary
''' 
''' Date:       07/26/2019
''' 
''' Assignment: Lab 05
''' 
''' Purpose:    Create a simple text editor to save and open files.
''' 
''' </summary>
Public Class frmMain
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
    ''' <summary>
    ''' Cut selected text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        txtText.Cut()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub
    ''' <summary>
    ''' see more about text editor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About()
    End Sub
    ''' <summary>
    ''' copy selected text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        txtText.Copy()
    End Sub
    ''' <summary>
    ''' Paste copied text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtText.Paste()
    End Sub
    ''' <summary>
    ''' Message for "About"
    ''' </summary>
    Private Sub About()
        MessageBox.Show("NETD-2202" & vbNewLine & vbNewLine & "Lab #5" & vbNewLine & vbNewLine & "N. Creary", "About", MessageBoxButtons.OK)
    End Sub
    
    Private Sub NewNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        NewFile()
        Me.Text = "Text Editor " & SaveFileDialog.FileName
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Text += " Select a file to open"
        Open()
        Me.Text = "Text Editor " & OpenFileDialog.FileName
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        Me.Text += " Save"
        Save()
        Me.Text = "Text Editor " & SaveFileDialog.FileName
    End Sub

    Private Sub SaveAsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem2.Click
        Me.Text += " Save As"
        SaveAs()
        Me.Text = "Text Editor " & SaveFileDialog.FileName
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
    ''' <summary>
    ''' Clears text
    ''' </summary>
    Private Sub NewFile()
        txtText.Clear()
    End Sub
    ''' <summary>
    ''' Opens "OpenFileDialog" to find a file to open
    ''' </summary>
    Private Sub Open()
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog.FileName)
                txtText.Text = reader.ReadToEnd
                reader.Close()
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)
            End Try
        End If

    End Sub
    ''' <summary>
    ''' Saves current file
    ''' </summary>
    Private Sub Save()
        If (File.Exists(OpenFileDialog.FileName)) Then
            My.Computer.FileSystem.WriteAllText(OpenFileDialog.FileName, txtText.Text, True)
        ElseIf (File.Exists(SaveFileDialog.FileName)) Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, txtText.Text, True)
        Else
            SaveAs()
        End If

    End Sub
    ''' <summary>
    ''' Saves file and allows to change name or location
    ''' </summary>
    Private Sub SaveAs()
        SaveFileDialog.Filter = "TXT Files (*.txt*)|*.txt"

        If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, txtText.Text, False)
        End If

    End Sub

End Class
