namespace BINCOMACADEMYTEST;

public class InquiryService : IInquiryService
{
    private readonly IInquiryRepository _inquiryRepository;
    private readonly ICarRepository _carRepository;

    public InquiryService(IInquiryRepository inquiryRepository, ICarRepository carRepository)
    {
        _inquiryRepository = inquiryRepository;
        _carRepository = carRepository;
    }

    public async Task<List<InquiryDto>> GetAllInquiriesAsync()
    {
        var inquiries = await _inquiryRepository.GetAllInquiriesAsync();
        var inquiryDtos = new List<InquiryDto>();

        foreach (var inquiry in inquiries)
        {
            var car = await _carRepository.GetCarByIdAsync(inquiry.CarId);
            inquiryDtos.Add(new InquiryDto
            {
                Id = inquiry.Id,
                CarId = inquiry.CarId,
                UserName = inquiry.UserName,
                UserEmail = inquiry.UserEmail,
                Message = inquiry.Message,
                CarName = car?.Name,
                CarPrice = car?.Price ?? 0 
            });
        }

        return inquiryDtos;
    }

    public async Task<InquiryDto> GetInquiryByIdAsync(int id)
    {
        var inquiry = await _inquiryRepository.GetInquiryByIdAsync(id);
        if (inquiry == null) return null;

        var car = await _carRepository.GetCarByIdAsync(inquiry.CarId);

        return new InquiryDto
        {
            Id = inquiry.Id,
            CarId = inquiry.CarId,
            UserName = inquiry.UserName,
            UserEmail = inquiry.UserEmail,
            Message = inquiry.Message,
            CarName = car?.Name,
            CarPrice = car?.Price ?? 0
        };
    }

    public async Task SubmitInquiryAsync(InquiryCreateDto inquiryDto)
    {
        var inquiry = new Inquiry
        {
            CarId = inquiryDto.CarId,
            UserName = inquiryDto.UserName,
            UserEmail = inquiryDto.UserEmail,
            Message = inquiryDto.Message
        };

        await _inquiryRepository.AddInquiryAsync(inquiry);
    }
}
