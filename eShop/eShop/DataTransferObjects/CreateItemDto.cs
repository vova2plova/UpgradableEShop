using System.ComponentModel.DataAnnotations;

namespace eShop.DataTransferObjects;
public record CreateItemDto
(
    [Required] string title,
    [Required] string description,
    [Required] decimal price,
    [Required] decimal discountPercentage,
    [Required] decimal rating,
    [Required] int stock,
    [Required] string brand,
    [Required] string category,
    [Required] string thumbnail,
    [Required] List<string> images
);
