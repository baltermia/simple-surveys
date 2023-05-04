using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.Models;
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

        private List<Survey> Surveys;

        protected async override Task OnInitializedAsync()
        {
            Surveys = await Http.GetFromJsonAsync<List<Survey>>("api");
        }
    }
}
