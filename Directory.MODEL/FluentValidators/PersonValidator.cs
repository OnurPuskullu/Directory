using Directory.MODEL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;


namespace Directory.MODEL.FluentValidators
{
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Zorunlu Alan").MaximumLength(15).WithMessage("Maksimum 15 karakter girebilirsiniz!");
            
        }
    }
}
