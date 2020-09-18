/// <summary>
/// Class to contain Credit data for an individual credit within a movie
/// e.g. a Director, an Actor, a Composer
/// </summary>
public readonly struct CreditData {
    public readonly string Name;
    public readonly int FacebookLikes;

    public CreditData(string name, int facebookLikes) {
        Name = name;
        FacebookLikes = facebookLikes;
    }
}
