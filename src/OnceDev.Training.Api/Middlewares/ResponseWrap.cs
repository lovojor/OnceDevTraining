using System;

namespace OnceDev.Training.Api.Middlewares
{
    public class ResponseWrap<T>
    {
        public ResponseWrap(T baseResponse)
        {
            Response = baseResponse;
        }
        public int ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
        public T Response { get; }

    }
}
