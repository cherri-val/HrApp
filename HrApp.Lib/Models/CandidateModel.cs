using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Lib.Models
{
    [Table("Candidates")]
    public class CandidateModel
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public EStatus Status { get; set; }

        public string Description { get; set; }
    }
}
