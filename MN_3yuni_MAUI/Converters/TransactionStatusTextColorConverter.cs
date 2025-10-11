using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.Converters
{
    public class TransactionStatusTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WalletTxStatus status)
            {
                return status switch
                {
                    WalletTxStatus.Pending => Color.FromArgb("#C8C8C8"),
                    WalletTxStatus.Completed => Color.FromArgb("#4DAB4D"),
                    WalletTxStatus.Failed => Color.FromArgb("#FF4D4D"),
                    WalletTxStatus.Cancelled => Color.FromArgb("#FF4D4D"),
                    _ => Color.FromArgb("#FF4D4D")
                };
            }
            return Color.FromArgb("#FF4D4D");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
