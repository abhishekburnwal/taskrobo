using System;
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
            int result = 0;
            UserTask objUserTask = new UserTask();
            try
            {
                objUserTask = context.UserTasks.Include("AppUser").Where(p => p.TaskId == taskId && p.User.Email == email).FirstOrDefault();
                if (objUserTask != null)
                {
                    context.UserTasks.Remove(objUserTask);
                    context.SaveChanges();
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                return result = 0;
            }
            return result;
        }

        // This method should be used to get all task details from database based upon user's email
        public IReadOnlyList<UserTask> GetAllTasks(string email)
        {
            List<UserTask> objUserTaskList = new List<UserTask>();
            try
            {
                objUserTaskList = context.UserTasks.ToList();
                return objUserTaskList;
            }
            catch (Exception ex)
            {
                return objUserTaskList;
            }
        }

        // This method should be used to get task details from database based upon user's email and task id
        public UserTask GetTaskById(string email, int taskId)
        {
            UserTask objUserTask = new UserTask();
            try
            {
                objUserTask = context.UserTasks.Where(p => p.TaskId == taskId && p.User.Email == email).FirstOrDefault();
                return objUserTask;
            }
            catch (Exception ex)
            {
                return objUserTask;
            }
        }

        // This method should be used to save task details into database 
        public int SaveTask(UserTask task)
        {
            int result = 0;
            try
            {
                context.UserTasks.Add(task);
                context.SaveChanges();
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

        // This method should be used to update task details into database
        public int UpdateTask(UserTask task)
        {
            int result = 0;
            try
            {
                UserTask objUserTask = new UserTask();
                objUserTask = context.UserTasks.Find(task.TaskId);
                objUserTask.TaskTitle = task.TaskTitle;
                objUserTask.TaskContent = task.TaskContent;
                objUserTask.TaskStatus = task.TaskStatus;
                objUserTask.UserId = task.UserId;
                objUserTask.CategoryId = task.CategoryId;
                context.SaveChanges();
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
    }
}