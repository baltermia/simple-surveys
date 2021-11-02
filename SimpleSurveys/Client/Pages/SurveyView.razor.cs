using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyView
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public int Id { get; set; }

        private Survey SurveyItem { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            SurveyItem = await Http.GetFromJsonAsync<Survey>("api/" + Id);

            await base.OnParametersSetAsync();
        }
    }
}
