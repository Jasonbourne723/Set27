using System.ComponentModel;

namespace Set27.Service
{
    public class OrderDto
    {
        public long Id { get; set; }
        [DisplayName("订单明细")]
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();

        [DisplayName("实收金额")]
        public decimal Amount
        {
            get { return Items.Sum(x => x.RealAmount); }
            set
            {
            }
        }

        [DisplayName("开始时间")]
        public DateTime? BeginDate { get; set; }
        [DisplayName("创捷时间")]
        public DateTime CreateDate { get; set; }


    }

    public class OrderItemDto
    {
        public long Id { get; set; }

        public long GoodsId { get; set; }
        [DisplayName("商品")]
        public string GoodsName { get; set; }
        [DisplayName("技师Id")]
        public long EmployeeId { get; set; }
        [DisplayName("技师")]
        public string EmployeeName { get; set; }
        [DisplayName("数量")]
        public int Nums { get; set; }
        [DisplayName("金额")]
        public decimal RealAmount { get; set; }
    }
}