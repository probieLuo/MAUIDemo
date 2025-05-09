using CocQuery.Models.Coc;
using System.ComponentModel;

namespace CocQuery.Services.Coc
{
    public class BaseResponseResult<T> where T : class
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
        public static BaseResponseResult<T> SuccessResult(T data)
        {
            return new BaseResponseResult<T> { Status = ResultStatus.Success, Data = data };
        }

        /// <summary>
        /// 失败状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">失败信息</param>
        /// <returns></returns>
        public static BaseResponseResult<T> FailResult(string? msg = null)
        {
            return new BaseResponseResult<T> { Status = ResultStatus.Fail, Message = msg };
        }

        /// <summary>
        /// 异常状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">异常信息</param>
        /// <returns></returns>
        public static BaseResponseResult<T> ErrorResult(CocErrorMessage errorData, string? msg = null)
        {
            return new BaseResponseResult<T> { Status = ResultStatus.Error, Message = msg, cocError = errorData };
        }

        /// <summary>
        /// 自定义状态返回结果
        /// </summary>
        /// <param name="status"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static BaseResponseResult<T> Result(ResultStatus status, T data, string? msg = null)
        {
            return new BaseResponseResult<T> { Status = status, Data = data, Message = msg };
        }
    }
    public enum ResultStatus
    {
        [Description("请求成功")]
        Success = 1,
        [Description("请求失败")]
        Fail = 0,
        [Description("请求异常")]
        Error = -1
    }
}
