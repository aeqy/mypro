using MyPro.Domain.Entities;

namespace MyPro.Domain.Interfaces;

public interface ITextEntryRepository
{
    void AddTextEntry(TextEntry textEntry);
    int GetTextEntryCount();
}