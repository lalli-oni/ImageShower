using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ImageShower.Models
{
    class ImageModel
    {
        private ImageSource _image;
        private DateTime _datePosted;
        private bool _isPosted;

        public ImageSource Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public DateTime DatePosted
        {
            get { return _datePosted; }
            private set { _datePosted = value; }
        }

        public bool IsPosted
        {
            get { return _isPosted; }
            set
            {
                if (value == true)
                {
                    DatePosted = DateTime.UtcNow;
                }
                _isPosted = value;
            }
        }
    }
}
