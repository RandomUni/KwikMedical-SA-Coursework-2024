using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace KwikMedicalServer.Data
{
    public class KwikUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Hospital { get; set; } = "";

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
