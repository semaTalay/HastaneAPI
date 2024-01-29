namespace HastaneAPI.Entities
{
    public class Hastane : BaseEntity
    {
        public string HastaneAd { get; set; }
        public string Adres { get; set; }
        public ICollection<Hasta> Hasta { get; set; }
    }
}
