using System;
using UnityEngine;

public static class MovieDataCSVTransformer
{
    public static string[] SplitRecordsFromMovieData(string text) {
        return text.Split(
            new[] {"\r\n", "\r", "\n"},
            StringSplitOptions.None
        );
    }

    public static MovieData LoadMovieDataFromRecord(string record) {
        MovieData newMovieData = new MovieData();
        
        string[] columns = record.Split(',');

        for (int i = 0; i < columns.Length; i++) {
            
            switch (i) {
                case 0: // color
                    break;
                case 1: // director_name also deal with director_facebook_likes
                    int directorFacebookLikes = 0;
                    if (!string.IsNullOrEmpty(columns[4])) {
                        directorFacebookLikes = int.Parse(columns[4]);
                    }
                    newMovieData.Director = new CreditData(columns[1], directorFacebookLikes);
                    break;
                case 2: // num_critic_for_reviews
                    break;
                case 3: // duration
                    int duration = 0;
                    if (!string.IsNullOrEmpty(columns[3])) {
                        duration = int.Parse(columns[3]);
                    }
                    newMovieData.Duration = duration;
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
                    break;
                case 18: // num_user_for_reviews
                    break;
                case 19: // language
                    break;
                case 20: // country
                    break;
                case 21: // content_rating
                    break;
                case 22: // budget
                    break;
                case 23: // title_year
                    newMovieData.TitleYear = int.Parse(columns[23]);
                    break;
                case 24: // actor_2_facebook_likes
                    break;
                case 25: // imdb_score
                    break;
                case 26: // aspect_ratio
                    break;
                case 27: // movie_facebook_likes
                    break;
                default:
                    Debug.Log($"No data for column index <{i}> exists.");
                    break;
            }
        }

        return newMovieData;
    }
    
}
