using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleSurveys.Client.Pages
{
    public partial class SurveyCreate
    {
        [Inject]
        public HttpClient Http { get; set; }

        private Survey SurveyItem { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            SurveyItem = new();

            await base.OnParametersSetAsync();
        }
    }
}
