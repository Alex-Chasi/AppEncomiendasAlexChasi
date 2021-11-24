using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppEncomiendasAlexChasi.Models;


namespace AppEncomiendasAlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Remitente : ContentPage
    {
        public Remitente()
        {
            InitializeComponent();
            llenarDatos();
        }

        //public int IdRemitente { get; internal set; }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                modelRemitente rem = new modelRemitente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Cedula = txtCedula.Text,
                    Telefono = txtTelefono.Text
                };
                //inserta en la BASE de datos
                await App.SQLiteDB.SaveRemitenteAsync(rem);
                Clear();
                await DisplayAlert("Registro", "Se ingreso con Exito el Remitente", "OK");

                //llamamos a la lista llenar Datos
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los Datos", "OK");
            }

        }

        //metodo llenar Datos
        public async void llenarDatos()
        {
            var remitenteList = await App.SQLiteDB.GetRemitenteAsync();
            if (remitenteList != null)
            {
                listaRemitente.ItemsSource = remitenteList;
            }
        }

        //metodo limpiar 
        void Clear()
        {

            txtIdAlumno.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
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
            if (!string.IsNullOrEmpty(txtIdAlumno.Text))
            {
                modelRemitente remi = new modelRemitente()
                {
                    IdRemitente = Convert.ToInt32(txtIdAlumno.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Cedula = txtCedula.Text,
                    Telefono = txtTelefono.Text
                };
                await App.SQLiteDB.SaveRemitenteAsync(remi);
                await DisplayAlert("Registro", "Se Actualizo de manera exitosa el Remitente", "OK");

                //limpiamos los campos
                Clear();
                txtIdAlumno.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnGuardar.IsVisible = true;
                llenarDatos();
            }
        }

        private async void listaRemitente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {       
            var obj = (modelRemitente)e.SelectedItem;
            btnGuardar.IsVisible = false;
            txtIdAlumno.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdRemitente.ToString()))
            {
                var remitente = await App.SQLiteDB.GetRemitenteByIdAsync(obj.IdRemitente);
                if (remitente!=null)
                {
                    txtIdAlumno.Text = remitente.IdRemitente.ToString();
                    txtNombre.Text = remitente.Nombre;
                    txtApellido.Text = remitente.Apellido;
                    txtCedula.Text = remitente.Cedula;
                    txtTelefono.Text = remitente.Telefono;
                }
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var remitente = await App.SQLiteDB.GetRemitenteByIdAsync(Convert.ToInt32(txtIdAlumno.Text));
            if (remitente != null)
            {
                await App.SQLiteDB.DeleteAlumnoAsync(remitente);
                await DisplayAlert("Remitente", "Se Elimino de manera exitosa el Remitente", "OK");
                Clear();
                llenarDatos();
                txtIdAlumno.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnGuardar.IsVisible = true;
            }
        }
    }
}