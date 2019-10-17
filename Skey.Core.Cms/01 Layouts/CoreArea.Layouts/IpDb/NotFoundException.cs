using System;

namespace CoreArea.Layouts.IpDb
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string name) : base(name)
        {
        }
    }
}
