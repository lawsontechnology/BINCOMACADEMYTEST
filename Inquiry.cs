namespace BINCOMACADEMYTEST;

public class Inquiry
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? Message { get; set; }

    public Car? Car { get; set; }
}
