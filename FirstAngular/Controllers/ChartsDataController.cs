using FirstAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsDataController : ControllerBase
    {
        private readonly ResumeContext _context;

        public ChartsDataController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/ChartsData/Skills/5
        [HttpGet("Skills/{id}")]
        public async Task<IActionResult> GetSkillsChart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skills = _context.PersonSkill.Where(x => x.PersonId == id).Include(x => x.Skill);

            if (skills == null)
            {
                return NotFound();
            }

            ChartData chartData = new ChartData();
            chartData.Data.Datasets[0].Label = "Years of Skill Chart";
            bool altColor = false;
            foreach(var skill in skills)
            {
                chartData.Data.Labels.Add(skill.Skill.Name);
                chartData.Data.Datasets[0].data.Add(skill.Skill.Years);
                if (altColor)
                {
                    chartData.Data.Datasets[0].backgroundColor.Add(@"#36A2EB");
                    altColor = false;
                }
                else
                {
                    chartData.Data.Datasets[0].backgroundColor.Add(@"#FFCE56");
                    altColor = true;
                }
            }

            return Ok(chartData);
        }
    }

    public class ChartData
    {
        public ChartData()
        {
            Data = new Data();
        }

        public Data Data { get; set; }
    }

    public class Data
    {
        public Data()
        {
            Labels = new List<string>();
            Datasets = new List<Dataset>();
            Datasets.Add(new Dataset());
        }

        public List<string> Labels { get; set; }
        public List<Dataset> Datasets { get; set; }
    }

    public class Dataset
    {
        public Dataset()
        {
            data = new List<int>();
            backgroundColor = new List<string>();
        }

        public string Label { get; set; }
        public List<int> data { get; set; }
        public List<string> backgroundColor { get; set; }
    }


}