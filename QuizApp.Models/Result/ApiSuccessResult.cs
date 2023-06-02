namespace QuizApp.Common.Result
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }

        public ApiSuccessResult(string msg)
        {
            IsSuccessed = true;
            Message = msg;
        }

        public ApiSuccessResult(object resultObj)
        {
            IsSuccessed = true;
            ResultObj = (T)resultObj;
        }
    }
}