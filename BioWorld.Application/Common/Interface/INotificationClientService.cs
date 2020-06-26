using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BioWorld.Application.Core;
using BioWorld.Application.Notification;

namespace BioWorld.Application.Common.Interface
{
    public interface INotificationClientService
    {
        bool IsEnabled { get; set; }

        Task SendNotificationRequest<T>(NotificationRequest<T> request,
            [CallerMemberName] string callerMemberName = "") where T : class;
    }
}