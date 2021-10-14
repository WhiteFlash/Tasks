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
        public int Id { get; set; }
        
        [DataMember]
        public string Title { get; set; }

        public class Config : IEntityTypeConfiguration<Status>
        {
            public void Configure(EntityTypeBuilder<Status> config)
            {
                config.ToTable("Status");
                config.HasKey(key => key.Id);
                config.Property(prop => prop.Title).HasColumnName("Title");

                config.Property(prop => prop.Title).IsRequired();
            }
        }
    }
}
