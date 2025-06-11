using CoreAnimation;

namespace FluentView.Ios;

public static class ControlsExtensions
{
    #region View

    public static TView Tune<TView>(this TView self, Action<TView> tune)
        where TView : UIView
    {
        tune?.Invoke(self);
        return self;
    }

    public static TView Background<TView>(this TView? self, UIColor? backgroundColor)
        where TView : UIView
    {
        self!.BackgroundColor = backgroundColor;
        return self;
    }

    public static TView Alpha<TView>(this TView self, nfloat alpha)
        where TView : UIView
    {
        self.Alpha = alpha;
        return self;
    }

    public static TView Hidden<TView>(this TView self, bool hidden)
        where TView : UIView
    {
        self.Hidden = hidden;
        return self;
    }

    public static TView ContentMode<TView>(this TView image, UIViewContentMode contentMode)
        where TView : UIView
    {
        image.ContentMode = contentMode;
        return image;
    }

    public static TView ClipsToBounds<TView>(this TView image, bool clipsToBounds)
        where TView : UIView
    {
        image.ClipsToBounds = clipsToBounds;
        return image;
    }

    public static TView Corners<TView>(this TView self, nfloat cornerRadius, CACornerMask? cornerMask = null)
        where TView : UIView
    {
        self.ClipsToBounds = true;
        self.Layer.MasksToBounds = true;
        self.Layer.CornerRadius = cornerRadius;
        if (cornerMask.HasValue)
            self.Layer.MaskedCorners = cornerMask.Value;
        else
            self.Layer.MaskedCorners =
                CACornerMask.MaxXMaxYCorner | CACornerMask.MaxXMinYCorner | CACornerMask.MinXMaxYCorner | CACornerMask.MinXMinYCorner;

        return self;
    }

    public static TView Shadow<TView>(this TView self, nfloat shadowRadius, float shadowOpacity, CGSize shadowOffset, UIColor shadowColor)
        where TView : UIView
    {
        self.Layer.ShadowRadius = shadowRadius;
        self.Layer.ShadowOpacity = shadowOpacity;
        self.Layer.ShadowOffset = shadowOffset;
        self.Layer.ShadowColor = shadowColor.CGColor;
        self.Layer.MasksToBounds = false;

        return self;
    }

    public static TView CornersAndShadow<TView>(this TView self, nfloat cornerRadius, nfloat shadowRadius, float shadowOpacity, CGSize shadowOffset, UIColor shadowColor)
        where TView : UIView
    {
        self.Layer.CornerRadius = cornerRadius;
        self.ClipsToBounds = true;
        self.Layer.ShadowRadius = shadowRadius;
        self.Layer.ShadowOpacity = shadowOpacity;
        self.Layer.ShadowOffset = shadowOffset;
        self.Layer.ShadowColor = shadowColor.CGColor;
        self.Layer.MasksToBounds = false;

        return self;
    }

    public static TView Border<TView>(this TView self, nfloat borderWidth, CGColor borderColor)
        where TView : UIView
    {
        self.ClipsToBounds = true;
        self.Layer.MasksToBounds = true;
        self.Layer.BorderWidth = borderWidth;
        self.Layer.BorderColor = borderColor;

        return self;
    }

    public static TView UserInteractionEnabled<TView>(this TView self, bool enabled)
        where TView : UIView
    {
        self.UserInteractionEnabled = enabled;
        return self;
    }
    
    public static TView HideKeyboardOnTap<TView>(this TView self)
        where TView : UIView
    {
        var tapRecognizer = new UITapGestureRecognizer(() => self.EndEditing(true));
        tapRecognizer.CancelsTouchesInView = false;
        self.AddGestureRecognizer(tapRecognizer);

        return self;
    } 

    public static TView SetCustomSpacing<TView>(this TView self, UIView subview, nfloat spacing)
        where TView : UIStackView
    {
        self.SetCustomSpacing(spacing, subview);
        return self;
    }
    
    public static TView KeyboardDismissMode<TView>(this TView table, UIScrollViewKeyboardDismissMode keyboardDismissMode)
        where TView : UIScrollView
    {
        table.KeyboardDismissMode = keyboardDismissMode;
        return table;
    }

    #endregion

    #region Label

    public static TView Text<TView>(this TView label, string? text)
       where TView : UILabel
    {
        label.Text = text;
        return label;
    }

    public static TView TextColor<TView>(this TView label, UIColor? color)
       where TView : UILabel
    {
        label.TextColor = color;
        return label;
    }

    public static TView Font<TView>(this TView label, UIFont font)
       where TView : UILabel
    {
        label.Font = font;
        return label;
    }

    public static TView LineBreakMode<TView>(this TView label, UILineBreakMode lineBreakMode)
       where TView : UILabel
    {
        label.LineBreakMode = lineBreakMode;
        return label;
    }

    public static TView Lines<TView>(this TView label, int lines)
       where TView : UILabel
    {
        label.Lines = lines;
        return label;
    }

    public static TView SingleLine<TView>(this TView label)
        where TView : UILabel
    {
        label.Lines = 1;
        label.LineBreakMode = UILineBreakMode.TailTruncation;

        return label;
    }

    public static TView Multiline<TView>(this TView label, UILineBreakMode lineBreakMode = UILineBreakMode.WordWrap)
        where TView : UILabel
    {
        label.Lines = 0;
        label.LineBreakMode = lineBreakMode;

        return label;
    }

    public static TView TextAlignment<TView>(this TView label, UITextAlignment textAlignment)
       where TView : UILabel
    {
        label.TextAlignment = textAlignment;
        return label;
    }

    public static TView AdjustsFontSize<TView>(this TView label, nfloat minimumScaleFactor)
        where TView : UILabel
    {
        label.Lines = 1;
        label.AdjustsFontSizeToFitWidth = true;
        label.MinimumScaleFactor = minimumScaleFactor;

        return label;
    }

    public static TView AttributedText<TView>(this TView label, NSAttributedString attributedString)
       where TView : UILabel
    {
        label.AttributedText = attributedString;
        return label;
    }

    #endregion

    #region Button

    public static TView TitleFont<TView>(this TView button, UIFont font)
       where TView : UIButton
    {
        button.TitleLabel.Font = font;
        return button;
    }

    #endregion

    #region EditText

    public static TView Placeholder<TView>(this TView field, string? placeholder)
        where TView : UITextField
    {
        field.Placeholder = placeholder;
        return field;
    }
    
    public static TView ContentType<TView>(this TView field, NSString contentType)
        where TView : UITextField
    {
        field.TextContentType = contentType;
        return field;
    }

    public static TView Email<TView>(this TView field)
        where TView : UITextField
    {
        return field
            .ContentType(UITextContentType.EmailAddress)
            .AutocapitalizationType(UITextAutocapitalizationType.None)
            .KeyboardType(UIKeyboardType.EmailAddress);
    }

    public static TView Phone<TView>(this TView field)
       where TView : UITextField
    {
        return field
            .ContentType(UITextContentType.TelephoneNumber)
            .AutocapitalizationType(UITextAutocapitalizationType.None)
            .KeyboardType(UIKeyboardType.PhonePad);
    }

    public static TView GivenName<TView>(this TView field)
        where TView : UITextField
    {
        return field
            .ContentType(UITextContentType.GivenName)
            .AutocapitalizationType(UITextAutocapitalizationType.Words)
            .KeyboardType(UIKeyboardType.Default);
    }

    public static TView FamilyName<TView>(this TView field)
       where TView : UITextField
    {
        return field
            .ContentType(UITextContentType.FamilyName)
            .AutocapitalizationType(UITextAutocapitalizationType.Words)
            .KeyboardType(UIKeyboardType.Default);
    }

    public static TView Password<TView>(this TView field)
       where TView : UITextField
    {
        return field
            .ContentType(UITextContentType.Password)
            .AutocapitalizationType(UITextAutocapitalizationType.None)
            .KeyboardType(UIKeyboardType.Default)
            .Tune(f => f.SecureTextEntry = true);
    }
    
    public static TView Money<TView>(this TView field)
        where TView : UITextField
    {
        return field
            .AutocapitalizationType(UITextAutocapitalizationType.None)
            .KeyboardType(UIKeyboardType.DecimalPad)
            .Tune(f => f.SecureTextEntry = true);
    }

    public static TView AutocapitalizationType<TView>(this TView field, UITextAutocapitalizationType autocapitalizationType)
       where TView : UITextField
    {
        field.AutocapitalizationType = autocapitalizationType;
        return field;
    }

    public static TView AutocorrectionType<TView>(this TView field, UITextAutocorrectionType autocorrectionType)
        where TView : UITextField
    {
        field.AutocorrectionType = autocorrectionType;
        return field;
    }
    
    public static TView ReturnKeyType<TView>(this TView field, UIReturnKeyType keyType)
        where TView : UITextField
    {
        field.ReturnKeyType = keyType;
        return field;
    }
    
    public static TView ShouldReturnFunc<TView>(this TView field, Func<bool> shouldReturn)
        where TView : UITextField
    {
        field.ShouldReturn = f => shouldReturn();
        return field;
    }

    public static TView KeyboardType<TView>(this TView field, UIKeyboardType keyboardType)
        where TView : UITextField
    {
        field.KeyboardType = keyboardType;
        return field;
    }

    #endregion

    #region Image

    public static TView TintColor<TView>(this TView image, UIColor tintColor)
        where TView : UIImageView
    {
        image.TintColor = tintColor;
        image.Image = image.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate).ApplyTintColor(tintColor);
        return image;
    }

    #endregion

    #region Table

    public static TView NoSeparator<TView>(this TView table)
        where TView : UITableView
    {
        table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        return table;
    }

    public static TView NoSelection<TView>(this TView table)
       where TView : UITableView
    {
        table.AllowsSelection = false;
        return table;
    }

    public static TView DataSource<TView>(this TView table, IUITableViewDataSource dataSource)
         where TView : UITableView
    {
        table.DataSource = dataSource;
        return table;
    }

    public static TView Source<TView>(this TView table, UITableViewSource source)
         where TView : UITableView
    {
        table.Source = source;
        return table;
    }
    
    public static TView RowHeight<TView>(this TView table, nfloat rowHeight)
        where TView : UITableView
    {
        table.RowHeight = rowHeight;
        return table;
    }
    
    public static TView EstimatedRowHeight<TView>(this TView table, nfloat estimatedRowHeight)
        where TView : UITableView
    {
        table.EstimatedRowHeight = estimatedRowHeight;
        return table;
    }

    public static TView AutomaticRowHeight<TView>(this TView table)
        where TView : UITableView
    {
        return table.RowHeight(UITableView.AutomaticDimension);
    }

    #endregion
}
