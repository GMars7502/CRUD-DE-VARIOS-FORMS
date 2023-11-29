using CRUD_CITASMEDICAS.Moldes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CITASMEDICAS
{
    public partial class CitasUpdate : Form
    {
        private int acu = 0;
        private int contraCount = 0;
        private string count = "";
        private double monto = 0;
        private double montoviejo = 0;


        public CitasUpdate()
        {
            InitializeComponent();
        }


        //Carga de form Actualización
        private void CitasUpdate_Load(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    txtDiagnostico.Enabled = false;
                    txtEstadoOtro.Enabled = false;

                    dtpFR.MinDate = DateTime.Now;

                    cmbEspecialidad.Items.AddRange(new object[] { "Cardiología", "Odontología", "Medicina General", "Neurología", "Traumatología", "Psicología" });
                    cmbEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Cancelada", "Atendida", "No Asistió", "Otro..." });


                    cmbCodigoCita.DataSource = bd.Citas.OrderBy(d => d.ctCodigo).ToList();

                    cmbCodigoCita.DisplayMember = "ctCodigo";
                    cmbCodigoCita.ValueMember = "idCitas";

                    LlenarcmbCodigo();
                    LlenarCampos();


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        //Cambio de indice de codigo
        private void cmbCodigoCita_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
               
                if (acu <= 3)
                {
                    txtDNi.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    acu += 2;
                }
                else
                {
                    LlenarcmbCodigo();
                    LlenarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //cmbEstado cambio del indice
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (count == "Proceso")
                {
                    count = "";
                }
                else
                {
                    ComportamientocmbEstado("");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        #region Clases creadas
        //cambio de cmbCodigo
        private void LlenarcmbCodigo()
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                int be;
                int ba;

                //object b = cmbID.SelectedValue;
                if (cmbCodigoCita.SelectedValue != null)
                {
                    //obtener el codigocita
                    string bi = cmbCodigoCita.GetItemText(cmbCodigoCita.SelectedItem);


                    //obtener el IdCita
                    ba = Convert.ToInt32(cmbCodigoCita.GetItemText(cmbCodigoCita.SelectedValue));


                    Citas b = bd.Citas.FirstOrDefault(d => d.idCitas == ba);

                    be = b.idPaciente;

                    Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);

                    if (a != null)
                    {
                        txtDNi.Text = a.pacDNi;
                        txtNombre.Text = a.pacNombres;

                    }
                    else
                    {
                        txtDNi.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                    }
                }
            }
        }

        //llenado de Campos
        private void LlenarCampos()
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int ba = 0;
                    ba = Convert.ToInt32(cmbCodigoCita.GetItemText(cmbCodigoCita.SelectedValue));

                    Citas b = bd.Citas.FirstOrDefault(d => d.idCitas == ba);

                    txtMedico.Text = b.ctMedico;

                    string especialidad = b.ctEspecialidad;

                    if (cmbEspecialidad.FindString(especialidad) >= 0)
                    {
                        int a = cmbEspecialidad.FindString(especialidad);
                        cmbEspecialidad.SelectedIndex = a;



                    }

                    ComportamientocmbEstado("inicio");

                    dtpFC.Text = Convert.ToString(b.ctFechaCita);

                    montoviejo = (double)b.ctCosto;

                    txtCosto.Text = montoviejo.ToString();


                    Costo();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
        }

        //Cambio principal de cmbEstado
        private string ComportamientocmbEstado(string ab)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {

                count = ab;

                
                try
                {
                    if (count == "inicio")
                    {
                        count = "proceso";
                        
                        int ba = 0;
                        ba = Convert.ToInt32(cmbCodigoCita.GetItemText(cmbCodigoCita.SelectedValue));

                        Citas b = bd.Citas.FirstOrDefault(d => d.idCitas == ba);

                        string estado = b.ctEstado;


                        int ac = cmbEstado.FindString(estado);


                        if (ac >= 0)
                        {
                            int a = cmbEstado.FindString(estado);

                            
                            cmbEstado.SelectedIndex = a;

                            string nombre = cmbEstado.GetItemText(cmbEstado.SelectedItem);


                            if ("Atendida" == nombre)
                            {
                                txtDiagnostico.Enabled = true;
                                txtDiagnostico.Text = b.ctDiagnostico;
                                txtEstadoOtro.Clear();
                                txtEstadoOtro.Enabled = false;

                            }

                        }    
                        else
                        {

                            if(estado.Length >= 3)
                            {
                                cmbEstado.SelectedIndex = 5;
                                txtEstadoOtro.Enabled = true;
                                txtEstadoOtro.Text = estado;
                                txtDiagnostico.Clear();
                                txtDiagnostico.Enabled = false;
                            }
                            else
                            {
                                cmbEspecialidad.SelectedIndex = 5;
                                txtEstadoOtro.Enabled = true;
                                txtEstadoOtro.Text = "Sin estado ingresado";
                                txtDiagnostico.Clear();
                                txtDiagnostico.Enabled = false;
                            }    

                            


                        }
                    }
                    else if(count == "")
                    {
                        

                        if (contraCount == 0)
                        {

                            if (cmbEstado.SelectedItem == null)
                            {

                            }
                            else if ("Otro..." == cmbEstado.SelectedItem.ToString())
                            {
                                txtEstadoOtro.Enabled = true;
                                txtDiagnostico.Clear();
                                txtDiagnostico.Enabled = false;
                            }
                            else if ("Atendida" == cmbEstado.SelectedItem.ToString())
                            {
                                txtDiagnostico.Enabled = true;
                                txtEstadoOtro.Clear();
                                txtEstadoOtro.Enabled = false;
                            }
                            else
                            {
                                txtDiagnostico.Clear();
                                txtEstadoOtro.Clear();
                                txtEstadoOtro.Enabled = false;
                                txtDiagnostico.Enabled = false;
                            }

                            Costo();
                        }
                        else
                        {
                            contraCount -= 1;
                        }

                    }

                    return null;
                } catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
            }
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



                txtCostoActual.Text = Convert.ToString(monto);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        private void Actualizar()
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    
                    var mensaje = MessageBox.Show($"Seguro la de actualizar la cita del paciente: {txtNombre.Text}. con DNI: {txtDNi.Text}", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    var preguntacosto = MessageBox.Show("Quiere cambiar el costo del por el costo actual, este cambio es irrevesible.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if ( mensaje == DialogResult.Yes)
                    {
                        int ba = 0;
                        string medico = txtMedico.Text;
                        string diagnostico = txtDiagnostico.Text;
                        string estado = txtEstadoOtro.Text;

                        ba = Convert.ToInt32(cmbCodigoCita.GetItemText(cmbCodigoCita.SelectedValue));


                        Citas a = bd.Citas.FirstOrDefault(d => d.idCitas == ba);


                        a.ctFechaRegistro = Convert.ToDateTime(dtpFR.Value.ToString());






                        if (medico.Length > 2) { a.ctMedico = txtMedico.Text; }
                        else { throw new Exception("Deber ingresar el nombre del Medico"); }


                        if (cmbEspecialidad.SelectedItem == null) { throw new Exception("Deber selecciona una especialidad"); }
                        else { a.ctEspecialidad = cmbEspecialidad.SelectedItem.ToString(); }








                        if (cmbEstado.SelectedItem == null)
                        {
                            throw new Exception("Deber selecciona un estado");
                        }
                        else if ("Otro..." == cmbEstado.SelectedItem.ToString())
                        {
                            if (estado.Length < 3)
                            {
                                throw new Exception("Deber llenar el cuadro de Estado");
                            }

                            a.ctEstado = txtEstadoOtro.Text;

                        }
                        else
                        {
                            a.ctEstado = cmbEstado.SelectedItem.ToString();
                        }



                        



                        if ("Atendida" == cmbEstado.SelectedItem.ToString())
                        {
                            if (diagnostico.Length < 5)
                            { throw new Exception("Deber llenar el diagnostico completo"); }
                            else
                            {
                                a.ctDiagnostico = txtDiagnostico.Text;
                            }
                        }
                        else
                        {
                            a.ctDiagnostico = "Sin diagnostico";
                        }


                        

                        if (monto == montoviejo) 
                        {
                            a.ctCosto = (decimal)monto;
                        }else
                        {
                            if(preguntacosto == DialogResult.Yes)
                            {
                                a.ctCosto = (decimal)monto;
                            }
                            else
                            {
                                a.ctCosto = (decimal)montoviejo;
                            }
                        }

                        
                        bd.SaveChanges();
                        MessageBox.Show("La actualización de la cita fue exitosa", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        //LimpiarCampos();
                    }




                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
             }

            #endregion

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btActualizar_Click(object sender, EventArgs e)
            {
                try { Actualizar(); } catch(Exception ex) { MessageBox.Show(ex.Message); }
                
        }

        private void dtpFC_ValueChanged(object sender, EventArgs e)
        {
            Costo();
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contraCount == 0)
                { }
            else
                contraCount -= 1;
        }
    }
    
    
}
