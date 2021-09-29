using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Serialization;
using Tasks.Core.Interfaces;

namespace Tasks.Core.Model
{
    /// <summary>
    /// Класс представляет таблицу "Задачи" в базе данных.
    /// </summary>

    [DataContract]
    public class Tasks : ITasks
    {
        [DataMember]
        public int TasksID { get; set; }
        
        [DataMember]
        public string TasksName { get; set; }
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int StatusId { get; set; }

        [DataMember]
        public Status Status { get; set; }



        public class Config : IEntityTypeConfiguration<Tasks>
        {
            public void Configure(EntityTypeBuilder<Tasks> config)
            {
                config.ToTable("Tasks");
                config.HasKey(key => key.TasksID);
                config.Property(prop => prop.TasksName).HasColumnName("TasksName");
                config.Property(prop => prop.Description).HasColumnName("Description");

                config.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
            }
        }
    }
}
