using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Set27.Model;

namespace Set27.Service
{
    public class OrderService : IOrderService, ITransient
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderService(IRepository<Order> OrderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _OrderRepository = OrderRepository;
            _orderItemRepository = orderItemRepository;
        }


        public async Task<PagedList<OrderDto>> pagedList(int pageIndex, int pageSize)
        {
            var orders = await _OrderRepository.DetachedEntities.Where(x => x.IsDel == 0).ToPagedListAsync(pageIndex, pageSize);
            var items = await _orderItemRepository.DetachedEntities.Where(x => x.IsDel == 0 && orders.Items.Select(y => y.Id).Contains(x.OrderId)).ToListAsync();

            var result = orders.Adapt<PagedList<OrderDto>>();
            var resultItems = result.Items.ToList();

            if (resultItems != null && resultItems.Count() > 0)
            {
                foreach (var item in resultItems)
                {
                    item.Items = items.FindAll(x => x.OrderId == item.Id).Adapt<List<OrderItemDto>>();
                }
            }
            result.Items = resultItems;
            return result;
        }

        public async Task<List<OrderDto>> List()
        {
            var result = await _OrderRepository.DetachedEntities.Where(x => x.IsDel == 0).ToListAsync();
            return result.Adapt<List<OrderDto>>();
        }


        public async Task Add(OrderDto dto)
        {
            var entity = dto.Adapt<Order>();
            entity.CreateDate = DateTime.Now;
            var entry = await _OrderRepository.InsertNowAsync(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            var orderitems = dto.Items.Adapt<List<OrderItem>>();
            orderitems.ForEach(ea => { ea.OrderId = entity.Id; });
            await _orderItemRepository.InsertNowAsync(orderitems);
        }

        public async Task Delete(long OrderId)
        {
            var entity = await _OrderRepository.FirstOrDefaultAsync(x => x.Id == OrderId && x.IsDel == 0);

            if (entity != null)
            {
                entity.IsDel = 1;
                await _OrderRepository.UpdateNowAsync(entity);

                var orderitems = await _orderItemRepository.Where(x => x.OrderId == OrderId).ToListAsync();
                if (orderitems != null && orderitems.Count > 0)
                {
                    orderitems.ForEach(ea => { ea.IsDel = 1; });
                    await _orderItemRepository.UpdateNowAsync(orderitems);
                }

            }
        }

        public async Task Update(OrderDto dto)
        {
            var entity = dto.Adapt<Order>();
            var entry = await _OrderRepository.UpdateNowAsync(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;


            var oldItems = await _orderItemRepository.DetachedEntities.Where(x => x.IsDel == 0 && x.OrderId == dto.Id).ToListAsync();
            await _orderItemRepository.DeleteNowAsync(oldItems);

            var orderitems = dto.Items.Adapt<List<OrderItem>>();
            orderitems.ForEach(ea => { ea.OrderId = dto.Id; ea.Id = 0; });
            await _orderItemRepository.InsertNowAsync(orderitems);
        }
    }
}