using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
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
    public partial class PanCreation : Form
    {
        bd_CitasMedicasEntities2 bd = new bd_CitasMedicasEntities2();
        Pacientes objPaciente = new Pacientes();

        public PanCreation()
        {
            InitializeComponent();
        }

        private void PanCreation_Load(object sender, EventArgs e)
        {
            cmbGenero.Items.Add("M");
            cmbGenero.Items.Add("F");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            RegistroPanciente();
        }

        public void RegistroPanciente()
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

                int edad2 = 0;

                //validación nombre y apellido
                if(nombre.Length > 2 && apellido.Length > 4) { }
                else { throw new Exception("Deber ingresar los datos nombre/s y apellido/s"); }

                //validacion de dni
                if (dni.Length == 8)
                {
                    if (int.TryParse(dni, out int i))
                    {
                        if(ExisteDNIEnPacientes(dni))
                        {
                            tbDni.Clear();
                            throw new Exception("Ya existe el DNI");
                            
                        }
                       
                        
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
                if(cmbGenero.SelectedItem == null) { throw new Exception("Deber seleccionada un genero"); }
                


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
                else if(celular.Length > 1)
                {
                    throw new Exception("Deber ser un numero Celular real");
                }
                else
                {

                }



                //validación de  email
                if(EmailValido(email) || email.Length == 0)
                {

                }
                else
                {
                    throw new Exception("Deber ser un correo electronico real");
                }


                edad2 = Convert.ToInt32(edad);


                //Despues de todas las excepciones
                objPaciente.pacDNi = dni;
                objPaciente.pacNombres = nombre;
                objPaciente.pacApellidos = apellido;
                objPaciente.pacEdad = edad2;
                objPaciente.pacGenero = genero;
                objPaciente.pacCelular = celular;
                objPaciente.pacEmail = email;

               
                var respuesta = MessageBox.Show("Inscribir Paciente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    bd.Pacientes.Add(objPaciente);
                    bd.SaveChanges();
                    MessageBox.Show("Fue un éxito la inscripción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }


                



            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        //validación de dni
        public bool ExisteDNIEnPacientes(string dni)
        {
            // Consulta para verificar si el DNI ya existe en la tabla Pacientes
            var pacienteExistente = bd.Pacientes.FirstOrDefault(p => p.pacDNi == dni);

            // Si pacienteExistente no es null, significa que el DNI ya existe en la tabla
            return pacienteExistente != null;
        }

        //validación de edad
        static bool EdadValida(string edad)
        {
            if(int.TryParse(edad,out int i))
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

        //limpiar campos
        public void Limpiar()
        {
            tbNombre.Clear();
           tbApellido.Clear();
            tbDni.Clear();
            tbEdad.Clear();
            tbEmail.Clear();
            tbCelular.Clear();
            cmbGenero.SelectedItem = null;
        }

       
    }
}
