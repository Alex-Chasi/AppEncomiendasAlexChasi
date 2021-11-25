using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms.Xaml;

namespace AppEncomiendasAlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Qr : ContentPage
    {
        ZXingBarcodeImageView qr;

        public Qr()
        {
            InitializeComponent();
        }

        private void btnGenerar_Clicked(object sender, EventArgs e)
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
            qr.BarcodeValue = "https://www.facebook.com/";
            //qr.BarcodeValue = txtDetalleEnvio.Text;

            stkQR.Children.Add(qr);

        }
    }
}