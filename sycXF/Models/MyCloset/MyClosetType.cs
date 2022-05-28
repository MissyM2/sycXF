namespace sycXF.Models.MyCloset
{
    public class MyClosetType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}