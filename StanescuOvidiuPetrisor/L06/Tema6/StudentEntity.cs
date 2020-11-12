using Microsoft.WindowsAzure.Storage.Table;

namespace Models
{
    public class StudentEntity : TableEntity
    {
        public StudentEntity(string University, string Cnp)
        {
            this.PartitionKey = University;
            this.RowKey = Cnp;
        }

        public StudentEntity() { }
        public string FullName { get; set; }
        public string Cnp { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
        public string University { get; set; }
    }
}