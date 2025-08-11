using Mini_Projet.Data;

namespace Mini_Projet.Repositories
{
    public class StatisticsRepository
    {
        private readonly AppDbContext _context;

        public StatisticsRepository(AppDbContext context)
        {
            _context = context;
        }
        public int GetTotalReclamations()
        {
            return _context.Reclamations.Count();
        }
        public Dictionary<string, double> GetReclamationPercentageByStatus()
        {
            var totalReclamations = _context.Reclamations.Count();
            if (totalReclamations == 0) return new Dictionary<string, double>();

            var statusCounts = _context.Reclamations
                .GroupBy(r => r.Statut)
                .Select(g => new { Statut = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Statut, x => (double)x.Count / totalReclamations * 100);

            return statusCounts;
        }

        public Dictionary<int, int> GetInterventionsCountByTechnician()
        {
            return _context.Interventions
                .GroupBy(i => i.TechnicienId)
                .Select(g => new { TechnicienId = g.Key, Count = g.Count() })
                .ToDictionary(x => x.TechnicienId, x => x.Count);
        }
        public int GetTotalFacturesHorsGarantie()
        {
            return _context.Interventions
                .Where(i => !i.SousGarantie)
                .Sum(i => i.MontantFacture);
        }

        public double GetCustomerSatisfactionRate()
        {
            // Exemple fictif : vous pouvez connecter ceci à une table de feedback
            var totalFeedbacks = 100; // Nombre total de feedbacks reçus
            var positiveFeedbacks = 80; // Nombre de feedbacks positifs

            return totalFeedbacks > 0 ? (double)positiveFeedbacks / totalFeedbacks * 100 : 0;
        }
        public List<string> GetMostReclaimedArticles()
        {
            return _context.Reclamations
                .GroupBy(r => r.Description)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToList();
        }
    }
}
