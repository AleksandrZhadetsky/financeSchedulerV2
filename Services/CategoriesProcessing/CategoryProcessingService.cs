using DAL.DbContext;
using Domain.Entities.Categories;

namespace Services.Categories
{
    public class CategoryProcessingService : ICategoryProcessingService
    {
        private readonly AuthDbContext context;

        public CategoryProcessingService(AuthDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public ValueTask<Category> GetCategoryAsync(string id, CancellationToken cancellationToken)
        {
            var category = context.Categories.FindAsync(id);

            // returning Task<T> without await because the signature of called method and caller are the same (GetCategoryAsync and FindAsync)
            return category;
        }

        /// <inheritdoc/>
        public ValueTask<IList<Category>> GetCategoriesAsync()
        {
            return ValueTask.FromResult(context.Categories.ToList() as IList<Category>);
        }

        /// <inheritdoc/>
        public async ValueTask<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            var createdCategory = (await context.Categories.AddAsync(category, cancellationToken)).Entity;
            await context.SaveChangesAsync(cancellationToken);

            return createdCategory;
        }

        /// <inheritdoc/>
        public async ValueTask DeleteCategoryAsync(string id, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(id, cancellationToken);
            context.Categories.Remove(category);
            await context.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async ValueTask<Category> UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            var updatedCategory = context.Categories.Update(category).Entity;
            await context.SaveChangesAsync(cancellationToken);

            return updatedCategory;
        }
    }
}
