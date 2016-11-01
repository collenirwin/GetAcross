using System;
using System.IO;
using System.Windows.Forms;

namespace GetAcross {
    public partial class Win : Form {

        TimeSpan ts;

        bool trueClose = false;

        public Win(TimeSpan ts) {
            InitializeComponent();

            this.ts = ts;
            lblSeconds.Text = Misc.prettyTime(ts);
        }

        private void lblSubmit_Click(object sender, EventArgs e) {
            writeScores();
        }

        private void writeScores() {
            if (!trueClose) {
                string name = txtName.Text.Trim();

                if (name == "") {
                    name = "- no name -";
                }

                using (StreamWriter W = File.AppendText(Misc.FILE_NAME)) {
                    W.WriteLine(name);
                    W.WriteLine(ts.TotalSeconds);
                }

                this.Hide();

                Scores s = new Scores();
                s.ShowDialog();

                trueClose = true;
                this.Close();
            }
        }

        private void lbl_MouseEnter(object sender, EventArgs e) {
            (sender as Label).Height = 99;
        }

        private void lbl_MouseLeave(object sender, EventArgs e) {
            (sender as Label).Height = 18;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                writeScores();
                e.SuppressKeyPress = true;
            }
        }
    }
}
