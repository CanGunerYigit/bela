namespace NewCalculator.Models
{
    public class Hesaplama
    {
        public int Id { get; set; }
        public double Sayi1 { get; set; }
        public double Sayi2 { get; set; }
        public string Islem { get; set; }
        public double Sonuc { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
