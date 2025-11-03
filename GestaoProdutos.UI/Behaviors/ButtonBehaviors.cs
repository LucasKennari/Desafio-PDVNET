using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestaoProdutos.UI.Behaviors
{
    public static class ButtonBehaviors
    {
        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.RegisterAttached(
                "ClickCommand",
                typeof(ICommand),
                typeof(ButtonBehaviors),
                new PropertyMetadata(null, OnClickCommandChanged));

        public static ICommand GetClickCommand(DependencyObject obj)
            => (ICommand)obj.GetValue(ClickCommandProperty);

        public static void SetClickCommand(DependencyObject obj, ICommand value)
            => obj.SetValue(ClickCommandProperty, value);

        private static void OnClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Button button) return;

            if (e.NewValue != null)
                button.Click += Button_Click;
            else
                button.Click -= Button_Click;
        }

        private static void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                var command = GetClickCommand(btn);
                if (command?.CanExecute(null) == true)
                    command.Execute(null);
            }
        }
    }
}
