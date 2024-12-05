namespace EmployeeManagement.Model.Dto
{
    public class ResponseDto
    {
        public string Message { get; set; } = "";
        public bool isSuccess { get; set; } 
        public object? Result { get; set; }

        //public IEnumerable<Employee?> emp { get; set; }
        //public Employee? empl { get; set; }
    }
}
