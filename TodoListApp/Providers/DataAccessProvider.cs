using System.Data.Entity;
using TodoListApp.Data;
using TodoListApp.Model;

namespace TodoListApp.Providers
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly DataContext _context;

        public DataAccessProvider(DataContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Tasks data)
        {
            _context.datas.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Tasks data, int id)
        {
            _context.datas.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            return await _context.datas.ToListAsync();
        }

        public async Task<List<Tasks>> GetPendingTasks()
        {
            return await _context.datas.Where(x => x.DueDate == null || x.DueDate > DateTime.UtcNow).ToListAsync();           
        }

        public async Task<List<Tasks>> GetOverdueTasks()
        {
            return await _context.datas.Where(x => x.DueDate < DateTime.UtcNow).ToListAsync();
        }
    }
}
