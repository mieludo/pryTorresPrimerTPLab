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

        clsRubros objRubros = new clsRubros();
        clsArticulos objArticulos = new clsArticulos();

        private void frmPrimerTP_Load(object sender, EventArgs e)
        {
            objRubros.ListarRubroEnCombo(cbxRubros);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cbxRubros.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rubro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                objArticulos.ListarArticulosPorRubro(
                    dgvArticulos,
                    lblCantidad,
                    lblTotal,
                    cbxRubros.SelectedItem.ToString());
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (cbxRubros.SelectedItem == null ||
            dgvArticulos.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un rubro y listar los artículos antes de exportar.", "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            objArticulos.ExportarListado
                (
                dgvArticulos,
                Int32.Parse(lblCantidad.Text),
                Double.Parse(lblTotal.Text),
                cbxRubros.SelectedItem.ToString()
                );
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
