using Microsoft.Extensions.Configuration;

namespace BookApi.Infrastructure.Common;
internal static class ConfigDecorator
{
    internal static IConfigurationManager? Config;

    internal static void InitializeConfig(IConfigurationManager? manager) => Config ??= manager;
}