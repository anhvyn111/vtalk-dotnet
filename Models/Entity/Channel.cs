using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Channel : IEntityGuid, ICoreEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string ChannelName { get; set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public Channel(Guid id, string channelName, Guid createdBy)
        {
            Id = id;
            ChannelName = channelName;
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
