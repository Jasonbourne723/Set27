using Furion.DatabaseAccessor;

namespace Set27.Model
{
    public class Goods : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal RealPrice { get; set; }

        public short IsDel { get; set; }
    }
}