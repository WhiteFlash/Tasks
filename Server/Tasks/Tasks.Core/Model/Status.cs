using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Serialization;
using Tasks.Core.Interfaces;

namespace Tasks.Core.Model
{
    /// <summary>
    /// Словарь. Таблица Статус.
    /// Значения Id - внешние ключи таблицы Задачи.
    /// </summary>
    [DataContract]
    public class Status : IStatus
    {
        [DataMember]
        public int StatusID { get; set; }
        
        [DataMember]
        public string StatusTypes { get; set; }

        public class Config : IEntityTypeConfiguration<Status>
        {
            public void Configure(EntityTypeBuilder<Status> config)
            {
                config.ToTable("Status");
                config.HasKey(key => key.StatusID);
                config.Property(prop => prop.StatusTypes).HasColumnName("StatusType");
            }
        }
    }
}
