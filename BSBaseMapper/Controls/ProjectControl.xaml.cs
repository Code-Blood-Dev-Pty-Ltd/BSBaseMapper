using BSBaseMapper.Models;
using BSLib.Models;
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

namespace BSBaseMapper.Controls
{
    /// <summary>
    /// Interaction logic for ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        InfoControl? infoControl;

        public ProjectControl()
        {
            InitializeComponent();

            buttonEdit.Click += ButtonEdit_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            SetToView();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SetToView();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            SetToEdit();
        }

        public void ClearInfo()
        {
            infoControl = null;
            tabControl.Items.Clear();
        }

        private EFileMode fileMode = EFileMode.View;

        private void SetToView()
        {
            fileMode = EFileMode.View;

            if (infoControl != null)
            {
                infoControl.FileMode = EFileMode.View;
            }

            buttonSave.Visibility = Visibility.Collapsed;
            buttonCancel.Visibility = Visibility.Collapsed;
            buttonEdit.Visibility = Visibility.Visible;
        }

        private void SetToEdit()
        {
            fileMode = EFileMode.Edit;
            if (infoControl != null)
            {
                infoControl.FileMode = EFileMode.Edit;
            }

            buttonSave.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Collapsed;
        }

        public void SetInfo(BSLib.Models.RootInfoObject rootInfoObject)
        {
            if (rootInfoObject == null)
            {
                return;
            }
            else
            {
                if (tabControl.Items.Count > 0 && tabControl.Items.AsQueryable().Cast<TabItem>().ToList().Any(o => o.Name == "tabItemInfo"))
                {
                    tabControl.Items.Remove(tabControl.Items.AsQueryable().Cast<TabItem>().ToList().First(o => o.Name == "tabItemInfo"));
                }

                infoControl = new InfoControl(rootInfoObject);
                TabItem tabItem = new TabItem();
                tabItem.Header = "Map Info";
                tabItem.Name = "tabItemInfo";
                tabItem.Content = infoControl;
                tabControl.Items.Add(tabItem);
                tabControl.SelectedItem = tabItem;

                SetToView();
            }
        }
    }
}
