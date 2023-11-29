using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_CITASMEDICAS.Moldes;

namespace CRUD_CITASMEDICAS
{
    public partial class CitasCreation : Form
    {
        private double monto = 0;
        private int acu = 0;
        public CitasCreation()
        {
            InitializeComponent();
        }

        private void CitasCreation_Load(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    Costo();
                    txtDiagnos.Enabled = false;
                    txtEstadoOtro.Enabled = false;
                    dtpFR.MinDate = DateTime.Now;
                    dtpFC.MinDate = DateTime.Now;

                    cmbEspecialidad.Items.AddRange(new object[] { "Cardiología", "Odontología", "Medicina General", "Neurología", "Traumatología", "Psicología" });
                    cmbEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Cancelada", "Atendida", "No Asistió", "Otro..." });

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
                catch(Exception ex) { MessageBox.Show(ex.Message); }
             }
            
        }

        private void dtpFR_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    if (MessageBox.Show("Seguro de crear la cita", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string medico = txtMedico.Text;
                        string diagnostico = txtDiagnos.Text;
                        string codigo = txtCodigo.Text;
                        string estado = txtEstadoOtro.Text;


                        Citas a = new Citas();
                        string idpaciente = cmbID.SelectedValue.ToString();


                        a.idPaciente = int.Parse(idpaciente);
                        a.ctFechaRegistro = Convert.ToDateTime(dtpFR.Value.ToString());






                        if (medico.Length > 2) { a.ctMedico = txtMedico.Text; }
                        else { throw new Exception("Deber ingresar el nombre del Medico"); }


                        if (cmbEspecialidad.SelectedItem == null) { throw new Exception("Deber selecciona una especialidad"); }
                        else { a.ctEspecialidad = cmbEspecialidad.SelectedItem.ToString(); }





                        if (codigo.Length == 10)
                        {

                            if (ExisteCodigoEnPacientes(codigo))
                            {
                                txtCodigo.Clear();
                                throw new Exception("Ya existe el codigo");

                            }

                            a.ctCodigo = txtCodigo.Text;



                        }
                        else
                        {
                            txtCodigo.Clear();
                            throw new Exception("Deber ingresar un numero real de codigo");
                        }



                        if (cmbEstado.SelectedItem == null)
                        {
                            throw new Exception("Deber selecciona un estado");
                        }
                        else if ("Otro..." == cmbEstado.SelectedItem.ToString())
                        {
                            if (estado.Length < 4)
                            {
                                throw new Exception("Deber llenar el cuadro de Estado");
                            }

                            a.ctEstado = txtEstadoOtro.Text;

                        }
                        else
                        {
                            a.ctEstado = cmbEstado.SelectedItem.ToString();
                        }



                        if (Comparafechas() < 0)
                        {
                            throw new Exception("Deber ingresar una fecha posible");
                        }
                        else
                        {
                            a.ctFechaCita = Convert.ToDateTime(dtpFC.Value.ToString());
                        }



                        if ("Atendida" == cmbEstado.SelectedItem.ToString())
                        {
                            if (diagnostico.Length < 5)
                            { throw new Exception("Deber llenar el diagnostico completo"); }
                            else
                            {
                                a.ctDiagnostico = txtDiagnos.Text;
                            }
                        }
                        else
                        {
                            a.ctDiagnostico = "Sin diagnostico";
                        }

                        

                        a.ctCosto = (decimal)monto;

                        bd.Citas.Add(a);
                        bd.SaveChanges();

                        LimpiarCampos();
                    }
                



                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            }


        }


        private bool ExisteCodigoEnPacientes(string CD)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                var pacienteExistente = bd.Citas.FirstOrDefault(p => p.ctCodigo == CD);


                return pacienteExistente != null;
            }
        }

        private void cmbEstado_SelectedValueChanged(object sender, EventArgs e)
        {  }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (contraCount == 0)
                {

                    if (cmbEstado.SelectedItem == null)
                    {

                    }
                    else if ("Otro..." == cmbEstado.SelectedItem.ToString())
                    {
                        txtEstadoOtro.Enabled = true;
                        txtDiagnos.Clear();
                        txtDiagnos.Enabled = false;
                    }
                    else if ("Atendida" == cmbEstado.SelectedItem.ToString())
                    {
                        txtDiagnos.Enabled = true;
                        txtEstadoOtro.Clear();
                        txtEstadoOtro.Enabled = false;
                    }
                    else
                    {
                        txtDiagnos.Clear();
                        txtEstadoOtro.Clear();
                        txtEstadoOtro.Enabled = false;
                        txtDiagnos.Enabled = false;
                    }


                    Costo();
                }
                else
                {
                    contraCount -= 1;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contraCount == 0)
                Costo();
            else
                contraCount -= 1;
        }

        private int Comparafechas()
        {
            

            DateTime fechaUno = Convert.ToDateTime(dtpFR.Value.ToString());
            DateTime fechaDos = Convert.ToDateTime(dtpFC.Value.ToString());

            TimeSpan difFechas = fechaDos - fechaUno;

            int days = (int)difFechas.TotalDays;

            string dias = Convert.ToString(days);

            return days;
        }


        private void Costo()
        {
            try
            {
                if (cmbEspecialidad.SelectedItem == null)
                {

                }
                else if (cmbEspecialidad.SelectedItem.ToString() == "Cardiología" ||
                    cmbEspecialidad.SelectedItem.ToString() == "Neurología" ||
                    cmbEspecialidad.SelectedItem.ToString() == "Traumatología")
                {
                    monto = 0;
                    monto += 250;
                }
                else
                {
                    monto = 0;
                    monto += 180;
                }

                if (cmbEstado.SelectedItem == null) { }
                else if (cmbEstado.SelectedItem.ToString() == "No Asistió")
                    monto += monto * 0.15;


                if (Comparafechas() <= 1)
                {
                    toolStripStatusLabel1.Text = "URGENCIA!!!!";
                    monto += monto * 0.20;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Cita Normal";

                }



                txtCosto.Text = Convert.ToString(monto);
            }catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void cmbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFC_ValueChanged(object sender, EventArgs e)
        {
            Costo();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private int contraCount = 0;
        private void LimpiarCampos()
        {
            contraCount += 2;
            txtDiagnos.Clear();
            txtEstadoOtro.Clear();
            txtDiagnos.Enabled = false;
            txtEstadoOtro.Enabled = false;
            dtpFR.MinDate = DateTime.Now;
            dtpFC.MinDate = DateTime.Now;
            txtMedico.Clear();
            cmbEspecialidad.SelectedItem = null;
            cmbEstado.SelectedItem = null;
            txtCodigo.Clear();
            monto = 0;
            acu = 0;
            contraCount = 0;
            txtCosto.Text = Convert.ToString(monto);

        }
    }
}
