using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GetAcross {
    enum playerState {
        up,
        down,
        left,
        right,
        idle
    }

    public partial class Form1 : Form {

        const int SPEED_MULT        = 2;
        const int PLAYER_SPEED_MULT = 2;
        const int SPRINT_MULT       = 3;
        const int SPRINT_MAX        = 500;
        const int SHIELD_MAX        = 100;

        const string FILE_PATH = "scores";

        DateTime start;

        int sprint = SPRINT_MAX;
        bool sprinting = false;

        int shield = SHIELD_MAX;
        bool shielded = false;

        playerState state = playerState.idle;

        List<Label> up   = new List<Label>();
        List<Label> down = new List<Label>();
        List<Label> wood = new List<Label>();

        public Form1() {
            InitializeComponent();

            // populating the label lists
            for (int x = 0; x < 5; x++) {
                up.Add(this.Controls["up" + x.ToString()] as Label);
                down.Add(this.Controls["down" + x.ToString()] as Label);
                wood.Add(this.Controls["wood" + x.ToString()] as Label);
            }

            // start game
            reset();
        }

        private void reset() {
            tmrMain.Start();
            player.Location = new Point(9, 9);
            state  = playerState.idle;
            sprint = SPRINT_MAX;
            shield = SHIELD_MAX;
            sprinting = false;
            shielded  = false;
            lblError.Hide();

            start = DateTime.Now;
        }

        private void win() {
            tmrMain.Stop();

            Win win = new Win(DateTime.Now - start);
            win.ShowDialog();

            reset();
        }

        private void setShield(bool on) {
            shielded = on;
            player.BackColor = (on) ? Color.MediumTurquoise : Color.MediumSeaGreen;
        }

        private void tmrMain_Tick(object sender, EventArgs e) {

            // decrementing shield, and turning it off when out of time
            if (shielded) {
                if (shield > 0) {
                    shield--; // counting down
                } else {
                    setShield(false); // turn off shield
                }
            } else if (shield < SHIELD_MAX) {
                shield++; // refilling
            }

            // toggling shield cd message
            if (shield <= 0) {
                lblError.Show();
            } else if (lblError.Visible && shield >= SHIELD_MAX) {
                lblError.Hide();
            }

            // we're moving
            if (state != playerState.idle) {
                Point nextPoint = player.Location;
                int posIncrease = PLAYER_SPEED_MULT;

                // check if we're sprinting
                if (sprinting && sprint > 0) {
                    posIncrease += SPRINT_MULT;
                    sprint -= 5;
                }

                // figure out where the next point is by player's direction
                if (state == playerState.up) {
                    nextPoint = new Point(player.Location.X, player.Location.Y - posIncrease);
                } else if (state == playerState.down) {
                    nextPoint = new Point(player.Location.X, player.Location.Y + posIncrease);
                } else if (state == playerState.left) {
                    nextPoint = new Point(player.Location.X - posIncrease, player.Location.Y);
                } else if (state == playerState.right) {
                    nextPoint = new Point(player.Location.X + posIncrease, player.Location.Y);
                }

                // representation of the player at new point
                Label positionTest = new Label();
                positionTest.Location = nextPoint;
                positionTest.Size = player.Size;
                pctMain.Controls.Add(positionTest);

                // check collisions
                if (pctMain.ClientRectangle.Contains(positionTest.Bounds)) {

                    bool canMove = true;
                    for (int x = 0; x < wood.Count; x++) {
                        if (positionTest.Bounds.IntersectsWith(wood[x].Bounds)) {
                            canMove = false;
                            break;
                        }
                    }

                    // move the player if we can
                    if (canMove) {
                        player.Location = nextPoint;
                    }
                }

                pctMain.Controls.Remove(positionTest);
                positionTest.Dispose();
            }

            if (player.Bounds.IntersectsWith(water.Bounds)) {
                win();
                return;
            }

            // scary moving red boxes
            for (int x = 0; x < up.Count; x++) {
                if (up[x].Top + up[x].Height > 0) {
                    up[x].Top -= ((x + 1) + SPEED_MULT);
                } else {
                    up[x].Top = pctMain.Height;
                }

                if (down[x].Top - down[x].Height < pctMain.Height) {
                    down[x].Top += ((x + 1) + SPEED_MULT);
                } else {
                    down[x].Top = 0 - down[x].Height;
                }

                if (!shielded) {

                    // player hit
                    if (player.Bounds.IntersectsWith(up[x].Bounds) || player.Bounds.IntersectsWith(down[x].Bounds)) {
                        tmrMain.Stop();
                        MessageBox.Show("You lost, and it only took you " + Misc.prettyTime(start) + ".", "RIP");
                        reset();
                        return;
                    }
                }
            }

            // filling up the sprint meter
            if (sprint < SPRINT_MAX) {
                sprint++;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.W) {
                state = playerState.up;
            } else if (e.KeyCode == Keys.A) {
                state = playerState.left;
            } else if (e.KeyCode == Keys.S) {
                state = playerState.down;
            } else if (e.KeyCode == Keys.D) {
                state = playerState.right;
            } else if (e.KeyCode == Keys.ControlKey) {
                setShield(true);
            }

            sprinting = e.Shift;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.W && state == playerState.up) ||
                (e.KeyCode == Keys.A && state == playerState.left) ||
                (e.KeyCode == Keys.S && state == playerState.down) ||
                (e.KeyCode == Keys.D && state == playerState.right)) 
            {
                state = playerState.idle;
            }

            sprinting = e.KeyCode == Keys.ShiftKey;
        }

        private void lbl_MouseEnter(object sender, EventArgs e) {
            (sender as Label).Height = 99;
        }

        private void lbl_MouseLeave(object sender, EventArgs e) {
            (sender as Label).Height = 18;
        }
    }
}
