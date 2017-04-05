using System;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Deposit_Line.Line_Details;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details;

namespace QuickBooks.Net.Data.Extensions
{
    internal static class LineDetailTypeExtensions
    {

        internal static Type GetDetailType(this LineDetailType type)
        {
            switch (type)
            {
                case LineDetailType.DescriptionOnly:
                    return typeof(DescriptionOnly);

                case LineDetailType.DiscountLineDetail:
                    return typeof(DiscountLineDetail);

                case LineDetailType.GroupLineDetail:
                    return typeof(GroupLineDetail);

                case LineDetailType.SalesItemLineDetail:
                    return typeof(SalesItemLineDetail);

                case LineDetailType.SubTotalLineDetail:
                    return typeof(SubtotalLineDetail);

                case LineDetailType.TaxLineDetail:
                    return typeof(TaxLineDetail);

                case LineDetailType.DepositLineDetail:
                    return typeof(DepositLineDetail);

                default:
                    throw new ArgumentException($"{nameof(type)} property is null or invalid.");
            }
        }

    }
}
