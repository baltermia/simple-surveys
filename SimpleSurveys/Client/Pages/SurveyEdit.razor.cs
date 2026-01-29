using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyEdit
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SurveyDto SurveyItem { get; set; } = new();

        private string password = string.Empty;
        private bool visible = true;
        private bool showError = false;

        protected async override Task OnParametersSetAsync()
        {
            SurveyItem = await Http.GetFromJsonAsync<SurveyDto>("api/" + Id);

            await base.OnParametersSetAsync();
        }

        private async void OnSubmit(SurveyDto survey)
        {
            if (visible)
            {
                return;
            }

            int id = survey.Id;

            await Http.PutBasicAsync("api/" + id, survey);

            NavManager.NavigateTo("/view/" + id);
        }

        private void HandleCancel()
        {
            NavManager.NavigateTo("view/" + SurveyItem.Id);
        }

        private void HandleSubmit()
        {
            if (password != SurveyItem.Password)
            {
                showError = true;

                return;
            }

            visible = false;
        }
    }
}
