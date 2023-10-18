using System.Windows;

namespace TaskLibrary.View;

public partial class BookDistributorsWindow : Window
{
    public BookDistributorsWindow()
    {
        InitializeComponent();
    }

    private void GetBookArticleButtonClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}