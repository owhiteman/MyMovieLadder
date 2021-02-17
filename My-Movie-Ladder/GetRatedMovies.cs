using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace My_Movie_Ladder
{

    public class Movies
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public IList<Result> results { get; set; }

        public class Result
        {
            public double popularity { get; set; }
            public int vote_count { get; set; }
            public bool video { get; set; }
            public string poster_path { get; set; }
            public int id { get; set; }
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public IList<int> genre_ids { get; set; }
            public string title { get; set; }
            public double vote_average { get; set; }
            public string overview { get; set; }
            public string release_date { get; set; }
        }
        
    }

    public class GetRatedMovies
    {
        private const string URL = "https://api.themoviedb.org/3/";
        private string urlParam = "discover/movie?api_key=663a0dd265290b5f684214244f6e7f0b&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&page=1&vote_count.gte=3000";

        Movies movie = null;

        public void GetMovie()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync(urlParam).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Movies>(result);
                
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
    }
}
