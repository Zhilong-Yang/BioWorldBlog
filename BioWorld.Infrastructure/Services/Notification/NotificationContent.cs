﻿using System.Net.Http;
using System.Text;
using System.Text.Json;
using BioWorld.Application.Core;
using BioWorld.Application.Notification;

namespace BioWorld.Infrastructure.Services.Notification
{
    public class NotificationContent<T> : StringContent where T : class
    {
        public NotificationContent(NotificationRequest<T> req) :
            base(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json")
        {

        }
    }
}
