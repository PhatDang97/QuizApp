namespace QuizApp.Common.Result
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult() { }

        public ApiErrorResult(string msg)
        {
            IsSuccessed = false;
            Message = msg;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
