using System;
namespace sycXF.Models.MyCloset
{
	public class MyClosetSize
    {
        public int Id { get; set; }
        public string Size { get; set; }

        public override string ToString()
        {
            return Size;
        }
    }
}

