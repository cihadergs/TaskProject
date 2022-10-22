using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Model
{
    public class Tasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string TodoTitle { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
