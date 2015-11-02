using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageShower.Models;

namespace ImageShower
{
    class ImageCollection
    {
        private List<ImageModel> _images;
        private static ImageCollection _theShower;

        public List<ImageModel> Images
        {
            get { return _images; }
            set { _images = value; }
        }

        public static ImageCollection TheShower
        {
            get
            {
                if (_theShower == null)
                {
                    _theShower = new ImageCollection();
                }
                return _theShower;
            }
        }

        //Private so that it cannot be instanciated. Only access it through GetInstance()
        private ImageCollection()
        {
            
        }

        public ImageCollection GetInstance()
        {
            return TheShower;
        }
    }
}
