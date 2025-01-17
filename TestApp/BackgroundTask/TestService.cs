﻿using TestApp.ImplementsRepository.Repositories;
using TestApp.ImplementsRepository.Interfaces;

namespace TestApp.BackgroundTask
{
    public class TestService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer? _timer;

        public TestService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer =
                new Timer(UpdateUser, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void UpdateUser(object? state)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var rep = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                var users = await rep.GetAllUsers();

                foreach (var item in users)
                {
                    if (!item.EmailConfirmed)
                    {
                        item.EmailConfirmed = true;

                        await rep.UpdateUser(item);

                    }
                }
            }

        }


       
    }
}
