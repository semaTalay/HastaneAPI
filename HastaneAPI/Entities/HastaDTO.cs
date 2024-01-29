namespace HastaneAPI.Entities
{
    public class HastaDTO
    {
       
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Klinik { get; set; }
        public DateTime MuayeneTarihi { get; set; }
        public int HastaneId { get; set; }
    }
}
