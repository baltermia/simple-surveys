using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyView
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SurveyDto SurveyItem { get; set; } = new();

        protected async override Task OnParametersSetAsync()
        {
            SurveyItem = await Http.GetFromJsonAsync<SurveyDto>("api/" + Id);

            await base.OnParametersSetAsync();
        }
        private void OnSubmit(SurveyResultDto result)
        {

        }
    }
}
