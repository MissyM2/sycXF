namespace sycXF.Models.MyCloset
{
    public class MyClosetSeason
    {
        public int Id { get; set; }
        public string Season { get; set; }

        public override string ToString()
        {
            return Season;
        }
    }
}