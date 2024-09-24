namespace BINCOMACADEMYTEST;

public interface IInquiryService
{
    Task<List<InquiryDto>> GetAllInquiriesAsync();
    Task<InquiryDto> GetInquiryByIdAsync(int id);
    Task SubmitInquiryAsync(InquiryCreateDto inquiryDto);
}
