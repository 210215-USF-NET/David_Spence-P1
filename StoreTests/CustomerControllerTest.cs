using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using StoreBL;
using StoreDL;
using StoreModels;
using StoreMVC;
using StoreMVC.Controllers;
using StoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreTests
{
    //[TestClass]
    public class CustomerControllerTest
    {
        //[TestMethod]
        [Fact]
        public void CustomerControllerShouldReturnIndex()
        {
            var mockRepo = new Mock<IStoreBL>();
            mockRepo.Setup(x => x.GetCustomers())
                .Returns(new List<Customer>()
                {
                    new Customer
                    {
                        Id = 1,
                        Name = "Bobby Joe",
                        Phone = "999-999-999"
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Elvis Presley",
                        Phone = "555-555-5555"
                    }
                }
                );
            var controller = new CustomerController(mockRepo.Object, new Mapper());

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerIndexVM>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());

        }
    }
}
