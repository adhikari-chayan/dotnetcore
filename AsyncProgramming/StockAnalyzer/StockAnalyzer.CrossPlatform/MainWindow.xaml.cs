using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Core.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;


namespace StockAnalyzer.CrossPlatform
{
    public class MainWindow : Window
    {
        public DataGrid Stocks => this.FindControl<DataGrid>(nameof(Stocks));
        public ProgressBar StockProgress => this.FindControl<ProgressBar>(nameof(StockProgress));
        public TextBox StockIdentifier => this.FindControl<TextBox>(nameof(StockIdentifier));
        public Button Search => this.FindControl<Button>(nameof(Search));
        public TextBox Notes => this.FindControl<TextBox>(nameof(Notes));
        public TextBlock StocksStatus => this.FindControl<TextBlock>(nameof(StocksStatus));
        public TextBlock DataProvidedBy => this.FindControl<TextBlock>(nameof(DataProvidedBy));
        public TextBlock IEX => this.FindControl<TextBlock>(nameof(IEX));
        public TextBlock IEX_Terms => this.FindControl<TextBlock>(nameof(IEX_Terms));

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            IEX.PointerPressed += (e, a) => Open("https://iextrading.com/developer/");
            IEX_Terms.PointerPressed += (e, a) => Open("https://iextrading.com/api-exhibit-a/");

            /// Data provided for free by <a href="https://iextrading.com/developer/" RequestNavigate="Hyperlink_OnRequestNavigate">IEX</Hyperlink>. View <Hyperlink NavigateUri="https://iextrading.com/api-exhibit-a/" RequestNavigate="Hyperlink_OnRequestNavigate">IEX’s Terms of Use.</Hyperlink>
        }




        private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
        private Stopwatch stopwatch = new Stopwatch();

        CancellationTokenSource cancellationTokenSource;
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            if(cancellationTokenSource != null)
            {
                //Already have an instance of the cancellation token source?
                //This means that the button has already been pressed.
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;

                Search.Content = "Search";
                return;
            }
            try
            {
                cancellationTokenSource = new CancellationTokenSource();

                cancellationTokenSource.Token.Register(() =>
                {
                    Notes.Text = "Cancellation Requsted";
                });

                Search.Content = "Cancel";
                BeforeLoadingStockData();

                #region Using Direct Http Call
                //using (var client = new HttpClient())
                //{
                //    var responseTask = client.GetAsync($"{API_URL}/{StockIdentifier.Text}");

                //    var response = await responseTask;

                //    var content = await response.Content.ReadAsStringAsync();

                //    var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);

                //    Stocks.Items = data;
                //}
                #endregion

                #region Using DataStore
                //var getStocksTask = GetStocks();
                //await getStocksTask;
                #endregion

                #region Using Continuation

                //var loadLinesTask = Task.Run(async () =>
                //{
                //    using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                //    {
                //        var lines = new List<string>();

                //        string line;
                //        while ((line = await stream.ReadLineAsync()) != null)
                //        {
                //            lines.Add(line);
                //        }

                //        return lines;
                //    }
                //});

                //loadLinesTask.ContinueWith(t =>
                //{
                //    Dispatcher.Invoke(() =>
                //    {
                //        Notes.Text = t.Exception.InnerException.Message;
                //    });
                //}, TaskContinuationOptions.OnlyOnFaulted);

                //var processStocksTask = loadLinesTask.ContinueWith((completedTask) =>
                //{
                //    var lines = completedTask.Result;
                //    var data = new List<StockPrice>();
                //    foreach (var line in lines.Skip(1))
                //    {
                //        var price = StockPrice.FromCSV(line);
                //        data.Add(price);
                //    }

                //    Dispatcher.Invoke(() =>
                //    {
                //        Stocks.Items = data.Where(sp => sp.Identifier == StockIdentifier.Text);
                //    });

                //}, TaskContinuationOptions.OnlyOnRanToCompletion);

                //processStocksTask.ContinueWith(_ =>
                //{

                //    Dispatcher.Invoke(() =>
                //    {
                //        AfterLoadingStockData();
                //    });
                //});

                #endregion

                #region Using CancellationToken
                //var loadLinesTask = SearchForStocks(cancellationTokenSource.Token);

                //loadLinesTask.ContinueWith(t =>
                //{
                //    Dispatcher.Invoke(() =>
                //    {
                //        Notes.Text = t.Exception.InnerException.Message;
                //    });
                //}, TaskContinuationOptions.OnlyOnFaulted);

                //var processStocksTask = loadLinesTask.ContinueWith((completedTask) =>
                //{
                //    var lines = completedTask.Result;
                //    var data = new List<StockPrice>();
                //    foreach (var line in lines.Skip(1))
                //    {
                //        var price = StockPrice.FromCSV(line);
                //        data.Add(price);
                //    }

                //    Dispatcher.Invoke(() =>
                //    {
                //        Stocks.Items = data.Where(sp => sp.Identifier == StockIdentifier.Text);
                //    });

                //},
                //cancellationTokenSource.Token,
                //TaskContinuationOptions.OnlyOnRanToCompletion,
                //TaskScheduler.Current
                //);

                //processStocksTask.ContinueWith(_ =>
                //{

                //    Dispatcher.Invoke(() =>
                //    {
                //        AfterLoadingStockData();
                //        cancellationTokenSource = null;
                //        Search.Content = "Search";
                //    });
                //});
                #endregion

                #region Using HttpClient and CancellationToken
                //var service = new StockService();

                //var data = await service.GetStockPricesFor(StockIdentifier.Text, cancellationTokenSource.Token);

                //Stocks.Items = data;
                #endregion

                #region Getting Stock Price for multiple identifiers

                var identifiers = StockIdentifier.Text.Split(',', ' ');

                var service = new StockService();
                var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();
                foreach (var identifier in identifiers)
                {
                    var loadTask = service.GetStockPricesFor(identifier, cancellationTokenSource.Token);

                    loadingTasks.Add(loadTask);
                }

                var timeoutTask = Task.Delay(120000);
                var allStocksLoadingTask = Task.WhenAll(loadingTasks);

                var completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask);

                if (completedTask == timeoutTask)
                {
                    cancellationTokenSource.Cancel();
                    throw new OperationCanceledException("Timeout!");
                }

                Stocks.Items = allStocksLoadingTask.Result.SelectMany(x => x);

                #endregion

                #region Using Concurrent Collection

                //var identifiers = StockIdentifier.Text.Split(',', ' ');

                //var service = new StockService();
                //var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

                //var stocks = new ConcurrentBag<StockPrice>();

                //foreach (var identifier in identifiers)
                //{
                //    var loadTask = service.GetStockPricesFor(identifier, cancellationTokenSource.Token);

                //    loadTask = loadTask.ContinueWith(t =>
                //    {
                //        var aFewStocks = t.Result.Take(5);

                //        foreach (var stock in aFewStocks)
                //        {
                //            stocks.Add(stock);
                //        }

                //        Dispatcher.Invoke(() =>
                //        {
                //            Stocks.Items = stocks.ToArray();
                //        });

                //        return aFewStocks;

                //    });


                //    loadingTasks.Add(loadTask);
                //}

                //var timeoutTask = Task.Delay(120000);
                //var allStocksLoadingTask = Task.WhenAll(loadingTasks);

                //var completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask);

                //if (completedTask == timeoutTask)
                //{
                //    cancellationTokenSource.Cancel();
                //    throw new OperationCanceledException("Timeout!");
                //}


                #endregion

            }
            catch (Exception ex)
            {
                Notes.Text = ex.Message;
            }
            finally
            {
                AfterLoadingStockData();
                cancellationTokenSource = null;
                Search.Content = "Search";
            }
        }

        private static Task<List<string>> SearchForStocks(CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                {
                    var lines = new List<string>();

                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            break;
                        }
                        lines.Add(line);
                    }

                    return lines;
                }
            });
        }

        private async Task GetStocks()
        {
            try
            {
                var store = new DataStore();
                var responseTask = store.GetStockPrices(StockIdentifier.Text);
                Stocks.Items = await responseTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






        private void BeforeLoadingStockData()
        {
            stopwatch.Restart();
            StockProgress.IsVisible = true;
            StockProgress.IsIndeterminate = true;
        }

        private void AfterLoadingStockData()
        {
            StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
            StockProgress.IsVisible = false;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                desktopLifetime.Shutdown();
            }
        }

        public static void Open(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
        }
    }
}
