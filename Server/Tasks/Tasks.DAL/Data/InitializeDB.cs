using System.Collections.Generic;
using Tasks.Core.Model;
using CustomTask = Tasks.Core.Model.Tasks;

namespace Tasks.DAL.Data
{
    public static class InitializeDB
    {
        public static  void Initialize(DataContext context)
        {
            List<Status> listOfStatuses = new List<Status>()
            {
                new Status()
                {
                    StatusTypes = "Создана"
                },
                new Status()
                {
                    StatusTypes = "В работе"
                },
                new  Status()
                {
                    StatusTypes = "Завершена"
                },
            };
            List<CustomTask> listOfTasks = new List<CustomTask>()
            {
                new CustomTask()
                {
                    TasksName = "Помыть машину",
                    Description = "Открыть гараж, помыть машину, вытереть машину",
                    Status = listOfStatuses[0]
                },
                new  CustomTask()
                {
                    TasksName = "Выкинуть мусор",
                    Description = "Открыть гараж, выкинуть мусор",
                    Status = listOfStatuses[1]
                },
                new  CustomTask()
                {
                    TasksName = "Протереть пыль",
                    Description = "Взять тряпку, протереть пыль. Всё.",
                    Status = listOfStatuses[2]
                },
                new  CustomTask()
                {
                    TasksName = "Пропылесосить пыль",
                    Description = "Взять тряпку, пропылесосить пыль.",
                    Status = listOfStatuses[1]
                },
            };
            
            context.AddRange(listOfStatuses);
            context.SaveChanges();

            context.AddRange(listOfTasks);
            context.SaveChanges();  
        }

    }
}
