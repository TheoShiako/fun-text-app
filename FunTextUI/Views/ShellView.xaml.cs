﻿namespace FunTextUI.Views;
/// <summary>
/// Interaction logic for ShellView.xaml
/// </summary>
public partial class ShellView : Window
{
    public ShellView()
    {
        InitializeComponent();
        DataContext = new ShellViewModel();
    }
}
