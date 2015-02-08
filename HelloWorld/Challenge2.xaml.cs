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
    public sealed partial class Challenge2 : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        int count2 = 0;
        int recent = 0;
        int choice = 0;
        int penalty = 0;
        Stopwatch stopWatch = new Stopwatch();

        //This is where the logic questions and answers reside
        string logic1 = "Tim has five bears. His brother Peter has seven of them. How many do they have together?";
        int ans1 = 12;

        string logic2 = "You had eight dolls, but you lost three of them. How many do you have now?";
        int ans2 = 5;

        string logic3 = "It takes your friend ten minutes to get to your house. How long would a roundtrip take him?";
        int ans3 = 20;

        string logic4 = "There are sixteen girls and ten boys in a class. How many more girls than boys are there?";
        int ans4 = 6;

        string logic5 = "Peter weighs 200 lbs, Tim weighs 192 lbs, and John weighs 174 lbs. How much more does Peter weigh" +
                        " than John?";
        int ans5 = 26;

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


        public Challenge2()
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
                choice = rnd.Next(1, 6);

                if(choice == 1)
                {
                    Problem.Text = logic1;
                    recent = 1;
                }


                else if (choice == 2)
                {
                    Problem.Text = logic2;
                    recent = 2;
                }

                else if (choice == 3)
                {
                    Problem.Text = logic3;
                    recent = 3;
                }

                else if (choice == 4)
                {
                    Problem.Text = logic4;
                    recent = 4;
                }

                else
                {
                    Problem.Text = logic5;
                    recent = 5;
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

                if(checkProblem()!=0)
                {
                    penalty += 100;
                }

            while(count2 < 2)
            {
                count2++;
                generateProblem();
            }

            if(count2 == 2)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                int milliseconds = ts.Milliseconds;

                if(penalty!=0)
                {
                    milliseconds += penalty;
                }
                if (this.Frame != null)
                {
                    this.Frame.Navigate(typeof(Challenge2Complete));
                }
            }
        }

        public int checkProblem()
        {
            int answer1 = 0;

            if(recent == 1)
            {
                answer1 = ans1;
            }

            else if (recent == 2)
            {
                answer1 = ans2;
            }

            else if (recent == 3)
            {
                answer1 = ans3;
            }

            else if (recent == 4)
            {
                answer1 = ans4;
            }

            else
            {
                answer1 = ans5;
            }

            if(answer.Text.CompareTo(answer.ToString()) == 0)
            {
                answer.Text = "";
                return -1;
            }

            else
            {
                answer.Text = "";
                return 0;
            }
        }
    }
}
