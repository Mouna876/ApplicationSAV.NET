using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Repositories;

namespace Mini_Projet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatistiquesController : ControllerBase
    {
        private readonly StatisticsRepository _repository;

        public StatistiquesController(StatisticsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("total-reclamations")]
        public IActionResult GetTotalReclamations()
        {
            var totalReclamations = _repository.GetTotalReclamations();
            return Ok(new { TotalReclamations = totalReclamations });
        }

        [HttpGet("reclamation-percentage")]
        public IActionResult GetReclamationPercentageByStatus()
        {
            var percentages = _repository.GetReclamationPercentageByStatus();
            return Ok(percentages);
        }

        [HttpGet("total-factures-hors-garantie")]
        public IActionResult GetTotalFacturesHorsGarantie()
        {
            var totalFactures = _repository.GetTotalFacturesHorsGarantie();
            return Ok(new { TotalFacturesHorsGarantie = totalFactures });
        }

        [HttpGet("interventions-by-technician")]
        public IActionResult GetInterventionsCountByTechnician()
        {
            var interventionsByTechnician = _repository.GetInterventionsCountByTechnician();
            return Ok(interventionsByTechnician);
        }

        [HttpGet("customer-satisfaction-rate")]
        public IActionResult GetCustomerSatisfactionRate()
        {
            var satisfactionRate = _repository.GetCustomerSatisfactionRate();
            return Ok(new { SatisfactionRate = satisfactionRate });
        }

        // 10. Lister les articles les plus réclamés
        [HttpGet("most-reclaimed-articles")]
        public IActionResult GetMostReclaimedArticles()
        {
            var articles = _repository.GetMostReclaimedArticles();
            return Ok(articles);
        }
    }
}
