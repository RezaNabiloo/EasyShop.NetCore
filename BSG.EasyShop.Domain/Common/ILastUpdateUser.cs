using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Domain.Common
{
    public interface ILastUpdateUser
    {
        public Guid? LastUpdateUserId { get; set; }
    }
}
