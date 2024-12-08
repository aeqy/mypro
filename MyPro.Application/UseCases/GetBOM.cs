using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.Application.UseCases;

public class GetBOM
{
    private readonly IBOMRepository _bomRepository;

    public GetBOM(IBOMRepository bomRepository)
    {
        _bomRepository = bomRepository;
    }

    public async Task<BOM> Execute(Guid id)
    {
        var bom = await _bomRepository.GetByIdAsync(id);
        
        return bom;
    }
}