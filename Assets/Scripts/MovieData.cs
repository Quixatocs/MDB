public readonly struct MovieData {
    // Title Data
    public readonly string Title;
    public readonly CreditData Director;
    public readonly int Duration;
    public readonly int TitleYear;
    
    // Technical Data
    public readonly string Color;
    public readonly int AspectRatio; // will * 100 to store in int instead of float
    public readonly int Budget;
    public readonly int Gross;

    //Community Data
    public readonly int FacebookLikes;
    public readonly int ImdbScore; // will * 10 to store in int instead of float
    public readonly int CriticsForReviewNum;
    public readonly int UserForReviewNum;
    
    //Actor Data

}
