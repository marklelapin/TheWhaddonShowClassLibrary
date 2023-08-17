[assembly: HostingStartup(typeof(TheWhaddonShowApp.Areas.Identity.IdentityHostingStartup))]
namespace TheWhaddonShowApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
