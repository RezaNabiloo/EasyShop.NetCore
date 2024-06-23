namespace BSG.EasyShop.Domain.Common
{
    public interface ILastUpdateUser
    {
        public Guid? LastUpdateUserId { get; set; }
    }
}
