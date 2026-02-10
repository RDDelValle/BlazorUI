namespace BlazorUI.Builders;

public sealed class CssStyleBuilder(string? value)
{
    private readonly IList<string> _cssStyles = 
        string.IsNullOrWhiteSpace(value) ? [] : [value];
    
    public CssStyleBuilder Add(string property, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            _cssStyles.Add($"{property}:{value};");
        return this;
    }
    
    public CssStyleBuilder AddIf(bool condition, string property, string? value)
        => condition ? Add(property, value) : this;
    
    public string? Build()
    {
        var value = string.Join("", _cssStyles);
        return string.IsNullOrWhiteSpace(value) 
            ? null 
            : value; 
    }
}