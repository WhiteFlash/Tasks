using System.Collections.Generic;
using Tasks.Core.Model;

namespace Tasks.DAL.Data
{
    public static class InitializeDB
    {
        public static void Initialize(DataContext context)
        {
            List<Status> listOfStatuses = new List<Status>()
            {
                new Status()
                {
                    Title = "Создана"
                },
                new Status()
                {
                    Title = "В работе"
                },
                new  Status()
                {
                    Title = "Завершена"
                },
            };
            List<Note> listOfTasks = new List<Note>()
            {
                new Note()
                {
                    Title = "Помыть машину",
                    Description = "Открыть гараж, помыть машину, вытереть машину",
                    Status = listOfStatuses[0]
                },
                new  Note()
                {
                    Title = "Выкинуть мусор",
                    Description = "Открыть гараж, выкинуть мусор",
                    Status = listOfStatuses[1]
                },
                new  Note()
                {
                    Title = "Протереть пыль",
                    Description = "Взять тряпку, протереть пыль. Всё.",
                    Status = listOfStatuses[2]
                },
                new  Note()
                {
                    Title = "Пропылесосить пыль",
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
