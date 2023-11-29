using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_CITASMEDICAS.Moldes;


namespace CRUD_CITASMEDICAS
{
    public partial class PanRead : Form
    {
        bd_CitasMedicasEntities2 db = new bd_CitasMedicasEntities2();

        public PanRead()
        {
            InitializeComponent();
        }

        private void PanRead_Load(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.DataSource = db.Pacientes.ToList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        
        }

    }
}
