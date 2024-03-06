using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.KasaRepository.Validation
{
    public class KasaValidator : AbstractValidator<Kasa>
    {
        public KasaValidator()
        {
        }
    }
}
