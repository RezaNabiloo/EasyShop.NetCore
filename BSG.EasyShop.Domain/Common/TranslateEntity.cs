using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Domain.Common
{
    public abstract class TranslateEntity : BaseEntity
    {
        public long LanuegeId { get; set; }
        public Languege Languege { get; set; }

    }
}
