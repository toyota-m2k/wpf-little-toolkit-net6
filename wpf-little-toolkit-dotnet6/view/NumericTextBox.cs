using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace io.github.toyota32k.dotnet6.toolkit.view {
    public class NumericTextBox : TextBox {
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int?), typeof(NumericTextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

        public int? Value {
            get => GetValue(ValueProperty) as int?;
            set => SetValue(ValueProperty, value);
        }

        public NumericTextBox() {
            this.TextAlignment = TextAlignment.Right;
            InputMethod.SetIsInputMethodEnabled(this, false);
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            NumericTextBox numericTextBox = (NumericTextBox)d;
            numericTextBox.Text = e.NewValue == null ? string.Empty : e.NewValue.ToString();

            BindingExpression? binding = numericTextBox.GetBindingExpression(NumericTextBox.ValueProperty);
            if (numericTextBox.Value == null || (binding != null && binding.Status == BindingStatus.UpdateSourceError)) {
                numericTextBox.Value = 0;
                numericTextBox.SelectAll();
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e) {
            base.OnTextChanged(e);

            if (this.Text.Length == 0) {
                this.Value = null;
            } else {
                if (IsNumeric(this.Text)) this.Value = int.Parse(this.Text);
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e) {
            base.OnPreviewKeyDown(e);

            switch (e.Key) {
                case Key.Space:
                    e.Handled = true;
                    break;

                case Key.Back:
                case Key.Delete:
                    break;
            }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e) {
            base.OnPreviewTextInput(e);

            e.Handled = true;

            int selectionStart = this.SelectionStart;
            int selectionEnd = selectionStart + this.SelectionLength;

            string value = string.Empty;
            value += this.Text.Substring(0, selectionStart);
            value += e.Text;
            if (this.Text.Length >= selectionEnd) value += this.Text.Substring(selectionEnd);

            if (!IsNumeric(e.Text)) {
                if (e.Text == "-" && selectionStart == 0) {
                    this.Text = value;
                    this.SelectionStart = 1;
                }
                return;
            }

            if (!IsNumeric(value)) return;

            this.Value = int.Parse(value);
            this.SelectionStart = selectionStart + 1;
        }

        private bool IsNumeric(string value) {
            int work;
            return int.TryParse(value, out work);
        }
    }
}
