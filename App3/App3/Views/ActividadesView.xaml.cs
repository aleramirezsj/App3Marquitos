using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActividadesView : ContentPage
    {
        public ActividadesView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewmodel = this.BindingContext as ActividadesViewModel;
            if (viewmodel.ActividadSeleccionada != null)
            {
                viewmodel.ObtenerActividades(this);
                viewmodel.ActividadSeleccionada = null;
            }
        }
    }
}