using DBConext.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConext.Implementation
{
    public class VTalkChannelDbContext : IDbConext
    {
        public VTalkChannelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; }
    }
}
