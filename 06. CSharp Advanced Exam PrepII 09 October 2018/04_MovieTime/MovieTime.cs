using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_MovieTime
{
    class MovieTime
    {
        static void Main(string[] args)
        {
            string favoriteGenre = Console.ReadLine();
            string sortByCriteria = Console.ReadLine();
            string currentMovie = Console.ReadLine();

            TimeSpan totalLibraryTime = new TimeSpan();
            Dictionary<string, Dictionary<string, TimeSpan>> movies = new Dictionary<string, Dictionary<string, TimeSpan>>();

            while (currentMovie!="POPCORN!")
            {
                string[] tokens = currentMovie.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string title = tokens[0];
                string genre = tokens[1];
                TimeSpan duration = TimeSpan.Parse(tokens[2], CultureInfo.InvariantCulture);

                if (!movies.ContainsKey(genre))
                {
                    movies.Add(genre, new Dictionary<string, TimeSpan>());
                }

                movies[genre].Add(title, duration);
                totalLibraryTime = totalLibraryTime + duration;

                currentMovie = Console.ReadLine();
            }

            if (sortByCriteria=="Short")
            {
                movies[favoriteGenre] = movies[favoriteGenre].OrderBy(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, y => y.Value);
            }
            else
            {
                movies[favoriteGenre] = movies[favoriteGenre].OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x=>x.Key, y=>y.Value);
            }


            foreach (var movie in movies[favoriteGenre])
            {
                Console.WriteLine(movie.Key);
                string wifeResponse = Console.ReadLine();

                if (wifeResponse=="Yes")
                {
                    Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                    break;
                }
            }

            Console.WriteLine($"Total Playlist Duration: {totalLibraryTime}");
        }
        // playlist isnt sorted
        //total playtime is not calculated
    }
}
