namespace U2ReguPrograweb.Models.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public double Precio { get; set; }
        public string NombreClasificacion { get; set; } = null!;
        public int IdClasificacion { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
