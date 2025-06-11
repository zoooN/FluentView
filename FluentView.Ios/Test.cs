using Cirrious.FluentLayouts.Touch;

namespace FluentView.Ios;

public class Test
{
    private readonly UIStackView _contentStack = new();
    
    private readonly UILabel _titleLabel = new();
    
    private readonly UITextField _emailField = new();
    private readonly UITextField _passwordField = new();
    
    private readonly UIButton _loginButton= new();
    
    public Test()
    {
        var view = new UIView();
        view
            .Subviews(
                FluentView.VStack(ref _contentStack)
                    .ArrangedSubviews(
                        
                        FluentView.Label(ref _titleLabel)
                            .Text("Login")
                            .Font(UIFont.SystemFontOfSize(18, UIFontWeight.Bold)),

                        FluentView.TextField(ref _emailField)
                            .Email(),

                        FluentView.TextField(ref _passwordField)
                            .Password(),

                        FluentView.Button(ref _loginButton, UIButtonConfiguration.FilledButtonConfiguration)
                            .Tune(button =>
                            {
                                var config = button.Configuration!;
                                config.Title = "Log in";

                                button.Configuration = config;
                            })
                    )
                    .SetCustomSpacing(_titleLabel, 16)
                    .SetCustomSpacing(_emailField, 8)
                    .SetCustomSpacing(_passwordField, 16)
            )
            .Constraints(
                
                _contentStack.AtLeadingOf(view, 16),
                _contentStack.AtTrailingOf(view, 16),
                _contentStack.WithSameCenterY(view)
            );
    }
}