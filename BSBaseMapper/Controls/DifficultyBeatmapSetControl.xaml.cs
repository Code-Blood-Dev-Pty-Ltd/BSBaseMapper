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
    /// Interaction logic for DifficultyBeatmapSetControl.xaml
    /// </summary>
    public partial class DifficultyBeatmapSetControl : UserControl
    {
        public DifficultyBeatmap DifficultyBeatmapObject { get; set; }

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
                    stackPanelLabels.Visibility = Visibility.Collapsed;
                    stackPanelControls.Visibility = Visibility.Visible;
                }
                else
                {
                    stackPanelLabels.Visibility = Visibility.Visible;
                    stackPanelControls.Visibility = Visibility.Collapsed;
                }
            }
        }

        public DifficultyBeatmapSetControl(DifficultyBeatmap difficultyBeatmap)
        {
            DifficultyBeatmapObject = difficultyBeatmap;
            Initialized += DifficultyBeatmapSetControl_Initialized;
            InitializeComponent();
        }

        private void DifficultyBeatmapSetControl_Initialized(object? sender, EventArgs e)
        {
            
        }
    }
}
