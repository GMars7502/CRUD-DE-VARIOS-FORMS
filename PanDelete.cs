using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_CITASMEDICAS.Moldes;

namespace CRUD_CITASMEDICAS
{
    public partial class PanDelete : Form
    {
        private int acu = 0;
        public PanDelete()
        {
            InitializeComponent();


        }




        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ignorar esto
        }

        private void PanDelete_Load(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {

                    cmbID.DataSource = bd.Pacientes.OrderBy(d => d.idPaciente).ToList();

                    cmbID.DisplayMember = "pacDNi";
                    cmbID.ValueMember = "idPaciente";

                    int be = 0;

                    //object b = cmbID.SelectedValue;
                    if (cmbID.SelectedValue != null)
                    {
                        be = Convert.ToInt32(cmbID.SelectedValue.ToString());

                        Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);
                        if (a != null)
                        {
                            tbNombre.Text = a.pacNombres;
                        }
                        else
                        {
                            tbNombre.Text = string.Empty;
                        }
                    }



                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
        }

       

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Reinsentacion()
        {
            using(bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int be = 0;

                    if (cmbID.SelectedValue != null)
                    {
                        be = Convert.ToInt32(cmbID.SelectedValue.ToString());

                        Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);
                        if (a != null)
                        {
                            tbNombre.Text = a.pacNombres;
                        }
                        else
                        {
                            tbNombre.Text = string.Empty;
                        }
                    }

                        //object b = cmbID.SelectedValue;
                        if (cmbID.SelectedValue != null)
                         {
                        be = Convert.ToInt32(cmbID.SelectedValue.ToString());

                        Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);
                        if (a != null)
                        {
                            tbNombre.Text = a.pacNombres;

                        }
                        else
                        {
                            tbNombre.Text = string.Empty;
                        }
                        }

                    cmbID.DataSource = bd.Pacientes.OrderBy(d => d.idPaciente).ToList();

                    cmbID.DisplayMember = "pacDNi";
                    cmbID.ValueMember = "idPaciente";


                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void cmbID_TextChanged(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {


                    if (acu <= 3)
                    {
                        tbNombre.Text = string.Empty;
                        acu += 2;
                    }
                    else
                    {
                        int be = 0;

                        //object b = cmbID.SelectedValue;
                        if (cmbID.SelectedValue != null)
                        {
                            be = Convert.ToInt32(cmbID.SelectedValue.ToString());

                            Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);
                            if (a != null)
                            {
                                tbNombre.Text = a.pacNombres;

                            }
                            else
                            {
                                tbNombre.Text = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            using(bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int be = 0;

                    if (MessageBox.Show("Estas seguro de eliminar este paciente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                        be = Convert.ToInt32(cmbID.SelectedValue.ToString());
                        Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);

                        bd.Pacientes.Remove(a);
                        bd.SaveChanges();

                        Reinsentacion();
                        MessageBox.Show("La eliminación se completo", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       

                    }

                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}