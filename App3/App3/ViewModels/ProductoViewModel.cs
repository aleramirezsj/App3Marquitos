using App3.Core;
using App3.Models;
using App3.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class ProductoViewModel : ObjetoNotificacion
    {
        private ProductosRepository productosRepository = new ProductosRepository();
        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get { return productos; }
            set { productos = value;
                OnPropertyChanged();
            }
        }

        private int productoSeleccionado;
        public int ProductoSeleccionado
        {
            get { return productoSeleccionado; }
            set { productoSeleccionado = value;
                    OnPropertyChanged();
            }
        }


        public Command CargarNuevoCommand { get; }
        public Command ModificarCommand { get; }
        public Command EliminarCommand { get; }
        public Command ObtenerProductosCommand { get; }
        public ProductoViewModel()
        {
            productos = new ObservableCollection<Producto>();
            ObtenerProductosCommand = new Command(ObtenerProductos);
            ObtenerProductos(this);
        }

        private async void ObtenerProductos(object obj)
        {
            productos.Clear();
            var productosCollection = await productosRepository.GetAllAsync();
            foreach(Producto producto in productosCollection)
            {
                productos.Add(producto);
            }
        }
    }
}
