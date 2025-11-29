using MyCustomAttributes;

namespace Employee
{
    [Serializable]
    [Table(TableName = "Employee")]
    public class Emp
    {
        [Column(ColumnName = "EmployeeId", ColumnType = "int")]
        public int Id { get; set; }

        [Column(ColumnName = "EmployeeName", ColumnType = "varchar(25)")]
        public string? EName { get; set; }

        [Column(ColumnName = "EmployeeAddress", ColumnType = "varchar(100)")]
        public string? EAddress { get; set; }
    }
}
