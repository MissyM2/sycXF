using System;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sycXF.Extensions
{
    [ContentProperty("Source")]
    class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public ImageSource ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            string assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
            return ImageSource.FromResource(assemblyName + "." + Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);

        }

    }

}
