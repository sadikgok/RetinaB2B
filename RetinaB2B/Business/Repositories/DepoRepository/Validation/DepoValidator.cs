using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.DepoRepository.Validation
{
    public class DepoValidator : AbstractValidator<Depo>
    {
        public DepoValidator()
        {
        }
    }
}
