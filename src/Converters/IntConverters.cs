﻿using System;
using System.Globalization;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace SourceGit.Converters
{
    public static class IntConverters
    {
        public static readonly FuncValueConverter<int, bool> IsGreaterThanZero =
            new FuncValueConverter<int, bool>(v => v > 0);

        public static readonly FuncValueConverter<int, bool> IsGreaterThanFour =
            new FuncValueConverter<int, bool>(v => v > 4);

        public static readonly FuncValueConverter<int, bool> IsZero =
            new FuncValueConverter<int, bool>(v => v == 0);

        public static readonly FuncValueConverter<int, bool> IsOne =
            new FuncValueConverter<int, bool>(v => v == 1);

        public static readonly FuncValueConverter<int, bool> IsNotOne =
            new FuncValueConverter<int, bool>(v => v != 1);

        public static readonly FuncValueConverter<int, bool> IsSubjectLengthBad =
            new FuncValueConverter<int, bool>(v => v > ViewModels.Preference.Instance.SubjectGuideLength);

        public static readonly FuncValueConverter<int, bool> IsSubjectLengthGood =
            new FuncValueConverter<int, bool>(v => v <= ViewModels.Preference.Instance.SubjectGuideLength);

        public static readonly FuncValueConverter<int, Thickness> ToTreeMargin =
            new FuncValueConverter<int, Thickness>(v => new Thickness(v * 16, 0, 0, 0));

        public static readonly FuncValueConverter<int, IBrush> ToBookmarkBrush =
            new FuncValueConverter<int, IBrush>(bookmark =>
            {
                if (bookmark == 0)
                    return Application.Current?.FindResource("Brush.FG1") as IBrush;
                else
                    return Models.Bookmarks.Brushes[bookmark];
            });

        public class ToColorHexStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Color.FromUInt32((uint)value).ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    var color = Color.Parse(value as string);
                    return color.ToUInt32();
                }
                catch
                {
                    return BindingOperations.DoNothing;
                }
            }
        }

        public static readonly ToColorHexStringConverter ToColorHexString = new ToColorHexStringConverter();
    }
}
