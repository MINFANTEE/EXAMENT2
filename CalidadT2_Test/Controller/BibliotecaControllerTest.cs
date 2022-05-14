using System.Collections.Generic;
using System.Security.Claims;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class BibliotecaControllerTest
{
    
    [Test]
    
    public void Test_Index1()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepositorio = new Mock<IUsuarioRepositorio>();
        mockUserRepositorio.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var controller = new BibliotecaController(null, mockUserRepositorio.Object, null);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var resultado = controller.Index;

        Assert.IsNotNull(resultado);
    }
    
    
    [Test]
    
    public void Test_Add2()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepositorio = new Mock<IUsuarioRepositorio>();
        mockUserRepositorio.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockBibliotecaRepositorio = new Mock<IBibliotecaRepositorio>();

        var controller = new BibliotecaController(null, mockUserRepositorio.Object, mockBibliotecaRepositorio.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var resultado = controller.Add(1);

        Assert.IsNotNull(resultado);
    }
    
    
    [Test]
    
    public void Test_MarcarComoLeyendo3()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepositorio = new Mock<IUsuarioRepositorio>();
        mockUserRepositorio.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockBibliotecaRepositorio = new Mock<IBibliotecaRepositorio>();

        var controller = new BibliotecaController(null, mockUserRepositorio.Object, mockBibliotecaRepositorio.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var resultado = controller.MarcarComoLeyendo(1);

        Assert.IsNotNull(resultado);
    }
    
    [Test]
    
    public void Test_MarcarComoTerminado4()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepositorio = new Mock<IUsuarioRepositorio>();
        mockUserRepositorio.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBibliotecaRepositorio>();

        var controller = new BibliotecaController(null, mockUserRepositorio.Object, mockBibliotecaRepo.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var resultado = controller.MarcarComoTerminado(1);

        Assert.IsNotNull(resultado);
    }
}