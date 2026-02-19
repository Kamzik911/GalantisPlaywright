using GalantisPlaywright.Interfaces;

namespace GalantisPlaywright.RoutePages
{
    public sealed class EnvironmentRouteProvider : ISetRoutePages
    {
        private readonly string _baseUrl;

        public EnvironmentRouteProvider()
        {
            _baseUrl = Environment.GetEnvironmentVariable("Base url")
                ?? "https://galantis.merchtable.com";
        }

        public string Get(SetRoutePages page)
        {
            var route = page switch
            {
                SetRoutePages.Home => "/",
                _ => throw new ArgumentOutOfRangeException(nameof(page))
            };

            return $"{_baseUrl}{route}";
        }
    }
}
