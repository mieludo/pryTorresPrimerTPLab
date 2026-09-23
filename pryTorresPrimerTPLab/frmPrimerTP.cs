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

namespace pryTorresPrimerTPLab
{
    public partial class frmPrimerTP : Form
    {
        public frmPrimerTP()
        {
            InitializeComponent();
        }

        private void frmPrimerTP_Load(object sender, EventArgs e)
        {
            cbxRubros.Items.Clear();

            StreamReader archivo = new StreamReader("RUBROS.CSV");

            while (archivo.EndOfStream == false)
            {
                string rubro = archivo.ReadLine();
                cbxRubros.Items.Add(rubro);
            }
            archivo.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cbxRubros.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rubro.");
            }
            else
            {
                dgvArticulos.Rows.Clear();

                int cantidad = 0;
                decimal total = 0;

                StreamReader archivo = new StreamReader("ARTICULOS.CSV");

                while (archivo.EndOfStream == false)
                {
                    string linea = archivo.ReadLine();
                    string[] datos = linea.Split(',');

                    if (datos[3] == cbxRubros.Text)
                    {
                        decimal costo = Convert.ToDecimal(datos[2]);
                        int stock = Convert.ToInt32(datos[4]);
                        decimal valor = costo * stock;

                        dgvArticulos.Rows.Add(
                            datos[0], datos[1], costo, stock, valor);

                        cantidad++;
                        total = total + valor;
                    }
                }

                archivo.Close();

                lblCantidad.Text = cantidad.ToString();
                lblTotal.Text = "$ " + total.ToString();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (cbxRubros.SelectedIndex != -1)
            {
                string nombreArchivo =
                    "ARTICULOS_" + cbxRubros.Text + ".CSV";

                StreamReader archivo =
                    new StreamReader("ARTICULOS.CSV");

                StreamWriter archivoExportado =
                    new StreamWriter(nombreArchivo, false);

                archivoExportado.WriteLine("Codigo;Descripcion;Costo;Stock;Valor");

                while (!archivo.EndOfStream)
                {
                    string linea = archivo.ReadLine();
                    string[] datos = linea.Split(',');

                    if (datos[3] == cbxRubros.Text)
                    {
                        decimal costo = Convert.ToDecimal(datos[2]);
                        int stock = Convert.ToInt32(datos[4]);
                        decimal valor = costo * stock;

                        archivoExportado.WriteLine(
                            datos[0] + ";" +
                            datos[1] + ";" +
                            costo + ";" +
                            stock + ";" +
                            valor);
                    }
                }

                archivo.Close();
                archivoExportado.Close();

                MessageBox.Show("Los datos se exportaron en " + nombreArchivo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rubro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void aCercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe ventana = new frmAcercaDe();
            ventana.ShowDialog(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
