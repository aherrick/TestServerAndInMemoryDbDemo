using System.ComponentModel.DataAnnotations.Schema;

namespace TestServerInMemoryDbPOC.Data
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
    }
}