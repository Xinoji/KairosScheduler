using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KairosScheduler;

namespace Forms.ManualScheduler
{
    public partial class ClaseBox : UserControl
    {
        private readonly Clase clase;
        
        public ClaseBox(Clase clase, bool b = true) 
        {
            this.clase = clase;
            InitializeComponent();
            InitializeData();

            if (b)
                button1.BackColor = Color.Green;
        }

        private void InitializeData()
        {
            NombreLabel.Text = clase.Nombre;
            cantButton.Text =  $"{clase.Horarios.Length}";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string Name = clase.Clave;
            var g = e.Graphics;
            g.DrawString(Name, new Font("Futura", 8), Brushes.Black, 2, 7,
                new StringFormat(StringFormatFlags.DirectionVertical));
        }

        private void NombreLabel_Click(object sender, EventArgs e)
        {

        }

        private void cantButton_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }
    }
}
