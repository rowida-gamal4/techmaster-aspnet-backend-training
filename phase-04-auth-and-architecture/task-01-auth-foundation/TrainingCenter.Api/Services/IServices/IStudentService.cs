using TrainingCenter.Common;
using TrainingCenter.DTOs;

namespace TrainingCenter.Services.IServices
{
    public interface IStudentService
    {
        public GeneralResponseDto<PagedResult<StudentListItemResponse>> GetAllStudents(string? search,bool? isActive,bool includeDeleted = false,int pageNumber = 1, int pageSize = 10);
        public GeneralResponseDto<StudentDetailsResponse>GetStudentById(int id);

        public GeneralResponseDto<StudentDetailsResponse>CreateStudent(CreateStudentRequest studentRequest);

        public GeneralResponseDto<StudentDetailsResponse>UpdateStudent(int id,UpdateStudentRequest studentRequest);
 
        public GeneralResponseDto<bool> DeleteStudent(int id) ;

       
    }
}