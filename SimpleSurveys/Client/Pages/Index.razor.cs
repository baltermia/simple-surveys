using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimpleSurveys.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient Http { get; set; }

        private Survey surveyObj;

        private bool show = false;

        protected async override Task OnInitializedAsync()
        {
            surveyObj = await Http.GetFromJsonAsync<Survey>("api/1");

            show = true;
        }
    }
}
