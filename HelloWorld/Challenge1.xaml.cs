using HelloWorld.Common;
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
using System.Diagnostics;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace HelloWorld
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Challenge1 : Page
    {
        int count = 0;
        Stopwatch stopWatch = new Stopwatch();
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        



        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public Challenge1()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            generateProblem();
            stopWatch.Start();
            
        }

        public void generateProblem()
        {
            Random rnd = new Random();
            Number1.Text = rnd.Next(0, 12).ToString();
            Number2.Text = rnd.Next(0, 12).ToString();
            int operatorChoice = rnd.Next(0, 2);

            if (operatorChoice.Equals(0))
            {
                Operator.Text = "+";
            }
            else
            {
                Operator.Text = "-";
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            checkProblem();
            count++;
            if(count < 5)
            {
                generateProblem();
            }

            if(count == 5)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                int milliseconds = ts.Milliseconds;
                Debug.WriteLine(milliseconds);
                Global.list.Add(milliseconds);
                if (this.Frame != null)
                {
                    this.Frame.Navigate(typeof(ChallengeComplete));
                }
            }


        }

        public int checkProblem()
        {
            Debug.WriteLine("Sound off.");
            int number1 = int.Parse(Number1.Text);
            int number2 = int.Parse(Number2.Text);
            Debug.WriteLine(number1 + " " + number2);
            string op = Operator.Text;
            int solution = 0;

            if (op.CompareTo("+") == 0)
            {
                solution = number1 + number2;
            }

            else
            {
                solution = number1 - number2;
            }


            if (answer.Text.CompareTo(solution.ToString()) == 0)
            {
                answer.Text = "";
                return 0;
            }

            else
            {
                answer.Text = "";
                return 1;
            }
        }
    }
}
