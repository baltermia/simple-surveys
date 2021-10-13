using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace SimpleSurveys.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient Http { get; set; }

        private async void Click()
        {
            Survey survey = new()
            {
                Description = "The first survey",
                Public = true,
                Title = "The very first Survey!"
            };

            Step step = new Text()
            {
                Title = "This is the first step! Do you like it?",
                Placeholder = "Put your answer here :)",
                Required = true
            };

            survey.Steps.Add(step);

            HttpResponseMessage response = await Http.PostAsJsonAsync("api", survey);
        }
    }
}
