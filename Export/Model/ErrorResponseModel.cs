namespace Export.Model
{
    public class ErrorResponseModel<T>
    {
        public static ErrorResponseModel<T> Success(T data)
        {
            return new ErrorResponseModel<T> { IsSucceed = true, Data = data };
        }

        public static ErrorResponseModel<T> Error(string errorMessage)
        {
            return new ErrorResponseModel<T> { IsSucceed = false, Message = errorMessage };
        }

        public T Data { get; set; }
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }
}
