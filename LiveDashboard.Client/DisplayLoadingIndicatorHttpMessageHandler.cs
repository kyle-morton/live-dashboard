using LiveDashboard.Client.Services;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LiveDashboard.Client
{
    public class DisplayLoadingIndicatorHttpMessageHandler : DelegatingHandler
    {
        private readonly LoadingIndicatorService _loadingIndicatorService;
        public DisplayLoadingIndicatorHttpMessageHandler(LoadingIndicatorService service)
        {
            _loadingIndicatorService = service;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _loadingIndicatorService.Show();
            await Task.Delay(1000);
            var response = await base.SendAsync(request, cancellationToken);
            _loadingIndicatorService.Hide();
            return response;
        }
    }
}
