using System.Collections.Generic;
using Tasks.API.Model;

namespace Tasks.API.Data
{
    public static class InitializeDB
    {
        public static  void Initialize(DataContext context)
        {
            List<Model.Status> listOfStatuses = new List<Model.Status>()
            {
                new Model.Status()
                {
                    StatusTypes = "Создана"
                },
                new Model.Status()
                {
                    StatusTypes = "В работе"
                },
                new Model.Status()
                {
                    StatusTypes = "Завершена"
                },
            };
            List<Model.Tasks> listOfTasks = new List<Model.Tasks>()
            {
                new Model.Tasks()
                {
                    TasksName = "Помыть машину",
                    Description = "Открыть гараж, помыть машину, вытереть машину",
                    Status = listOfStatuses[0]
                },
                new Model.Tasks()
                {
                    TasksName = "Выкинуть мусор",
                    Description = "Открыть гараж, выкинуть мусор",
                    Status = listOfStatuses[1]
                },
                new Model.Tasks()
                {
                    TasksName = "Протереть пыль",
                    Description = "Взять тряпку, протереть пыль. Всё.",
                    Status = listOfStatuses[2]
                },
                new Model.Tasks()
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
