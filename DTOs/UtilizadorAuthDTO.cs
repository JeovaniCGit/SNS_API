using Microsoft.AspNetCore.Authentication;
using SNS.Models;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SNS.DTOs
{
    public class UtilizadorAuthDTO
    {
        private int Id { get; set; }
        //private string PasswordHash { get; set; }
        public string Nome { get; set; }
        private int NumeroCC { get; set; }
    }
}
