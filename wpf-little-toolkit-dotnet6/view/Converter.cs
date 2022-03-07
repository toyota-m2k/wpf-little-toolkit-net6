using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace io.github.toyota32k.dotnet6.toolkit.view {
    public class BoolVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
    public class NegBoolVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (!(bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    public class NegBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value as bool? != true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value as bool? != true;
        }
    }


    public class EnumBooleanConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            string? parameterString = parameter as string;
            if (parameterString == null) {
                return DependencyProperty.UnsetValue;
            }

            if (Enum.IsDefined(value.GetType(), value) == false) {
                return DependencyProperty.UnsetValue;
            }

            object paramValue = Enum.Parse(value.GetType(), parameterString);

            if (paramValue.Equals(value)) {
                return true;
            } else {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(bool)value) {
                // true の場合以外は値が不定
                return DependencyProperty.UnsetValue;
            }
            string? parameterString = parameter as string;
            if (parameterString == null) {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, parameterString);
        }
    }

    public class NegEnumBooleanConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string? parameterString = parameter as string;
            if (parameterString == null) {
                return DependencyProperty.UnsetValue;
            }

            if (Enum.IsDefined(value.GetType(), value) == false) {
                return DependencyProperty.UnsetValue;
            }

            object paramValue = Enum.Parse(value.GetType(), parameterString);

            if (paramValue.Equals(value)) {
                return false;
            } else {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((bool)value) {
                // falseの場合以外は値が不定
                return DependencyProperty.UnsetValue;
            }
            string? parameterString = parameter as string;
            if (parameterString == null) {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, parameterString);
        }
    }


    public class EnumVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            string? parameterString = parameter as string;
            if (parameterString == null) {
                return DependencyProperty.UnsetValue;
            }

            if (Enum.IsDefined(value.GetType(), value) == false) {
                return DependencyProperty.UnsetValue;
            }

            object paramValue = Enum.Parse(value.GetType(), parameterString);

            if (paramValue.Equals(value)) {
                return Visibility.Visible;
            } else {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }

    public class NegEnumVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            string? parameterString = parameter as string;
            if (parameterString == null) {
                return DependencyProperty.UnsetValue;
            }

            if (Enum.IsDefined(value.GetType(), value) == false) {
                return DependencyProperty.UnsetValue;
            }

            object paramValue = Enum.Parse(value.GetType(), parameterString);

            if (paramValue.Equals(value)) {
                return Visibility.Collapsed;
            } else {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }

    public class DateStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is DateTime dateTime) {
                if (!DateTime.MinValue.Equals(value)) {
                    return dateTime.ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss");
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    public class DecimalStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return $"{value:#,0}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    public class EmptyStringToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (string.IsNullOrEmpty(value as string)) {
                return Visibility.Visible;
            } else {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    //public class AspectStringConverter : IValueConverter {
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    //        switch (System.Convert.ToInt32(value)) {
    //            case (int)WfAspect.CUSTOM125:
    //                return "5:4";
    //            case (int)WfAspect.CUSTOM133:
    //                return "4:3";
    //            case (int)WfAspect.CUSTOM150:
    //                return "3:2";
    //            case (int)WfAspect.CUSTOM177:
    //                return "16:9";
    //            default:
    //                return "";
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    //        throw new NotImplementedException();
    //    }
    //}
}
