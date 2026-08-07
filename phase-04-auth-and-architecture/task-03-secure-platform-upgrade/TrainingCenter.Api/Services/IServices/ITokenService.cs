using TrainingCenter.Entities;

namespace TrainingCenter.Services.IServices
{
    public interface ITokenService
    {
        public string GenerateToken(int userId, string email, string userName, string role);
    }
}