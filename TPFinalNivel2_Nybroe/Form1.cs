using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Articulo;
using SQL;

namespace TPFinalNivel2_Nybroe
{
    public partial class Form1 : Form
    {
        private List <Articulos> Lista = null;
        private string imagenBorrar = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDGV();
            cBoxCampo.Items.Add("Nombre");
            cBoxCampo.Items.Add("Marca");
            cBoxCampo.Items.Add("Categoria");
            cBoxCampo.Items.Add("Precio");
        }

        private void cargarDGV()
        {
           
            try
            {
                RegistroArticulo registroArticulo = new RegistroArticulo();
                Lista = registroArticulo.listar();
                dgVArticulos.DataSource = Lista;
                if (imagenBorrar != null)
                {
                    File.Delete(imagenBorrar);
                    imagenBorrar = null;
                }
                ocultarColumnas();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void ocultarColumnas()
        {
            dgVArticulos.Columns["ID"].Visible = false;
            dgVArticulos.Columns["UrlImagen"].Visible = false;
            dgVArticulos.Columns["Precio"].DefaultCellStyle.Format = "00.000";
        }

        private void cargarImagen(string carga)
        {
            try
            {
                pBImagen.Load(carga);

            }catch (Exception)
            {
                pBImagen.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }

        private void dgVArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgVArticulos.CurrentRow != null)
            {
                Articulos art = (Articulos)dgVArticulos.CurrentRow.DataBoundItem;
                cargarImagen(art.UrlImagen);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ventanaAgregar ventana = new ventanaAgregar();
            ventana.ShowDialog();
            cargarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos seleccionado;
            seleccionado = (Articulos)dgVArticulos.CurrentRow.DataBoundItem;

            ventanaAgregar modificar = new ventanaAgregar(seleccionado);
            modificar.ShowDialog();
            cargarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RegistroArticulo regArticulo = new RegistroArticulo();
            Articulos seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar de forma permanente el articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulos)dgVArticulos.CurrentRow.DataBoundItem;
                    if (!(seleccionado.UrlImagen.ToLower().Contains("http")))
                    {
                        imagenBorrar = seleccionado.UrlImagen;
                    }
                    regArticulo.eliminar(seleccionado.Id);
                    cargarDGV();
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ocultarFiltro(bool ocultado = false)
        {
            if(ocultado)
            {
                txtBoxFiltro.Enabled = false;
                txtBoxFiltro.Visible = false;
                lblFiltro.Visible = false;
            }
            else
            {
                txtBoxFiltro.Enabled = true;
                txtBoxFiltro.Visible = true;
                lblFiltro.Visible = true;
            }
        }
        private void cBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistroMarca regMarca = new RegistroMarca();
            RegistroCategoria regCategoria = new RegistroCategoria();
            switch (cBoxCampo.SelectedIndex)
            {
                case 0:
                    cBoxCriterio.DataSource = null;
                    cBoxCriterio.Items.Add("Empieza con");
                    cBoxCriterio.Items.Add("Termina con");
                    cBoxCriterio.Items.Add("Contiene");
                    ocultarFiltro();
                    break;
                case 1:
                    cBoxCriterio.DataSource = null;
                    cBoxCriterio.DataSource = regMarca.listar();
                    cBoxCriterio.ValueMember = "Id";
                    cBoxCriterio.DisplayMember = "Descripcion";
                    ocultarFiltro(true);
                    break;
                case 2:
                    cBoxCriterio.DataSource = null;
                    cBoxCriterio.DataSource = regCategoria.listar();
                    cBoxCriterio.ValueMember = "Id";
                    cBoxCriterio.DisplayMember = "Descripcion";
                    ocultarFiltro(true);
                    break; 
                default:
                    cBoxCriterio.DataSource = null;
                    cBoxCriterio.Items.Add("Mayor a");
                    cBoxCriterio.Items.Add("Menor a");
                    cBoxCriterio.Items.Add("Igual a");
                    ocultarFiltro();
                    break;
            }
        }

        private void txtBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cBoxCampo.SelectedIndex == 3)
            {
                if((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar !=8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
        }

        private bool validarTxtBox()
        {
            if(cBoxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes elegir un campo a filtrar");
                return true;
            }
            if(cBoxCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debes elegir un criterio a filtrar");
                return true;
            }

            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RegistroArticulo regArticulo = new RegistroArticulo();
            try
            {
                if (validarTxtBox())
                    return;
                string campo = cBoxCampo.SelectedItem.ToString();
                string criterio = cBoxCriterio.SelectedItem.ToString();
                string filtro = txtBoxFiltro.Text;
                dgVArticulos.DataSource = regArticulo.filtrar(campo, criterio, filtro);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarDGV();
        }
    }

}
