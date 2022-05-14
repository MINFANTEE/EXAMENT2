using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class HomeControllerTest
{
     
    [Test]
    public void Test_Index01()
    {
        var mockRepsHome = new Mock<ILibroRepositorio>();
        
        var controller = new HomeController(null, mockRepsHome.Object);
        var resultado = (ViewResult) controller.Index();
        
        Assert.IsNotNull(resultado);
        Assert.IsInstanceOf<ViewResult>(resultado);

    }


}