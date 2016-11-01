using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetAcross {

    public struct score {
        string name;
        TimeSpan ts;
    }

    public static class Misc {

        public const string FILE_NAME = "scores.ga";

        public static Dictionary<int, score> scores = new Dictionary<int, score>();

        public static string prettyTime(DateTime start) {
            return (DateTime.Now - start).TotalSeconds.ToString("n2") + " seconds";
        }

        public static string prettyTime(TimeSpan ts) {
            return ts.TotalSeconds.ToString("n2") + " seconds";
        }

        public static string prettyTime(string seconds) {
            return Convert.ToDecimal(seconds).ToString("n2") + " seconds"; 
        }
    }
}
