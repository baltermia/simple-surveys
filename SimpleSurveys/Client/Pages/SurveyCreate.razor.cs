using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.Models;
using System.Net.Http;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyCreate
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        private async void OnSubmit(Survey survey)
        {
            HttpResponseMessage result = await Http.PostBasicAsync("api", survey);

            Survey created = await result.DeserializeResponse<Survey>();

            NavManager.NavigateTo("/view/" + created.ID);
        }
    }
}
