namespace BINCOMACADEMYTEST;

public record CarCreateDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
