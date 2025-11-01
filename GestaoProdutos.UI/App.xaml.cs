using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data;
using GestaoProdutos.Data.ProdutoRepository;
using GestaoProdutos.UI.Services;
using GestaoProdutos.UI.ViewModels;
using GestaoProdutos.UI.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddTransient<ProdutoFormViewModel>();
            services.AddTransient<ProdutoFormAddViewModel>();

            services.AddSingleton<MainViewModel>();
            services.AddTransient<ProdutoFormAdd>();
            services.AddTransient<ProdutoFormView>();
            services.AddSingleton<INavigationService, NavigationService>();

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
