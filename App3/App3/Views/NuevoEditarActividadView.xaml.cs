using App3.Models;
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
    public partial class NuevoEditarActividadView : ContentPage
    {
        NuevoEditarActividadViewModel nuevoEditarActividadViewModel;
        public NuevoEditarActividadView()
        {
            InitializeComponent();
        }
        public NuevoEditarActividadView(Actividad actividadAModificar)
        {
            InitializeComponent();
            nuevoEditarActividadViewModel= this.BindingContext as NuevoEditarActividadViewModel;
            nuevoEditarActividadViewModel.ActividadEditada = actividadAModificar;
            nuevoEditarActividadViewModel.CargarDatosDePantalla();
        }
    }
}