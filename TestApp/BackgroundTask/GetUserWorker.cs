using Newtonsoft.Json;
using System.Net.Http.Headers;
using TestApp.Controllers;
using TestApp.DTOs;
using TestApp.Implements.Interface;
using TestApp.Models;

namespace TestApp.BackgroundTask
{
    public class GetUserWorker : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private const string UserBaseAddress = "http://localhost:5256/User/";

        public GetUserWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {


            _timer = new Timer(GetAllUserJob, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void GetAllUserJob(object? state)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UserBaseAddress + "GetAll");


                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await httpClient.GetAsync(UserBaseAddress);

                if (Res.IsSuccessStatusCode)
                {
                    var stream = await Res.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<List<ApplicationUser>>(stream);
                }

            }
        }
    }
}
