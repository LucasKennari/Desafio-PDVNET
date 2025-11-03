using System.Windows;

namespace GestaoProdutos.UI.Behaviors
{
    public static class TextBoxBehaviors
    {
        public static readonly DependencyProperty OnlyNumbersProperty
            = DependencyProperty.RegisterAttached(
                "OnlyNumbers",
                typeof(bool),
                typeof(TextBoxBehaviors),
                new PropertyMetadata(false, OnOnlyNumbersChanged));

        public static bool GetOnlyNumbersChanged(DependencyObject obj) => (bool)obj.GetValue(OnlyNumbersProperty);
        public static void SetOnlyNumbers(DependencyObject obj, bool value) => obj.SetValue(OnlyNumbersProperty, value);
        private static void OnOnlyNumbersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as System.Windows.Controls.TextBox;
            if (textBox == null) return;

            if ((bool)e.NewValue)
            {
                textBox.PreviewTextInput += TextBox_PreviewTextInput;
                DataObject.AddPastingHandler(textBox, OnPaste);
            }
            else
            {
                textBox.PreviewTextInput -= TextBox_PreviewTextInput;
                DataObject.RemovePastingHandler(textBox, OnPaste);
            }
        }
        private static void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }
        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                var text = e.DataObject.GetData(DataFormats.Text) as string;
                if (!IsTextNumeric(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private static bool IsTextNumeric(string text)
        {
            return text.All(char.IsDigit);
        }
    }
}
