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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Host currentHost;
        List<Host> hostsList = new List<Host>()
        {
                new Host() {
                            HostName = "beachHouse",
                            Units = new List<HostingUnit>()
                                {
                                   new HostingUnit()
                                   {
                                      UnitName="surf's up duuude!",
                                    Rooms=2,
                                      IsSwimmingPool=true,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){"https://bit.ly/2Y2LaMU","https://bit.ly/34FXGnQ"}

                        },
                        new HostingUnit()
                        {
                            UnitName="white sands resort",
                            Rooms=2,
                            IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://bit.ly/2OCHmi5","https://bit.ly/34KpTdy" }

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
                            Uris=new List<string>(){ "https://bit.ly/2R8ylz7", "https://bit.ly/2OEsjoo", "https://bit.ly/2qTSO03" }

                        },
                        new HostingUnit()
                        {
                            UnitName="king david",
                            Rooms=3,
                            IsSwimmingPool=true,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://bit.ly/35Wa8jx", "https://bit.ly/2R8pzkH" }

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
                            Uris=new List<string>(){ "https://bit.ly/2La5syA", "https://bit.ly/2Raxr5o"}

                        },
                        new HostingUnit()
                        {
                            UnitName="Tel-Aviv",
                            Rooms=3,
                            IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://bit.ly/2r2pvZ7", "https://bit.ly/34IqMDe","https://bit.ly/34Er9yt" }

                        },
                         new HostingUnit()
                        {
                            UnitName="New-York",
                            Rooms=3,
                            IsSwimmingPool=false,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://bit.ly/2OBalD3", "https://bit.ly/33IU03L" }

                        }
                    }
                }
        };
    public MainWindow()
        {
            InitializeComponent();
            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;

            
        }

        private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs
e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }
    }
}
