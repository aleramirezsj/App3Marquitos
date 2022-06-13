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
    public partial class ListaProvinciasGrid : ContentPage
    {
        public ListaProvinciasGrid()
        {
            InitializeComponent();
            btnRecordatorio.Clicked += MostrarRecordatorio;
        }

        private void MostrarRecordatorio(object sender, EventArgs e)
        {
            DisplayAlert("Recordatorio", "Hacer las tareas obligatorias", "OK");
        }

        private void setDarkMode(object sender, EventArgs args)
        {
            if (btnDarkModeProvincias.Text == "DarkMode")
            {
                btnDarkModeProvincias.Text = "WhiteMode";
                SetColorDarkMode(Color.White, Color.FromHex("#1f1f1f"), Color.Azure, Color.FromHex("#2f2f2f"));
            }
            else
            {
                btnDarkModeProvincias.Text = "DarkMode";
                SetColorDarkMode(Color.Black, Color.White, Color.FromHex("#1f1f1f"), Color.FromHex("#efefef"));
            }
        }

        private void SetColorDarkMode(Color ColorTextPrimary, Color ColorBackgroundPrimary, Color ColorTextSecondary, Color ColorBackgroundSecondary)
        {
            btnDarkModeProvincias.TextColor = ColorTextPrimary;
            btnRecordatorio.TextColor = ColorTextPrimary;
            lblProvincias.TextColor = ColorTextPrimary;

            lblBsAs.TextColor = ColorTextSecondary;
            lblLaPlata.TextColor = ColorTextSecondary;
            lblEntreRios.TextColor = ColorTextSecondary;
            lblParana.TextColor = ColorTextSecondary;
            lblSalta.TextColor = ColorTextSecondary;
            lblCSalta.TextColor = ColorTextSecondary;
            lblSantaFe.TextColor = ColorTextSecondary;
            lblCSantaFe.TextColor = ColorTextSecondary;
            lblCordoba.TextColor = ColorTextSecondary;
            lblCCordoba.TextColor = ColorTextSecondary;
            lblCorrientes.TextColor = ColorTextSecondary;
            lblCCorrientes.TextColor = ColorTextSecondary;
            lblFormosa.TextColor = ColorTextSecondary;
            lblCFormosa.TextColor = ColorTextSecondary;
            lblMendoza.TextColor = ColorTextSecondary;
            lblCMendoza.TextColor = ColorTextSecondary;
            lblMisiones.TextColor = ColorTextSecondary;
            lblPosadas.TextColor = ColorTextSecondary;
            lblTierraDelFuego.TextColor = ColorTextSecondary;
            lblUshuaia.TextColor = ColorTextSecondary;

            btnDarkModeProvincias.BackgroundColor = ColorBackgroundSecondary;
            btnRecordatorio.BackgroundColor = ColorBackgroundSecondary;
            stkBodyProvincias.BackgroundColor = ColorBackgroundSecondary;
            scrBodyProvincias.BackgroundColor = ColorBackgroundSecondary;

            grdFondoProvincias.BackgroundColor = ColorBackgroundPrimary;
        }
    }
}