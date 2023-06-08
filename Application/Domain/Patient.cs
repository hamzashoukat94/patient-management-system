using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Domain
{
    public class Patient
    {
        private Patient()
        {

        }

        public Patient(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            if (!isEmail)
            {
                throw new ArgumentException("email is not valid", nameof(email));
            }

            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        public string Address { get; set; }
    }
}
