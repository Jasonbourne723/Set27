using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Set27.Model;

namespace Set27.Service
{
    public class EmployeeService : IEmployeeService,ITransient
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task<PagedList<EmployeeDto>> pagedList(int pageIndex, int pageSize)
        {
            var result = await _employeeRepository.Where(x => x.IsDel == 0).ToPagedListAsync(pageIndex, pageSize);

            return result.Adapt<PagedList<EmployeeDto>>();
        }

        public async Task<List<EmployeeDto>> List()
        {
            var result = await _employeeRepository.Where(x => x.IsDel == 0).ToListAsync();
            return result.Adapt<List<EmployeeDto>>();
        }


        public async Task Add(EmployeeDto dto)
        {
            var entity = dto.Adapt<Employee>();
            var entry = await _employeeRepository.InsertNowAsync(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public async Task Delete(long employeeId)
        {
            var entity = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == employeeId && x.IsDel == 0);

            if (entity != null)
            {
                entity.IsDel = 1;
                await _employeeRepository.UpdateNowAsync(entity);
            }
        }

        public async Task Update(EmployeeDto dto)
        {
            var entity = dto.Adapt<Employee>();
            var entry = await _employeeRepository.UpdateNowAsync(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
    }
}