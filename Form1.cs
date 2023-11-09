using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircleDrawingApp
{
    public partial class Form1 : Form
    {
        private Pen circlePenGreen = new Pen(Color.Green, 2); // Pen for drawing the circle when mouse is inside
        private Pen circlePenRed = new Pen(Color.Red, 2); // Pen for drawing the circle when mouse is outside

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black; // Set form's background color to black
            this.MouseMove += Form1_MouseMove; // Subscribe to MouseMove event
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            int circleDiameter = Math.Min(ClientSize.Width, ClientSize.Height) - 20; // Diameter of the circle
            int circleRadius = circleDiameter / 2;

            // Calculate the center of the circle
            int circleCenterX = ClientSize.Width / 2;
            int circleCenterY = ClientSize.Height / 2;

            // Calculate the distance between mouse pointer and circle center
            // Lägg till koden som behövs.
            double distance = Math.Sqrt(Math.Pow(mouseX - circleCenterX,2) + Math.Pow(mouseY - circleCenterY,2));

            // Change circle color based on mouse position
            using (Graphics g = CreateGraphics())
            {
                // Clear the previous circle
                g.Clear(Color.Black);

                // Draw the circle with appropriate color (green inside, red outside)
                Pen circlePen = (distance <= circleRadius) ? circlePenGreen : circlePenRed;
                g.DrawEllipse(circlePen, circleCenterX - circleRadius, circleCenterY - circleRadius, circleDiameter, circleDiameter);
            }
        }
    }

}
