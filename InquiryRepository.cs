using Microsoft.EntityFrameworkCore;

namespace BINCOMACADEMYTEST;

public class InquiryRepository : IInquiryRepository
{
    private readonly ApplicationDbContext _context;

    public InquiryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Inquiry>> GetAllInquiriesAsync()
    {
        return await _context.Inquiries.ToListAsync();
    }

    public async Task<Inquiry> GetInquiryByIdAsync(int id)
    {
        return await _context.Inquiries.FindAsync(id);
    }

    public async Task AddInquiryAsync(Inquiry inquiry)
    {
        _context.Inquiries.Add(inquiry);
        await _context.SaveChangesAsync();
    }
}
