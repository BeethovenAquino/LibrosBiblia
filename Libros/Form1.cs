using Libros.Entidades;
using Libros.UI.Consulta;
using Libros.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Libros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroLibros L = new RegistroLibros();
            L.Show();
        }

        private void librosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaLibros c = new ConsultaLibros();
            c.Show();
            
        }
    }
}
