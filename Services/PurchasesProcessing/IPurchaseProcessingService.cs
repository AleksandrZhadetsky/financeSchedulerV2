﻿using Domain.Purchases;

namespace Services.Purchases
{
    public interface IPurchaseProcessingService
    {
        /// <summary>
        /// Method for retrieving specific purchase.
        /// </summary>
        /// <param name="id">Instance of type <see cref="string"/>.</param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Instance of type <see cref="Purchase"/>.
        /// </returns>
        ValueTask<Purchase> GetPurchaseAsync(string id);

        /// <summary>
        /// Method for retrieving specific purchase.
        /// </summary>
        /// <returns>
        /// Instance of type <see cref="ValueTask{IList{Purchase}}"/>.
        /// </returns>
        ValueTask<IList<Purchase>> GetPurchasesAsync();

        /// <summary>
        /// Method for creating the purchase.
        /// </summary>
        /// <param name="purchase">Instance of type <see cref="Purchase"/>.</param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Instance of type <see cref="Purchase"/>.
        /// </returns>
        ValueTask<Purchase> CreatePurchaseAsync(Purchase purchase);

        /// <summary>
        /// Method for deleting specific purchase.
        /// </summary>
        /// <param name="id">Instance of type <see cref="string"/>.</param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        ValueTask DeletePurchaseAsync(string id);

        /// <summary>
        /// Method for updating specific purchase.
        /// </summary>
        /// <param name="purchase">Instance of type <see cref="Purchase"/>.</param>
        /// <param name="cancellationToken">Instance of type <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Instance of type <see cref="Purchase"/>.
        /// </returns>
        ValueTask<Purchase> UpdatePurchaseAsync(Purchase purchase);
    }
}