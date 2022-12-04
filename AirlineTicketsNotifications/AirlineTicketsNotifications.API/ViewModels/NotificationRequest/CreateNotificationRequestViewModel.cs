﻿using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.API.ViewModels.NotificationRequest
{
    public class CreateNotificationRequestViewModel
    {
        public string Email { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
