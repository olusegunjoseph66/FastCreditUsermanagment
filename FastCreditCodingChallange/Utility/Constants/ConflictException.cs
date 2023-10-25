﻿using FastCreditCodingChallange.ViewModels.Response;
using System.Globalization;

namespace FastCreditCodingChallange.Utility.Constants
{
    public class ConflictException : Exception
    {
        public ConflictException() : base()
        {
            Response = ResponseHandler.FailureResponse(ErrorCodes.CONFLICT_ERROR_CODE, ErrorMessages.CONFLICT_ERROR);
        }

        public ConflictException(string message) : base(message)
        {
            Response = ResponseHandler.FailureResponse(ErrorCodes.CONFLICT_ERROR_CODE, message);
        }

        public ApiResponse Response { get; private set; }

        public ConflictException(string message, string code, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
            Response = ResponseHandler.FailureResponse(code, message);
        }
    }
}


