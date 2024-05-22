using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Domain.Primitives
{
    public class Result<T>
    {
        public Result(string message, T data)
        {
            Message = message;
            Data = data;
            Errors = new List<string>();
            IsSuccess = true;
        }

        public Result(Dictionary<string, string[]> validations)
        {
            Message = "";
            Errors = new List<string>();
            Validations = validations;
            IsSuccess = false;
        }

        public Result(List<string> errors)
        {
            Message = "";
            Errors = errors;
            IsSuccess = false;
        }

        public Result(string message, T data, List<string> errors, bool isSuccess)
        {
            Message = message;
            Data = data;
            Errors = errors;
            IsSuccess = isSuccess;
        }

        public Result()
        {
            Message = "";
            Errors = new List<string>();
            IsSuccess = false;
        }

        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public IDictionary<string, string[]> Validations { get; set; } = new Dictionary<string, string[]>();
        public bool IsSuccess { get; init; }
    }
}