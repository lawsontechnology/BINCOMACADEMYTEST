namespace BINCOMACADEMYTEST;

public record InquiryCreateDto
{
    public int CarId { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? Message { get; set; }
}
