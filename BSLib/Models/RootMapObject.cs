using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSLib.Models
{
    public class RootMapObject
    {
        public string version { get; set; }
        public List<BPMEvent> bpmEvents { get; set; }
        public List<ColorNote> colorNotes { get; set; }
    }
}
