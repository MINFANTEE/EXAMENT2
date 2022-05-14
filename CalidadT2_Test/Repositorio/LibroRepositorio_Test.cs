using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Moq;
using NUnit.Framework;


namespace CalidadT2Test.Repositorio;

public class LibroRepositorioTest
{
    private IQueryable<Libro> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Libro>
        {
            new Libro(){Id = 1, Nombre = "Victor", Imagen = "Cascada", Puntaje = 3},
            new Libro(){Id = 2, Nombre = "Alesandro", Imagen = "Oro", Puntaje = 3},
            
        }.AsQueryable();
        
        var mockDbseLibro = new MockDbSet<Libro>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Libros).Returns(mockDbseLibro.Object);

    }

    //---------------------------

    [Test]
    
    public void Test_ObtenerLibrosRepo1()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);
        var resultado = repositorio.ObtenerLibros();
        
        Assert.AreEqual(2, resultado.Count);
    }
    
    //---------------------------

    [Test]
    public void Test_ObtenerLibrosPorId2()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);
        var resultado = repositorio.ObtenetLibroPorId(2);
        
        Assert.AreEqual(2, resultado.Id);
    }

}