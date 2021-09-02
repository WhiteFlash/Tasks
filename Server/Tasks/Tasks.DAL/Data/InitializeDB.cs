using System.Collections.Generic;
using Tasks.Core.Model;

namespace Tasks.DAL.Data
{
    public static class InitializeDB
    {
        public static  void Initialize(DataContext context)
        {
            List<Core.Model.Status> listOfStatuses = new List<Tasks.Core.Model.Status>()
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
            List<Core.Model.Tasks> listOfTasks = new List< Core.Model.Tasks>()
            {
                new  Core.Model.Tasks()
                {
                    TasksName = "Помыть машину",
                    Description = "Открыть гараж, помыть машину, вытереть машину",
                    Status = listOfStatuses[0]
                },
                new  Core.Model.Tasks()
                {
                    TasksName = "Выкинуть мусор",
                    Description = "Открыть гараж, выкинуть мусор",
                    Status = listOfStatuses[1]
                },
                new  Core.Model.Tasks()
                {
                    TasksName = "Протереть пыль",
                    Description = "Взять тряпку, протереть пыль. Всё.",
                    Status = listOfStatuses[2]
                },
                new  Core.Model.Tasks()
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
