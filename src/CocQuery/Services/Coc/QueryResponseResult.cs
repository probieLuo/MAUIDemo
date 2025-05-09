using CocQuery.Models.Coc;

namespace CocQuery.Services.Coc
{
    public class QueryResponseResult<T> where T : class
    {
        /// <summary>
        /// 状态结果
        /// </summary>
        public ResultStatus Status { get; set; } = ResultStatus.Success;

        private string? _msg;

        /// <summary>
        /// 消息描述
        /// </summary>
        public string? Message
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// coc错误信息
        /// </summary>
        public CocErrorMessage cocError { get; set; } = null;

        /// <summary>
        /// 成功状态返回结果
        /// </summary>
        /// <param name="result">返回的数据</param>
        /// <returns></returns>
        public static QueryResponseResult<T> SuccessResult(T data)
        {
            return new QueryResponseResult<T> { Status = ResultStatus.Success, Data = data };
        }

        /// <summary>
        /// 失败状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">失败信息</param>
        /// <returns></returns>
        public static QueryResponseResult<T> FailResult(string? msg = null)
        {
            return new QueryResponseResult<T> { Status = ResultStatus.Fail, Message = msg };
        }

        /// <summary>
        /// 异常状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">异常信息</param>
        /// <returns></returns>
        public static QueryResponseResult<T> ErrorResult(CocErrorMessage errorData, string? msg = null)
        {
            return new QueryResponseResult<T> { Status = ResultStatus.Error, Message = msg, cocError = errorData };
        }

        /// <summary>
        /// 自定义状态返回结果
        /// </summary>
        /// <param name="status"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static QueryResponseResult<T> Result(ResultStatus status, T data, string? msg = null)
        {
            return new QueryResponseResult<T> { Status = status, Data = data, Message = msg };
        }
    }
}
