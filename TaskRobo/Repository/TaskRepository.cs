using System.Collections.Generic;
using System.Linq;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class TaskRepository:ITaskRepository
    {
        readonly TaskDbContext context;
        public TaskRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to delete task details from database based upon user's email & task id
        public int DeleteTask(string email, int taskId)
        {
            
        }

        // This method should be used to get all task details from database based upon user's email
        public IReadOnlyList<UserTask> GetAllTasks(string email)
        {
            
        }

        // This method should be used to get task details from database based upon user's email and task id
        public UserTask GetTaskById(string email, int taskId)
        {
            
        }

        // This method should be used to save task details into database 
        public int SaveTask(UserTask task)
        {
            
        }

        // This method should be used to update task details into database
        public int UpdateTask(UserTask task)
        {

        }
    }
}