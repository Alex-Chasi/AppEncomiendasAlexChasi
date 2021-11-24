using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using AppEncomiendasAlexChasi.Models;
using System.Net.Http;
using System.Net;

namespace AppEncomiendasAlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            Logi log = new Logi
            {
                usuario = txtUsuario.Text,
                contrasenia = txtContrasenia.Text            
            };

            Uri RequestUri = new Uri("http://192.168.50.106:8000/api/consulta");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new MainPage());


            }
            else
            {
                await DisplayAlert("Mensaje", "Datos incorrectos ", "Ok");
            }

        }
    }
}