using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEncomiendasAlexChasi.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEncomiendasAlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Destinatario : ContentPage
    {
        public Destinatario()
        {
            InitializeComponent();
            llenarDatos();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                modelDestinatario desti = new modelDestinatario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Cedula = int.Parse(txtCedula.Text),
                    Telefono = int.Parse(txtTelefono.Text)
                };
                //inserta en la BASE de datos
                await App.SQLiteDB.SaveDestinatarioAsync(desti);
                
                await DisplayAlert("Registro", "Se ingreso con Exito el Destinatario", "OK");
                Clear();
                //llamamos a la lista llenar Datos
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los Datos", "OK");
            }

        }

        //lenarDatos
        public async void llenarDatos()
        {
            var destinatarioList = await App.SQLiteDB.GetDestinatarioAsync();
            if (destinatarioList != null)
            {
                listaDestinatario.ItemsSource = destinatarioList;
            }
        }

        //metodo limpiar 
        void Clear()
        {
            txtIdDestinatario.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
        }


        //validacion de datos que no esten vacios
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
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
            if (!string.IsNullOrEmpty(txtIdDestinatario.Text))
            {
                modelDestinatario desti = new modelDestinatario()
                {
                    IdDestinatario = Convert.ToInt32(txtIdDestinatario.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Cedula = Convert.ToInt32(txtCedula.Text),
                    Telefono = Convert.ToInt32(txtTelefono.Text),
                };
                await App.SQLiteDB.SaveDestinatarioAsync(desti);
                await DisplayAlert("Registro", "Se Actualizo de manera exitosa el Destinatario", "OK");

                //limpiamos los campos
                Clear();
                txtIdDestinatario.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnGuardar.IsVisible = true;
                llenarDatos();
            }

        }

        private async void listaDestinatario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (modelDestinatario)e.SelectedItem;
            btnGuardar.IsVisible = false;
            txtIdDestinatario.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdDestinatario.ToString()))
            {
                var destinatario = await App.SQLiteDB.GetDestinatarioByIdAsync(obj.IdDestinatario);
                if (destinatario != null)
                {
                    txtIdDestinatario.Text = destinatario.IdDestinatario.ToString();
                    txtNombre.Text = destinatario.Nombre;
                    txtApellido.Text = destinatario.Apellido;
                    txtEmail.Text = destinatario.Email;
                    txtCedula.Text = destinatario.Cedula.ToString();
                    txtTelefono.Text = destinatario.Telefono.ToString();
                }
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var destinatario = await App.SQLiteDB.GetDestinatarioByIdAsync(Convert.ToInt32(txtIdDestinatario.Text));
            if (destinatario != null)
            {
                await App.SQLiteDB.DeleteDestinatarioAsync(destinatario);
                await DisplayAlert("Destinatario", "Se Elimino de manera exitosa el Destinatario", "OK");
                Clear();
                llenarDatos();
                txtIdDestinatario.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnGuardar.IsVisible = true;
            }

        }
    }
}