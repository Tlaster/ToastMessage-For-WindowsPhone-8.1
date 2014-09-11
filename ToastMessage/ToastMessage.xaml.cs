using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace ToastMessage
{
    public sealed partial class ToastMessage : UserControl
    {
        /// <summary>
        /// When ToastMessage complete its show
        /// </summary>
        public event EventHandler<Object> Completed;

        /// <summary>
        /// Create a new ToastMessage
        /// </summary>
        /// <param name="title">Toast content</param>
        public ToastMessage(string content)
        {
            this.InitializeComponent();
            this.innerText.Text = content;
            this.border.Width = (Window.Current.Content as Frame).ActualWidth;
        }



        /// <summary>
        /// Show the ToastMessage
        /// </summary>
        public void Show()
        {
            popup.IsOpen = true;
            this.SlideAnimation.Begin();
        }

        private void SlideAnimation_Completed(object sender, object e)
        {
            popup.IsOpen = false;
            if (this.Completed!=null)
            {
                this.Completed(sender, e);
            }
        }
    }
}
