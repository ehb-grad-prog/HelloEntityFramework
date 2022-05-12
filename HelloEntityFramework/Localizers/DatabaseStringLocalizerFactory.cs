using HelloEntityFramework.Data;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace HelloEntityFramework.Localizers;

public class DatabaseStringLocalizerFactory : IStringLocalizerFactory
{
    public IServiceScopeFactory ScopeFactory { get; }
    private Dictionary<string, Dictionary<string, string>> _translations = new();

    public DatabaseStringLocalizerFactory(IServiceScopeFactory scopeFactory)
    {
        ScopeFactory = scopeFactory;
        Update();
    }

    public void Update()
    {
        using var scope = ScopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<HelloEntityFrameworkContext>();

        foreach (var translation in context.Translations)
        {
            var language = _translations.ContainsKey(translation.Language) ? _translations[translation.Language] : new();

            language[translation.Key] = translation.Value;
            _translations[translation.Language] = language;
        }
    }

    public IStringLocalizer Create(Type resourceSource)
    {
        var translations = _translations.ContainsKey(CultureInfo.CurrentUICulture.Name) ? _translations[CultureInfo.CurrentUICulture.Name] : new();

        return new CachedStringLocalizer(CultureInfo.CurrentUICulture, translations);
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        var translations = _translations.ContainsKey(CultureInfo.CurrentUICulture.Name) ? _translations[CultureInfo.CurrentUICulture.Name] : new();

        return new CachedStringLocalizer(CultureInfo.CurrentUICulture, translations);
    }
}
