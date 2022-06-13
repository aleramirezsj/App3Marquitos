using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InicioNavigationPage());

        }

        protected override void OnStart()
        {
            Debug.Print(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>La aplicación inició correctamente");
        }

        protected override void OnSleep()
        {
            Debug.Print(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Salimos de la aplicación y la dejamos en segundo plano");
        }

        protected override void OnResume()
        {
            Debug.Print(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Hemos vuelto correctamente a APP");
        }
    }
}
