namespace ChoicesSuperMarket.Domain.Enums
{
    public enum EAssignedDiscount
    {
        /// <summary>
        /// Assigned to a product
        /// </summary>
        AssignedToProduct = 1,

        /// <summary>
        /// Assigned to categories (all products in a category)
        /// </summary>
        AssignedToCategory = 2,

        /// <summary>
		/// Assigned to sub categories (all products in a sub category)
        /// </summary>
        AssignedToSubCategory = 3
    }
}