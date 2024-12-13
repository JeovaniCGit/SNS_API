using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SNS.Utilities
{
    public class Result<T>
    {
        public T? Data { get; }
        public string? Message { get; }
        public bool IsSuccess { get; }

        private Result(T data)
        {
            Data = data;
            IsSuccess = true;
            Message = null;
        }

        private Result(string message)
        {
            Data = default;
            Message = message;
            IsSuccess = false;
        }

        public static Result<T> IsValid(T data)
        {
            return new Result<T>(data);
        }
        public static Result<bool> IsDeleted()
        {
            return new Result<bool>(true);
        }
        public static Result<T> IsUpdated(T data)
        {
            return new Result<T>(data);
        }
        public static Result<bool> NaoApagado()
        {
            string message = $"Recurso não encontrado. \nO recurso não pôde ser apagado. Verifique o pedido.";
            return new Result<bool>(message);
        }
        public static Result<T> NaoEncontrado()
        {
            string message = $"O recurso procurado não foi encontrado.";
            return new Result<T>(message);
        }
        public static Result<T> ErroInesperado()
        {
            string message = $"Ocurreu um erro inesperado.";
            return new Result<T>(message);
        }
        public static Result<T> ErroNoPedido()
        {
            string message = $"O corpo da requisição não pôde ser lido corretamente";
            return new Result<T>(message);
        }
        public static Result<T> ValorDuplicado()
        {
            string message = $"Valor duplicado, o recurso já existe.";
            return new Result<T>(message);
        }
    }
 }
