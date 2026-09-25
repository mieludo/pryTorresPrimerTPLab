using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace pryTorresPrimerTPLab
{
    internal class clsArticulos
    {
        private String archivo = "../../Archivos/ARTICULOS.csv";
        public void ListarArticulosPorRubro(
            DataGridView dgvArticulos,
            Label lblCantidad,
            Label lblTotal,
            String rubro)
        {
            StreamReader SR = new StreamReader(archivo);

            String linea = SR.ReadLine();

            Int32 cantidad = 0;
            Double valorstock;
            Double valortotal = 0;

            dgvArticulos.Rows.Clear();

            while (linea != null)
            {
                String[] datos = linea.Split(';');

                if (datos[3] == rubro)
                {
                    valorstock =
                        Int32.Parse(datos[2]) * Int32.Parse(datos[4]);

                    dgvArticulos.Rows.Add(
                        datos[0],
                        datos[1],
                        datos[2],
                        datos[4],
                        valorstock);

                    cantidad++;
                    valortotal += valorstock;
                }

                linea = SR.ReadLine();
            }

            lblCantidad.Text = cantidad.ToString();
            lblTotal.Text = valortotal.ToString();
        }
    
    public void ExportarListado(DataGridView dgvArticulos, Int32 cantidad, Double valortotal, String rubro)
        {
            StreamWriter SW = new StreamWriter("../../Archivos/reporte_" + rubro.ToLower() + ".csv", false, Encoding.UTF8);

            SW.WriteLine("Código;Descripción;Costo;Stock;Valor en Stock");

            for (Int32 i = 0; i < dgvArticulos.Rows.Count; i++)
            {
                String codigo = dgvArticulos.Rows[i].Cells[0].Value.ToString();
                String descripcion = dgvArticulos.Rows[i].Cells[1].Value.ToString();
                String costo = dgvArticulos.Rows[i].Cells[2].Value.ToString();
                String stock = dgvArticulos.Rows[i].Cells[3].Value.ToString();
                String valorStock = dgvArticulos.Rows[i].Cells[4].Value.ToString();

                SW.WriteLine(codigo + ";" + descripcion + ";" + costo + ";" + stock + ";" + valorStock);
            }

            SW.WriteLine(";");
            SW.WriteLine("Cantidad de Artículos: ;" + cantidad);
            SW.WriteLine("Valor Total: ;" + valortotal);

            SW.Close();

            MessageBox.Show("Se exportó el listado correctamente.",
                "Reporte realizado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
    }


