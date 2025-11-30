using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCapp.Models
{
    [Table("Emp")]
    public class Emp
    {
        [Key]
        public int empno { get; set; }

        public string ename { get; set; }

        public string address { get; set; }
    }
}
