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
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace HelloWorld
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Challenge3 : Page
    {
        Stopwatch stopWatch = new Stopwatch();
        int count = 0;
        int question = 0;
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


        public Challenge3()
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
            stopWatch.Start();
            generateQuestion();
          
        }

        public void generateQuestion()
        {
            Debug.WriteLine("count: " + count);
            if(count == 3)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                int milliseconds = ts.Milliseconds;
                Global.list.Add(milliseconds);
                Debug.WriteLine("Challenge 3 Time: " + milliseconds);
                if (this.Frame != null)
                {
                    this.Frame.Navigate(typeof(Challenge3Complete));
                }
            }
           
            if (count == 0)
            {
                Question.Text = "Double click the hottest item.";
                question++;
            }

            if (count == 1)
            {
                Question.Text = "Double click Man's Best Friend.";
                question++;
            }

            if (count == 2)
            {
                Question.Text = "Double click the animal with 9 lives.";
                question++;
            }

            Debug.WriteLine("Question: " + question);
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

        private void AnswerFireButton_Click(object sender, DoubleTappedRoutedEventArgs e)
        {
            checkFireAnswer();
            count++;
            generateQuestion();
        }

        public int checkFireAnswer()
        {
            if (Question.Text.CompareTo("Double click the hottest item.") == 0)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }

        private void AnswerDogButton_Click(object sender, DoubleTappedRoutedEventArgs e)
        {
            checkDogAnswer();
            count++;
            generateQuestion();
        }

        public int checkDogAnswer()
        {
            if(Question.Text.CompareTo("Double click Man's Best Friend.") == 0)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }

        private void AnswerCatButton_Click(object sender, DoubleTappedRoutedEventArgs e)
        {
            checkCatAnswer();
            count++;
            generateQuestion();
        }

        public int checkCatAnswer()
        {
            if(Question.Text.CompareTo("Double click the animal with 9 lives.") == 0)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }


    }
}
