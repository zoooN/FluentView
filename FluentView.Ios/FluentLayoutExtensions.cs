using Cirrious.FluentLayouts.Touch;

namespace FluentView.Ios;

public static class FluentLayoutExtensions
{
    public static TView Constraints<TView>(this TView self, params FluentLayout[] constraints)
        where TView : UIView
    {
        self.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        self.AddConstraints(constraints);

        return self;
    }
    
    public static TView Constraints<TView>(this TView self, IEnumerable<FluentLayout> constraints)
        where TView : UIView
    {
        return self.Constraints(constraints.ToArray());
    }

    public static TView Constraints<TView>(this TView self, params FluentLayout[][] constraints)
        where TView : UIView
    {
        var flatConstraints = constraints.SelectMany(x => x).ToArray();
        self.Constraints(flatConstraints);

        return self;
    }
}