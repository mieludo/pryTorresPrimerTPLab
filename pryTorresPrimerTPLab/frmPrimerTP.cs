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
    }
}
