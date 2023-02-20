using System.Text;

namespace Mexican_wave
{
    public class Kata
    {
        public List<string> wave(string str)
        {
            var result = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    var symbol = Char.ToUpper(str[i]);
                    StringBuilder newStr = new StringBuilder(str);
                    newStr[i] = symbol;
                    result.Add(newStr.ToString());
                }
            }

            return result;
        }
    }
}