using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace DolarJson
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnPesquisa_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync($"https://economia.awesomeapi.com.br/json/last/USD-BRL");
            var dados = JsonConvert.DeserializeObject<Dolar>(json);

            edtCompra.Text = dados.bid;
            edtVenda.Text = dados.ask;
            edtMax.Text = dados.high;
            edtMin.Text = dados.low;
            edtPctVariacao.Text = dados.pctChange;
            edtVariacao.Text = dados.varBid;
        }
    }
}
