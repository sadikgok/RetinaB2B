using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.KasaHareketRepository.Validation
{
    public class KasaHareketValidator : AbstractValidator<KasaHareket>
    {
        public KasaHareketValidator()
        {
        }
    }
}
