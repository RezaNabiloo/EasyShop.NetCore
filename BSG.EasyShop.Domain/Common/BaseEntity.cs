using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Domain.Common
{
    public abstract class BaseEntity : ICreateTime, ICreateUser, ILastUpdateTime, ILastUpdateUser
    {
        public long Id { get; set; }

        public DateTime CreateTime { get; set; } 

        public Guid? CreateUserId { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public Guid? LastUpdateUserId{ get; set; }


    }
}
