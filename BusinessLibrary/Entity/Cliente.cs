using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLibrary.Entity
{
    public class Cliente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nome do Cliente"), Required]
        public int clie_id { get; set; }
        [DisplayName("Nome do Cliente"), Required]
        public string clie_nm_nome { get; set; }
        [DisplayName("Matricula")]
        public int clie_nr_matricula { get; set; }
    }
}