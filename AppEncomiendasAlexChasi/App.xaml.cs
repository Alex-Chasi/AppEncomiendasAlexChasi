using AppEncomiendasAlexChasi.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEncomiendasAlexChasi
{
    public partial class App : Application
    {

        //conexion
        static SQLiteHelper db;

        //public NavigationPage Login { get; }

        public static MasterDetailPage MasterDet { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            //MainPage = MainPage = new NavigationPage(new MainPage()); //esto funciona correcto

            MainPage = new NavigationPage(new Login());

            //MainPage = MainPage = new NavigationPage(new Login());


        }

        //conexion creado
        public static SQLiteHelper SQLiteDB 
        {
            get
            {
                if (db==null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Encomienda.db3"));
                    
                }
                return db;
            }
        
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
