using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BioWorld.Application.Response;
using Microsoft.Extensions.Logging;

namespace BioWorld.Infrastructure.Services
{
    public class ApplicationService
    {
        protected readonly ILogger<ApplicationService> Logger;

        public ApplicationService(ILogger<ApplicationService> logger = null)
        {
            if (null != logger) Logger = logger;
        }

        public Response TryExecute(Func<Response> func, 
            [CallerMemberName] string callerMemberName = "", 
            object keyParameter = null)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error executing {callerMemberName}({keyParameter})");
                return new FailedResponse((int)ResponseFailureCode.GeneralException, e.Message);
            }
        }

        public Response<T> TryExecute<T>(Func<Response<T>> func, 
            [CallerMemberName] string callerMemberName = "", 
            object keyParameter = null)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error executing {callerMemberName}({keyParameter})");
                return new FailedResponse<T>((int)ResponseFailureCode.GeneralException, e.Message);
            }
        }

        public async Task<Response> TryExecuteAsync(Func<Task<Response>> func,
            [CallerMemberName] string callerMemberName = "",
            object keyParameter = null)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error executing {callerMemberName}({keyParameter})");
                return new FailedResponse((int)ResponseFailureCode.GeneralException, e.Message);
            }
        }

        public async Task<Response<T>> TryExecuteAsync<T>(Func<Task<Response<T>>> func,
            [CallerMemberName] string callerMemberName = "", 
            object keyParameter = null)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error executing {callerMemberName}({keyParameter})");
                return new FailedResponse<T>((int)ResponseFailureCode.GeneralException, e.Message);
            }
        }
    }
}
