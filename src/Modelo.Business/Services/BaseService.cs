using FluentValidation;
using FluentValidation.Results;
using Modelo.Business.Models;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Business.Services
{
    public abstract class BaseService
    {
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificar(item.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            // Propagar erro para a camada de apresentação
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
