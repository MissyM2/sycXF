namespace sycXF.Models.MyCloset
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }
        public byte[] ImgContent { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}