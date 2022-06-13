using App3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioNavigationPage : ContentPage
    {
        public InicioNavigationPage()
        {
            InitializeComponent();
        }
        public async void AbrirListaAlumnos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaAlumnos());
        }
        public async void AbrirListaProvincias(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaProvinciasGrid());
        }
        public async void AbrirControlesComunes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ControlesComunes());
        }
    }
}