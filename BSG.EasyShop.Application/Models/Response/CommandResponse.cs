namespace BSG.EasyShop.Application.Models.Response
{
    public class CommandResponse<T>
    {
        public bool Success { get; set; }
        public T?  Result { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }        
        public List<ResultMessage> ResultMessages { get; set; }
        
    }
}
