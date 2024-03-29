﻿using App3.Core;
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
    public class ActividadesViewModel : ObjetoNotificacion
    {
        private ActividadesRepository actividadesRepository = new ActividadesRepository();

        //campo actividades(va con minúsculas y es privada)
        private ObservableCollection<Actividad> actividades;

        //propiedad Actividades (va con mayúsculas y es pública)
        public ObservableCollection<Actividad> Actividades
        {
            get { return actividades; }
            set { actividades = value;
                OnPropertyChanged();
            }
        }
        //campo
        private Actividad actividadSeleccionada;

        //propiedad
        public Actividad ActividadSeleccionada
        {
            get { return actividadSeleccionada; }
            set { actividadSeleccionada = value;
                    OnPropertyChanged();
                ModificarCommand.ChangeCanExecute();
                EliminarCommand.ChangeCanExecute();
            }
        }


        public Command CargarNuevoCommand { get; }
        public Command ModificarCommand { get; }
        public Command EliminarCommand { get; }
        public Command ObtenerActividadesCommand { get; }
        
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public ActividadesViewModel()
        {
            actividades = new ObservableCollection<Actividad>();
            ObtenerActividadesCommand = new Command(ObtenerActividades);
            CargarNuevoCommand = new Command(CargarNuevo);
            ModificarCommand = new Command(Modificar,PermitirModificar);
            EliminarCommand = new Command(Eliminar,PermitirEliminar) ;
            ObtenerActividades(this);
        }

        private bool PermitirEliminar(object arg)
        {
            return actividadSeleccionada!=null;
        }

        private bool PermitirModificar(object arg)
        {
            return actividadSeleccionada!=null;
        }

        private async void Eliminar(object obj)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar actividad", $"¿Está seguro que desea borrar la actividad {actividadSeleccionada.Nombre}?", "Si", "No");
            if(respuesta)
            {
                actividadesRepository.RemoveAsync(actividadSeleccionada.Id);
                actividadSeleccionada = null;
                ObtenerActividades(this);
            }
        }

        private void Modificar(object obj)
        {
            MessagingCenter.Send<object,Actividad>(this, "AbrirNuevoEditarActividadView",ActividadSeleccionada);
        }

        private void CargarNuevo(object obj)
        {
             MessagingCenter.Send<object>(this,"AbrirNuevoEditarActividadView");
        }

        public async void ObtenerActividades(object obj)
        {
            actividades.Clear();
            var actividadesCollection = await actividadesRepository.GetAllAsync();
            foreach(Actividad actividad in actividadesCollection)
            {
                actividades.Add(actividad);
            }
            IsRefreshing = false;
        }
    }
}
