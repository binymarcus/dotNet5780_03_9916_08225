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

        public Calendar MyCalendar1 { get => MyCalendar; set => MyCalendar = value; }
        public int ImageIndex { get => imageIndex; set => imageIndex = value; }
        public Viewbox VbImage { get => vbImage; set => vbImage = value; }
        public Image MyImage1 { get => MyImage; set => MyImage = value; }
        public HostingUnit CurrentHostingUnit { get => currentHostingUnit; set => currentHostingUnit = value; }

        public HostingUnit GetCurrentHostingUnit()
        {
            return CurrentHostingUnit;
        }

        public void SetCurrentHostingUnit(HostingUnit value)
        {
            CurrentHostingUnit = value;
        }

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
        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            VbImage.Width = 85;
            VbImage.Height = 85;
        }
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            VbImage.Width = this.Width / 3;
            VbImage.Height = this.Height;
        }
        private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VbImage.Child = null;
            ImageIndex =
           (ImageIndex + GetCurrentHostingUnit().Uris.Count - 1) % GetCurrentHostingUnit().Uris.Count;
            MyImage1 = CreateViewImage();
            VbImage.Child = MyImage1;
        }
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();
            MonthlyCalendar.Name = "MonthlyCalendar";
            MonthlyCalendar.DisplayMode = CalendarMode.Month;
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }
        private void SetBlackOutDates()
        {
            foreach (DateTime date in GetCurrentHostingUnit().AllOrders)
            {
                MyCalendar1.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }


        public HostingUnitUserControl()
        {

            InitializeComponent();
        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalendar1.SelectedDates.ToList();
            MyCalendar1 = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar1;
            addCurrentList(myList);
            SetBlackOutDates();
        }
        private void addCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                GetCurrentHostingUnit().AllOrders.Add(d);
            }
        }

        private void tbUnitName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IsSwimigPool_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
