using Furion.DatabaseAccessor;
using System.ComponentModel;

namespace Set27.Model
{
    public class Order : IEntity
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }


        public DateTime? BeginDate { get; set; }


        public DateTime CreateDate { get; set; }

        public short IsDel { get; set; }
    }
}