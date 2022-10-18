using App3.Models;
using App3.Repositories;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class TestsActividades
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddActividad()
        {
            ActividadesRepository actividadesRepository = new ActividadesRepository();
            Actividad actividadCargada = await actividadesRepository.AddAsync("Ajedrez Ale", "Viernes de 13:50hs a 17:20hs", 2000);
            Assert.That("Ajedrez Ale", Is.EqualTo(actividadCargada.Nombre));
        }

        [Test]
        public async Task TestDeleteActividad()
        {
            var actividadesRepository = new ActividadesRepository();
            var borrado=await actividadesRepository.RemoveAsync(14);
            Assert.That(true, Is.EqualTo(borrado));
        }
        [Test]
        public async Task TestUpdateActividad()
        {
            var actividadesRepository = new ActividadesRepository();
            var actualizado = await actividadesRepository.UpdateAsync("Ajedrez Ramirez","Viernes 13:50hs a 16:40hs", 1500, 4);
            Assert.That(true, Is.EqualTo(actualizado));
        }
        [Test]
        public async Task TestGetAllAsyncActividades()
        {
            var actividadesRepository = new ActividadesRepository();
            var actividades = await actividadesRepository.GetAllAsync();
            var primerActividad = actividades.ElementAt<Actividad>(0);
            Assert.That(primerActividad.Nombre,Is.EqualTo("Folklore en la nube"));
        }
        [Test]
        public async Task TestGetByIdAsyncProductos()
        {
            var actividadesRepository = new ActividadesRepository();
            var actividad = await actividadesRepository.GetByIdAsync(1);
            Assert.That(actividad.Nombre, Is.EqualTo("Folklore en la nube"));
        }
    }
}