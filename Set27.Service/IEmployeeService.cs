using Set27.Model;

namespace Set27.Service
{
    public interface IEmployeeService
    {
        Task Add(EmployeeDto dto);
        Task Delete(long employeeId);
        Task<List<EmployeeDto>> List();
        Task<PagedList<EmployeeDto>> pagedList(int pageIndex, int pageSize);
        Task Update(EmployeeDto dto);
    }
}