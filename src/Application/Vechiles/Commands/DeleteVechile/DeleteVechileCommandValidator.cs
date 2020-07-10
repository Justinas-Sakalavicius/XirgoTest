using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XirgoTest.Application.Vechiles.DeleteVechile;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vechiles.Commands.DeleteVechile
{
    public class DeleteVechileCommandValidator : AbstractValidator<DeleteVechileCommand>
    {
        public DeleteVechileCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
