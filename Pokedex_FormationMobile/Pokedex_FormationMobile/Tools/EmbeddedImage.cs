using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex_FormationMobile.Tools
{
    class EmbeddedImage : IMarkupExtension
    {
        public string Ressourse { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return ImageSource.FromResource(Ressourse);
        }
    }
}
