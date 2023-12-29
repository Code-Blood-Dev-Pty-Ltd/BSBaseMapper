using BSLib.Models;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSBaseMapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            menuItemOpenInfoFile.Click += MenuItemOpenInfoFile_Click;
            menuItemOpenMapFile.Click += MenuItemOpenMapFile_Click;
            menuItemCloseFiles.Click += MenuItemCloseFiles_Click;
        }

        private void MenuItemCloseFiles_Click(object sender, RoutedEventArgs e)
        {
            projectControl.ClearInfo();
            menuItemOpenInfoFile.IsEnabled = true;
            menuItemOpenMapFile.IsEnabled = true;
            menuItemCloseFiles.IsEnabled = false;
        }

        private void MenuItemOpenMapFile_Click(object sender, RoutedEventArgs e)
        {
            OpenMapFile();
        }

        private void MenuItemOpenInfoFile_Click(object sender, RoutedEventArgs e)
        {
            OpenInfoFile();
        }

        private void OpenInfoFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Beat Saber Info File (*.dat)|*.dat|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                var fileContents = File.ReadAllText(selectedFilePath);

                var result = BSLib.Routines.ParseInfoJson(fileContents);
                if (result != null)
                {
                    projectControl.SetInfo(result);
                }

                menuItemOpenInfoFile.IsEnabled = false;
                menuItemCloseFiles.IsEnabled = true;
            }

            
        }

        private RootMapObject? OpenMapFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Beat Saber Map File (*.dat)|*.dat|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                var fileContents = File.ReadAllText(selectedFilePath);

                var result = BSLib.Routines.ParseMapJson(fileContents);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}