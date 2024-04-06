using Entity;

namespace Web.Models
{
    public class ApiResponseContent
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<Employee> Data { get; set; }
    }
}
