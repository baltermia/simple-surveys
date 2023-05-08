using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;
using System.Net.Http;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyCreate
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        private async void OnSubmit(SurveyDto survey)
        {
            HttpResponseMessage result = await Http.PostBasicAsync("api", survey);

            SurveyDto created = await result.DeserializeResponse<SurveyDto>();

            NavManager.NavigateTo("/view/" + created.Id);
        }
    }
}
