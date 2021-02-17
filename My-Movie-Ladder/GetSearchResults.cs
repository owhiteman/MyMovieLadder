using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace My_Movie_Ladder
{

    public class Root
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    
        public class Result
            {
                public bool adult { get; set; }
                public string backdrop_path { get; set; }
                public List<int> genre_ids { get; set; }
                public int id { get; set; }
                public string original_language { get; set; }
                public string original_title { get; set; }
                public string overview { get; set; }
                public double popularity { get; set; }
                public string poster_path { get; set; }
                public string release_date { get; set; }
                public string title { get; set; }
                public bool video { get; set; }
                public double vote_average { get; set; }
                public int vote_count { get; set; }
            }

    }

    public class GetSearchResults
    {
        private const string URL = "https://api.themoviedb.org/3/";
        private string urlParam = "search/movie?api_key=663a0dd265290b5f684214244f6e7f0b&language=en-US&query=";

        Root movie = null;


        public void GetMovie(string search)
        {
            search = search.Replace(" ", "%20");
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync(urlParam + search).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Root>(result);
                
            }
            else
            {
                Console.WriteLine("Zudis");
            }
        }

        public string MovieTitle(int x)
        {
            return movie.results[x].title;
        }

        public string MovieReleaseDate(int x)
        {
            return movie.results[x].release_date;
        }

        public double MovieRating(int x)
        {
            return movie.results[x].vote_average;
        }

        public string PosterPath(int x)
        {
            return "https://image.tmdb.org/t/p/w200" + movie.results[x].poster_path;
        }

        public int MovieID(int x)
        {
            return movie.results[x].id;
        }

        public int GetResultLength()
        {
            return movie.total_results;
        }
    }
}
