﻿using Dotnet.Homeworks.Shared.MessagingContracts.Email;
using MassTransit;
using static System.Net.Mime.MediaTypeNames;

namespace Dotnet.Homeworks.MainProject.Services;

public class CommunicationService : ICommunicationService
{
    private readonly IBus _bus;
    
    public CommunicationService(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendEmailAsync(SendEmail sendEmailDto)
    {
        await _bus.Publish(sendEmailDto);
    }
}