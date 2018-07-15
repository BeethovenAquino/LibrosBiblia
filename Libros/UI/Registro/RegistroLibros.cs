using Libros.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Libros.UI.Registro
{
    public partial class RegistroLibros : Form
    {
        public RegistroLibros()
        {
            InitializeComponent();
        }

        public bool Validar(int error)
        {
            bool paso = false;
            if (error == 1 && (LibroIDnumericUpDown.Value == 0))
            {
                ValidarerrorProvider.SetError(LibroIDnumericUpDown, "Favor LLenar");
                paso = true;
            }

            if (error == 2 && string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                ValidarerrorProvider.SetError(DescripciontextBox, "Favor LLenar");
                paso = true;
            }
            if (error == 2 && string.IsNullOrEmpty(SiglastextBox.Text))
            {
                ValidarerrorProvider.SetError(SiglastextBox, "Favor LLenar");
                paso = true;
            }

            if (error == 2 && string.IsNullOrEmpty(TipotextBox.Text))
            {
                ValidarerrorProvider.SetError(TipotextBox, "Favor LLenar");
                paso = true;
            }
            return paso;
        }

        private LibrosBiblia LlenaClase()
        {
            LibrosBiblia Libros = new LibrosBiblia();

            Libros.LibroId = Convert.ToInt32(LibroIDnumericUpDown.Value);
            Libros.Descripcion = DescripciontextBox.Text;
            Libros.Siglas = SiglastextBox.Text;
            Libros.Tipo = TipotextBox.Text;
            return Libros;

        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            LibroIDnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            SiglastextBox.Clear();
            TipotextBox.Clear();
            ValidarerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("Llenar campos", "Llene los campos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LibrosBiblia Libros = LlenaClase();

                bool paso = false;

                int id = Convert.ToInt32(LibroIDnumericUpDown.Value);
                if (id == 0)
                {
                    paso = BLL.LibrosBLL.Guardar(Libros);
                }
                else
                {
                    var L = BLL.LibrosBLL.Buscar(id);

                    if (L != null)
                    {
                        paso = BLL.LibrosBLL.Modificar(Libros);
                    }

                    if (paso)
                    {
                        MessageBox.Show("Guardado!!", "Se Guardo Correctamente",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LibroIDnumericUpDown.Value = 0;
                        DescripciontextBox.Clear();
                        SiglastextBox.Clear();
                        TipotextBox.Clear();
                        ValidarerrorProvider.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo!!", "Intente Guardar de nuevo",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("El TipoID esta vacio", "Llene Campo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int id = Convert.ToInt32(LibroIDnumericUpDown.Value);

                if (BLL.LibrosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Bien hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LibroIDnumericUpDown.Value = 0;
                    DescripciontextBox.Clear();
                    SiglastextBox.Clear();
                    TipotextBox.Clear();
                    ValidarerrorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("No se puede Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(LibroIDnumericUpDown.Value);
            LibrosBiblia Libros = BLL.LibrosBLL.Buscar(id);



            if (Libros != null)
            {
                LibroIDnumericUpDown.Value = Libros.LibroId;
                DescripciontextBox.Text = Libros.Descripcion;
                SiglastextBox.Text = Libros.Siglas;
                TipotextBox.Text = Libros.Tipo;
            }
            else
            {
                MessageBox.Show("No se encontro", "Intente Buscar de nuevo",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}

