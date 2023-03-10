using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectID()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var createCommentCommand = new CreateCommentCommand()
            {
                Content = "Comentário aqui.",
                IdProject = 1,
                IdUser = 2
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock.Object);

            //Act
            var content = await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            //Assert
            Assert.True(content.ToString() != null);

            projectRepositoryMock.Verify(pr => pr.CreateCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}
