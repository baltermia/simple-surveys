using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.Models;
using System;
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

        protected async override Task OnParametersSetAsync()
        {
            //Surveys = await Http.GetFromJsonAsync<List<Survey>>("api");
            await Task.CompletedTask;

            Surveys = new();

            Survey survey = new Survey()
            {
                Title = "How do you like the website?",
                Description = "The very first survey, in which you can let us know how you like the site.",
                Password = "survey1",
                Updated = DateTime.Now.AddDays(4),
                MaxSubmissions = 10,
                Steps = new HashSet<Step>()
                {
                    new Text()
                    {
                        Title = "What do you like about the site?",
                        Required = true,
                        Placeholder = "Be honest :)"
                    },
                    new Text()
                    {
                        Title = "What do you NOT like about the site?",
                        Required = true,
                        Placeholder = "Now you can be mean ;)"
                    }
                }
            };

            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
            Surveys.Add(survey);
        }
    }
}
