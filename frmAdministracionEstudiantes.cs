using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmAdministracionEstudiantes : Form
    {
        public frmAdministracionEstudiantes()
        {
            InitializeComponent();
            this.dgwTodos.AutoGenerateColumns = false;
            using (UniversidadEntities conexion = new UniversidadEntities())
            {
                this.dgwTodos.DataSource = conexion.EstudianteSet.ToList();

            }
        }
        
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                MessageBox.Show("Ingrese Identificación");
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingrese Nombre");
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Ingrese Email");
                return false;
            }
            return true;
        }

       

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            if (Validar())
            {
                EstudianteSet estudiante = new EstudianteSet
                {
                    Identificacion = Convert.ToInt32(this.txtIdentificacion.Text),
                    Nombre = this.txtNombre.Text,
                    Email = this.txtEmail.Text,
                    GradoId = Convert.ToInt32(this.nudGrado.Value),
                    FechaNac = dtpFechaNac.Value
                };

                using (UniversidadEntities conexion = new UniversidadEntities())
                {
                    conexion.EstudianteSet.Add(estudiante);
                    conexion.SaveChanges();
                    Limpiar();
                    btnConsultarTodos_Click(sender, e);
                    MessageBox.Show("Estudiante guardado");

                }




            }
            
        }

        

        private void btnConsultarTodos_Click(object sender, EventArgs e)
        {
            using(UniversidadEntities conexion = new UniversidadEntities())
            {
                this.dgwTodos.DataSource = conexion.EstudianteSet.ToList();
                
            }
        }

        private void dgwTodos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (UniversidadEntities conexion = new UniversidadEntities())
            {
                if (string.IsNullOrEmpty(this.txtIdentificacion.Text))
                {
                    MessageBox.Show("Ingrese la Identificación a consultar");
                }
                else
                {
                    var identificador = Convert.ToInt32
                        (this.txtIdentificacion.Text);
                    var estudiante = conexion.EstudianteSet
                        .Where(p => p.Identificacion == identificador )
                        .FirstOrDefault();

                    if (estudiante == null)
                    {
                        MessageBox.Show("No hay resultados");
                        Limpiar();
                    }
                    else
                    {
                        this.txtNombre.Text = estudiante.Nombre;
                        this.nudGrado.Value = estudiante.GradoId;
                        this.txtEmail.Text = estudiante.Email;
                        this.dtpFechaNac.Value = estudiante.FechaNac;

                    }
                }




            }
        }

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.nudGrado.Value = this.nudGrado.Minimum;
            this.txtEmail.Text = string.Empty;
            this.dtpFechaNac.Value = this.dtpFechaNac.MinDate;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (UniversidadEntities conexion = new UniversidadEntities())
            {
                if (string.IsNullOrEmpty(this.txtIdentificacion.Text))
                {
                    MessageBox.Show("Ingrese la Identificación a consultar");
                }
                else
                {
                    var identificador = Convert.ToInt32
                        (this.txtIdentificacion.Text);
                    var estudiante = conexion.EstudianteSet
                        .Where(p => p.Identificacion == identificador)
                        .FirstOrDefault();

                    MessageBox.Show("Eliminar " + estudiante.Nombre);
                    if (estudiante == null)
                    {
                        MessageBox.Show("No hay resultados");
                        this.txtNombre.Text = string.Empty;
                        this.nudGrado.Value = this.nudGrado.Minimum;
                        this.txtEmail.Text = string.Empty;
                        this.dtpFechaNac.Value = this.dtpFechaNac.MinDate;
                    }
                    else
                    {
                        conexion.EstudianteSet.
                            Remove(estudiante);
                        MessageBox.Show("Estudiante Eliminado");
                        
                        conexion.SaveChanges();

                    }
                }




            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

                

                using (UniversidadEntities conexion = new UniversidadEntities())
                {
                    var identificador = Convert.ToInt32
                        (this.txtIdentificacion.Text);
                    var estudiante = conexion.EstudianteSet
                        .Where(p => p.Identificacion == identificador)
                        .FirstOrDefault();
                    if (estudiante == null)
                    {
                        MessageBox.Show("Identificador no valido");
                    }
                    else
                    {
                        estudiante.Identificacion = Convert.ToInt32(this.txtIdentificacion.Text);
                        estudiante.Nombre = this.txtNombre.Text;
                        estudiante.Email = this.txtEmail.Text;
                        estudiante.GradoId = Convert.ToInt32(this.nudGrado.Value);
                        estudiante.FechaNac = dtpFechaNac.Value;
                        conexion.SaveChanges();
                        Limpiar();
                        btnConsultarTodos_Click(sender, e);
                        MessageBox.Show("Estudiante Actualizado");
                    }

                    

                }




            }
        }
    }
}
