using System.ComponentModel;

namespace Set27.Service
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        [DisplayName("名字")]
        public string Name { get; set; }
        [DisplayName("手机号")]
        public string Mobile { get; set; }
        [DisplayName("微信号")]
        public string Wx { get; set; }
        [DisplayName("入职时间")]
        public DateTime? JoinDate { get; set; }
    }

   
}