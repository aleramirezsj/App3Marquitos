using App3.Core;
using App3.Models;
using App3.Repositories;
using App3.Views;
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

        private Producto productoSeleccionado;
        public Producto ProductoSeleccionado
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
            CargarNuevoCommand = new Command(CargarNuevo);
            ModificarCommand = new Command(Modificar);
            EliminarCommand = new Command(Eliminar);
            ObtenerProductos(this);
        }

        private async void Eliminar(object obj)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar producto", $"¿Está seguro que desea borrar el producto {productoSeleccionado.Nombre}?", "Si", "No");
            if(respuesta)
            {
                productosRepository.DeleteAsync(productoSeleccionado._id);
                productoSeleccionado = null;
                ObtenerProductos(this);
            }
        }

        private void Modificar(object obj)
        {
            MessagingCenter.Send<object>(this, "AbrirNuevoEditarProductoView");
        }

        private void CargarNuevo(object obj)
        {
             MessagingCenter.Send<object>(this,"AbrirNuevoEditarProductoView");
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
