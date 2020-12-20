using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Core.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Linq;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
        private Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }


       
        CancellationTokenSource cancellationTokenSource;
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            if (cancellationTokenSource != null)
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

                //var identifiers = StockIdentifier.Text.Split(',', ' ');

                //var service = new StockService();
                //var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();
                //foreach (var identifier in identifiers)
                //{
                //    var loadTask = service.GetStockPricesFor(identifier, cancellationTokenSource.Token);

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

                //Stocks.Items = allStocksLoadingTask.Result.SelectMany(x => x);

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
                //            Stocks.ItemsSource = stocks.ToArray();
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

                #region Execution Context Demo
                var data = await GetStocksFor(StockIdentifier.Text);
                Notes.Text = "Stocks Loaded!!";
                Stocks.ItemsSource = data;

                #endregion

                #region Reporting Progress of Task
                //var progress = new Progress<IEnumerable<StockPrice>>();
                //progress.ProgressChanged += (_, stocks) =>
                //{
                //    StockProgress.Value += 1;
                //    Notes.Text += $"Loaded {stocks.Count()} for {stocks.First().Identifier}{Environment.NewLine}";
                //};

                //await SearchForStocks(progress);
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

        private async Task<IEnumerable<StockPrice>> GetStocksFor(string identifier)
        {
            var service = new StockService();
            var data = await service.GetStockPricesFor(identifier,CancellationToken.None).ConfigureAwait(false);

            return data.Take(5);
        }

        private async Task SearchForStocks(IProgress<IEnumerable<StockPrice>> progress)
        {
            var service = new StockService();
            var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

            foreach (var identifier in StockIdentifier.Text.Split(' ',','))
            {
                var loadTask = service.GetStockPricesFor(identifier, CancellationToken.None);

                loadTask = loadTask.ContinueWith(completedTask =>
                {
                    progress?.Report(completedTask.Result);
                    return completedTask.Result;
                });

                loadingTasks.Add(loadTask);
            }

            var data = await Task.WhenAll(loadingTasks);

            Stocks.ItemsSource = data.SelectMany(stock => stock);
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
                Stocks.ItemsSource = await responseTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        private void BeforeLoadingStockData()
        {
            stopwatch.Restart();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;
            StockProgress.Value = 0;
            StockProgress.Maximum = StockIdentifier.Text.Split(' ', ',').Length;
        }

        private void AfterLoadingStockData()
        {
            StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
