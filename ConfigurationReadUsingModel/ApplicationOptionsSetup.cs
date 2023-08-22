using Microsoft.Extensions.Options;

namespace ConfigurationReadUsingModel
{
    public class ApplicationOptionsSetup : IConfigureOptions<MySettings>
    {
        private readonly IConfiguration _configuration;
        public ApplicationOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(MySettings options)
        {
            _configuration.GetSection(nameof(MySettings)).Bind(options);
        }
    }
}
