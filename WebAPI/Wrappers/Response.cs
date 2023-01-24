namespace WebAPI.Wrappers
{
    public class Response<TEntity>
    {
        public TEntity Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public Response() { }

        public Response(TEntity entity) 
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = entity;
        }
    }
}
