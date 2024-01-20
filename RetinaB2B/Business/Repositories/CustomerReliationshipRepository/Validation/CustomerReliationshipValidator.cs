using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.CustomerReliationshipRepository.Validation
{
    public class CustomerReliationshipValidator : AbstractValidator<CustomerReliationship>
    {
        public CustomerReliationshipValidator()
        {
        }
    }
}
