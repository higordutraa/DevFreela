﻿using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido.");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caractere especial.");

            RuleFor(p => p.Fullname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório.");
                
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}