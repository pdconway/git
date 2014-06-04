using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Card;
using Models.Classes;
using Data_.Classes;
using Models.Sections;

namespace Dispatch.Classes
{
    public class DataTransfer
    {
        private string name = "";
        private List<Asset> assetList;
        private List<Worker> workerList;
        private List<TripCard> tripCardList;
        private Services services = new Services();

        public DataTransfer()
        {
            Model model = services.RetrieveData();
            this.assetList = model.getAssetList();
            this.workerList = model.getWorkerList();
            this.tripCardList = model.getCardList();
        }
        public DataTransfer(string na)
        {
            this.name = na;
            Model model = services.RetrieveData();
            this.assetList = model.getAssetList();
            this.workerList = model.getWorkerList();
            this.tripCardList = model.getCardList();
        }

    }
}
