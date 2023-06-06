using Furion.DatabaseAccessor;

namespace Set27.Model
{
    public class OrderItem : IEntity
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long GoodsId { get; set; }

        public string GoodsName { get; set; }

        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int Nums { get; set; }

        public decimal RealAmount { get; set; }

        public short IsDel { get; set; }
    }
}