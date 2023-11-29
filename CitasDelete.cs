using CRUD_CITASMEDICAS.Moldes;
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
    public partial class CitasDelete : Form
    {
        private string estado = "";
        public CitasDelete()
        {
            InitializeComponent();
        }


        private void Reinsentacion()
        {
            using(bd_CitasMedicasEntities2 bd= new bd_CitasMedicasEntities2())
            {
                try { 
                         estado = "inicio";

                         cmbCodigo.DataSource = bd.Citas.OrderBy(d => d.ctCodigo).ToList();
                    
                    
                    cmbCodigo.DisplayMember = "ctCodigo";
                         cmbCodigo.ValueMember = "idCitas";



                        llenarDatos();
                     }catch(Exception ex) { MessageBox.Show(ex.Message); }

                }
        }


        private void CitasDelete_Load(object sender, EventArgs e)
        {
            using(bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {

                    estado = "inicio";

                    cmbCodigo.DataSource = bd.Citas.OrderBy(d => d.ctCodigo).ToList();
                    estado = "inicio";
                    cmbCodigo.DisplayMember = "ctCodigo";
                    cmbCodigo.ValueMember = "idCitas";



                    llenarDatos();
                    dtpFECHA.Enabled = false;




                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void llenarDatos()
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int ba = 0;
                    int be = 0;
                    if(cmbCodigo.SelectedValue != null)
                    {

                        ba = Convert.ToInt32(cmbCodigo.GetItemText(cmbCodigo.SelectedValue));


                        Citas b = bd.Citas.FirstOrDefault(d => d.idCitas == ba);

                        be = b.idPaciente;

                        Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);

                        if (a != null)
                        {
                            txtDni.Text = a.pacDNi;
                            txtNombre.Text = a.pacNombres;
                            dtpFECHA.Text = Convert.ToString(b.ctFechaCita);

                        }
                        else
                        {
                            txtDni.Text = string.Empty;
                            txtNombre.Text = string.Empty;
                        }
                    }





                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void cmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(estado == "inicio")
            {
                estado = "";
            }
            else
            {
                llenarDatos();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int be = 0;

                    if (MessageBox.Show("Estas seguro de eliminar esta cita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        be = Convert.ToInt32(cmbCodigo.GetItemText(cmbCodigo.SelectedValue));
                        Citas a = bd.Citas.FirstOrDefault(d => d.idCitas == be);

                        bd.Citas.Remove(a);
                        bd.SaveChanges();

                        Reinsentacion();
                        MessageBox.Show("La eliminación se completo", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
