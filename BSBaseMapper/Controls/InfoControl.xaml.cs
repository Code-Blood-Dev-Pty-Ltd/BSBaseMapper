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
    /// Interaction logic for InfoControl.xaml
    /// </summary>
    public partial class InfoControl : UserControl
    {
        public RootInfoObject RootInfoObject { get; set; }

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

        public InfoControl(RootInfoObject rootInfoObject)
        {
            RootInfoObject = rootInfoObject;
            InitializeComponent();

            Initialized += InfoControl_Initialized;
        }

        private void InfoControl_Initialized(object? sender, EventArgs e)
        {
            stackPanelLabels.Visibility = Visibility.Visible;
            stackPanelControls.Visibility = Visibility.Collapsed;
        }
    }
}
