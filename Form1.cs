using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CITASMEDICAS
{
    
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Pacientes leer
        private void pacientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(PanRead))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }


            PanRead leer = new PanRead();
            leer.MdiParent = this;
            leer.Show();
            leer.Focus();

        }

        //Citas leer
        private void citasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CitasRead))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            CitasRead leer = new CitasRead();
            leer.MdiParent = this;
            leer.Show();
        }

        //Pacientes Crear
        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(PanCreation))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            PanCreation leer  = new PanCreation();
            leer.MdiParent = this;
            leer.Show();
        }

        //Pacientes actualizar
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(PanUpdate))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            PanUpdate leer = new PanUpdate();
            leer.MdiParent = this;
            leer.Show();
        }

        //Pacientes eliminar
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(PanDelete))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            PanDelete leer = new PanDelete();
            leer.MdiParent = this;
            leer.Show();
        }

        //Citas Crear
        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CitasCreation))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            CitasCreation leer = new CitasCreation();
            leer.MdiParent = this;
            leer.Show();
        }

        //Citas altualizar
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CitasUpdate))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            CitasUpdate leer = new CitasUpdate();
            leer.MdiParent = this;
            leer.Show();
        }

        private string nombre = "";

        //Citas eliminar
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CitasDelete))
                {
                    form.Activate(); //Entrega el foco al fomulario abierto
                    form.BringToFront(); //trae el form al frente de los demas forms abiertos
                    return;
                }
            }

            CitasDelete leer = new CitasDelete();
            leer.MdiParent = this;
            leer.Show();
        }

        

    }
}
