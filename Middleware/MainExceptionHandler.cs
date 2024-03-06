using WholeSaler.Exceptions;

namespace WholeSaler.Middleware
{
    public class MainExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }catch (EntityNotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Resource not found");
            }catch (WrongCredentialsException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("You put wrong credentials");
            }
            catch (EmptyFileException ex)
            {
                context.Response.StatusCode = 406;
                await context.Response.WriteAsync("No file specified");
            }
            catch (FormatNotSupportedException ex)
            {
                context.Response.StatusCode = 406;
                await context.Response.WriteAsync("File format it's not supported");
            }
            catch(AssortmentAlreadyExist ex)
            {
                context.Response.StatusCode = 406;
                await context.Response.WriteAsync("Assortment with this name already exist!");
            }catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");

            }
        }
    }
}
