using FridayDataApp.Tables.TableImages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FridayDataApp.ViewTables
{
    //customer     ViewModel
    class ViewImage : ViewTableBase
    {
        private FridayDataApp.App app = (Application.Current as App);
        private ObservableCollection<ImagesViewer> img;
        public ObservableCollection<ImagesViewer> Img
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
                //RaisePropertyChanged("Customers");
            }
        }
        //FINISHED WITH DECLARING CLASS VARIABLES AND WHATEVER Img IS >>> NOT VAR AND NOT FUNC/METH


        public ObservableCollection<ImagesViewer> GetImages()
        {
            img = new ObservableCollection<ImagesViewer>();
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                ///THE COMMAND: db.Table<Tables.TableImage> is the same as sql command SELECT * FROM TableImages
                ///then ORDER BY imageName
                var query = db.Table<Tables.TableImages>().OrderBy(c => c.imageName);
                foreach (var im in query)
                {
                    var imger = new ImagesViewer(){
                     ID = im.ID,
                     imagePath = im.imagePath,
                     imageName = im.imageName,
                     imageDate = im.imageDate,
                     binaryLargeImage = im.binaryLargeImage,
                    };
                    img.Add(imger);
                }
            }
            return img;
        }







    }






}
