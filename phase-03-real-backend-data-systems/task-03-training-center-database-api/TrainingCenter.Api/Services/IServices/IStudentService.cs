using TrainingCenter.Common;
using TrainingCenter.DTOs;

namespace TrainingCenter.Services.IServices
{
    public interface IStudentService
    {
        public GeneralResponseDto<List<StudentListItemResponse>>GetAllStudents(string? search, bool? isActive,int pageNumber,int pageSize);
        public GeneralResponseDto<StudentDetailsResponse>GetStudentById(int id);

        public GeneralResponseDto<StudentDetailsResponse>CreateStudent(CreateStudentRequest studentRequest);

        public GeneralResponseDto<StudentDetailsResponse>UpdateStudent(int id,UpdateStudentRequest studentRequest);
 
        public GeneralResponseDto<bool> DeleteStudent(int id) ;

       
    }
}