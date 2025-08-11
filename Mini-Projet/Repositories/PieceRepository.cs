using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
        public class PieceRepository : IPieceRepository
        {
            private readonly AppDbContext _context;

            public PieceRepository(AppDbContext context)
            {
                _context = context;
            }

            // Get all pieces
            public async Task<IEnumerable<Piece>> GetAllPiecesAsync()
            {
                return await _context.Pieces.Include(p => p.Article).ToListAsync();
            }

            // Get a piece by Id
            public async Task<Piece> GetPieceByIdAsync(int id)
            {
                return await _context.Pieces.Include(p => p.Article)
                                            .FirstOrDefaultAsync(p => p.Id == id);
            }

            // Create a new piece
            public async Task<Piece> CreatePieceAsync(Piece piece)
            {
                _context.Pieces.Add(piece);
                await _context.SaveChangesAsync();
                return piece;
            }

            // Update an existing piece
            public async Task<Piece> UpdatePieceAsync(Piece piece)
            {
                _context.Pieces.Update(piece);
                await _context.SaveChangesAsync();
                return piece;
            }

            // Delete a piece by Id
            public async Task<bool> DeletePieceAsync(int id)
            {
                var piece = await _context.Pieces.FindAsync(id);
                if (piece == null)
                {
                    return false;
                }

                _context.Pieces.Remove(piece);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }