namespace BSG.EasyShop.Application.Models.Response
{
    public class BaseCommandResponse<T>
    {
        public long? Id { get; set; }
        //public T Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
