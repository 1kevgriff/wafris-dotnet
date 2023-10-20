
using System.ComponentModel.DataAnnotations;

public class WafrisOptions
{
    [Required]
    [MinLength(1)]
    public string RedisConnectionString { get; set; } = default!;
}