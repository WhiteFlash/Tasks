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
    public class Note : INote
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Title { get; set; }
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int StatusId { get; set; }

        [DataMember]
        public Status Status { get; set; }


        public class Config : IEntityTypeConfiguration<Note>
        {
            public void Configure(EntityTypeBuilder<Note> config)
            {
                config.ToTable("Notes");
                config.HasKey(key => key.Id);
                config.Property(prop => prop.Title).HasColumnName("Title");
                config.Property(prop => prop.Description).HasColumnName("Description");
                
                config.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);

                config.Property(prop => prop.Title).IsRequired();
            }
        }
    }
}
