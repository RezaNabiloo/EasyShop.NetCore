namespace BSG.EasyShop.Domain.Common
{
    public abstract class BaseDomainTranslateEntity : BaseDomainEntity
    {
        public long LanuegeId { get; set; }
        public Languege Languege { get; set; }

    }
}
