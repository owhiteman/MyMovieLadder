using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace My_Movie_Ladder
{
    public class Movie
    {
        
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public List<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompany> production_companies { get; set; }
        public List<ProductionCountry> production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguage> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class ProductionCompany
        {
            public int id { get; set; }
            public string logo_path { get; set; }
            public string name { get; set; }
            public string origin_country { get; set; }
        }

        public class ProductionCountry
        {
            public string iso_3166_1 { get; set; }
            public string name { get; set; }
        }

        public class SpokenLanguage
        {
            public string iso_639_1 { get; set; }
            public string name { get; set; }
        }



    }

    public class GetRatedMovies
    {
        private const string URL = "https://api.themoviedb.org/3/";
        private string urlParameters = "movie/278?api_key=663a0dd265290b5f684214244f6e7f0b&language=en-US";

        public String GetMovie()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Movie movie = null;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Movie>(result);
                return movie.title;
            }
            else
            {
                return "Zudis";
            }

        }

    }
}
