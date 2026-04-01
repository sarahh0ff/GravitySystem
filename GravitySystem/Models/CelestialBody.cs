namespace GravitySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CelestialBody
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Masa")]
        public double Mass { get; set; }

        [Required]
        [Display(Name = "Posición X")]
        public double PositionX { get; set; }

        [Required]
        [Display(Name = "Posición Y")]
        public double PositionY { get; set; }

        [Display(Name = "Velocidad X")]
        public double VelocityX { get; set; }

        [Display(Name = "Velocidad Y")]
        public double VelocityY { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string Type { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
