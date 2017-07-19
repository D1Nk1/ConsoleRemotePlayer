using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleRemotePlayer
{

    public partial class Player : Form
    {
        FileSystemWatcher fsw = new FileSystemWatcher();
        public Player()
        {
            InitializeComponent();
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;


            string[] Files = Directory.GetFiles(@"D:\Twenty One Pilots\Albums\2016 - Blurryface (Limited Edition)", "*.mp3", SearchOption.TopDirectoryOnly);

            foreach (string file in Files)
            {
                media = axWindowsMediaPlayer1.newMedia(file);
                playlist.appendItem(media);
            }
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            fsw.Path = @"C:\Users\Igor Koryakin\Documents\Visual Studio 2017\Projects\ConsoleRemotePlayer\ConsoleRemotePlayer\bin\Debug";
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Changed += new FileSystemEventHandler(OnChanged);
            fsw.EnableRaisingEvents = true;

            timer1.Enabled = false;
            timer1.Interval = 2500;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            StreamReader readtext = new StreamReader(@"controls.txt");
            string readMeText = readtext.ReadLine();
            readtext.Dispose();
            if (readMeText == readMeText + "next")
            {
                axWindowsMediaPlayer1.Ctlcontrols.next();
                StreamWriter sw = new StreamWriter(@"controls.txt");
                sw.WriteLine("");
                sw.Dispose();
                fsw.Dispose(); //doesn't work!!!!!! need to reopen somehow after disposing!!!!!
            }
            else
            {
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\Users\Igor Koryakin\Documents\Visual Studio 2017\Projects\ConsoleRemotePlayer\ConsoleRemotePlayer\bin\Debug";
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Changed += new FileSystemEventHandler(OnChanged);
            fsw.EnableRaisingEvents = true;
        }
    }
}
