using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Models.CardAttributes;
using Models.Classes;
using Models.UserStuff;
using Dispatch.Transfer;
using Models.Sections;
using Models.Card;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using Windows.UI;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dispatch.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActivityCardsPage : Page
    {
        private TripCard myTripCard;
        private Asset selectedAsset;
        private Worker selectedWorker;
        private Activity activity;
        //private CardAction action;
        //private Demand demand;
        //MAKE NEW TRIP CARDS BELONG TO THIS CLASS NOT TO INSTANCES OF THIS CLASS
        private static TripCard newTripCard;
        private static Mapper<string, ObservableCollection<TripCard>> newMapper;
        private static string holdSelectedList;
 

        //////////////////////////////////////////////////////////////ON PAGE OPEN////////////////////////////////////////////////////////
        public ActivityCardsPage()
        {
            this.InitializeComponent();
            this.LoadInformation();
            //this prevents the data from being instantiated every single time you load the page
            if (DataTransfer.isFirstTimeEntered == 0)
                DataTransfer.useSampleDataWithNewDataStructure();
                //DataTransfer.useMoreSampleData();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {        
            base.OnNavigatedTo(e);
            DataTransfer.isFirstTimeEntered++;
            //DataTransfer.clearData();
        }


        public void LoadInformation()
        {
            this.name.Text = UserData.currentUser.getName();
            if (DataTransfer.existsNewData)
            {
                foreach (Mapper<string, ObservableCollection<TripCard>> item in DataTransfer.ListOfGridViewsContainingCards)
                {
                    if (holdSelectedList == item.key)
                    {
                        item.value.Add(newTripCard);
                        //remember item is a mapper and that value is actually a list of tripcards. 
                    }
                }
                DataTransfer.TripCardList.Add(newTripCard);
                DataTransfer.existsNewData = false;
            }

            if (DataTransfer.existsNewListData)
            {
                DataTransfer.ListOfGridViewsContainingCards.Add(newMapper);
                DataTransfer.existsNewListData = false;
            }
        }
        //////////////////////////////////////////////////////////////ON PAGE OPEN////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////MAKE NEW LIST TO JOIN VIEW/////////////////////////////////////////////
        private void addNewList(object sender, RoutedEventArgs e)
        {
            ObservableCollection<TripCard> newList = new ObservableCollection<TripCard>();
            newMapper = new Mapper<string, ObservableCollection<TripCard>>(this.newListName.Text, newList);
            DataTransfer.existsNewListData = true;
            Frame.Navigate(typeof(ActivityCardsPage));
        }
        ///////////////////////////////////////////////////////MAKE NEW LIST TO JOIN VIEW/////////////////////////////////////////////


        ////////////////////////////////////////////////////////PAGE NAVIGATION///////////////////////////////////////////////////////
        private void logout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }
        private void goHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void GoBackPage(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
        ////////////////////////////////////////////////////////PAGE NAVIGATION///////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////CHOOSE LIST POPUP/////////////////////////////////////////////////////////////
        private void openPopUp(object sender, RoutedEventArgs e)
        {
            this.chooseListPopup.IsOpen = true;
        }
        async private void selectList(object sender, RoutedEventArgs e)
        {
            if (this.chooseListListview.SelectedItem != null)
            {
                Mapper<string, ObservableCollection<TripCard>> temp = (Mapper<string, ObservableCollection<TripCard>>)this.chooseListListview.SelectedItem;
                holdSelectedList = temp.key;
                this.chooseListPopup.IsOpen = false;
                this.newCard.IsOpen = true;
            }
            else
            {
                MessageDialog wrong = new MessageDialog("Please Select List");
                await wrong.ShowAsync();
            }
        }
        private void closeChoiceListPopup(object sender, RoutedEventArgs e)
        {
            this.chooseListPopup.IsOpen = false;
        }
        ///////////////////////////////////////////////////////CHOOSE LIST POPUP/////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////NEW CARD POPUP////////////////////////////////////////////////////////
        private void close(object sender, RoutedEventArgs e)
        {
            this.newCard.IsOpen = false;
            this.selectedAsset = null;
            this.selectedWorker = null;
        }
        //this is where we take the information from the card and try to instantiate a new TripCard
        async private void tryMakeNewCard(object sender, RoutedEventArgs e)
        {
            if ((this.selectedAsset != null) && (this.selectedWorker != null))
            {
                this.activity = new Activity(this.selectedAsset, this.selectedWorker);
                newTripCard = new TripCard(this.activity);
                DataTransfer.existsNewData = true;
                Frame.Navigate(typeof(ActivityCardsPage));
            }
            else
            {
                MessageDialog bad = new MessageDialog("Incomplete Form");
                await bad.ShowAsync();
            }
        }
        //////////////////////////////////////////////////////NEW CARD POPUP////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////WORKER POPUP///////////////////////////////////////////////////////////////
        private void openWorkerPopUp(object sender, TappedRoutedEventArgs e)
        {
            this.workerPopup.IsOpen = true;
        }
        private void selectWorker(object sender, RoutedEventArgs e)
        {
            if (this.workerListBox.SelectedItem != null)
            {
                this.selectedWorker = (Worker)this.workerListBox.SelectedItem;
                this.workerID.Text = Convert.ToString(this.selectedWorker.getID());
                this.workerPopup.IsOpen = false;
            }

        }
        private void closeWorkerPopup(object sender, RoutedEventArgs e)
        {
            this.workerPopup.IsOpen = false;
        }
        //////////////////////////////////////////////////////////////////WORKER POPUP///////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////ASSET POPUP//////////////////////////////////////////////////////////
        private void openAssetsPopUp(object sender, TappedRoutedEventArgs e)
        {
            this.assetPopup.IsOpen = true;
        }
        private void selectAsset(object sender, RoutedEventArgs e)
        {
            if (this.assetListBox.SelectedItem != null)
            {
                this.selectedAsset = (Asset)this.assetListBox.SelectedItem;
                this.assetID.Text = Convert.ToString(this.selectedAsset.getID());
                this.assetPopup.IsOpen = false;
            }

        }
        private void closeAssetPopup(object sender, RoutedEventArgs e)
        {
            this.assetPopup.IsOpen = false;
        }
        /////////////////////////////////////////////////////////////////ASSET POPUP//////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////*CARD ASSET POPUP////////////////////////////////////////////////////////////
        private void openCardAssetsPopUp(object sender, TappedRoutedEventArgs e)
        {
            this.cardAssetPopup.IsOpen = true;
        }
        private void cardSelectAsset(object sender, RoutedEventArgs e)
        {
            if (this.cardAssetListBox.SelectedItem != null)
            {
                this.selectedAsset = (Asset)this.cardAssetListBox.SelectedItem;
                this.cardAssetID.Text = Convert.ToString(this.selectedAsset.getID());
                this.cardAssetPopup.IsOpen = false;
            }
        }
        private void cardCloseAssetPopup(object sender, RoutedEventArgs e)
        {
            this.cardAssetPopup.IsOpen = false;
        }
        ////////////////////////////////////////////////////////*CARD ASSET POPUP////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////*CARD WORKER POPUP////////////////////////////////////////////////////////////
        private void openCardWorkerPopUp(object sender, TappedRoutedEventArgs e)
        {
            this.cardWorkerPopup.IsOpen = true;
        }
        private void cardSelectWorker(object sender, RoutedEventArgs e)
        {
            if (this.cardWorkerListBox.SelectedItem != null)
            {
                this.selectedWorker = (Worker)this.cardWorkerListBox.SelectedItem;
                this.cardWorkerID.Text = Convert.ToString(this.selectedWorker.getID());
                this.cardWorkerPopup.IsOpen = false;
            }
        }
        private void cardCloseWorkerPopup(object sender, RoutedEventArgs e)
        {
            this.cardWorkerPopup.IsOpen = false;
        }
        ////////////////////////////////////////////////////////*CARD WORKER POPUP////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////CARD INFORMATION////////////////////////////////////////////////////////////
        private void pullUpCardInformationPopup(object sender, DoubleTappedRoutedEventArgs e)
        {
            Grid myGrid = (Grid)sender;
            this.myTripCard = (TripCard)myGrid.DataContext;
            try
            {
                this.cardAssetID.Text = Convert.ToString(myTripCard.getActivity().getAsset().getID());
                this.cardWorkerID.Text = Convert.ToString(myTripCard.getActivity().getWorker().getID());
            }
            catch
            {
                this.cardAssetID.Text = "";
                this.cardWorkerID.Text = "";
            }
            this.cardInformationPopup.IsOpen = true;
        }
        private void pullUpCardInformationPopup(object sender, RightTappedRoutedEventArgs e)
        {
            Grid myGrid = (Grid)sender;
            this.myTripCard = (TripCard)myGrid.DataContext;
            try
            {
                this.cardAssetID.Text = Convert.ToString(myTripCard.getActivity().getAsset().getID());
                this.cardWorkerID.Text = Convert.ToString(myTripCard.getActivity().getWorker().getID());
            }
            catch
            {
                this.cardAssetID.Text = "";
                this.cardWorkerID.Text = "";
            }
            this.cardInformationPopup.IsOpen = true;
        }
        async private void tryChangeCard(object sender, RoutedEventArgs e)
        {
            if ((this.cardAssetID.Text != "") && (this.cardWorkerID.Text != ""))
            {
                if ((this.selectedWorker != null) && (this.selectedAsset != null))
                {
                    this.myTripCard.setActivity(new Activity(this.selectedAsset, this.selectedWorker));
                    Frame.Navigate(typeof(ActivityCardsPage));
                    return;
                }
                else
                {
                    if (this.selectedAsset != null)
                    {
                        this.myTripCard.getActivity().setAsset(this.selectedAsset);
                        Frame.Navigate(typeof(ActivityCardsPage));
                        return;
                    }
                    if (this.selectedWorker != null)
                    {
                        this.myTripCard.getActivity().setWorker(this.selectedWorker);
                        Frame.Navigate(typeof(ActivityCardsPage));
                        return;
                    }
                    Frame.Navigate(typeof(ActivityCardsPage));
                    return;
                }
            }
            else
            {
                
                MessageDialog bad = new MessageDialog("Incomplete Form");
                await bad.ShowAsync();
            }
        }
        private void closeCardView(object sender, RoutedEventArgs e)
        {
            this.cardInformationPopup.IsOpen = false;
            this.selectedWorker = null;
            this.selectedAsset = null; 
        }
        /////////////////////////////////////////////////////////CARD INFORMATION////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////TOOL BAR LIST VIEW///////////////////////////////////////////////////////////
        private void switchToAssets(object sender, TappedRoutedEventArgs e)
        {
            this.assetTextBlock.Foreground = new SolidColorBrush(Colors.DarkOrange);
            this.workerTextBlock.Foreground = new SolidColorBrush(Colors.White);
            this.demandTextBlock.Foreground = new SolidColorBrush(Colors.White);
            Binding sourceBinding = new Binding();
            sourceBinding.Path = new PropertyPath("AssetList");
            BindingOperations.SetBinding(this.toolBar, ListView.ItemsSourceProperty, sourceBinding);
        }
        private void switchToWorkers(object sender, TappedRoutedEventArgs e)
        {
            this.workerTextBlock.Foreground = new SolidColorBrush(Colors.DarkOrange);
            this.assetTextBlock.Foreground = new SolidColorBrush(Colors.White);
            this.demandTextBlock.Foreground = new SolidColorBrush(Colors.White);
            Binding sourceBinding = new Binding();
            sourceBinding.Path = new PropertyPath("WorkerList");
            BindingOperations.SetBinding(this.toolBar, ListView.ItemsSourceProperty, sourceBinding);
        }
        private void switchToDemands(object sender, TappedRoutedEventArgs e)
        {
            this.demandTextBlock.Foreground = new SolidColorBrush(Colors.DarkOrange);
            this.workerTextBlock.Foreground = new SolidColorBrush(Colors.White);
            this.assetTextBlock.Foreground = new SolidColorBrush(Colors.White);
        }
        ////////////////////////////////////////////////////////TOOL BAR LIST VIEW///////////////////////////////////////////////////////////









        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }





        

  
        



        /*
        async private void pullUpCardInformationPopup(object sender, DoubleTappedRoutedEventArgs e)
        {
            
            GridView myGridView = 
            if (myGridView != null)
            {
                TripCard tempTrip = (TripCard)myGridView.SelectedItem;
                this.cardAssetID.Text = Convert.ToString(tempTrip.getActivity().getAsset().getID());
                this.cardWorkerID.Text = Convert.ToString(tempTrip.getActivity().getWorker().getID());
                this.cardInformationPopup.IsOpen = true;
            }
            else
            {
                MessageDialog bad = new MessageDialog("Information Cannot Be Pulled Up");
                await bad.ShowAsync();
            }
             
            
        }
        */

        /*
        async private void pullUpCardInformationPopup(object sender, DoubleTappedRoutedEventArgs e)
        {
            TripCard tempTrip;
            Grid temp = (Grid)sender;
            TextBox tb = new TextBox();
            for (int i = 0; i < temp.Children.Count; i++)
            {
                UIElement child = temp.Children[i];
                if (child.GetType() == tb.GetType())
                {
                    tb = (TextBox)child;
                }
            }
            int cardnumber;
            bool result = Int32.TryParse(tb.Text, out cardnumber);
            if (result)
            {
                
            }
            else
            {
                MessageDialog bad = new MessageDialog("Information Cannot Be Pulled Up");
                await bad.ShowAsync();
            }
           // this.cardAssetID.Text = Convert.ToString(tempTrip.getActivity().getAsset().getID());
           // this.cardWorkerID.Text = Convert.ToString(tempTrip.getActivity().getWorker().getID());
            this.cardInformationPopup.IsOpen = true;
        }
         */




    }
}


/*

 * 
 * 
 * 
*/