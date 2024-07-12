using System.ComponentModel.DataAnnotations;

namespace software.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        private string _name = string.Empty; // Inicializar el campo

        public string Name
        {
            get { return _name; }
            set { _name = value ?? throw new ArgumentNullException(nameof(Name)); }
        }
        public int Age { get; set; }
    }
}
