using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attributes.Card;
using Attributes.Classes;

namespace Data.Classes
{
    public class Services
    {
        //instantiates the data which is static throughout the projects
        private Models model = new Models();
        //returns the data that we are to work with for this project
        public Models RetrieveData()
        {
            return this.model;
        }


        public void setTripCardDataArr(List<TripCard> newTripCard)
        {
            this.model.setTripCardList(newTripCard);
        }
        public void setTripCardDataDic(Dictionary<TripCard, Asset> newTripCard)
        {
            this.model.setTripCardListAss(newTripCard);
        }
    }
}
