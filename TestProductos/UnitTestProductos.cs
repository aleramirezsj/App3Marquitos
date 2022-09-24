using App3.Models;
using App3.Repositories;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TestProductos
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAddProducto()
        {
            ProductosRepository productosRepository = new ProductosRepository();
            Producto productoCargado = await productosRepository.AddAsync("Alfajor Milka", 180.0f);
            Assert.That("Alfajor Milka", Is.EqualTo(productoCargado.Nombre));
        }

        [Test]
        public async Task TestDeleteProducto()
        {
            var productosRepository = new ProductosRepository();
            var borrado=await productosRepository.DeleteAsync("62b610da72ab58170000166b");
            
            Assert.That(true, Is.EqualTo(borrado));
        }
        [Test]
        public async Task TestUpdateProducto()
        {
            var productosRepository = new ProductosRepository();
            var actualizado = await productosRepository.UpdateAsync("Coca cola 3lts", 300f, "62b5fd2c72ab581700001591");
            Assert.That(true, Is.EqualTo(actualizado));
        }
        [Test]
        public async Task TestGetAllAsyncProductos()
        {
            var productosRepository = new ProductosRepository();
            var productos= await productosRepository.GetAllAsync();
            var primerProducto = productos.ElementAt<Producto>(0);
            Assert.That(primerProducto.Nombre,Is.EqualTo("Coca cola 3lts"));
        }
        [Test]
        public async Task TestGetByIdAsyncProductos()
        {
            var productosRepository = new ProductosRepository();
            var producto = await productosRepository.GetByIdAsync("62b5fd2c72ab581700001591");
            Assert.That(producto.Nombre, Is.EqualTo("Coca cola 3lts"));
        }
    }
}