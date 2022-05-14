using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class UsuarioRepositoriotest
{
    private IQueryable<Usuario> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Usuario>
        {
            new Usuario(){Id = 1, Username = "admin", Password = "admin", Nombres = "Maloni"},
            new Usuario(){Id = 2, Username = "Dan", Password = "Dan", Nombres = "Dany"}
            
        }.AsQueryable();
        
        var mockDbseUsuario = new MockDbSet<Usuario>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Usuarios).Returns(mockDbseUsuario.Object);

    }

    [Test]
    public void Test_ObUsuario1()
    {
        var ropositorio = new UsuarioRepositorio(mockDB.Object);
        var resultado = ropositorio.UsuarioLoguer("admin");
        
        Assert.AreEqual("admin", resultado.Username);
    }
}