using System;
using System.Globalization;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Converters
{
	public class WebNavigatedEventArgsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var eventArgs = value as WebNavigatedEventArgs;
			if (eventArgs == null)
				throw new ArgumentException("Expected WebNavigatedEventArgs as value", "value");

			return eventArgs.Url;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
