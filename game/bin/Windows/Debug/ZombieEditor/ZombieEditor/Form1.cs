using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZombieEditor
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string inputHP = txtBoxHP.Text;
            string inputAtt = txtBoxAtt.Text;
            string inputSpeed = txtBoxSpeed.Text;

           // StreamWriter writer = new StreamWriter("bunkr/game/bin/Windows/Debug/ZombieEditor.txt");
            StreamWriter writer = new StreamWriter("ZombieEditor.txt");

            writer.WriteLine(inputHP);
            //writer.Write(",");
            writer.WriteLine(inputAtt);
            //writer.Write(",");
            writer.WriteLine(inputSpeed);

            writer.Close();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            txtBoxHP.Text = "100";
            txtBoxAtt.Text = "1"; 
            txtBoxSpeed.Text = "1";
        }
    }
}
