using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GetAcross {
    public partial class Scores : Form {

        List<ScoreLabel> lstScores = new List<ScoreLabel>();

        public Scores() {
            InitializeComponent();
        }

        private void Scores_Load(object sender, EventArgs e) {
            using (StreamReader R = File.OpenText(Misc.FILE_NAME)) {

                while (!R.EndOfStream) {
                    string name = R.ReadLine();
                    string time = R.ReadLine();

                    createLabel(name, time);
                }
            }

            sortLabels();
        }

        private void sortLabels() {
            lstScores.Sort();

            int x = 3;
            int y = 3;

            for (int i = 0; i < lstScores.Count; i++) {
                lstScores[i].Text = (i + 1).ToString() + ". " + lstScores[i].Text;
                lstScores[i].Location = new Point(x, y);
                y += 30;
            }

            pnlScores.Refresh();
        }

        private void createLabel(string name, string time) {
            ScoreLabel lbl = new ScoreLabel(Convert.ToDouble(time));
            lbl.ForeColor = Color.MediumSeaGreen;
            lbl.Text = name + " [" + Misc.prettyTime(time) + "]";
            lbl.AutoSize = true;

            pnlScores.Controls.Add(lbl);
            lstScores.Add(lbl);
        }

        private void lblGoAgain_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void lbl_MouseEnter(object sender, EventArgs e) {
            (sender as Label).Height = 27;
        }

        private void lbl_MouseLeave(object sender, EventArgs e) {
            (sender as Label).Height = 18;
        }
    }
}
