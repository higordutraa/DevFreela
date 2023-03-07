using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTest
    {
        private static readonly AuthService authService;
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var createUserCommand = new CreateUserCommand
            {
                FullName = "Higor Dutra",
                Email = "higor.dutra@hotmail.com",
                Password = "Teste1@21",
                BirthDate = new DateTime(1999, 11, 30),
                Role = "freelancer"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authService);

            //Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(id>=0);
            userRepositoryMock.Verify(pr => pr.Create(It.IsAny<User>()), Times.Once());
        }
    }
}
