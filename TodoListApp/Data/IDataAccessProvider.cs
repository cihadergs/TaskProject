using TodoListApp.Model;

namespace TodoListApp.Data
{
    public interface IDataAccessProvider
    {
        Task<List<Tasks>> GetAllAsync();

        Task<List<Tasks>> GetPendingTasks();

        Task<List<Tasks>> GetOverdueTasks();
        Task SaveAsync(Tasks newTasks);
        Task EditAsync(Tasks newTasks,int id);
    }
}
