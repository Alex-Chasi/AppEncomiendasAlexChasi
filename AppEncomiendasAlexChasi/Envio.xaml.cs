using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace AppEncomiendasAlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Envio : ContentPage
    {
        ZXingBarcodeImageView qr;
        public Envio()
        {
            InitializeComponent();
            //QRInit();
        }

        private async void btnGenerar_Clicked(object sender, EventArgs e)
        {

            try
            {

                //calculo de porcentaje
                double iva = 0.12;
                double v1 = Convert.ToDouble(txtValorEnvio.Text);
                txtTotal.Text = v1.ToString();
                txtSubTotal.Text = v1.ToString();
                //calculo 12%
                double to = ((v1 * iva)+v1);
                txtPrecioTotal.Text = to.ToString();


                QRInit();

                //await DisplayAlert("Registro","Se registro con exito el envio", "Ok");
                //clear();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Ok");
            }

        }
        void clear()
        {
            txtDetalleEnvio.Text = " ";
            txtValorEnvio.Text = " ";
            txtTotal.Text = " ";
            txtSubTotal.Text = " ";
            txtPrecioTotal.Text = " ";     
            
        }
           

        void QRInit()
        {
            //generar QR
            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //seleccionamos el tipo de codigo QR (barras,circulo,cuadrado)
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            //qr.BarcodeValue = "https://www.facebook.com/";
            //qr.BarcodeValue = txtDetalleEnvio.Text;
            var Tex = "Descripcion de Envio: ";
            var Tex1 = "Precio TOTAL a Pagar es: $";

            qr.BarcodeValue = Tex + ' ' + txtDetalleEnvio.Text + ' ' +
                Tex1 + ' ' + txtPrecioTotal.Text;

            stkQR.Children.Add(qr);
        }


    }
}