using Newtonsoft.Json;

namespace Subscriber.WebApi.Config
{
    public class ErrorHandlingMiddleware
    {
        
            private readonly RequestDelegate next;
            private readonly ILogger<ErrorHandlingMiddleware> _looger;
            public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> looger)
            {
                this.next = next;
                _looger = looger;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {

                    ///שורה הכי חשובה שגורמת להמשך במקרה ולא רוצים שימשיך אנחנו לא לקרוא לURV VZU 
                    await next(context);

                 _looger.LogInformation($"the function is {context.Request.Method} finished successfuly");



                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
            }
            private static Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                //ממיר את השגיאה לJSON ומחזיר מכל הפונקציות במקרה ונפל 

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                //context.Response.ContentType = "application/json";            
                return context.Response.WriteAsync(result);
            }
        }

 

    
}
