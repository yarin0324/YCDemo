using Castle.DynamicProxy;
using Serilog;

namespace Api.Interceptor
{
    public class ExceptionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //獲取功能執行相關資訊
            var typeName = invocation.TargetType.FullName;
            var methodName = invocation.Method.Name;

            try
            {
                /**
                  *invocation.TargetType：也就是攔截的目標型別。
                  *invocation.Method：也就是這次攔截到的方法。
                  *invocation.Arguments：呼叫目標物件的方法，所傳入的參數。
                  *invocation.Proceed()：實際呼叫目標物件的方法。
                  *invocation.ReturnValue：實際目標方法的回傳值，可於攔截器中重新設定想要回傳的值。             
                 **/

                //調用業務方法
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                Log.Error(exception, $"執行方法{typeName} - {methodName}時發生異常");

                throw;
            }
        }
    }
}
