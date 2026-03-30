using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlan
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Sobre_Load(object sender, EventArgs e)
        {
            texto_sobre.Text = "Tool developed within the scope of a research project funded by the Espírito Santo Research and Innovation Support Foundation (FAPES).";
            texto_sobre.Text += "\n\n";
            texto_sobre.Text += "Author: Clainer Bravin Donadel.";
            texto_sobre.Text += "\n\n";
            texto_sobre.Text += "License Terms:";
            texto_sobre.Text += "\n";
            texto_sobre.Text += "1) OpenDSS" + Convert.ToChar(174) + ": Open-Source Software.";
            texto_sobre.Text += "\n";
            texto_sobre.Text += "2) Icon: Umeicon – Flaticon, licensed for commercial use with attribution.";

        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
