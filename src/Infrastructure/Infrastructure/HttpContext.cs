using Microsoft.AspNetCore.Http;

namespace Infrastructure
{
    public class Infrastructure
    {
        // <summary>
        /// HttpContext(自定義)
        /// Asp.Net Core 框架的目的之一就是為了跨平台，要跨平台就必須跳出依賴於Windows底層的dll，
        /// 那麽framework框架很多函數庫就無法使用了，就必須重新使用新的方式
        /// </summary>
        public static class HttpContext
        {
            private static IHttpContextAccessor _httpContextAccessor;

            public static void Init(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public static Microsoft.AspNetCore.Http.HttpContext Current
            {
                get
                {
                    if (_httpContextAccessor == null)
                    {
                        return null;
                    }

                    return _httpContextAccessor.HttpContext;
                }
            }
        }
    }
}
