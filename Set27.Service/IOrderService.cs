using Set27.Model;

namespace Set27.Service
{
    public interface IOrderService
    {
        Task Add(OrderDto dto);
        Task Delete(long OrderId);
        Task<List<OrderDto>> List();
        Task<PagedList<OrderDto>> pagedList(int pageIndex, int pageSize);
        Task Update(OrderDto dto);
    }
}