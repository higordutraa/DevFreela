using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class  GetAllProjectsCommandHandlerTest
    {
        [Fact]
        //Give-When-Then
        //Dado que os dados de entrada estão corretos- Quando executado - Retorna o Id do project
        public async Task ThreeProjectsExists_Executed_ReturnThreeProjectViewModels()
        {

            // Padrão AAA
            //Arrange: Onde os testes são preparados, definição e configuração de dependências
            var projects = new List<Project>
            {
                new Project("Nome do teste 1", "Descrição do teste 1", 1, 2, 10000),
                new Project("Nome do teste 2", "Descrição do teste 2", 1, 2, 20000),
                new Project("Nome do teste 3", "Descrição do teste 3", 1, 2, 30000),

            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr=>pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act: A ação a ser testada é executada
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert: São realizadas verificações sobre o estado final
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
