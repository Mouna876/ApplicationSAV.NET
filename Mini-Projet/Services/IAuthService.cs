using Mini_Projet.Models.Secure;

namespace Mini_Projet.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<List<ApplicationUser>> GetUsersAsync();
    }
}
