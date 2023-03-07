using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTest
    {
        [Fact]
        public async Task ThreeSkillsExist_Executed_ReturnThreeSkillViewModels()
        {
            //Arrange
            var skillsDTO = new List<SkillDTO>
            {
                new SkillDTO(1, "C#"),
                new SkillDTO(2, "SQL"),
                new SkillDTO(3, ".NET")
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(skillsDTO);

            var getAllSkillsDTOQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            //Act
            var skillViewModelList = await getAllSkillsQueryHandler.Handle(getAllSkillsDTOQuery, new CancellationToken());

            //Assert
            Assert.NotNull(skillViewModelList);
            Assert.NotEmpty(skillViewModelList);
            Assert.Equal(skillsDTO.Count, skillViewModelList.Count);

            skillRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once());    
        }
    }
}
