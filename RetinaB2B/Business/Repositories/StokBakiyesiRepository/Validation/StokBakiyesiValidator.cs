using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StokBakiyesiRepository.Validation
{
    public class StokBakiyesiValidator : AbstractValidator<StokBakiyesi>
    {
        public StokBakiyesiValidator()
        {
        }
    }
}
