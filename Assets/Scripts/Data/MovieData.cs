
/// <summary>
/// Class to contain a representation of a Movie Item
/// </summary>
public class MovieData {
    // Title Data
    public string Title;
    public CreditData Director;
    public int Duration;
    public int TitleYear;
    
    // Technical Data
    public string Color;
    public int AspectRatio; // will * 100 to store in int instead of float
    public long Budget;
    public int Gross;
    public string Language;
    public string Country;
    public string ContentRating;


    //Community Data
    public int FacebookLikes;
    public int ImdbScore; // will * 10 to store in int instead of float
    public int CriticsForReviewNum;
    public int UserForReviewNum;
    public string ImdbUrl;

}
