using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Outside.Tdd._2ClassesCollaboration.Api;
using Outside.Tdd._2ClassesCollaboration.Api.Controllers;
using Shouldly;
using Xunit;

namespace Outside.Tdd._2ClassesCollaboration
{
    public class UserControllerShould
    {
        private readonly UsersController _usersController;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IUserToUserResponseParser> _userToUserResponseParserMock;

        public UserControllerShould()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userToUserResponseParserMock = new Mock<IUserToUserResponseParser>();
            _usersController = new UsersController(_userRepositoryMock.Object, _userToUserResponseParserMock.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void ReturnParsedUserFromRepository(int id)
        {
            var user = new User();
            var userResponse = new UserResponse();
            _userRepositoryMock.Setup(p => p.GetBy(id))
                .Returns(user);
            _userToUserResponseParserMock.Setup(p => p.Parse(user))
                .Returns(userResponse);

            var result = (OkObjectResult)_usersController.GetUserBy(id);

            result.Value.ShouldBe(userResponse);

            _userRepositoryMock.Verify(p => p.GetBy(id));
        }

        [Fact]
        public void ReturnNotFoundOnUserNotFoundException()
        {
            int id = 1;
            _userRepositoryMock.Setup(p => p.GetBy(id))
                .Throws<UserNotFoundException>();

            var result = _usersController.GetUserBy(id);

            result.ShouldBeOfType<NotFoundResult>();
        }
    }

}
