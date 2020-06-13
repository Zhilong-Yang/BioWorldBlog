using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace BioWorld.Core
{
    public class ApplicationService
    {
        protected readonly ILogger<ApplicationService> Logger;

        public ApplicationService(ILogger<ApplicationService> logger)
        {
            Logger = logger;
        }

        public Response TryExecute(Func<Response> func, [CallerMemberName] string callerMemberName = "", object keyParameter = null)
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
    }
}
