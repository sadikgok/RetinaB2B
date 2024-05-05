using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.IslemDetayRepository.Validation
{
    public class IslemDetayValidator : AbstractValidator<IslemDetay>
    {
        public IslemDetayValidator()
        {
        }
    }
}
