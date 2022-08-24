namespace Eclilar.Dominio.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public int SpecialtyId {get; set;}
        public string CategoryName { get; set; }
        public int CategoryStatus { get; set; }
    }
}