using MN_3yuni_MAUI.MVVM.ViewModels;
using Shared.Models;

namespace MN_3yuni_MAUI.MVVM.Views
{
    [QueryProperty(nameof(SelectedOrder), "SelectedOrder")]
    public partial class OrderDetails : ContentPage
    {
        private readonly OrderDetailsVM _viewModel;
        private Order _selectedOrder;

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                if (_selectedOrder != null)
                {
                    _viewModel.Initialize(_selectedOrder);
                }
            }
        }

        public OrderDetails(OrderDetailsVM viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);


            if (_selectedOrder == null)
            {
                TryGetOrderFromParameters();
            }
        }

        private void TryGetOrderFromParameters()
        {

            if (Shell.Current?.CurrentState?.Location is Uri uri)
            {
                var queryString = uri.ToString().Split('?').LastOrDefault();
                if (!string.IsNullOrEmpty(queryString))
                {
                    var parameters = ParseQueryString(queryString);
                    if (parameters.ContainsKey("SelectedOrder"))
                    {

                    }
                }
            }


            _viewModel.Initialize();
        }

        private Dictionary<string, string> ParseQueryString(string query)
        {
            var parameters = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(query)) return parameters;

            var pairs = query.Split('&');
            foreach (var pair in pairs)
            {
                var keyValue = pair.Split('=');
                if (keyValue.Length == 2)
                {
                    parameters[keyValue[0]] = Uri.UnescapeDataString(keyValue[1]);
                }
            }
            return parameters;
        }
    }
}