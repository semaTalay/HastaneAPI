namespace HastaneAPI.Entities
{
    public class Hasta : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Klinik { get; set; }
        public DateTime MuayeneTarihi { get; set; }
        public int HastaneId { get; set; }
        public Hastane Hastane { get; set; }
    }
}
