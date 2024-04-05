using System.Web;

namespace Web.Models
{
    public class ResponseResult
    {
        public bool IsSuccess { get; set; }

        protected string _message = null;

        public string Message
        {
            get
            {
                return HttpUtility.HtmlEncode(_message);
            }
            set
            {
                this._message = value;
            }
        }

        /// <summary>
        /// return object
        /// </summary>
        public dynamic Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        public ResponseResult(bool success, string message = "", dynamic? result = null)
        {
            this.IsSuccess = success;
            this.Message = message;
            this.Result = result;
        }
    }
}
