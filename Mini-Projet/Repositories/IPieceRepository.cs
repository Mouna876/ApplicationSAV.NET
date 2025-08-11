using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public interface IPieceRepository
    {
        Task<IEnumerable<Piece>> GetAllPiecesAsync();
        Task<Piece> GetPieceByIdAsync(int id);
        Task<Piece> CreatePieceAsync(Piece piece);
        Task<Piece> UpdatePieceAsync(Piece piece);
        Task<bool> DeletePieceAsync(int id);
    }
}
