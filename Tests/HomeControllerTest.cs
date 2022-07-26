using Microsoft.AspNetCore.Mvc;
using LoanApp.Controllers;
using Xunit;
using Moq;
using LoanApp.Repositories;
using LoanApp.Models;
using System.Security.Claims;
using System.Linq.Expressions;

namespace UnitTestApp.Tests
{
    public class HomeControllerTests
    {
        private User signedUserMock = new User { Name = "Mock", Phone = "12345", Password = "MockPass", ContactList = "2,3", TotalLoan = -300, UserId = 1 };
        [Fact]
        public void IndexViewDataMessage()
        {
            // Mock repo data
            var userMock = new Mock<IRepository<User>>();
            userMock.Setup(repo => repo.GetByCondition(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(this.signedUserMock);
            var loanMock = new Mock<IRepository<Loan>>();
            loanMock.Setup(repo => repo.GetRangeByCondition(It.IsAny<Expression<Func<Loan, bool>>>())).ReturnsAsync(GetLoanList());

            var controller = new HomeController(loanMock.Object, userMock.Object);

            //
            var result = controller.Index();
            result.Wait();
            var viewResult = result.Result as ViewResult;

            //
            Assert.IsType<ViewResult>(viewResult);
            var model = Assert.IsAssignableFrom<List<Loan>>(viewResult?.Model);
            Assert.Equal(GetLoanList().Count(), model.Count());
        }
        
        private IEnumerable<Loan> GetLoanList()
        {
            var loans = new List<Loan>
            {
                new Loan {Id = 1, UserId = 1, Reason = "Buy a car", DateOfCreation = DateTime.Now, Value = -300, WhomUserId = 2},
                new Loan {Id = 2, UserId = 1, Reason = "Returning car", DateOfCreation = DateTime.Now, Value = 300, WhomUserId = 2},
                new Loan {Id = 3, UserId = 1, Reason = "Gold for wow", DateOfCreation = DateTime.Now, Value = 70, WhomUserId = 2},
                new Loan {Id = 4, UserId = 1, Reason = "Anime", DateOfCreation = DateTime.Now, Value = 398, WhomUserId = 2},
                new Loan {Id = 5, UserId = 1, Reason = "Anime 2", DateOfCreation = DateTime.Now, Value = -75, WhomUserId = 2},
            };
            return loans;
        }
    }
}