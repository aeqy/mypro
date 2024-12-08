using MyPro.Application.Interfaces;

namespace MyPro.Application.UseCases;

public class DeleteBOM
{
    private readonly IBOMRepository _bomRepository;

    public DeleteBOM(IBOMRepository bomRepository)
    {
        _bomRepository = bomRepository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        // 检查是否存在指定 ID的 BOM
        var existingBOM = await _bomRepository.GetByIdAsync(id);
        if (existingBOM == null)
        {
            throw new Exception("BOM not found");
        }

        // 删除BOM
        await _bomRepository.DeleteAsync(id);
    }

}