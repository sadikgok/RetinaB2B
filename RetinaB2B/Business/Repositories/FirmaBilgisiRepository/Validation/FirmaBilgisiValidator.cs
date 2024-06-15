using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.FirmaBilgisiRepository.Validation
{
    public class FirmaBilgisiValidator : AbstractValidator<FirmaBilgisi>
    {
        public FirmaBilgisiValidator()
        {
        }
    }
}
