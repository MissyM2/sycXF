using System;
namespace sycXF.Models.MyCloset
{
	public class SizeCategory
    {
        public int Id { get; set; }
        public string SizeCategoryName { get; set; }

        public override string ToString()
        {
            return SizeCategoryName;
        }
    }
}

