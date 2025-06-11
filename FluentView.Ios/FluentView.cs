namespace FluentView.Ios;

public static class FluentView
{
    public static UILabel Label(ref UILabel label, string? text = null) 
    {
        return label = new UILabel()
            .Text(text)
            .TextColor(UIColor.Label)
            .Multiline();
    }

    public static UIButton Button(ref UIButton button, UIButtonConfiguration configuration)
    {
        return button = new UIButton()
            .Tune(button => button.Configuration = configuration);
    }

    public static UITextField TextField(ref UITextField field, string? placeholder = null)
    {
        return field = new UITextField()
            .Placeholder(placeholder);
    }
    
    public static UIImageView Image(ref UIImageView image)
    {
        return image = new UIImageView();
    }
    
    public static UIImageView Image(ref UIImageView image, UIImage imageData)
    {
        return image = new UIImageView(imageData);
    }

    public static UIImageView ImageBundle(ref UIImageView image, string imageName, UIColor? imageTint = null)
    {
        if (imageTint != null)
        {
            image = new UIImageView(UIImage.FromBundle(imageName)!.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate));
            image.TintColor = imageTint;
        }
        else
        {
            image = new UIImageView(UIImage.FromBundle(imageName)!.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal));
        }

        return image;
    }

    public static UIImageView ImageSystem(ref UIImageView? image, string systemImageName, UIColor? imageTint = null)
    {
        if (imageTint != null)
        {
            image = new UIImageView(UIImage.GetSystemImage(systemImageName)!.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate));
            image.TintColor = imageTint;
        }
        else
        {
            image = new UIImageView(UIImage.GetSystemImage(systemImageName)!.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal));
        }

        return image;
    }
    
    public static UIStackView Stack(ref UIStackView stackView, UILayoutConstraintAxis axis, UIStackViewDistribution distribution, nfloat spacing)
    {
        return stackView = new UIStackView()
            .Tune(view =>
            {
                view.Axis = axis;
                view.Distribution = distribution;
                view.Spacing = spacing;
            });
    }
    
    public static UIStackView VStack(ref UIStackView stackView, float spacing = 0f, UIStackViewDistribution distribution = UIStackViewDistribution.Fill)
    {
        return Stack(ref stackView, UILayoutConstraintAxis.Vertical, distribution, spacing);
    }

    public static UIStackView HStack(ref UIStackView stackView, float spacing = 0f, UIStackViewDistribution distribution = UIStackViewDistribution.Fill)
    {
        return Stack(ref stackView, UILayoutConstraintAxis.Horizontal, distribution, spacing);
    }
    
    public static UITableView Table(ref UITableView tableView)
    {
        return tableView = new UITableView();
    }

    public static UICollectionView Collection(ref UICollectionView collection, UICollectionViewLayout layout)
    {
        return collection = new UICollectionView(CGRect.Empty, layout);
    }

    public static UIScrollView Scroll(ref UIScrollView scrollView)
    {
        return scrollView = new UIScrollView();
    }
    
    public static UIVisualEffectView Blur(ref UIVisualEffectView view, UIBlurEffectStyle style)
    {
        return view = new UIVisualEffectView(UIBlurEffect.FromStyle(style));
    }
    
    public static UIActivityIndicatorView ActivityIndicator(ref UIActivityIndicatorView? view, UIActivityIndicatorViewStyle style)
    {
        return view = new UIActivityIndicatorView(style);
    }
}