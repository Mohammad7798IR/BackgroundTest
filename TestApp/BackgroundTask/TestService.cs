using TestApp.Service;

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
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(RemoveUser, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void RemoveUser(object? state)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var rep = scope.ServiceProvider.GetRequiredService<IUserService>();
                var users = await rep?.GetAllUsers();


                foreach (var item in users)
                {
                    if (!item.EmailConfirmed)
                    {
                         rep.UpdateUser(item);
                        await rep.SaveChanges();
                    }
                }
            }

        }
    }
}
