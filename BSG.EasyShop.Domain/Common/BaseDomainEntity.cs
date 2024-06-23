namespace BSG.EasyShop.Domain.Common
{
    public abstract class BaseDomainEntity : ICreateTime, ICreateUser, ILastUpdateTime, ILastUpdateUser
    {
        public long Id { get; set; }

        public DateTime CreateTime { get; set; } 

        public Guid? CreateUserId { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public Guid? LastUpdateUserId{ get; set; }


    }
}
