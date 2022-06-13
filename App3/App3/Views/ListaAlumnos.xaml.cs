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
    public partial class ListaAlumnos : ContentPage
    {
        public ListaAlumnos()
        {
            InitializeComponent();
            btnVentanaEmergente.Clicked += MostrarVentana;
        }

        private void MostrarVentana(object sender, EventArgs e)
        {
            DisplayAlert("Mensaje", "Hacer la tarea", "OK");
        }

        private void SetDarkMode(object sender, EventArgs args)
        {

            if (btnDarkMode.Text == "DarkMode")
            {
                btnDarkMode.Text = "WhiteMode";
                SetColorDarkMode(Color.White, Color.FromHex("#1f1f1f"), Color.Azure, Color.FromHex("#2f2f2f"));
                
            }
            else
            {

                btnDarkMode.Text = "DarkMode";
                SetColorDarkMode(Color.Black, Color.White, Color.FromHex("#1f1f1f"), Color.FromHex("#efefef"));

            }

        }

        private void SetColorDarkMode(Color ColorTextPrimary, Color ColorBackgroundPrimary, Color ColorTextSecondary, Color ColorBackgroundSecondary)
        {
            
            btnDarkMode.TextColor = ColorTextPrimary;
            lblTitulo.TextColor = ColorTextPrimary;

            lblMarcos.TextColor = ColorTextSecondary;
            lblTomas.TextColor = ColorTextSecondary;
            lblLautaro.TextColor = ColorTextSecondary;
            lblChino.TextColor = ColorTextSecondary;
            lblGaspar.TextColor = ColorTextSecondary;
            lblAlan.TextColor = ColorTextSecondary;
            lblCesar.TextColor = ColorTextSecondary;
            lblJoana.TextColor = ColorTextSecondary;
            lblGabriel.TextColor = ColorTextSecondary;

            btnDarkMode.BackgroundColor = ColorBackgroundSecondary;
            stkBody.BackgroundColor = ColorBackgroundSecondary;
            stkBody2.BackgroundColor = ColorBackgroundSecondary;

            frmFondo.BackgroundColor = ColorBackgroundPrimary;

            
        }
    }
}