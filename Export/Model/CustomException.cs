using System.Globalization;

namespace Export.Model
{
    public class CustomException : Exception
    {
        public CustomException() : base() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
