using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Tasks.Core.Model
{

    [DataContract]
    public class Status : Services.IStatus
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
