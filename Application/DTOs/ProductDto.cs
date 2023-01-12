using AutoMapper;
using Domain.Models;

namespace POS.Application.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
