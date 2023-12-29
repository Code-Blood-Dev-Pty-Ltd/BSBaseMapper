using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSLib.Models
{
    public class DifficultyBeatmap
    {
        public string _difficulty { get; set; }
        public int _difficultyRank { get; set; }
        public string _beatmapFilename { get; set; }
        public double _noteJumpMovementSpeed { get; set; }
        public double _noteJumpStartBeatOffset { get; set; }
        public CustomData _customData { get; set; }
    }
}
