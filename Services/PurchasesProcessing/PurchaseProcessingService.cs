using DAL.DbContext;
using Domain.Entities.Purchases;

namespace Services.Purchases
{
    public class PurchaseProcessingService : IPurchaseProcessingService
    {
        private readonly AuthDbContext context;

        public PurchaseProcessingService(AuthDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public ValueTask<Purchase> GetPurchaseAsync(string id, CancellationToken cancellationToken)
        {
            var purchase = context.Purchases.FindAsync(id, cancellationToken);

            return purchase;
        }

        /// <inheritdoc/>
        public ValueTask<IList<Purchase>> GetPurchasesAsync(CancellationToken cancellationToken)
        {
            return ValueTask.FromResult(context.Purchases.ToList() as IList<Purchase>);
        }

        /// <inheritdoc/>
        public async ValueTask<Purchase> CreatePurchaseAsync(Purchase purchase, CancellationToken cancellationToken)
        {
            purchase.CreationDate = DateTime.Now;
            var createdPurchase = await context.Purchases.AddAsync(purchase, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return createdPurchase.Entity;
        }

        /// <inheritdoc/>
        public async ValueTask DeletePurchaseAsync(string id, CancellationToken cancellationToken)
        {
            var purchase = await context.Purchases.FindAsync(id, cancellationToken);
            context.Purchases.Remove(purchase);
            await context.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async ValueTask<Purchase> UpdatePurchaseAsync(Purchase purchase, CancellationToken cancellationToken)
        {
            var updatedPurchases = context.Purchases.Update(purchase);
            await context.SaveChangesAsync(cancellationToken);

            return updatedPurchases.Entity;
        }
    }
}
