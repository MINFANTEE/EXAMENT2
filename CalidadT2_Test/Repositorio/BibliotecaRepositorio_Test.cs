using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Moq;
using NUnit.Framework;


namespace CalidadT2Test.Repositorio;


public class BibliotecaRepositorioTest
{
    private IQueryable<Biblioteca> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Biblioteca>
        {
            new Biblioteca(){Id = 1, UsuarioId = 1, LibroId = 1},
            new Biblioteca(){Id = 2, UsuarioId = 2, LibroId = 2}
            
        }.AsQueryable();
        
        var mockDbseBiblioteca = new MockDbSet<Biblioteca>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Bibliotecas).Returns(mockDbseBiblioteca.Object);

    }

    //---------------------------

    [Test]
    public void Test_Obt_Biblioteca1()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var resultado = repositorio.Obt_Biblioteca(1);
        
        Assert.AreEqual(1, resultado.Count);
    }
    
    [Test]
    public void Test_Agr_Biblioteca2()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var resultado = repositorio.Agr_Biblioteca(new Biblioteca() {
            Id = 3, UsuarioId = 2, LibroId = 1
        });

        Assert.AreEqual(3, resultado.Id);
    }
    
    [Test]
    public void Test_Act_Estado3()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var resultado = repositorio.Act_Estado(1,1);

        Assert.AreEqual(1, resultado.Id);
    }
}