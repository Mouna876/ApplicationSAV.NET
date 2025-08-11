using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Article> AddArticle(Article article)
        {
            var result = await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            var existingArticle = await _context.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);
            if (existingArticle != null)
            {
                existingArticle.Nom = article.Nom;
                existingArticle.Description = article.Description;
                existingArticle.Prix = article.Prix;
                existingArticle.SousGarantie = article.SousGarantie;

                await _context.SaveChangesAsync();
                return existingArticle;
            }
            return null;
        }

        public async Task<Article> DeleteArticle(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return article;
            }
            return null;
        }
    }
}
