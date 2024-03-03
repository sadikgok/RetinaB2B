using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StokGrupRepository.Validation
{
    public class StokGrupValidator : AbstractValidator<StokGrup>
    {
        public StokGrupValidator()
        {
        }
    }
}
