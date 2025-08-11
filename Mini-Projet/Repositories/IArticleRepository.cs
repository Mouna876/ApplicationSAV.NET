using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> AddArticle(Article article);
        Task<Article> UpdateArticle(Article article);
        Task<Article> DeleteArticle(int id);
    }
}
