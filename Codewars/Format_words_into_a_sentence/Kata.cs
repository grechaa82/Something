using System.Text;

namespace Format_words_into_a_sentence
{
    public class Kata
    {
        public static string FormatWords(string[] words)
        {
            if (words is null)
            {
                return "";
            }

            var temporaryWords = new List<string>();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                {
                    temporaryWords.Add(words[i]);
                }
            }

            for (int i = 0; i < temporaryWords.Count; i++)
            {
                if (result.Length == 0)
                {
                    result.Append(temporaryWords[i]);
                }
                else
                {
                    if (i != temporaryWords.Count - 1)
                    {
                        result.Append(", ");
                    }
                    else
                    {
                        result.Append(" and ");
                    }

                    result.Append(temporaryWords[i]);
                }

            }

            return result.ToString();
        }
    }
}