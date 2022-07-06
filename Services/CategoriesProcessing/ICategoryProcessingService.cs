using Domain.Entities.Categories;

namespace Services.Categories
{
    public interface ICategoryProcessingService
    {
        /// <summary>
        /// Method for retrieving specific category.
        /// </summary>
        /// <param name="id">Instance of type <see cref="string"/>.</param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Instance of type <see cref="Category"/>.
        /// </returns>
        ValueTask<Category> GetCategoryAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all stored categories.
        /// </summary>
        /// <returns>
        /// Instance of type <see cref="ValueTask{IList{Category}}"/>
        /// </returns>
        ValueTask<IList<Category>> GetCategoriesAsync();

        /// <summary>
        /// Method for creating the category.
        /// </summary>
        /// <param name="category"> Instance of type <see cref="Category"/>. </param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Instance of type <see cref="Category"/>.
        /// </returns>
        ValueTask<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken);

        /// <summary>
        /// Method for retrieving specific category.
        /// </summary>
        /// <param name="id"> Instance of type <see cref="string"/>. </param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        ValueTask DeleteCategoryAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Method for retrieving specific category.
        /// </summary>
        /// <param name="category"> Instance of type <see cref="Category"/>. </param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Instance of type <see cref="Category"/>.
        /// </returns>
        ValueTask<Category> UpdateCategoryAsync(Category category, CancellationToken cancellationToken);
    }
}