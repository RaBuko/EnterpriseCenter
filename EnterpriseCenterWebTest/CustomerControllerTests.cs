using EnterpriseCenterWeb.Controllers;
using EnterpriseCenterWeb.Models;
using EnterpriseCenterWeb.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xunit;

namespace EnterpriseCenterWebTest
{
    [Collection("Customer Controller Tests")]
    public class CustomerControllerTests
    {


        CustomersController Controller { get; set; }

        public CustomerControllerTests()
        {
            Controller = new CustomersController(new LogToFileService(Directory.GetCurrentDirectory()));
        }

        [Fact]
        public async void Get_customers()
        {
            var actionResult = await Controller.Index("");

            //Assert
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
        }
    }
}
