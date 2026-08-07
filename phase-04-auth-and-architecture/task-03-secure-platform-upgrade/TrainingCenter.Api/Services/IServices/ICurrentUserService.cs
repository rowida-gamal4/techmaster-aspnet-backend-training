using TrainingCenter.Entities;

namespace TrainingCenter.Services.IServices
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        Role? Role { get; }
    }
}