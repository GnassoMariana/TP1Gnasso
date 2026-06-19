using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public List<string> Errors { get; } = new();
        public bool IsConcurrencyConflict { get;}
        private Result(bool success, List<string> errors, bool isConcurrencyConflict=false)
        {
            IsSuccess = success;
            Errors = errors;
            IsConcurrencyConflict = isConcurrencyConflict;
        }

        public static Result Success()
        {
            return new Result(true, new List<string>());
        }
        public static Result Failure(List<string> errors)
        {
            return new Result(false, errors);
        }
        public static Result Failure(string error)
        {
            return new Result(false, new List<string> { error });
        }

        public static Result ConcurrencyConflict(string error)
        {
            return new Result(false, new List<string> { error }, false);
        }
    }
}

