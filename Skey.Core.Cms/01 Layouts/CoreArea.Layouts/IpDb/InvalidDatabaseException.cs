using System.IO;

namespace CoreArea.Layouts.IpDb
{
    public class InvalidDatabaseException : IOException
    {
        public InvalidDatabaseException(string message) : base(message)
        {
        }
    }
}