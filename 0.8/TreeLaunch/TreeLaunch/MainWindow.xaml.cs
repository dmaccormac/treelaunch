//Copyright (C) 2015 Dan MacCormac <info@danmac.co>

//This program is free software: you can redistribute it and/or modify 
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.



using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace TreeLaunch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data Members
        public XmlDataProvider DataProvider { get; set; }


        
        //Methods
        
        public MainWindow()
        {
            InitializeComponent();


            //Set window to bottom right of screen
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 40;


            //Load XML TreeFile
            LoadTree();
        }


        private void LoadTree() //Load the XML Tree File
        {



            try
            {
                string treefile = System.IO.Path.GetFileName(Properties.Settings.Default.TreeFile);
                string path = System.IO.Path.GetDirectoryName(Properties.Settings.Default.TreeFile);

                if (path == "")
                    path = Directory.GetCurrentDirectory();


                //Initiliaze XmlDataProvider 
                DataProvider = new XmlDataProvider();
                DataProvider.Source = new Uri(path + @"\" + treefile);
                DataProvider.XPath = "/Tree";
                this.treeview.DataContext = DataProvider;

                //Add FileSystemWatcher to update treeview on change
                FileSystemWatcher fsWatcher = new FileSystemWatcher(path, treefile); //path, filter
                fsWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fsWatcher.Changed += new FileSystemEventHandler(fsWatcher_Changed);
                fsWatcher.EnableRaisingEvents = true;

            }


            catch (Exception e)
            {
                MessageBox.Show("Problem loading XML Tree File: \n\n" + e.ToString());
            }

        }


        void fsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            DataProvider.Refresh();
        }


        private void DoSession()
        {
            try
            {
                //Get Selected Tree Item as XmlElement
                XmlElement xmlElement = (XmlElement)treeview.SelectedItem;

                //Create a new Session Item. 
                Session mySession;


                //Check if parameters are included in XML. 
                string name = (xmlElement.GetAttribute("Name").ToString());
                string command = (xmlElement.GetAttribute("Command").ToString());
                string parameters = (xmlElement.GetAttribute("Parameters").ToString());


                //Fire constructor
                mySession = new Session(name, command, parameters);


                //Launch Session
                mySession.Launch();



            }


            catch (Exception e)
            {
                if (e is InvalidOperationException)
                {
                    MessageBox.Show("Cannot launch a group item.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else if (e is NullReferenceException)
                {
                    MessageBox.Show("No item selected. \n" + e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


                else
                {
                    MessageBox.Show("There was a problem creating the session. Possibly something to do with the XML Tree file. Here's the technical details...\n\n" + e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }

        }


        
        private void MenuLaunch_Click(object sender, RoutedEventArgs e)
        {
            DoSession();

        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {

            //Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            if ((bool)result) //If user chose a file
            {
                Properties.Settings.Default.TreeFile = dlg.FileName;
                Properties.Settings.Default.Save();
                LoadTree(); //Reload Tree
            }



        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            //Open Tree.xml File in TextEditor
            System.Diagnostics.Process.Start(Properties.Settings.Default.Editor, Properties.Settings.Default.TreeFile);
        }

        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            DataProvider.Refresh();

        }

        private void MenuLog_Click(object sender, RoutedEventArgs e)
        {
            //Open Log File in TextEditor
            System.Diagnostics.Process.Start(Properties.Settings.Default.Editor, Properties.Settings.Default.LogFile);

        }


        private void MenuTopmost_Click(object sender, RoutedEventArgs e)
        {
           this.Topmost = !(this.Topmost); //Flip Topmost value

        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("TreeLaunch 0.8 by Dan MacCormac \n" +
                            "http://go.danmac.co/treelaunch \n\n" +
                            "GNU General Public License Version 3", "About", MessageBoxButton.OK, MessageBoxImage.Information);

        }


        private void treeview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoSession();
        }
 
    }
}
