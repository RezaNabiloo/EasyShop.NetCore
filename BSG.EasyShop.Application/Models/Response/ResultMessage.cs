using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Application.Models.Response
{
    public class ResultMessage
    {
        public ResultMessageType MessageType { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
    }
}
