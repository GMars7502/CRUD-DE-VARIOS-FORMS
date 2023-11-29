using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_CITASMEDICAS.Moldes;

namespace CRUD_CITASMEDICAS
{
    public partial class PanUpdate : Form
    {

        private int acu = 0;
        private void PanUpdate_Load(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    

                    cmbGenero.Items.Add("M");
                    cmbGenero.Items.Add("F");
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
                            txtNombre.Text = a.pacNombres;
                        }
                        else
                        {
                            txtNombre.Text = string.Empty;
                        }
                    }

                    if (acu >= 4)
                    {
                        LlenaDatos();
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Actualizar()
        {
            using(bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int id = Convert.ToInt32(cmbID.SelectedValue.ToString());

                    Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == id);

                    a.pacNombres = tbNombre.Text;
                    a.pacCelular = tbCelular.Text;
                    a.pacApellidos = tbApellido.Text;
                    a.pacCelular = tbCelular.Text;
                    a.pacDNi = tbDni.Text;
                    a.pacEmail = tbEmail.Text;
                    a.pacEdad = int.Parse(tbEdad.Text);
                    a.pacGenero = cmbGenero.Text;

                    bd.SaveChanges();
                    

                    

                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void limpiaDatos()
        {
            tbApellido.Text = string.Empty;
            tbCelular.Text = string.Empty;
            tbDni.Text = string.Empty;
            tbEdad.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbNombre.Text = string.Empty;

           
        }

        private void LlenaDatos()
        {
            using(bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2())
            {
                try
                {
                    int be = 0;

                    be = Convert.ToInt32(cmbID.SelectedValue.ToString());

                    Pacientes a = bd.Pacientes.FirstOrDefault(d => d.idPaciente == be);

                    if (a != null)
                    {
                        tbApellido.Text = a.pacApellidos;
                        tbCelular.Text = a.pacCelular;
                        tbDni.Text = a.pacDNi;
                        tbEdad.Text = Convert.ToString(a.pacEdad);
                        tbEmail.Text = a.pacEmail;
                        tbNombre.Text = a.pacNombres;

                        Comprobar();



                    }
                    else
                    {
                        txtNombre.Text = string.Empty;
                    }
                    
                    
                    


                }
                catch(Exception ex) {  MessageBox.Show(ex.Message); }
            }

        }

        private void cmbID_TextChanged(object sender, EventArgs e)
        {
            using (bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2()) { 
            try
            {
                    

                    if(acu <= 3)
                    {
                        txtNombre.Text = string.Empty;
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
                                txtNombre.Text = a.pacNombres;
                                LlenaDatos();
                                Comprobar();
                            }
                            else
                            {
                                txtNombre.Text = string.Empty;
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

        private bool? confim;

        private bool? Comprobar(bool? confi = null)
        {

            try
            {
                string nombre = tbNombre.Text.Trim();
                string apellido = tbApellido.Text.Trim();
                string dni = tbDni.Text.Trim();
                string edad = tbEdad.Text.Trim();
                string genero = cmbGenero.Text.Trim();
                string celular = tbCelular.Text.Trim();
                string email = tbEmail.Text.Trim();

                

                //validación nombre y apellido
                if (nombre.Length > 2 && apellido.Length > 4) {  }
                else {throw new Exception("Deber ingresar los datos nombre/s y apellido/s"); }


                //validacion de dni
                if (dni.Length == 8)
                {
                    if (int.TryParse(dni, out int i))
                    {
                        


                    }
                    else
                    {
                        
                        throw new Exception("Deber ser real el DNI");
                    }


                }
                else
                {
                    
                    throw new Exception("Deber ingresar un numero real de DNI");
                }


                //validación de edad
                if (EdadValida(edad))
                {
                    if (int.Parse(edad) > 1 && int.Parse(edad) < 120)
                    {
                        
                    }
                    else
                    {
                       
                        throw new Exception("Deber ser una edad real");
                    }

                }
                else if (edad.Length == 0)
                {
                    
                    throw new Exception("Deber ingresar una edad");
                }
                else
                {
                    throw new Exception("Deber ser una edad real");
                }

                //validación de genero
                if (cmbGenero.SelectedItem == null) { throw new Exception("Deber seleccionada un genero"); }



                //validación de celular
                if (celular.Length == 9)
                {
                    if (int.TryParse(celular, out int i))
                    {
                        
                    }
                    else
                    {
                        throw new Exception("Deber ser un numero Celular real");
                    }
                }
                else if (celular.Length > 1)
                {
                    throw new Exception("Deber ser un numero Celular real");
                }
                else
                {

                }



                //validación de  email
                if (EmailValido(email) || email.Length == 0)
                {

                }
                else
                {
                    throw new Exception("Deber ser un correo electronico real");

                }

                return confi = true;
                

                
            }catch(Exception ex) { MessageBox.Show(ex.Message); return confi = false; }

        }




        

        //validación de edad
        static bool EdadValida(string edad)
        {
            if (int.TryParse(edad, out int i))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //validacion de email --https://learn.microsoft.com/es-es/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        static bool EmailValido(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }


        }

        public PanUpdate()
        {

            InitializeComponent();
        }

        //boton cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {


            bool? a = Comprobar(confim);
            

            if (a == null) { a = false; }
            else if((bool)a){ Actualizar();
                MessageBox.Show("Se Realizo con éxito la actualización");
            }
            else {MessageBox.Show("No se pudo realizar con éxito la actualización"); }
                
            
        }

        //boton limpia campos
        private void button1_Click(object sender, EventArgs e)
        {
            limpiaDatos();
        }
    }
}
