namespace BINCOMACADEMYTEST;

public record InquiryDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? Message { get; set; }
    public string? CarName { get; set; }
    public decimal CarPrice { get; set; }
}
