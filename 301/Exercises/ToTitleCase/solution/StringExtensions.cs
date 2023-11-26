namespace ToTitleCase
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            // Null or empty check
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            // Split the string into words
            string[] words = str.Split(' ');

            // Loop through each word
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                // Capitalize the first letter of each word
                if (word.Length > 0)
                {
                    words[i] = char.ToUpper(word[0]) + word.Substring(1).ToLower();
                }
            }

            // Join the words back together into a single string
            return string.Join(' ', words);
        }
    }
}

