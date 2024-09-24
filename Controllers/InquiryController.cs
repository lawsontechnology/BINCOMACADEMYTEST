using BINCOMACADEMYTEST;
using Microsoft.AspNetCore.Mvc;

[Route("api/inquiries")]
[ApiController]
public class InquiryController : ControllerBase
{
    private readonly IInquiryService _inquiryService;

    public InquiryController(IInquiryService inquiryService)
    {
        _inquiryService = inquiryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInquiries()
    {
        var inquiries = await _inquiryService.GetAllInquiriesAsync();
        return Ok(inquiries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInquiryById(int id)
    {
        var inquiry = await _inquiryService.GetInquiryByIdAsync(id);
        if (inquiry == null) return NotFound();
        return Ok(inquiry);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitInquiry([FromBody] InquiryCreateDto inquiryDto)
    {
        await _inquiryService.SubmitInquiryAsync(inquiryDto);
        return Ok();
    }
}
