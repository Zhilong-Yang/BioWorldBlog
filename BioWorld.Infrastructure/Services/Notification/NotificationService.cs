using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BioWorld.Application;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace BioWorld.Infrastructure.Services.Notification
{
    public class NotificationService 
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NotificationService> _logger;
        private readonly IBlogConfigService _blogConfigService;

        public bool IsEnabled { get; set; }

        public NotificationService(HttpClient httpClient,
            IOptions<AppSettings> settings,
            ILogger<NotificationService> logger,
            IBlogConfigService blogConfigS)
        {
            _httpClient = httpClient;
            _logger = logger;
            _blogConfigService = blogConfigS;

            if (settings.Value.Notification.Enabled)
            {
                if (Uri.IsWellFormedUriString(settings.Value.Notification.AzureFunctionEndpoint,
                    UriKind.Absolute))
                {
                    httpClient.BaseAddress = new Uri(settings.Value.Notification.AzureFunctionEndpoint);
                }

                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, $"BioWorld/{Utils.AppVersion}");
                _httpClient = httpClient;

                if (_blogConfigService.NotificationSettings.EnableEmailSending)
                {
                    IsEnabled = true;
                }
            }
        }
        
        public async Task SendNotificationRequest<T>(NotificationRequest<T> request,
            [CallerMemberName] string callerMemberName = "") where T : class
        {
            var req = BuildNotificationRequest(() => request);
            var response = await _httpClient.SendAsync(req);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing request '{callerMemberName}', response: {response.StatusCode}");
            }
        }

        private HttpRequestMessage BuildNotificationRequest<T>(Func<NotificationRequest<T>> request) where T : class
        {
            var nf = request();
            nf.EmailDisplayName = _blogConfigService.NotificationSettings.EmailDisplayName;
            nf.AdminEmail = _blogConfigService.NotificationSettings.AdminEmail;

            var req = new HttpRequestMessage(HttpMethod.Post, string.Empty)
            {
                Content = new NotificationContent<T>(nf)
            };
            return req;
        }
    }
}