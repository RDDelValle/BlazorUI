using BlazorUI.Builders;
using BlazorUI.Extensions;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Base;

public abstract class BaseComponent : ComponentBase
{
    protected CssClassBuilder CssClassBuilder 
        => new CssClassBuilder(GetType().Name.ToKebabCase())
            .Add(Class);

    protected CssStyleBuilder CssStyleBuilder
        => new CssStyleBuilder(Style);
    
    protected virtual string? CssClass 
        => CssClassBuilder.Build();
    
    protected virtual string? CssStyle
        => CssStyleBuilder.Build();

    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Style { get; set; }
}