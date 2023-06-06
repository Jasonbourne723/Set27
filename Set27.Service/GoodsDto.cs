using System.ComponentModel;

namespace Set27.Service
{
    public class GoodsDto
    {

        public long Id { get; set; }
        [DisplayName("名称")]
        public string Name { get; set; }
        [DisplayName("标价")]
        public decimal Price { get; set; }
        [DisplayName("销售价")]
        public decimal RealPrice { get; set; }

    }
}