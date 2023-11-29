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
    public partial class CitasRead : Form
    {
        bd_CitasMedicasEntities2 db = new bd_CitasMedicasEntities2();
            
        public CitasRead()
        {
            InitializeComponent();
        }

        private void CitasRead_Load(object sender, EventArgs e)
        {
            
                try
                {
                    dataGridView1.DataSource = db.Citas.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            


        
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
