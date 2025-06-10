namespace FluentView.Ios;

public static class ViewExtensions
{
    public static TView Subviews<TView>(this TView self, params UIView[] subviews)
        where TView : UIView
    {
        self.AddSubviews(subviews);
        return self;
    }

    public static TView ArrangedSubview<TView>(this TView self, params UIView[] subviews)
        where TView : UIStackView
    {
        foreach (var subview in subviews)
            self.AddArrangedSubview(subview);
        
        return self;
    }

    public static TView ActivateConstraints<TView>(this TView self)
        where TView : UIView
    {
        NSLayoutConstraint.ActivateConstraints(self.Constraints);
        return self;
    }

    public static TView ActivateConstraints<TView>(this TView self, params NSLayoutConstraint[] constraints)
        where TView : UIView
    {
        NSLayoutConstraint.ActivateConstraints(constraints);
        return self;
    }

    public static TView Frame<TView>(this TView self, CGRect frame)
        where TView  : UIView
    {
        self.Frame = frame;
        return self;
    }

    public static TView Frame<TView>(this TView self, float left, float top, float width, float height)
        where TView : UIView
    {
        self.Frame = new CGRect(left, top, width, height);
        return self;
    }

    public static TView Frame<TView>(this TView self, nfloat left, nfloat top, nfloat width, nfloat height)
        where TView : UIView
    {
        self.Frame = new CGRect(left, top, width, height);
        return self;
    }
}

