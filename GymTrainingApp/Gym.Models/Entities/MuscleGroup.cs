using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class MuscleGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;


        // Navigation
        public ICollection<Muscle> Muscles { get; set; } = [];
        public ICollection<TrainingTypeSequence> TrainingTypeSequences { get; set; } = [];
    }
}
