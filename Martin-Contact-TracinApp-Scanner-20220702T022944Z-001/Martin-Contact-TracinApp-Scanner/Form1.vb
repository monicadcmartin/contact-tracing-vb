Imports WebCam_Capture
Imports MessagingToolkit.QRCode.Codec

Public Class Form1
    Dim iExit As DialogResult
    WithEvents MyWebcam As WebCamCapture
    Dim Reader As QRCodeDecoder
    Private Sub MyWebcam_ImageCaptured(source As Object, e As WebcamEventArgs) Handles MyWebcam.ImageCaptured
        PictureBox1.Image = e.WebCamImage

    End Sub
    Private Sub StartWebcam()
        StopWebcam()
        MyWebcam = New WebCamCapture
        MyWebcam.Start(0)

    End Sub
    Private Sub StopWebcam()
        If MyWebcam Is Nothing Then
            MyWebcam = New WebCamCapture
        End If
        MyWebcam.Stop()
        MyWebcam.Dispose()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            StopWebcam()
            Reader = New QRCodeDecoder
            TextBox1.Text = Reader.decode(New Data.QRCodeBitmapImage(PictureBox1.Image))
            MsgBox("QR code is detected!")

        Catch ex As Exception
            MsgBox("QR code is not detected!, Scan Again")
            StartWebcam()
            TextBox1.Clear()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        iExit = MessageBox.Show("Do you want to exit? ", "Contact Tracing Scanner", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If iExit = DialogResult.Yes Then
            Application.Exit()
        Else
            'do nothing
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StartWebcam()
        TextBox1.Clear()
    End Sub

End Class
