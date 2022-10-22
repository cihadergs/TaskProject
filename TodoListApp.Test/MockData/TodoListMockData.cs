using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Test.MockData
{
    public class TodoListMockData
    {
        public static List<Tasks> GetTodos()
        {
            return new List<Tasks>{
                new Tasks{
                    Id = 1,
                    TodoTitle = "Need To Go Shopping",
                    DueDate = DateTime.UtcNow,
                    IsDone = true
                },
                new Tasks{
                    Id = 2,
                    TodoTitle = "Cook Food",
                    DueDate = DateTime.UtcNow,
                    IsDone = true
                },
                new Tasks{
                    Id = 3,
                    TodoTitle = "Play Games",
                    DueDate = DateTime.UtcNow,
                    IsDone = true
                }
            };
        }

        public static List<Tasks> GetEmptyTodos()
        {
            return new List<Tasks>();
        }

        public static Tasks NewTodo()
        {
            return new Tasks
            {
                Id = 0,
                TodoTitle = "wash cloths",
                DueDate = DateTime.UtcNow,
                IsDone = false
            };
        }
    }
}
