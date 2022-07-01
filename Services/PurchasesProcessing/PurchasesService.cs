using DAL.DbContext;
using Domain.Purchases;

namespace Services.Purchases
{
    public class PurchasesService : IPurchaseProcessingService
    {
        private readonly AuthDbContext context;

        public PurchasesService(AuthDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public ValueTask<Purchase> GetPurchaseAsync(string id)
        {
            var purchase = context.Purchases.FindAsync(id);

            return purchase;
        }

        /// <inheritdoc/>
        public ValueTask<IList<Purchase>> GetPurchasesAsync()
        {
            return ValueTask.FromResult(context.Purchases.ToList() as IList<Purchase>);
        }

        /// <inheritdoc/>
        public async ValueTask<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            purchase.RegistrationDate = DateTime.Now;
            var createdPurchase = await context.Purchases.AddAsync(purchase);
            await context.SaveChangesAsync();

            return createdPurchase.Entity;
        }

        /// <inheritdoc/>
        public async ValueTask DeletePurchaseAsync(string id)
        {
            var purchase = await context.Purchases.FindAsync(id);
            context.Purchases.Remove(purchase);
            await context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async ValueTask<Purchase> UpdatePurchaseAsync(Purchase purchase)
        {
            var updatedCategory = context.Purchases.Update(purchase);
            await context.SaveChangesAsync();

            return updatedCategory.Entity;
        }
    }
}
