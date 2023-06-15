using FluentValidation;

namespace Application.ApplicationLayer.Patients
{
    public class PatientUpdateValidator : AbstractValidator<PatientDto>
    {
        public PatientUpdateValidator()
        {

            RuleFor(patient => patient.Name)
               .NotEmpty()
               .WithMessage("Name is requied.");
            RuleFor(patient => patient.Address)
                .NotEmpty()
                .WithMessage("Address is required.");
            RuleFor(patient => patient.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Please enter a valid email address.");
            RuleFor(patient => patient.Contact)
                .NotEmpty()
                .WithMessage("Contact is required.")
                .Matches("[0-9]{11}")
                .WithMessage("Contact number must be exactly 11 digits.");
        }
    }
}
