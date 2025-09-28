using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.Converters
{
    public class TransactionStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WalletTxStatus status)
            {
                return status switch
                {
                    WalletTxStatus.Pending => Color.FromArgb("#F5F5F7"),
                    WalletTxStatus.Completed => Color.FromArgb("#E6FFE6"),
                    WalletTxStatus.Failed => Color.FromArgb("#FFE6E6"),
                    WalletTxStatus.Cancelled => Color.FromArgb("#FFE6E6"),
                    _ => Color.FromArgb("#FFE6E6")
                };
            }
            return Color.FromArgb("#FFE6E6");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
