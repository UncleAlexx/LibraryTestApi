namespace Library.Infrastructure.Common;

internal static class ConfigDecorator
{
    internal static IConfigurationManager? Config;

    internal static void InitializeConfig(IConfigurationManager? manager) => Config ??= manager;
}