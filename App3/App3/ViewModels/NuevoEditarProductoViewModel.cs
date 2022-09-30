using App3.Core;
using App3.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class NuevoEditarProductoViewModel: ObjetoNotificacion
    {
        ProductosRepository productosRepository= new ProductosRepository();
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; 
				OnPropertyChanged();
			}
		}
		private float precio;

		public float Precio
		{
			get { return precio; }
			set { precio = value;
				OnPropertyChanged();
			}
		}
		public Command GuardarCommand { get; }
		public Command CancelarCommand { get; }

		public NuevoEditarProductoViewModel()
		{
			GuardarCommand = new Command(Guardar);
			CancelarCommand = new Command(Cancelar);
		}

		private void Cancelar(object obj)
		{
            MessagingCenter.Send<object>(this, "VolverAProductoView");
        }

        private async void Guardar(object obj)
		{
			await productosRepository.AddAsync(nombre,precio);
			MessagingCenter.Send<object>(this, "VolverAProductoView");
		}
	}
}
