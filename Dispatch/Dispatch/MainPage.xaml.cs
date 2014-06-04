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
using Attributes.CardAttributes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dispatch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadInformation();
        }

        public void LoadInformation()
        {
            MyAction act = new MyAction();
            Dictionary<MyAction.action, bool> dict = act.getEnumDict();

            this.one.Text = Convert.ToString(dict[MyAction.action.arrive]);
            act.setActionStatus(MyAction.action.arrive, true);
            this.two.Text = Convert.ToString(dict[MyAction.action.arrive]);
        }

    }
}
