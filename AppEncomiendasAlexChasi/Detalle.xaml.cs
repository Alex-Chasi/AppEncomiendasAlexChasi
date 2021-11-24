using AppEncomiendasAlexChasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEncomiendasAlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalle : ContentPage
    {
        public Detalle()
        {
            InitializeComponent();
            llenarDatos();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                modelDetalle det = new modelDetalle
                {
                    Descripcion = txtDescripcion.Text,
                    Tamanio = txtTamanio.Text,
                    Peso = txtPeso.Text
                };
                //inserta en la BASE de datos
                await App.SQLiteDB.SaveDetalleAsync(det);
                Clear();
                await DisplayAlert("Registro", "Se ingreso con Exito el Detalle", "OK");

                //llamamos a la lista llenar Datos
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los Datos", "OK");
            }

        }

        
        public async void llenarDatos()
        {
            var detalleList = await App.SQLiteDB.GetDetalleAsync();
            if (detalleList != null)
            {
                listaDetalle.ItemsSource = detalleList;
            }
        }


        //metodo limpiar 
        void Clear()
        {
            txtIdDetalle.Text = "";
            txtDescripcion.Text = "";
            txtTamanio.Text = "";
            txtPeso.Text = "";
        }

        //validacion de datos que no esten vacios
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTamanio.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPeso.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdDetalle.Text))
            {
                modelDetalle detalle = new modelDetalle()
                {
                    IdDetalle= Convert.ToInt32(txtIdDetalle.Text),
                    Descripcion = txtDescripcion.Text,
                    Tamanio = txtTamanio.Text,
                    Peso = txtPeso.Text,
                };
                await App.SQLiteDB.SaveDetalleAsync(detalle);
                await DisplayAlert("Registro", "Se Actualizo de manera exitosa el Detalle", "OK");

                //limpiamos los campos
                Clear();
                txtIdDetalle.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnGuardar.IsVisible = true;
                llenarDatos();
            }

        }

        private async void listaDetalle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (modelDetalle)e.SelectedItem;
            btnGuardar.IsVisible = false;
            txtIdDetalle.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdDetalle.ToString()))
            {
                var detalle = await App.SQLiteDB.GetDetalleByIdAsync(obj.IdDetalle);
                if (detalle != null)
                {
                    txtIdDetalle.Text = detalle.IdDetalle.ToString();
                    txtDescripcion.Text = detalle.Descripcion;
                    txtTamanio.Text = detalle.Tamanio;
                    txtPeso.Text = detalle.Peso;
                }
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var detalle = await App.SQLiteDB.GetDetalleByIdAsync(Convert.ToInt32(txtIdDetalle.Text));
            if (detalle != null)
            {
                await App.SQLiteDB.DeleteDetalleAsync(detalle);
                await DisplayAlert("Detalle", "Se Elimino de manera exitosa el Detalle", "OK");
                Clear();
                llenarDatos();
                txtIdDetalle.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnGuardar.IsVisible = true;
            }

        }
    }
}