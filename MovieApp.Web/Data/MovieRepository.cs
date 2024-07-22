using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;


namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                 new Movie {
                    MovieId = 1,
                    Title="Kolpaçino",
                    Description=" Birbiriyle bağlantılı yedi komik karakterin bir günde başına gelen olağanüstü olayların komik bir şekilde beyazperde'ye yansıtıldığı bu filmde Şafak Sezer, tabiri caizse adeta destan yazıyor",
                    Director="Yönetmen 1",
                    Actors=new string[] { "Agit Altay","Sinem Kobal"},
                    ImageUrl="1.jpg",
                    GenreId=1
                    },

                new Movie {
                    MovieId = 2,
                    Title="Fight Clup",
                    Description="Hayata dair inancını yitirmiş olan ofis çalışanı, arkadaşı Tyler Durden ile birlikte gizli bir topluluk kurar. Böylece iki arkadaş, bastırılmış duygularını dışa vurma fırsatı elde eder",
                    Director="Yönetmen 2",
                    Actors=new string[] {"Hasan Hüseyin Kadı","Zeynep Bastık"},
                    ImageUrl="2.jpg",
                    GenreId=3
                    },

                new Movie {
                    MovieId = 3,
                    Title="Hateful Eight",
                    Description="Bir hesaplaşma öyküsünün anlatıldığı The Hateful Eight'te 8 gizemli kişinin gittikçe kızışan ilişkilerine şahit oluyoruz.",
                    Director="Yönetmen 3",
                    Actors=new string[] {"oyuncu 5","oyuncu 6"},
                    ImageUrl="3.jpg",
                    GenreId=3
                    },



                 new Movie {
                    MovieId = 4,
                    Title="FİLM 4",
                    Description="Açıklama 1",
                    Director="Yönetmen 1",
                    Actors=new string[] { "oyuncu 1","oyuncu 2"},
                    ImageUrl="1.jpg",
                    GenreId=4
                    },

                new Movie {
                    MovieId = 5,
                    Title="FİLM 5",
                    Description="Açıklama 2",
                    Director="Yönetmen 2",
                    Actors=new string[] {"oyuncu 3","oyuncu 4"},
                    ImageUrl="2.jpg",
                    GenreId=4
                    },

                new Movie {
                    MovieId = 6,
                    Title="FİLM 6",
                    Description="Açıklama 3",
                    Director="Yönetmen 3",
                    Actors=new string[] {"oyuncu 5","oyuncu 6"},
                    ImageUrl="3.jpg",
                    GenreId=1
                    }
            };
        }

        public static List<Movie> Movies
        {

            get
            {
                return _movies;
            }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }

        public static void Edit(Movie m)
        {
            foreach (var movie in _movies)
            {
                if (movie.MovieId == m.MovieId)
                {
                    movie.Title = m.Title;
                    movie.Description = m.Description;
                    movie.Director = m.Director;
                    movie.Actors = m.Actors;
                    movie.GenreId = m.GenreId;
                    break;
                }
            }
        }

        public static void Delete(int MovieId)
        {
            var movie= GetById(MovieId);

            if (movie != null) 
            { 
                _movies.Remove(movie);
            }
        }
    }
}
