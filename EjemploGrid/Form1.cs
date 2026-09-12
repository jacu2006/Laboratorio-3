using System;
using System.Collections;
using System.Windows.Forms;

namespace EjemploGrid
{
    public partial class Form1 : Form
    {
        // ArrayList para almacenar los objetos Persona
        // ArrayList pertenece al espacio de nombres System.Collections

        ArrayList listaPersonas = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona mColaborador1 = new Persona();

            mColaborador1.Id = 1;
            mColaborador1.Nombres = "Elena Carolina";
            mColaborador1.Apellidos = "González Rodríguez";
            mColaborador1.Correo = "elena.gonzalez@ejemplo.com";
            mColaborador1.FechaNacimiento = new DateTime(1990, 5, 15);
            listaPersonas.Add(mColaborador1);
            dgvDatos.DataSource = null; //Limpiar
            dgvDatos.DataSource = listaPersonas;
        }

        private void tsbGuardar_Click_1(object sender, EventArgs e)
        {
            // Validar que el ID sea un número entero válido (sin texto, sin decimales y no vacío)
            int id;
            if (!int.TryParse(txtID.Text, out id))
            {
                errorProvider1.SetError(txtID, "Ingrese un ID válido (debe ser un número entero)");
                txtID.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtID, "");
            }

            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Ingrese los nombres del Colaborador");
                txtNombre.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtNombre, "");
            }

            if (txtApellido.Text == "")
            {
                errorProvider1.SetError(txtApellido, "Ingrese los apellidos del Colaborador");
                txtApellido.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtApellido, "");
            }

            if (Utilidades.EsCorreoValido(txtCorreo.Text) == false)
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido");
                txtCorreo.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtCorreo, "");
            }

            decimal salario;
            if (!decimal.TryParse(txtSalario.Text, out salario))
            {
                errorProvider1.SetError(txtSalario, "Ingrese un salario válido");
                txtSalario.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtSalario, "");
            }

            // Asignación de datos a la nueva instancia
            Persona colaborador1 = new Persona();
            colaborador1.Id = id; // Se usa la variable 'id' ya validada
            colaborador1.Nombres = txtNombre.Text;
            colaborador1.Apellidos = txtApellido.Text;
            colaborador1.Correo = txtCorreo.Text;
            colaborador1.Salario = salario;
            colaborador1.FechaNacimiento = dtpFecha.Value;

            listaPersonas.Add(colaborador1);
            dgvDatos.DataSource = null; // Limpiar el DataSource antes de asignar la nueva lista
            dgvDatos.DataSource = listaPersonas;
        }
    }
}