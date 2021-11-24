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
    public partial class Transporte : ContentPage
    {
        public Transporte()
        {
            InitializeComponent();
            llenarDatos();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                modelTransporte transpor = new modelTransporte
                {
                    Descripcion = txtDescripcion.Text,
                    TipoTransporte = txtTipoTransporte.Text,
                    Marca = txtMarca.Text,
                    Modelo = txtModelo.Text,
                    Chofer = txtChofer.Text

                };
                //inserta en la BASE de datos
                await App.SQLiteDB.SaveTransporteAsync(transpor);
                Clear();
                await DisplayAlert("Registro", "Se ingreso con Exito el Transporte", "OK");

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
            var transporteList = await App.SQLiteDB.GetTransporteAsync();
            if (transporteList != null)
            {
                listaTransporte.ItemsSource = transporteList;
            }
        }


        //metodo limpiar 
        void Clear()
        {
            txtIdTransporte.Text = "";
            txtDescripcion.Text = "";
            txtTipoTransporte.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtChofer.Text = "";
        }

        //validacion de datos que no esten vacios
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTipoTransporte.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtMarca.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtModelo.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtChofer.Text))
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
            if (!string.IsNullOrEmpty(txtIdTransporte.Text))
            {
                modelTransporte transporte = new modelTransporte()
                {
                    IdTransporte = Convert.ToInt32(txtIdTransporte.Text),
                    Descripcion = txtDescripcion.Text,
                    TipoTransporte = txtTipoTransporte.Text,
                    Marca = txtMarca.Text,
                    Modelo = txtModelo.Text,
                    Chofer = txtChofer.Text,

                };
                await App.SQLiteDB.SaveTransporteAsync(transporte);
                await DisplayAlert("Registro", "Se Actualizo de manera exitosa el Transporte", "OK");

                //limpiamos los campos
                Clear();
                txtIdTransporte.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnGuardar.IsVisible = true;
                llenarDatos();
            }


        }

        private async void listaTransporte_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (modelTransporte)e.SelectedItem;
            btnGuardar.IsVisible = false;
            txtIdTransporte.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdTransporte.ToString()))
            {
                var transporte = await App.SQLiteDB.GetTransporteByIdAsync(obj.IdTransporte);
                if (transporte != null)
                {
                    txtIdTransporte.Text = transporte.IdTransporte.ToString();
                    txtDescripcion.Text = transporte.Descripcion;
                    txtTipoTransporte.Text = transporte.TipoTransporte;
                    txtMarca.Text = transporte.Marca;
                    txtModelo.Text = transporte.Modelo;
                    txtChofer.Text = transporte.Chofer;
                }

            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var transporte = await App.SQLiteDB.GetTransporteByIdAsync(Convert.ToInt32(txtIdTransporte.Text));
            if (transporte != null)
            {
                await App.SQLiteDB.DeleteTransporteAsync(transporte);
                await DisplayAlert("Transporte", "Se Elimino de manera exitosa el Transporte", "OK");
                Clear();
                llenarDatos();
                txtIdTransporte.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnGuardar.IsVisible = true;
            }

        }
    }
}
