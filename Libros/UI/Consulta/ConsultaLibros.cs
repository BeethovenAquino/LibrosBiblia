using Libros.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Libros.UI.Consulta
{
    public partial class ConsultaLibros : Form
    {
        public ConsultaLibros()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<LibrosBiblia, bool>> filtro = x => true;
            int id;
            if (CriteriotextBox.Text == string.Empty && FiltrocomboBox.SelectedIndex != 2)
            {
                MessageBox.Show("Digite el criterio", "Debe introducir el criterio",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0: //id
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.LibroId == id;
                    break;

                case 1: //Descripcion
                    string d = CriteriotextBox.Text;
                    filtro = x => x.Siglas == d;
                    //filtro = x => x.Descripcion.Equals(CriteriotextBox.Text) && x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value;
                    break;

                case 2: //Fecha
                    filtro = x => x.Fecha.Equals(CriteriotextBox.Text) && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year)
                    && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);

                    break;
                case 3: //Siglas
                    string s =CriteriotextBox.Text;
                    filtro = x => x.Siglas == s;
                    //filtro = x => x.Siglas.Equals(CriteriotextBox.Text) && x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value;
                    break;

                case 4: //Tipo
                    string t = CriteriotextBox.Text;
                    filtro = x => x.Tipo == t;
                    //filtro = x => x.Tipo.Equals(CriteriotextBox.Text) && x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value;
                    break;

                case 5://todo
                    LibrosdataGridView.DataSource = BLL.LibrosBLL.GetList(filtro);
                    break;
            }
            LibrosdataGridView.DataSource = BLL.LibrosBLL.GetList(filtro);
        }

            private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (FiltrocomboBox.SelectedIndex == 6)
                {
                    CriteriotextBox.Enabled = false;
                }
                else
                    CriteriotextBox.Enabled = true;
              }

        
        
    }
 }
        
    
    

