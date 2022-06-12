namespace sycXF.Models.MyCloset
{
    public class ApparelCategory
    {
        public int Id { get; set; }
        public string ApparelCategoryName { get; set; }

        public override string ToString()
        {
            return ApparelCategoryName;
        }
    }
}