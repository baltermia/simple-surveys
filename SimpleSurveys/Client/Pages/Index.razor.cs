using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimpleSurveys.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient Http { get; set; }

        private List<SurveyDto> Surveys;

        protected async override Task OnInitializedAsync()
        {
            Surveys = await Http.GetFromJsonAsync<List<SurveyDto>>("api");
        }
    }
}
