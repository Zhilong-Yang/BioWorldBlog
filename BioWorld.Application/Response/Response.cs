namespace BioWorld.Application.Response
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public int ResponseCode { get; set; }

        public dynamic Addition { get; set; }

        // Workaround for .NET Core 3.0 bloody Json API issue
        // https://github.com/dotnet/corefx/issues/41102
        public Response() : this(false)
        {
        }

        public Response(bool isSuccess = false, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class Response<T> : Response
    {
        public T Item { get; set; }

        // Workaround for .NET Core 3.0 bloody Json API issue
        // https://github.com/dotnet/corefx/issues/41102
        public Response() : this(default)
        {
        }

        public Response(T item = default)
        {
            Item = item;
        }
    }
}