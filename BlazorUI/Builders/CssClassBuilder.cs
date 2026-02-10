namespace BlazorUI.Builders;

public sealed class CssClassBuilder(string? value)
{
    private readonly IList<string> _cssClasses = 
        string.IsNullOrWhiteSpace(value) ? [] : [value];
    
    public CssClassBuilder Add(string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            _cssClasses.Add(value);
        return this;
    }
    
    public CssClassBuilder AddIf(bool condition, string? value)
        => condition ? Add(value) : this;
    
    public string? Build()
    {
        var value = string.Join(" ", _cssClasses);
        return string.IsNullOrWhiteSpace(value) 
            ? null 
            : value; 
    }
}