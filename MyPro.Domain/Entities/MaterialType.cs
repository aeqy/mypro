namespace MyPro.Domain.Entities;

public class MaterialType
{
    // 使用 GUID 作为主键
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Specification { get; set; }
    public string Description { get; set; }
}