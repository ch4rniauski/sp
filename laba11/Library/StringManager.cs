namespace Library;

public static class StringManager
{
    public static int CountVowels(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        const string vowels = "aeiouyAEIOUYаеёиоуыэюяАЕЁИОУЫЭЮЯ";
        
        return str.Count(c => vowels.Contains(c));
    }
}