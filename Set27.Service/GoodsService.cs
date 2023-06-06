using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Set27.Model;

namespace Set27.Service
{
    public class GoodsService : IGoodsService,ITransient
    {
        private readonly IRepository<Goods> _GoodsRepository;

        public GoodsService(IRepository<Goods> GoodsRepository)
        {
            _GoodsRepository = GoodsRepository;
        }


        public async Task<PagedList<GoodsDto>> pagedList(int pageIndex, int pageSize)
        {
            var result = await _GoodsRepository.Where(x => x.IsDel == 0).ToPagedListAsync(pageIndex, pageSize);

            return result.Adapt<PagedList<GoodsDto>>();
        }

        public async Task<List<GoodsDto>> List()
        {
            var result = await _GoodsRepository.Where(x => x.IsDel == 0).ToListAsync();
            return result.Adapt<List<GoodsDto>>();
        }


        public async Task Add(GoodsDto dto)
        {
            var entity = dto.Adapt<Goods>();
            var entry = await _GoodsRepository.InsertNowAsync(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public async Task Delete(long GoodsId)
        {
            var entity = await _GoodsRepository.FirstOrDefaultAsync(x => x.Id == GoodsId && x.IsDel == 0);

            if (entity != null)
            {
                entity.IsDel = 1;
                await _GoodsRepository.UpdateNowAsync(entity);
            }
        }

        public async Task Update(GoodsDto dto)
        {
            var entity = dto.Adapt<Goods>();
            var entry = await _GoodsRepository.UpdateNowAsync(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
    }
}