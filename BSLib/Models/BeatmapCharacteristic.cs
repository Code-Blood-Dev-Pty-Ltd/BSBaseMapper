using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSLib.Models
{
    public class BeatmapCharacteristic
    {
        public string _beatmapCharacteristicName { get; set; }
        public List<DifficultyBeatmap> _difficultyBeatmaps { get; set; }
    }
}
