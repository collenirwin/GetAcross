using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetAcross {
    public class ScoreLabel : Label, IComparable<ScoreLabel> {
        private double _time;

        public double time {
            get { return _time; }
        }

        public ScoreLabel(double time) : base() {
            _time = time;
        }

        public int CompareTo(ScoreLabel other) {
            if (this.time >  other.time) return 1;
            if (this.time == other.time) return 0;
            return -1;
        }
    }
}
