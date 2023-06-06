using Furion.DatabaseAccessor;

namespace Set27.Model
{
    public class Employee : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Wx { get; set; }

        public DateTime JoinDate { get; set; }


        public short Sex { get; set; }

        public short IsDel { get; set; }

    }
}