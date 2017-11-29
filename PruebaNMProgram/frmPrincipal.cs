using Ejercicio.Modelo.Entidades;
using Ejercicio.Modelo.Servicios;
using PruebaNMProgramLibrary.Servicios;
using PruebaNMProgramLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Ejercicio
{
    public partial class frmPrincipal : Form
    {

        object instance;
        Type instanceType;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            // Leyendo las clases del servicio
            cboEntidades.DisplayMember = "Nombre";
            cboEntidades.DataSource = ServicioEntidades.recuperaEntidades();
            cboEntidades.Refresh();
        }

        private void cboEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntidadeDisponible entidadSeleccionada = cboEntidades.SelectedValue as EntidadeDisponible;
            // configurando la información de la entidad seleccionada
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = entidadSeleccionada.Columnas.Count;

            for (int i = 0; i < entidadSeleccionada.Columnas.Count; i++)
            {
                dataGridView1.Columns[i].DataPropertyName = entidadSeleccionada.Columnas[i].Key;
                dataGridView1.Columns[i].Name = entidadSeleccionada.Columnas[i].Value;
            }

            // creando una instancia del servicio solicitado
            instance = Activator.CreateInstance(entidadSeleccionada.Servicio);
            instanceType = entidadSeleccionada.Servicio;
            textBox1_TextChanged(null, null);
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MethodInfo method = instanceType.GetMethod("buscarPorTitulo");
            dataGridView1.DataSource = method.Invoke(instance, new object[] { textBox1.Text });
            dataGridView1.Refresh();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MethodInfo method = instanceType.GetMethod("eliminarTodo");
            method.Invoke(instance, null);
            textBox1_TextChanged(null, null);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Directory.GetCurrentDirectory() + "\\log.txt");
        }

        private void btnEliminarSelecionado_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (null != row.Cells[0].Value)
                {
                    int id;
                    bool resultado = int.TryParse(row.Cells[0].Value.ToString(), out id);
                    MethodInfo method = instanceType.GetMethod("eliminar");
                    method.Invoke(instance, new object[] { id });                    
                }
            }
            textBox1_TextChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* Generando valores por ejemplo */
            if (instance.GetType() == typeof(ServicioLibros))
            {
                ((ServicioLibros)instance).crear(new Libro("Coluna de fogo"));
                ((ServicioLibros)instance).crear(new Libro("The Girl Who Takes an Eye for an Eye"));
                ((ServicioLibros)instance).crear(new Libro("Em Águas Sombrias"));
            }
            else if (instance.GetType() == typeof(ServicioPeliculas))
            {
                ((ServicioPeliculas)instance).crear(new Pelicula("Mulher Maravilha", 2017));
                ((ServicioPeliculas)instance).crear(new Pelicula("Thor: Ragnarok", 2016));
                ((ServicioPeliculas)instance).crear(new Pelicula("Star Wars: Os Últimos Jedi", 2015));
            }
            else if (instance.GetType() == typeof(ServicioRevistas))
            {
                ((ServicioRevistas)instance).crear(new Revista("Benji Knewman"));
                ((ServicioRevistas)instance).crear(new Revista("Delayed Gratification"));
                ((ServicioRevistas)instance).crear(new Revista("Disegno"));
                ((ServicioRevistas)instance).crear(new Revista("The Gentlewoman"));
            }
            textBox1_TextChanged(null, null);
        }
    }
}