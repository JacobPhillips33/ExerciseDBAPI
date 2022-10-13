using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ExerciseDBAPI
{
    public class Methods
    {     
        public static IRestResponse AllExercises()
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string key = config.GetConnectionString("X-RapidAPI-Key");
            string host = config.GetConnectionString("X-RapidAPI-Host");
            var client = new RestClient("https://exercisedb.p.rapidapi.com/exercises");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-RapidAPI-Key", key);
            request.AddHeader("X-RapidAPI-Host", host);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static Exercise SpecificExercise(IRestResponse response, int exerciseNumber)
        {
            var allExerciseParse = JArray.Parse(response.Content);

            var thisBodyPart = allExerciseParse[exerciseNumber - 1]["bodyPart"];
            var thisEquipment = allExerciseParse[exerciseNumber - 1]["equipment"];
            var thisGifUrl = allExerciseParse[exerciseNumber-1]["gifUrl"];
            var thisID = allExerciseParse[exerciseNumber-1]["id"];
            var thisName = allExerciseParse[exerciseNumber - 1]["name"];
            var thisTarget = allExerciseParse[exerciseNumber - 1]["target"];            

            var exercise = new Exercise()
            {
                BodyPart = (string)thisBodyPart,
                Equipment = (string)thisEquipment,
                GifUrl = (string)thisGifUrl,
                ID = (string)thisID,
                Name = (string)thisName,
                Target = (string)thisTarget
            };

            return exercise;
        }
    }
}
