using System.Text.RegularExpressions;

namespace ProjetFileRouge.Classes
{
    public class Tools
    {
        public static bool IsText(string text)
        {
            string pathern = @"^[A-Za-z]+$";
            return Regex.IsMatch(text, pathern);
        }

        public static bool IsTel(string tel)
        {
            string pathern = @"(^0([1-9]{1})|^\+33([1-9]{1}))(\.|\s|-)?((\d){2}(\.|\s|-)?){3}(\d{2})$";
            return Regex.IsMatch(tel, pathern);
        }
        public static bool IsMail(string mail)
        {
            string pattern = @"^[A-z0-9._-]+@[a-z0-9._-]{2,}\.[a-z]{2,4}$";
            return Regex.IsMatch(mail, pattern);
        }
    }
}
