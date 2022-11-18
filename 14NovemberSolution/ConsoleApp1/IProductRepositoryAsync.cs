namespace ConsoleApp1
{
    public interface IProductRepositoryAsync : IProductRepository
    {
        Task<bool> CreateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<Product>>? SelectAllAsync();
        Task<Product>? SelectByIdAsync(int id);
        Task<bool> UpdateAsync(Product modifiedProduct);
    }
}