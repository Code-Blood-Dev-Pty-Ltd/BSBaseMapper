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
        DifficultyBeatmapSetContainerControl? difficultyBeatmapSetContainerControl;

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
            difficultyBeatmapSetContainerControl = null;
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

            if (difficultyBeatmapSetContainerControl != null)
            {
                difficultyBeatmapSetContainerControl.FileMode = EFileMode.View;
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

            if (difficultyBeatmapSetContainerControl != null)
            {
                difficultyBeatmapSetContainerControl.FileMode = EFileMode.Edit;
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

                if (tabControl.Items.Count > 0 && tabControl.Items.AsQueryable().Cast<TabItem>().ToList().Any(o => o.Name == "tabItemDifficultySets"))
                {
                    tabControl.Items.Remove(tabControl.Items.AsQueryable().Cast<TabItem>().ToList().First(o => o.Name == "tabItemDifficultySets"));
                }

                infoControl = new InfoControl(rootInfoObject);
                TabItem tabItemInfo = new TabItem();
                tabItemInfo.Header = "Map Info";
                tabItemInfo.Name = "tabItemInfo";
                tabItemInfo.Content = infoControl;
                tabControl.Items.Add(tabItemInfo);
                tabControl.SelectedItem = tabItemInfo;

                difficultyBeatmapSetContainerControl = new DifficultyBeatmapSetContainerControl(rootInfoObject._difficultyBeatmapSets);
                TabItem tabItemDifficultyBeatmapSetContainer = new TabItem();
                tabItemDifficultyBeatmapSetContainer.Header = "Difficulty Sets";
                tabItemDifficultyBeatmapSetContainer.Name = "tabItemDifficultySets";
                tabItemDifficultyBeatmapSetContainer.Content = difficultyBeatmapSetContainerControl;
                tabControl.Items.Add(tabItemDifficultyBeatmapSetContainer);

                SetToView();
            }
        }
    }
}
