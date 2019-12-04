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
/*binyamin marcus 212329916 moshe zuckerbrat */
namespace dotNet5780_03_9916_08225
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Host currentHost;// variable for use of our current host. only used in this class
        List<Host> hostsList = new List<Host>()// list of hosts to be projected on main window
        {
                new Host()
                {
                            HostName = "beachHouse",// arbitrary name
                            Units = new List<HostingUnit>()
                                {
                                   new HostingUnit()
                                   {
                                      UnitName="surf's up duuude!",
                                      Rooms=2,
                                      IsSwimmingPool=true,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://baliretreats-a1ca.kxcdn.com/wp-content/uploads/2017/06/beachhouse-slide1.jpg",
                                "https://cwimages.imgix.net/resorts/C-Scape.jpg" }//th picturs for the main window
                                   },
                        new HostingUnit()
                        {
                            UnitName="white sands resort",
                            Rooms=2,
                            IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://www.places.co.za/crs/photolarge/67169.jpg" ,
                            "https://cdn.architecturendesign.net/wp-content/uploads/2014/08/Beach-House-05-1.jpg"}// the pictrues

                        }
                    }

                },
                new Host() {
                            HostName = "hotels",
                            Units = new List<HostingUnit>()
                                {
                                   new HostingUnit()
                                   {
                                      UnitName="the Plaza",
                                      Rooms=2,
                                      IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://cdn.architecturendesign.net/wp-content/uploads/2014/08/Beach-House-17-0.jpg",
                            "http://undisclosable.co/wp-content/uploads/2017/03/soho_malibu_014_copy@2x.jpg"}//the pictures
                        },
                        new HostingUnit()
                        {
                            UnitName="king david",
                            Rooms=3,
                            IsSwimmingPool=true,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "http://www.malibubeachsoberliving.org/wp-content/uploads/2016/12/BeachHouseMalibuPoolDeck.jpg",
                            "http://www.beachhousesofbyron.com.au/wp-content/uploads/2015/07/instagram-21-1024x1024.jpg"}// the pictures

                        }
                    }

                },
                new Host() {
                            HostName = "B&B",
                            Units = new List<HostingUnit>()
                                {
                                   new HostingUnit()
                                   {
                                      UnitName="Rome",
                                    Rooms=1,
                                      IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://pictures.escapia.com/BEREVR/55309/8757850960.jpg",
                            "https://www.twiddy.com/rns/unitimages.twd/j10837-rearext.jpg"}

                        },
                        new HostingUnit()
                        {
                            UnitName="Tel-Aviv",
                            Rooms=3,
                            IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://www.australiantraveller.com/wp-content/uploads/2012/10/Abalone-Beach-house-gallery-4.jpg",
                            "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/La_casa_desde_la_playa.JPG/1200px-La_casa_desde_la_playa.JPG"}
                        },
                         new HostingUnit()
                        {
                            UnitName="New-York",
                            Rooms=3,
                            IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://ffcp.s3.amazonaws.com/tfc/Resorts/turtleinn/dwellings/beach_house/_MGL3866-m.jpg", 
                                "https://www.prickettproperties.com/rental_photos/gulf-shores-gulf-front-beach-house-for-rent.jpg" }
                        }
                    }
                }
        };
        /// <summary>
        /// default constructor for the class main window, which intializes the veiwing screen
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;
        }
        /// <summary>
        /// getter and setter function for the curretn host
        /// </summary>
        public Host CurrentHost { get => currentHost; set => currentHost = value; }
        /// <summary>
        /// ataumatic creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs
e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }
        /// <summary>
        /// function to create the host and to set him in the program
        /// </summary>
        /// <param name="index"></param>
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            CurrentHost = hostsList[index];
            UpGrid.DataContext = CurrentHost;
            for (int i = 0; i < CurrentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(CurrentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }
        /// <summary>
        /// a function which contrils when the text of the host name is changes. is created automatically and therfore emopty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbHostName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
