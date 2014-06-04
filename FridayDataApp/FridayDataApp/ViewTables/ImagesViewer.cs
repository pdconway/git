using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridayDataApp.ViewTables
{
    //customers   ViewModel
    class ImagesViewer : ViewTableBase
    {
        #region Properties

        private int ID = 0;
        public int Id
        {
            get
            { return ID; }
            set
            {
                if (ID == value) return;
                ID = value;
                //LOOK HERE! ----- RaisePropertyChanged("Id");
            }
        }
        private string imagePath = "";
        public string ImagePath
        {
            get
            { return imagePath; }
            set
            {
                if (imagePath == value) return;
                imagePath = value;
                //LOOK HERE! -------- RaisePropertyChanged("ImagePath");
            }
        }
        private string imageName = "";
        public string ImageName
        {
            get
            { return imageName; }
            set
            {
                if (imageName == value) return;
                imageName = value;
                //LOOK HERE! -------- RaisePropertyChanged("ImageName");
            }
        }
        private string imageDate = "";
        public string ImageDate
        {
            get
            { return imageDate; }
            set
            {
                if (imageDate == value) return;
                imagePath = value;
                //LOOK HERE! -------- RaisePropertyChanged("ImagePath");
            }
        }
        private byte[] binaryLargeImage;
        public byte[] BinaryLargeImage
        {
            get
            { return binaryLargeImage; }
            set
            {
                if (binaryLargeImage == value) return;
                binaryLargeImage = value;
                //LOOK HERE! -------- RaisePropertyChanged("ImagePath");
            }
        }



        #endregion

    }
}

