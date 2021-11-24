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
    public partial class Envio : ContentPage
    {
        public Envio()
        {
            InitializeComponent();
        }

        private void btnGenerar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //double iva = 0.12;
                double v1 = Convert.ToDouble(txtValorEnvio.Text);
                txtTotal.Text = v1.ToString();
                txtSubTotal.Text = v1.ToString();
                txtPrecioTotal.Text = v1.ToString();



            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
            }

        }
    }
}