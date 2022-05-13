using System.Threading.Tasks;

namespace cashflow.infrastructure.security
{
    public interface IJwtAuthManagerService
    {
        Task<string> GetTokenAsync(string email, string role);
    }
}