using System;
using UnityEngine;

public static class MovieDataCSVTransformer {
    /// <summary>
    /// Splits the records from the raw movie data and separates by new lines and carriage returns
    /// </summary>
    public static string[] SplitRecordsFromMovieData(string text) {
        return text.Split(
            new[] {"\r\n", "\r", "\n"},
            StringSplitOptions.None
        );
    }

    /// <summary>
    /// Splits a single record into its columns then publishes this into a new MovieData object
    /// </summary>
    public static MovieData LoadMovieDataFromRecord(string record) {
        MovieData newMovieData = new MovieData();
        
        string[] columns = record.Split(',');

        for (int i = 0; i < columns.Length; i++) {
            
            // Avoids garbage by not caching the current loop's string or any int.Parse temporary variables
            // This does come at a slight cost of readability as using cached strings and int temporary variables 
            // would increase readability. This choice was made as a performance focus is requested in the test.
            switch (i) {
                case 0: // color
                    newMovieData.Color = columns[0];
                    break;
                case 1: // director_name also deal with director_facebook_likes
                    newMovieData.Director = new CreditData(columns[1],
                        !string.IsNullOrEmpty(columns[4]) ? int.Parse(columns[4]) : 0);
                    break;
                case 2: // num_critic_for_reviews
                    newMovieData.CriticsForReviewNum = !string.IsNullOrEmpty(columns[2]) ? int.Parse(columns[2]) : 0;
                    break;
                case 3: // duration
                    newMovieData.Duration = !string.IsNullOrEmpty(columns[3]) ? int.Parse(columns[3]) : 0;
                    break;
                case 4: // director_facebook_likes
                    // Do nothing as we've already taken care of this above
                    break;
                case 5: // actor_3_facebook_likes
                    break;
                case 6: // actor_2_name
                    break;
                case 7: // actor_1_facebook_likes
                    break;
                case 8: // gross
                    newMovieData.Gross = !string.IsNullOrEmpty(columns[8]) ? int.Parse(columns[8]) : 0;
                    break;
                case 9: // genres
                    break;
                case 10: // actor_1_name
                    break;
                case 11: // movie_title
                    newMovieData.Title = columns[11];
                    break;
                case 12: // num_voted_users
                    break;
                case 13: // cast_total_facebook_likes
                    break;
                case 14: // actor_3_name
                    break;
                case 15: // facenumber_in_poster
                    break;
                case 16: // plot_keywords
                    break;
                case 17: // movie_imdb_link
                    newMovieData.ImdbUrl = columns[17];
                    break;
                case 18: // num_user_for_reviews
                    newMovieData.UserForReviewNum = !string.IsNullOrEmpty(columns[18]) ? int.Parse(columns[18]) : 0;
                    break;
                case 19: // language
                    newMovieData.Language = columns[19];
                    break;
                case 20: // country
                    newMovieData.Country = columns[20];
                    break;
                case 21: // content_rating
                    newMovieData.ContentRating = columns[21];
                    break;
                case 22: // budget
                    newMovieData.Budget = !string.IsNullOrEmpty(columns[22]) ? long.Parse(columns[22]) : 0;
                    break;
                case 23: // title_year
                    newMovieData.TitleYear = !string.IsNullOrEmpty(columns[23]) ? int.Parse(columns[23]) : 0;
                    break;
                case 24: // actor_2_facebook_likes
                    break;
                case 25: // imdb_score
                    newMovieData.ImdbScore = !string.IsNullOrEmpty(columns[25]) ? Mathf.FloorToInt(float.Parse(columns[25]) * 10) : 0;
                    break;
                case 26: // aspect_ratio
                    newMovieData.AspectRatio = !string.IsNullOrEmpty(columns[26]) ? Mathf.FloorToInt(float.Parse(columns[26]) * 100) : 0;
                    break;
                case 27: // movie_facebook_likes
                    newMovieData.FacebookLikes = !string.IsNullOrEmpty(columns[27]) ? int.Parse(columns[27]) : 0;
                    break;
                default:
                    Debug.Log($"No data for column index <{i}> exists.");
                    break;
            }
        }
        return newMovieData;
    }

}
