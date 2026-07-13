namespace StudentManagementApi.DTOs
{
    public class PagedResultResponse
    {
        public int? PageNumber {get;set;}

        public int? PageSize {get;set;}

        public int TotalCount {get;set;}

        public List<StudentResponse> studentResponses {get;set;} = new();
    
    }
}