Imports System
Imports System.Net
Imports System.IO.Compression

Public Class Form1
    Private VersionName As String = "3.5"
    Public InstallPath As String = "https://github.com/sebastian2007bro/CV/releases/download/3.0.0.200/Sebs.SW.CV.3.0.zip"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sd As String = ""
            Dim your_mom As New Net.WebClient
            your_mom.DownloadFile("https://raw.githubusercontent.com/sebastian2007bro/CV/master/Info/Version_Now.swfiles", My.Application.Info.DirectoryPath & "\Version")
            sd = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Version")
            If sd.Contains("https://github.com/sebastian2007bro/CV/releases/download") = True Then
                InstallPath = sd
            End If
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Version")
        Catch ex As Exception
            MsgBox("Is Internet working?")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
        Else

            'Try
            'TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
            'Catch ex As Exception
            'End Try
            If TextBox2.Text.Contains("https://github.com/sebastian2007bro/CV/releases/download") = True Then
                Try
                    Dim your_mom As New Net.WebClient
                    your_mom.DownloadFile(TextBox2.Text, TextBox1.Text & "\CVZip.zip")
                Catch ex As Exception

                End Try
                If My.Computer.FileSystem.FileExists(TextBox1.Text & "\CVZip.zip") Then
                    ZipFile.ExtractToDirectory(TextBox1.Text & "\CVZip.zip", TextBox1.Text & "\")
                Else
                    MsgBox("This Failed")
                    Exit Sub
                End If
            Else
                If TextBox2.Text = "" Then
                    Try
                        Dim your_mom As New Net.WebClient
                        your_mom.DownloadFile(InstallPath, TextBox1.Text & "\CVZip.zip")
                    Catch ex As Exception

                    End Try
                    If My.Computer.FileSystem.FileExists(TextBox1.Text & "\CVZip.zip") Then
                        ZipFile.ExtractToDirectory(TextBox1.Text & "\CVZip.zip", TextBox1.Text & "\")
                    Else
                        MsgBox("This Failed")
                        Exit Sub
                    End If
                End If
            End If

            'Installer()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub Downloader()
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        If My.Computer.FileSystem.DirectoryExists(TextBox1.Text) Then
        Else
            Exit Sub
        End If

        Dim UserLocalFolder As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
        Dim UserLocalFolderCompiler As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\CVCompiler"
        My.Computer.FileSystem.CreateDirectory(UserLocalFolder & "\CVCompiler")
        Dim DownloaderClient As New Net.WebClient
        'Downloads 
        'Main program and version manager.
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/CV/" & VersionName & "/Sebs SW CV.exe", UserLocalFolderCompiler & "\CV.exe")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/CV/" & VersionName & "/VersionManager.dll", UserLocalFolderCompiler & "\VersionManager.dll")
        'FontAwesome
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/SomeDll/CV" & VersionName & "/FontAwesome.Sharp.dll", UserLocalFolderCompiler & "\FontAwesome.Sharp.dll")
        'Webview2
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/Webview2/CV" & VersionName & "/Microsoft.Web.WebView2.Core.dll", UserLocalFolderCompiler & "\Microsoft.Web.WebView2.Core.dll")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/Webview2/CV" & VersionName & "/Microsoft.Web.WebView2.WinForms.dll", UserLocalFolderCompiler & "\Microsoft.Web.WebView2.WinForms.dll")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/Webview2/CV" & VersionName & "/Microsoft.Web.WebView2.Wpf.dll", UserLocalFolderCompiler & "\Microsoft.Web.WebView2.Wpf.dll")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/Webview2/CV" & VersionName & "/runtimes/win-x64/native/WebView2Loader.dll", UserLocalFolderCompiler & "\WebView2Loader_x64.dll")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/Webview2/CV" & VersionName & "/runtimes/win-x86/native/WebView2Loader.dll", UserLocalFolderCompiler & "\WebView2Loader_x86.dll")
        'WindowsMediaPlayer
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/WindowsMediaPlayer/CV" & VersionName & "/AxInterop.WMPLib.dll", UserLocalFolderCompiler & "\AxInterop.WMPLib.dll")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/WindowsMediaPlayer/CV" & VersionName & "/Interop.SHDocVw.dll", UserLocalFolderCompiler & "\Interop.SHDocVw.dll")
        DownloaderClient.DownloadFile("https://sbfc-group-download.netlify.app/WindowsMediaPlayer/CV" & VersionName & "/Interop.WMPLib.dll", UserLocalFolderCompiler & "\Interop.WMPLib.dll")

        'Starts to Compile/Install program
        Installer()
    End Sub

    Private Sub Installer()
        Dim UserLocalFolder As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
        Dim UserLocalFolderCompiler As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\CVCompiler"

        CreateFolder("Sebs SW CV")
        CreateFolder("Sebs SW CV\bin")
        CreateFolder("Sebs SW CV\bin\Debug")
        CreateFolder("Sebs SW CV\bin\Debug\Apps")
        CreateFolder("Sebs SW CV\bin\Debug\Settings")
        CreateFolder("Sebs SW CV\bin\Debug\runtimes")
        CreateFolder("Sebs SW CV\bin\Debug\runtimes\win-x64")
        CreateFolder("Sebs SW CV\bin\Debug\runtimes\win-x86")
        CreateFolder("Sebs SW CV\bin\Debug\runtimes\win-x64\native")
        CreateFolder("Sebs SW CV\bin\Debug\runtimes\win-x86\native")

        MoveFile("MainProgram")
        MoveFile("VersionManager")
        MoveFile("webview2core")
        MoveFile("webview2forms")
        MoveFile("webview2wpf")
        MoveFile("webview2loaderx64")
        MoveFile("webview2loaderx86")
        MoveFile("FontThingy")
        MoveFile("media1")
        MoveFile("media2")
        MoveFile("media3")

        AppsOrSettingsCreater(True, "quickedit", "3.5.0")
        AppsOrSettingsCreater(True, "imageview", "3.5.0")
        AppsOrSettingsCreater(True, "swstore", "3.5.0")

        AppsOrSettingsCreater(False, "Menu", "0")
        AppsOrSettingsCreater(False, "Version", "TXk0MUxqQXVNQT09")

        If My.Computer.FileSystem.DirectoryExists(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Settings") Then
            If My.Computer.FileSystem.FileExists(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Settings\settings.config") Then
                My.Computer.FileSystem.WriteAllText(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Settings\settings.config", SettingsConfigString, False)
            End If
        End If

        If TextBox1.Text.EndsWith("\") = True Then
            My.Computer.FileSystem.CopyDirectory(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug", TextBox1.Text)
        Else
            My.Computer.FileSystem.CopyDirectory(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug", TextBox1.Text & "\")
        End If

        'CleanUp()
    End Sub

    Private Sub CreateFolder(DirectoryName As String)
        Dim UserLocalFolderCompiler As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\CVCompiler"
        If My.Computer.FileSystem.DirectoryExists(UserLocalFolderCompiler & "\" & DirectoryName) = True Then
            My.Computer.FileSystem.DeleteDirectory(UserLocalFolderCompiler & "\" & DirectoryName, FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.CreateDirectory(UserLocalFolderCompiler & "\" & DirectoryName)
        ElseIf My.Computer.FileSystem.DirectoryExists(UserLocalFolderCompiler & "\" & DirectoryName) = False Then
            My.Computer.FileSystem.CreateDirectory(UserLocalFolderCompiler & "\" & DirectoryName)
        End If
    End Sub

    Private Sub MoveFile(MovePathName As String)
        Dim UserLocalFolderCompiler As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\CVCompiler"
        If MovePathName = "MainProgram" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\CV.exe", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\CV.exe")
            My.Computer.FileSystem.RenameFile(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\CV.exe", "Sebs SW CV.exe")
        ElseIf MovePathName = "VersionManager" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\VersionManager.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\VersionManager.dll")
        ElseIf MovePathName = "webview2core" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\Microsoft.Web.WebView2.Core.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Microsoft.Web.WebView2.Core.dll")
        ElseIf MovePathName = "webview2forms" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\Microsoft.Web.WebView2.WinForms.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Microsoft.Web.WebView2.WinForms.dll")
        ElseIf MovePathName = "webview2wpf" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\Microsoft.Web.WebView2.Wpf.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Microsoft.Web.WebView2.Wpf.dll")
        ElseIf MovePathName = "webview2loaderx64" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\WebView2Loader_x64.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\runtimes\win-x64\native\WebView2Loader_x64.dll")
            My.Computer.FileSystem.RenameFile(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\runtimes\win-x64\native\WebView2Loader_x64.dll", "WebView2Loader.dll")
        ElseIf MovePathName = "webview2loaderx86" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\WebView2Loader_x86.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\runtimes\win-x86\native\WebView2Loader_x86.dll")
            My.Computer.FileSystem.RenameFile(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\runtimes\win-x86\native\WebView2Loader_x86.dll", "WebView2Loader.dll")
        ElseIf MovePathName = "FontThingy" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\FontAwesome.Sharp.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\FontAwesome.Sharp.dll")
        ElseIf MovePathName = "media1" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\AxInterop.WMPLib.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\AxInterop.WMPLib.dll")
        ElseIf MovePathName = "media2" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\Interop.SHDocVw.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Interop.SHDocVw.dll")
        ElseIf MovePathName = "media3" Then
            My.Computer.FileSystem.MoveFile(UserLocalFolderCompiler & "\Interop.WMPLib.dll", UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Interop.WMPLib.dll")
        End If


    End Sub

    Private Sub AppsOrSettingsCreater(IsApp As Boolean, NameThing As String, Optional Data As String = "")
        Dim UserLocalFolderCompiler As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\CVCompiler"
        If IsApp = True Then
            'This means that this is a app.
            If My.Computer.FileSystem.DirectoryExists(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Apps") Then
                If My.Computer.FileSystem.FileExists(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Apps\" & NameThing & ".swfiles") Then
                    My.Computer.FileSystem.WriteAllText(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Apps\" & NameThing & ".swfiles", Data, False)
                End If
            End If
        ElseIf IsApp = False Then
            'This means that this not a setting.
            If My.Computer.FileSystem.DirectoryExists(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Settings") Then
                If My.Computer.FileSystem.FileExists(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Settings\" & NameThing & ".swfiles") Then
                    My.Computer.FileSystem.WriteAllText(UserLocalFolderCompiler & "\Sebs SW CV\bin\Debug\Settings\" & NameThing & ".swfiles", Data, False)
                End If
            End If
        End If
    End Sub

    Private Sub CleanUp()
        'Dim UserLocalFolderCompiler As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\CVCompiler"
        'My.Computer.FileSystem.DeleteDirectory(UserLocalFolderCompiler, FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently)
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Downloader()
        'If TextBox1.Text = "" Then
        'Else
        'If My.Computer.FileSystem.FileExists(TextBox1.Text & "\CVZip.zip") Then
        'ZipFile.ExtractToDirectory(TextBox1.Text & "\CVZip.zip", TextBox1.Text & "\")
        'Else
        'MsgBox("This Failed")
        'Exit Sub
        'End If
        'Installer()
        'End If
    End Sub

    Private SettingsConfigString As String = "BlockerOld=1
BlockerSebs=0
BlockerNotSebs=0
BlockerAppsInternet=0
BlockerUsercontrol=0
ShowCustomColor=1"

End Class
