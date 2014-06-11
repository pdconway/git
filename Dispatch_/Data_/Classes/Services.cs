using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Card;
using Models.Classes;
using Models.Sections;
using System.Collections.ObjectModel;

namespace Data_.Classes
{
    public class Services
    {
        //instantiates the data which is static throughout the projects
        private Model model = new Model();
        //returns the data that we are to work with for this project
        public Model RetrieveData()
        {
            return this.model;
        }


        public void setTripCardDataArr(ObservableCollection<TripCard> newTripCard)
        {
            this.model.setTripCardList(newTripCard);
        }
        /*
        public void setTripCardDataDic(Dictionary<TripCard, Asset> newTripCard)
        {
            this.model.setTripCardListAss(newTripCard);
        }
         * */
    }
}
