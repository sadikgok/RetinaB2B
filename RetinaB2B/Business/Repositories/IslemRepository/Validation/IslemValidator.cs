using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.IslemRepository.Validation
{
    public class IslemValidator : AbstractValidator<Islem>
    {
        public IslemValidator()
        {
        }
    }
}
