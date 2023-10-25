﻿using Microsoft.IdentityModel.Tokens;
using FluentValidation.Results;
using FastCreditCodingChallange.Utility.Constants;

namespace FastCreditCodingChallange.Utility.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base()
        {
            Response = new ErrorDto(ErrorCodes.DEFAULT_VALIDATION_CODE, ErrorMessages.DEFAULT_VALIDATION_MESSAGE);
        }

        public ValidationException(string message) : base(message)
        {
            Response = new ErrorDto(ErrorCodes.DEFAULT_VALIDATION_CODE, message);
        }

        public ValidationException(string message, string code) : base(message)
        {
            Response = new ErrorDto(code, message);
        }

        public ErrorDto Response { get; private set; }

        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures) : this()
        {
            if (failures.Any())
            {
                var error = failures.Select(x => new ValidationDto { Field = x.PropertyName, Message = x.ErrorMessage }).FirstOrDefault();
                Response = new ErrorDto(code: error.Field, error.Message);
            }
        }
    }
}

