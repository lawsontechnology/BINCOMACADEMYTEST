namespace BINCOMACADEMYTEST;

public interface IInquiryRepository
{
    Task<List<Inquiry>> GetAllInquiriesAsync();
    Task<Inquiry> GetInquiryByIdAsync(int id);
    Task AddInquiryAsync(Inquiry inquiry);
}
