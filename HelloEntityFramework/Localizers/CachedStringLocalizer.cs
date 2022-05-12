using Microsoft.Extensions.Localization;
using System.Globalization;

namespace HelloEntityFramework.Localizers;

public class CachedStringLocalizer : IStringLocalizer
{
    public CultureInfo Culture { get; }
    public IReadOnlyDictionary<string, string> Translations { get; }

    public CachedStringLocalizer(CultureInfo culture, IReadOnlyDictionary<string, string> translations)
    {
        Culture = culture;
        Translations = translations;
    }

    public LocalizedString this[string name]
    {
        get
        {
            if (Translations.ContainsKey(name))
            {
                return new LocalizedString(name, Translations[name]);
            }

            return new LocalizedString(name, name);
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            string translation = Translations.ContainsKey(name) ? Translations[name] : name;

            return new LocalizedString(name, string.Format(translation, arguments));
        }
    }


    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return Translations.Select(pair => new LocalizedString(pair.Key, pair.Value));
    }
}
