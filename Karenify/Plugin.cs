using ManagedCommon;
using System.Windows.Forms;
using Wox.Plugin;

namespace Community.Powertoys.Run.Plugin.Karenify;

public class Plugin : IPlugin
{
    public string Name => "Karenify";
    public string Description => "Karenify input and copy it to the clipboard";
    public static string PluginID => "5EAAFCA8209044DA80F026B8EFE24FAD";

    private PluginInitContext? _context;
    private string? _iconPath;

    public void Init(PluginInitContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        _context = context;
        _context.API.ThemeChanged += (_, theme) => UpdateIconPath(theme);
        UpdateIconPath(_context.API.GetCurrentTheme());
    }

    public List<Result> Query(Query query)
    {
        ArgumentNullException.ThrowIfNull(query);
        if (string.IsNullOrEmpty(query.Search))
            return new();

        var options = new KarenifyOptions[] {
            new(UppercaseFirst: true),
            new(UppercaseFirst: false),
        };
        return options
            .Select(options => {
                var result = Karenify(query.Search, options);
                return new Result()
                {
                    QueryTextDisplay = query.Search,
                    IcoPath = _iconPath,
                    Title = result,
                    SubTitle = Name,
                    Action = _ => {
                        Clipboard.SetText(result);
                        return true;
                    },
                };
            })
            .ToList();
    }

    private string Karenify(string source, KarenifyOptions options)
    {
        var upper = options.UppercaseFirst;
        var buffer = new char[source.Length];

        for (var i = 0; i < source.Length; i++)
        {
            if (!Char.IsLetter(source[i]))
            {
                buffer[i] = source[i];
            }
            else
            {
                buffer[i] = upper
                    ? Char.ToUpper(source[i])
                    : Char.ToLower(source[i]);
                upper = !upper;
            }
        }

        return new(buffer);
    }

    private void UpdateIconPath(Theme theme)
    {
        _iconPath = theme is Theme.Light or Theme.HighContrastWhite
            ? "res/Karenify.light.png"
            : "res/Karenify.dark.png";
    }
}

public record struct KarenifyOptions(bool UppercaseFirst);
