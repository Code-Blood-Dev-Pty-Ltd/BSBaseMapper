using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSLib.Models
{
    public class RootInfoObject
    {
        public string _version { get; set; }
        public string _songName { get; set; }
        public string _songSubName { get; set; }
        public string _songAuthorName { get; set; }
        public string _levelAuthorName { get; set; }
        public double _beatsPerMinute { get; set; }
        public double _shuffle { get; set; }
        public double _shufflePeriod { get; set; }
        public double _previewStartTime { get; set; }
        public double _previewDuration { get; set; }
        public string _songFilename { get; set; }
        public string _coverImageFilename { get; set; }
        public string _environmentName { get; set; }
        public double _songTimeOffset { get; set; }
        public CustomData _customData { get; set; }
        public List<BeatmapCharacteristic> _difficultyBeatmapSets { get; set; }
    }
}
