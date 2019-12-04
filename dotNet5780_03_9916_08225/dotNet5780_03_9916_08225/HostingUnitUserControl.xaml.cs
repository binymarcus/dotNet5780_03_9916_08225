using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5780_03_9916_08225
{
    /// <summary>
    /// Interaction logic for HostingUnitUserControl.xaml
    /// </summary>
    public partial class HostingUnitUserControl : UserControl
    {
       private Calendar MyCalendar;
       private int imageIndex;
       private Viewbox vbImage;
       private Image MyImage;
        private HostingUnit currentHostingUnit;
        /// <summary>
        /// basic gettr and setter
        /// </summary>
        public Calendar MyCalendar1 { get => MyCalendar; set => MyCalendar = value; }
        /// <summary>
        /// basic gettr and setter
        /// </summary>
        public int ImageIndex { get => imageIndex; set => imageIndex = value; }
        /// <summary>
        /// basic gettr and setter
        /// </summary>
        public Viewbox VbImage { get => vbImage; set => vbImage = value; }
        /// <summary>
        /// basic gettr and setter
        /// </summary>
        public Image MyImage1 { get => MyImage; set => MyImage = value; }\        /// <summary>
        /// basic gettr and setter
        /// </summary>
        public HostingUnit CurrentHostingUnit { get => currentHostingUnit; set => currentHostingUnit = value; }
        //getter fot eh unit
        public HostingUnit GetCurrentHostingUnit()
        {
            return CurrentHostingUnit;
        }
        /// <summary>
        /// sets the current hosting unit
        /// </summary>
        /// <param name="value"></param>
        public void SetCurrentHostingUnit(HostingUnit value)
        {
            CurrentHostingUnit = value;
        }
        /// <summary>
        /// cunstructor with a unit, also sets everything
        /// </summary>
        /// <param name="hostUnit"></param>
        public HostingUnitUserControl(HostingUnit hostUnit)
        {
            VbImage = new Viewbox();
            InitializeComponent();
            this.SetCurrentHostingUnit(hostUnit);
            UserControlGrid.DataContext = hostUnit;
            MyCalendar1 = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar1;
            SetBlackOutDates();
            ImageIndex = 0;
            VbImage.Width = 75;
            VbImage.Height = 75;
            VbImage.Stretch = Stretch.Fill;
            UserControlGrid.Children.Add(VbImage);
            Grid.SetColumn(VbImage, 2);
            Grid.SetRow(VbImage, 0);
            MyImage1 = CreateViewImage();
            VbImage.Child = null;
            VbImage.Child = MyImage1;
            VbImage.MouseUp += vbImage_MouseUp;
            VbImage.MouseEnter += vbImage_MouseEnter;
            VbImage.MouseLeave += vbImage_MouseLeave;

        }
        /// <summary>
        /// creates the image that we view
        /// </summary>
        /// <returns></returns>
        private Image CreateViewImage()
        {
            Image dynamicImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(GetCurrentHostingUnit().Uris[ImageIndex]);
            bitmap.EndInit();
            // Set Image.Source
            dynamicImage.Source = bitmap;
            // Add Image to Window
            return dynamicImage;
        }
        /// <summary>
        /// decides what happens when the mouse leaves the picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            VbImage.Width = 85;
            VbImage.Height = 85;
        }
        /// <summary>
        /// sets the function that happens when the mosue enters the oicture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            VbImage.Width = this.Width / 3;
            VbImage.Height = this.Height;
        }
        /// <summary>
        /// sets the mouse up button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VbImage.Child = null;
            ImageIndex =
           (ImageIndex + GetCurrentHostingUnit().Uris.Count - 1) % GetCurrentHostingUnit().Uris.Count;
            MyImage1 = CreateViewImage();
            VbImage.Child = MyImage1;
        }
        /// <summary>
        /// creates the calender for the screen
        /// </summary>
        /// <returns></returns>
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();
            MonthlyCalendar.Name = "MonthlyCalendar";
            MonthlyCalendar.DisplayMode = CalendarMode.Month;
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }
        /// <summary>
        /// sets the dates whwne a client chooses
        /// </summary>
        private void SetBlackOutDates()
        {
            foreach (DateTime date in GetCurrentHostingUnit().AllOrders)
            {
                MyCalendar1.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public HostingUnitUserControl()
        {

            InitializeComponent();
        }

        /// <summary>
        /// sets the click button on mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalendar1.SelectedDates.ToList();
            MyCalendar1 = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar1;
            addCurrentList(myList);
            SetBlackOutDates();
        }
        /// <summary>
        /// adds a host to the list or an order
        /// </summary>
        /// <param name="tList"></param>
        private void addCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                GetCurrentHostingUnit().AllOrders.Add(d);
            }
        }
        /// <summary>
        /// controls the text change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUnitName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// function to check the botton of the swimming pool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsSwimigPool_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
