using System.Text.Json.Serialization;

namespace Eclilar.Dominio.Entidades
{
    public class Especialista
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public string SpecialtyImage { get; set; }
        public int SpecialtyCategory { get; set; }
        public int SpecialtyStatus { get; set; }
    }
}