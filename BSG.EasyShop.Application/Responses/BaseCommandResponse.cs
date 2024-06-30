namespace BSG.EasyShop.Application.Responses
{
    //public class BaseCommandResponse<T>
    public class BaseCommandResponse
    {
        public long? Id { get; set; }
        //public T Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
