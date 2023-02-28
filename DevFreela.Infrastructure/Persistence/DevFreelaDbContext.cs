using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de projeto", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha descrição de projeto", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha descrição de projeto", 1, 1, 30000)
            };
            Users = new List<User>
            {
                new User("Higor Dutra", "higor.dutra@hotmail.com", new DateTime(1999,11,30)),
                new User("Italo Dutra", "italo.dutra@hotmail.com", new DateTime(2004,04,02)),
                new User("Fernanda Dutra", "fernanda.dutra@hotmail.com", new DateTime(2006,12,30))
            };
            Skills = new List<Skill>
            {
                new Skill("C#"),
                new Skill(".NET Core"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
