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
            MessagingCenter.Subscribe<object>(this, "AbrirNuevoEditarProductoView", 
                async (obj) =>
            {
                await Navigation.PushAsync(new NuevoEditarProductoView());
            });
            MessagingCenter.Subscribe<object>(this, "VolverAProductoView",
                async (obj) =>
                {
                    await Navigation.PopAsync();
                });
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
        public async void AbrirListaProductos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoView());
        }
        public async void AbrirListaActividades(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActividadesView());
        }
    }
}