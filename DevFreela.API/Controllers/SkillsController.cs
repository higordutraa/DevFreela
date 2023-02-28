using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly SkillsController _skillController;
        public SkillsController(SkillsController skillController)
        {
            _skillController= skillController;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var skills = _skillController.Get();

            return Ok(skills);
        }
    }
}
