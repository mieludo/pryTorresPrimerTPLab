using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTorresPrimerTPLab
{
    internal class clsRubros
    {
        private String archivo = "../../Archivos/RUBROS.csv";

        public void ListarRubroEnCombo(ComboBox cbxRubro)
        {
            StreamReader SR = new StreamReader(archivo);

            String linea = SR.ReadLine();

            while (linea != null)
            {
                cbxRubro.Items.Add(linea);
                linea = SR.ReadLine();
            }
        }
    
            public void ExportarListado(
            DataGridView dgvArticulos,
            Int32 cantidad,
            Double valortotal,
            String rubro)
        {
            StreamWriter SW = new StreamWriter("../../Archivos/reporte_" + rubro.ToLower() + ".csv", false, Encoding.UTF8);

            SW.WriteLine("Código;Descripción;Costo;Stock;Valor en Stock");

            for (Int32 i = 0; i < dgvArticulos.Rows.Count; i++)
            {
                String codigo =
                    dgvArticulos.Rows[i].Cells[0].Value.ToString();

                String descripcion =
                    dgvArticulos.Rows[i].Cells[1].Value.ToString();

                String costo =
                    dgvArticulos.Rows[i].Cells[2].Value.ToString();

                String stock =
                    dgvArticulos.Rows[i].Cells[3].Value.ToString();

                String valorStock =
                    dgvArticulos.Rows[i].Cells[4].Value.ToString();

                SW.WriteLine
                    (
                    codigo + ";" +
                    descripcion + ";" +
                    costo + ";" +
                    stock + ";" +
                    valorStock
                    );
            }

            SW.WriteLine("");
            SW.WriteLine("Cantidad de Artículos: ;" + cantidad);
            SW.WriteLine("Valor Total: ;" + valortotal);

            SW.Close();

            MessageBox.Show(
                "Se exportó el listado correctamente.",
                "Reporte realizado con éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

        
    
