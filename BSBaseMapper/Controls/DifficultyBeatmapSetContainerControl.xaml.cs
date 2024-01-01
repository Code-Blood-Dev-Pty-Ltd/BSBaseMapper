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
    /// Interaction logic for DifficultyBeatmapSetContainerControl.xaml
    /// </summary>
    public partial class DifficultyBeatmapSetContainerControl : UserControl
    {
        public List<BeatmapCharacteristic> DifficultyBeatmaps { get; set; } = new List<BeatmapCharacteristic>();

        public DifficultyBeatmapSetContainerControl()
        {
            DifficultyBeatmaps = new List<BeatmapCharacteristic>();
            InitializeComponent();
        }

        public DifficultyBeatmapSetContainerControl(List<BeatmapCharacteristic> beatmapCharacteristics)
        {
            DifficultyBeatmaps = beatmapCharacteristics;
            Initialized += DifficultyBeatmapSetContainerControl_Initialized;
            InitializeComponent();
        }

        private void DifficultyBeatmapSetContainerControl_Initialized(object? sender, EventArgs e)
        {
            foreach (var o in DifficultyBeatmaps)
            {
                foreach (var p in o._difficultyBeatmaps)
                {
                    var control = new DifficultyBeatmapSetControl(p);
                    control.FileMode = EFileMode.View;

                    TabItem tabItem = new TabItem();
                    tabItem.Header = p._difficulty;
                    tabItem.Name = $"tabItemDifficultyBeatmap{p._difficulty}";
                    tabItem.Content = control;
                    tabControl.Items.Add(tabItem);
                }
            }

            if (DifficultyBeatmaps.Any())
            {
                tabControl.SelectedIndex = 0;
            }
        }

        private EFileMode fileMode;
        public EFileMode FileMode
        {
            get
            {
                return fileMode;
            }
            set
            {
                fileMode = value;

                if (value == EFileMode.Edit)
                {
                    //
                }
                else
                {
                    //
                }
            }
        }
    }
}