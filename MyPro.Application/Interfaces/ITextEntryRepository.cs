using MyPro.Domain.Entities;

namespace MyPro.Application.Interfaces;

public interface ITextEntryRepository
{
    void AddTextEntry(TextEntry textEntry);
    int GetTextEntryCount();
}