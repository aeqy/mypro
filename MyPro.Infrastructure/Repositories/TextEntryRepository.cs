using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;
using MyPro.Infrastructure.DbContex;

namespace MyPro.Infrastructure.Repositories;

public class TextEntryRepository(MyProDbContext context) : ITextEntryRepository
{
    public void AddTextEntry(TextEntry textEntry)
    {
        context.TextEntries.Add(textEntry);
        context.SaveChanges();
    }

    public int GetTextEntryCount()
    {
        return context.TextEntries.Count();
    }
}