using Articulo;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinalNivel2_Nybroe
{
    public partial class ventanaAgregar : Form
    {
        private Articulos art = null;
        private OpenFileDialog arch = null;
        public ventanaAgregar()
        {
            InitializeComponent();
        }

        public ventanaAgregar(Articulos art)
        {
            InitializeComponent();
            this.art = art;
            Text = "Modificar articulo";
            btnAgregar.Text = "Modificar";
        }

        private void ventanaAgregar_Load(object sender, EventArgs e)
        {
            RegistroCategoria regCategoria = new RegistroCategoria();
            RegistroMarca regMarca = new RegistroMarca();

            try
            {
                cBoxMarca.DataSource = regMarca.listar();
                cBoxMarca.ValueMember = "Id";
                cBoxMarca.DisplayMember = "Descripcion";
                cBoxCategoria.DataSource = regCategoria.listar();
                cBoxCategoria.ValueMember = "Id";
                cBoxCategoria.DisplayMember = "Descripcion";

                if(art != null)
                {
                    txtBoxCodigo.Text = art.Codigo;
                    txtBoxNombre.Text = art.Nombre;
                    txtBoxDesc.Text = art.Descripcion;
                    cBoxMarca.SelectedValue = art.Marca.Id;
                    cBoxCategoria.SelectedValue = art.Categoria.Id;
                    txtBoxImagen.Text = art.UrlImagen;
                    cargarImagen(txtBoxImagen.Text);
                    txtBoxPrecio.Text = art.Precio.ToString();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validarTxtBox()
        {
            if(txtBoxCodigo.Text == "")
            {

                MessageBox.Show("Debes colocar el código del articulo.");
                return true;
            }

            if(txtBoxNombre.Text == "")
            {
                MessageBox.Show("Debes colocar el nombre del articulo.");
                return true;
            }

            if(txtBoxDesc.Text == "")
            {
                MessageBox.Show("Debes colocar la descripción del articulo.");
                return true;
            }

            if(txtBoxPrecio.Text == "")
            {
                MessageBox.Show("Debes colocar el precio del articulo.");
                return true;
            }

            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RegistroArticulo regArticulo = new RegistroArticulo();
            try
            {
                if (art == null)
                    art = new Articulos();
                if (validarTxtBox())
                    return;

                art.Codigo = txtBoxCodigo.Text;
                art.Nombre = txtBoxNombre.Text;
                art.Descripcion = txtBoxDesc.Text;
                art.Marca = (Caracteristica)cBoxMarca.SelectedItem;
                art.Categoria = (Caracteristica)cBoxCategoria.SelectedItem;
                if(arch != null && !(txtBoxImagen.Text.ToLower().Contains("http")))
                {
                    if (!(File.Exists(ConfigurationManager.AppSettings["Articulos"] + arch.SafeFileName)))
                    {
                        File.Copy(arch.FileName, ConfigurationManager.AppSettings["Articulos"] + arch.SafeFileName);
                        txtBoxImagen.Text = ConfigurationManager.AppSettings["Articulos"] + arch.SafeFileName;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un articulo con esa imagen", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                art.UrlImagen = txtBoxImagen.Text;
                art.Precio = decimal.Parse(txtBoxPrecio.Text);

                if (art.Id != 0)
                {
                    regArticulo.modificar(art);
                    MessageBox.Show("Articulo modificado");
                }
                else
                {
                    regArticulo.agregar(art);
                    MessageBox.Show("Articulo agregado");
                }
                Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < 48 || e.KeyChar > 58) && e.KeyChar != 8 && e.KeyChar !=46)
            {
                e.Handled = true;
            } 
        }

        private void cargarImagen(string carga)
        {
            try
            {
                pBoxAgregar.Load(carga);

            }
            catch (Exception)
            {
                pBoxAgregar.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }

        private void txtBoxImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtBoxImagen.Text);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            arch = new OpenFileDialog();
            arch.Filter = ".jpeg|*.jpg;|.png|*.png";
            if (Directory.Exists("C:\\Articulos"))
            {
                if (arch.ShowDialog() == DialogResult.OK)
                {
                    txtBoxImagen.Text = arch.FileName;
                    cargarImagen(arch.FileName);
                }
            }
            else
            {
                MessageBox.Show("No se pueden guardar imagenes locales. No existe la carpeta C:\\Articulos.");
            }
            

        }
    }
}
