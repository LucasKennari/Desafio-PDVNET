using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data;
using GestaoProdutos.Data.ProdutoRepository;
using GestaoProdutos.UI.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
namespace GestaoProdutos.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration; 
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<ProdutoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GestaoProdutosDb"));
            });

      
            services.AddSingleton<MainWindow>();
            services.AddScoped<ProdutoRepository>();
            services.AddScoped<ProdutoService>();

            services.AddTransient<ViewModels.ProdutoFormViewModel>();
            services.AddTransient<ProdutoFormView>();
            services.AddSingleton<ViewModels.MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }
        private void OnStartUp(object s, StartupEventArgs e)
        {
            var mainView = _serviceProvider.GetRequiredService<MainWindow>();
            mainView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainView.Show();
        }
    }
}
