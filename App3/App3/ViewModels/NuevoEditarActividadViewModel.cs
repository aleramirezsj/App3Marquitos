using App3.Core;
using App3.Models;
using App3.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class NuevoEditarActividadViewModel: ObjetoNotificacion
    {
        ActividadesRepository actividadesRepository= new ActividadesRepository();
		
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; 
				OnPropertyChanged();
			}
		}
		private decimal costo;

		public decimal Costo
		{
			get { return costo; }
			set { costo = value;
				OnPropertyChanged();
			}
		}

		private string horarios;

		public string Horarios
		{
			get => horarios;
			set { 
				horarios = value;
				OnPropertyChanged();
			}
		}


		public Command GuardarCommand { get; }
		public Command CancelarCommand { get; }
        public Actividad ActividadEditada { get; internal set; }

        public NuevoEditarActividadViewModel()
		{
			GuardarCommand = new Command(Guardar);
			CancelarCommand = new Command(Cancelar);
		}

		private void Cancelar(object obj)
		{
            MessagingCenter.Send<object>(this, "VolverAActividadesView");
        }

        private async void Guardar(object obj)
		{
			if (ActividadEditada == null)
				await actividadesRepository.AddAsync(nombre, horarios, costo);
			else
				await actividadesRepository.UpdateAsync(nombre, horarios, costo, ActividadEditada.Id);
			MessagingCenter.Send<object>(this, "VolverAActividadesView");
		}

        internal void CargarDatosDePantalla()
        {
            Nombre=ActividadEditada.Nombre;
			Horarios=ActividadEditada.Horarios;
			Costo=ActividadEditada.Costo;
        }
    }
}
