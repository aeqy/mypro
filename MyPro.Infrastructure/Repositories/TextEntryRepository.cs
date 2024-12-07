using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using MyPro.Infrastructure.Data;

namespace MyPro.Infrastructure.Repositories;

public class TextEntryRepository: ITextEntryRepository
{
    private readonly MyProDbContext _context;

    public TextEntryRepository(MyProDbContext context)
    {
        _context = context;
    }
    public void AddTextEntry(TextEntry textEntry)
    {
        _context.TextEntries.Add(textEntry);
        _context.SaveChanges();
    }

    public int GetTextEntryCount()
    {
        return _context.TextEntries.Count();
    }
}