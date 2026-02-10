using System.Text.RegularExpressions;

namespace BlazorUI.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Converts a PascalCase or camelCase string into kebab-case.
    /// Examples: "UiComponentName" -> "ui-component-name".
    /// </summary>
    public static string ToKebabCase(this string? value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        var s = value.Trim();

        // Normalize separators
        s = s.Replace(" ", "-").Replace("_", "-");

        // lower-to-upper (aB -> a-B) and digit-to-upper (1A -> 1-A)
        s = Regex.Replace(s, "([a-z0-9])([A-Z])", "$1-$2");

        // handle boundary between an acronym and a normal word (HTMLInput -> HTML-Input)
        s = Regex.Replace(s, "([A-Z])([A-Z][a-z])", "$1-$2");

        // collapse repeated hyphens
        s = Regex.Replace(s, "-{2,}", "-");

        return s.Trim('-').ToLowerInvariant();
    }
}