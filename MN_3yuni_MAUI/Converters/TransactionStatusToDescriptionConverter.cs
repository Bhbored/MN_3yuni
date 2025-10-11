using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.Converters
{
    public class TransactionStatusToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WalletTxStatus status)
            {
                return status switch
                {
                    WalletTxStatus.Pending => "Pending Transaction",
                    WalletTxStatus.Completed => "Completed",
                    WalletTxStatus.Failed => "Failed",
                    WalletTxStatus.Cancelled => "Cancelled",
                    _ => "Transaction"
                };
            }
            return "Transaction";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
