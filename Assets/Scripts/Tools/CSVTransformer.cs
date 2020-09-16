using System;

public static class CSVTransformer
{
    public static string[] SplitRecordsFromMovieData(string text) {
        return text.Split(
            new[] {"\r\n", "\r", "\n"},
            StringSplitOptions.None
        );
    }
}
