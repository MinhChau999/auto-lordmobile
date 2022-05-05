using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KAutoHelper;

namespace ToolAuto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region data
        Bitmap ICON_APP;
        Bitmap ICON_EXIT;
        Bitmap ICON_HEART;
        Bitmap ICON_DAILY;
        Bitmap ICON_TRAIN;
        Bitmap ICON_HUNTER;
        Bitmap ICON_CHECKHUNTER;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            ICON_APP =(Bitmap) Bitmap.FromFile("data//LordsMobile.png");
            ICON_EXIT = (Bitmap)Bitmap.FromFile("data//ExitIcon.png");
            ICON_HEART = (Bitmap)Bitmap.FromFile("data//Heart.png");
            ICON_DAILY = (Bitmap)Bitmap.FromFile("data//Daily.png");
            ICON_TRAIN = (Bitmap)Bitmap.FromFile("data//Train.png");
            ICON_HUNTER = (Bitmap)Bitmap.FromFile("data//Hunter.png");
            ICON_CHECKHUNTER = (Bitmap)Bitmap.FromFile("data//CheckHunter.png");
        }
        private void ClickButton(object sender, RoutedEventArgs e)
        {
            isStop = false;
            Task t = new Task(() =>{
                Auto(devices);
            });
            t.Start();
        }
        bool isStop = false;
        bool flag = true;
        List<string> devices = new List<string>();

        void Auto(List<string> devices)
        {
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (string deviceID in devices)
            {
                Task t = new Task(() =>
                {
                    checkExit(deviceID);
                    openBox(deviceID);
                    if (isStop)
                    {
                        return;
                    }
                    openBoat(deviceID);
                    if (isStop)
                    {
                        return;
                    }
                    recieveDaily(deviceID);
                    if (isStop)
                    {
                        return;
                    }
                    useHeart(deviceID);
                    if (isStop)
                    {
                        return;
                    }
                    bienDoi(deviceID);
                    if (isStop)
                    {
                        return;
                    }
                    arena(deviceID);
                    if (isStop)
                    {
                        return;
                    }
                });
                t.Start();
            }
        }
 
        void openApp(string deviceID)
        {
            // Tắt quảng cáo nếu có
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 97.1, 33.3);
            Delay(1);

            // Mở app bằng cách xác nhận hình ảnh IconApp
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var iconLordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ICON_APP);
            if (iconLordPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, iconLordPoint.Value.X, iconLordPoint.Value.Y);
            }

        }
        // Mở rương săn bang hội
        void openBox(string deviceID)
        {
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 47.3, 91.7);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 76.5, 36.8);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.4, 20.4);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 75.8, 20.7);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 78.0, 33.2);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.4, 20.4);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 75.8, 20.7);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.0, 32.6);
            Delay(1);
            checkExit(deviceID);
        }

        void openBoat(string deviceID)
        {
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 14.9, 90.2);
            Delay(1);
            // Mở 4 vị trí trên thuyền
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 28.2, 61.0);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.4, 89.0);
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 72.6, 60.1);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.4, 89.0);
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 27.9, 89.3);
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.4, 89.0);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 72.1, 90.2);
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.4, 89.0);
            Delay(1);
            checkExit(deviceID);
        }
        
        void useHeart(string deviceID)
        {
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 3.0, 27.0);
            Delay(1);
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var iconHeart = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ICON_HEART);
            if(iconHeart != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, iconHeart.Value.X, iconHeart.Value.Y);
                Delay(3);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 52.3, 69.0);
                Delay(1);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 88.2, 53.2);
                Delay(3);
                checkExit(deviceID);
            }
            
        }

        void bienDoi(string deviceID)
        {
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.3, 26.4);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 32.2, 90.2);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.8, 68.7);
            Delay(2);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.8, 68.7);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 96.3, 6.4);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 24.2, 68.1);
            Delay(2);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 24.2, 68.1);
            Delay(1);
            if (isStop)
            {
                return;
            }
            exitAnything(deviceID);
        }
        bool exitAnything(string deviceID)
        {
            // Mở app bằng cách xác nhận hình ảnh IconApp
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var iconExit = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ICON_EXIT);
            if(iconExit != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, iconExit.Value.X, iconExit.Value.Y);
                return true;
            }
            return false;
        }

        void checkExit(string deviceID)
        {
            // Exit các thông tin không cần thiết
            // KAutoHelper.ADBHelper.TapByPercent(deviceID, 96.5, 5.5);
            flag = true;
            while (flag)
            {
                if (isStop)
                {
                    return;
                }
                flag = exitAnything(deviceID);
                Delay(1);
            }
        }
        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                {
                    return;
                }
            }
        }

        // Swipe màn hình
        void swipeDown(string deviceID)
        {
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 66, 50, 46, 150);
        }

        void swipeUp(string deviceID)
        {
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 46, 50, 66, 150);
        }
        void swipeLeft(string deviceID)
        {
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 46, 50, 66, 50, 150);
        }
        void swipeRight(string deviceID)
        {
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 66, 50, 46, 50, 150);
        }

        // Vòng lặp săn quái
        void hunter(string deviceID)
        {
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var iconHunter = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ICON_HUNTER);
            if(iconHunter != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID,iconHunter.Value.X,iconHunter.Value.Y);
                Delay(1);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 59.9, 66.3);
                Delay(1);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.9, 74.1);
                Delay(3);
                if (isStop)
                {
                    return;
                }
                flag = true;
                int count = 1;
                while (flag)
                {
                    var screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var iconCheckHunter = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, ICON_CHECKHUNTER);
                    Delay(1);
                    if (isStop)
                    {
                        return;
                    }
                    count++;
                    if(iconCheckHunter != null)
                    {
                        flag = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (isStop)
                            {
                                return;
                            }
                            Delay(3*count);
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.0, 44.0);
                            Delay(1);
                            if (isStop)
                            {
                                return;
                            }
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 59.9, 66.3);
                            Delay(1);
                            if (isStop)
                            {
                                return;
                            }
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.9, 74.1);
                            Delay(3*count);
                        }
                        checkExit(deviceID);
                    }
                }
            }
        }

        private void ClickButtonStop(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }

        private void ClickConnect(object sender, RoutedEventArgs e)
        {
            isStop = false;
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (string deviceID in devices)
            {
                Task t = new Task(() =>
                {
                    openApp(deviceID);
                });
                t.Start();
            }
        }

        private void ClickButtonTest(object sender, RoutedEventArgs e)
        {
            isStop = false;
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (string deviceID in devices)
            {
                Task t = new Task(() =>
                {
                    bienDoi(deviceID);
                });
                t.Start();
            }
        }

        void recieveDaily(string deviceID)
        {
            // Nhấn quà hàng ngày
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 27.5, 14.7);
            Delay(1);
            if (isStop)
            {
                return;
            }
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var iconDaily = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ICON_DAILY);
            if (isStop)
            {
                return;
            }
            if (iconDaily != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID,iconDaily.Value.X,iconDaily.Value.Y);
                Delay(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 83.2, 22.8);
                Delay(1);
            }
            checkExit(deviceID);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 88.9, 75.3);
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.7, 74.4);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 36.4, 13.8);
            Delay(2);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 4.4, 62.1);
            Delay(1);
            checkExit(deviceID);
        }

        void train(string deviceID)
        {
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var iconTrain = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ICON_TRAIN);
            if (isStop)
            {
                return;
            }

            if (iconTrain != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, iconTrain.Value.X, iconTrain.Value.Y);
                Delay(3);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 66, 50, 45, 150);
                Delay(3);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 57.9, 52.3);
                Delay(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 86.6, 87.2);
                Delay(1);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.0, 89.0);
                Delay(1);
                checkExit(deviceID);
            }
        }

        // Tham gia trận chiến đấu trường
        void arena(string deviceID)
        {
            for (int i = 0; i < 2; i++)
            {
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.3, 90.2);
                Delay(1);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 1.4, 46.9);
                Delay(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 85.4, 57.4);
                Delay(1);
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 82.5, 75.3);
                Delay(8);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 96.1, 6.7);
                if (isStop)
                {
                    return;
                }
                Delay(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 41.3, 47.5);
                Delay(3);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 92.8, 87.5);
                Delay(1);
            }
        }
        // Click help
        void help(string deviceID)
        {
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.6, 92.3);
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 93.1, 69.6);
            Delay(1);
            if (isStop)
            {
                return;
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.8, 64.8);
            Delay(1);
            if (isStop)
            {
                return;
            }
            while(true)
            {
                if (isStop)
                {
                    return;
                }
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 47.3, 91.1);
                Delay(1);
            }
        }

        private void ClickButtonHelp(object sender, RoutedEventArgs e)
        {
            isStop = false;
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (string deviceID in devices)
            {
                Task t = new Task(() =>
                {
                    help(deviceID);
                });
                t.Start();
            }
        }
    }
}
