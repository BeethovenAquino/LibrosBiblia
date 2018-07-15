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
            if (CriteriotextBox.Text == string.Empty && FiltrocomboBox.SelectedIndex != 3)
            {
                MessageBox.Show("Digite el criterio", "Debe introducir el criterio",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://LibroID
                    id = Convert.ToInt32(CriteriotextBox.Text);

                    filtro = x => x.LibroId == id && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year)
                    && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);

                    break;

                case 1://Fecha
                    filtro = x => x.Fecha.Equals(CriteriotextBox.Text) && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year)
                    && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);

                    break;


                case 2://Descripcion
                    filtro = x => x.Descripcion.Equals(CriteriotextBox.Text) && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year)
                    && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);

                    break;

                case 3://Siglas
                    filtro = x => x.Siglas.Equals(CriteriotextBox.Text) && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year)
                    && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);

                    break;

                case 4://Tipo
                    filtro = x => x.Tipo.Equals(CriteriotextBox.Text) && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year)
                    && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);

                    break;

                case 5://Todo
                    LibrosdataGridView.DataSource = BLL.LibrosBLL.GetList(filtro);
                    break;
            }
            LibrosdataGridView.DataSource = BLL.LibrosBLL.GetList(filtro);


        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrocomboBox.SelectedIndex == 5)
            {
                CriteriotextBox.Enabled = false;
            }
            else
                CriteriotextBox.Enabled = true;
        }
    }
    }

