Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraPrinting
' ...


Namespace docBrickGraphicsDrawBrick
	Public Partial Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click
            ' Obtain the PrintingSystem's graphics.
            Dim gr As BrickGraphics = printingSystem1.Graph

            ' Load an image from a file.
            Dim img As Image = Image.FromFile("..\..\Fish.png")

            ' Create an ImageBrick and specify its properties.
            Dim ibrk As ImageBrick = New ImageBrick()
            ibrk.Image = img
            ibrk.Sides = BorderSide.All
            ibrk.BorderColor = Color.Blue
            ibrk.BorderWidth = 10

            ' Start report generation.
            printingSystem1.Begin()

            ' Add the ImageBrick to the Detail section of the report.
            Dim r As RectangleF = New RectangleF(New PointF(0, 0), New SizeF(256, 160))
            gr.Modifier = BrickModifier.Detail
            gr.DrawBrick(ibrk, r)

            ' Finish report generation.
            printingSystem1.End()

            ' Display the Print Preview form.
            printingSystem1.PreviewFormEx.Show()
        End Sub

	End Class
End Namespace