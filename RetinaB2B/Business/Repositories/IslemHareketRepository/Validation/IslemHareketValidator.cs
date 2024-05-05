using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.IslemHareketRepository.Validation
{
    public class IslemHareketValidator : AbstractValidator<IslemHareket>
    {
        public IslemHareketValidator()
        {
        }
    }
}
