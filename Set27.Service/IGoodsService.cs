using Set27.Model;

namespace Set27.Service
{
    public interface IGoodsService
    {
        Task Add(GoodsDto dto);
        Task Delete(long GoodsId);
        Task<List<GoodsDto>> List();
        Task<PagedList<GoodsDto>> pagedList(int pageIndex, int pageSize);
        Task Update(GoodsDto dto);
    }
}