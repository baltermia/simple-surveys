using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyEdit
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public NavigationManager NavManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        private Survey SurveyItem { get; set; } = new();

        protected async override Task OnParametersSetAsync()
        {
            SurveyItem = await Http.GetFromJsonAsync<Survey>("api/" + Id);

            await base.OnParametersSetAsync();
        }

        private async void OnSubmit(Survey survey)
        {
            await Http.PutBasicAsync("api/" + survey.ID, survey);

            NavManager.NavigateTo("/view/" + survey.ID);
        }
    }
}
