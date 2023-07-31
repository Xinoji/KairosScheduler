using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KairosScheduler;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Forms.ManualScheduler
{
    public partial class Main : Form
    {
        private Dictionary<string, string> data;
        public Main()
        {
            InitializeComponent();
            data = Siiau.GetCuDictionary();
            cicloComboBox.DataSource = data.Values.ToList();
            tabControl1.TabPages.Remove(tabTemplate);
            MaximizeBox = false;

            var urlString = "http://consulta.siiau.udg.mx/wco/sspseca.consulta_oferta?ciclop=202310&cup=D&majrp=&crsep=I7032&materiap=&horaip=&horafp=&edifp=&aulap=&ordenp=0&mostrarp=100";
            var clase = Siiau.GetClase(urlString);

            for (int i = 0; i < 6; i++)
            {
                var test = new ClaseBox(clase);
               
                //testPanel.Controls.Add(test);
            }

            for (int i = 0; i < 6; i++)
            {
                var test = new ClaseBox(clase, false);

                //flowLayoutPanel1.Controls.Add(test);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabTemplate_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void cicloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(data.ElementAt(cicloComboBox.SelectedIndex));
        }

        private void dataGridView5_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = "Select";
        }
    }
}
