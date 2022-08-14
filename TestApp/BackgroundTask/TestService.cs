using TestApp.Repository;
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

            //if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    _timer = new Timer(RemoveUser, null, TimeSpan.Zero, TimeSpan.Zero);
            //}
            _timer = new Timer(RemoveUser, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

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
