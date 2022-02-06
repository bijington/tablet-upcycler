using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace dashy.Widgets
{
    public partial class QuoteOfTheDayWidget
    {
        private HttpClient httpClient;

        public string Message { get; private set; }

        public QuoteOfTheDayWidget()
        {
            InitializeComponent();
            this.BindingContext = this;

            _ = this.LoadQuote();
        }

        private async Task LoadQuote()
        {
            this.httpClient = new HttpClient();

            var response = await this.httpClient.GetAsync("https://quotes.rest/qod?language=en");

            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            var token = JToken.Parse(content);

            var contents = token["contents"];

            var quotes = contents["quotes"] as JArray;

            var quote = quotes[0];

            this.Message = quote["quote"].Value<string>();
            this.OnPropertyChanged(nameof(Message));
        }
    }
}
