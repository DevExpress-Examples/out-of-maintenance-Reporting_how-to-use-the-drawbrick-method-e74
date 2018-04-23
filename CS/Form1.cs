using System;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraPrinting;
// ...


namespace docBrickGraphicsDrawBrick {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Obtain the PrintingSystem's graphics.
            BrickGraphics gr = printingSystem1.Graph;

            // Load an image from a file.
            Image img = Image.FromFile(@"..\..\Fish.png");

            // Create an ImageBrick and specify its properties.
            ImageBrick ibrk = new ImageBrick();
            ibrk.Image = img;
            ibrk.Sides = BorderSide.All;
            ibrk.BorderColor = Color.Blue;
            ibrk.BorderWidth = 10;

            // Start report generation.
            printingSystem1.Begin();

            // Add the ImageBrick to the Detail section of the report.
            RectangleF r = new RectangleF(new PointF(0, 0), new SizeF(256, 160));
            gr.Modifier = BrickModifier.Detail;
            gr.DrawBrick(ibrk, r);
            
            // Finish report generation.
            printingSystem1.End();

            // Display the Print Preview form.
            printingSystem1.PreviewFormEx.Show();
        }

    }
}

