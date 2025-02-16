using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerateButtons();
            GenerateMines();
            GenerateNumbers();
        }

        byte[,] Positions = new byte[12, 12];
        Button[,] ButtonList = new Button[12, 12];
        Random rnd = new Random();
        int timeLeft;
        int time;

        public void GenerateMines()
        {
            int bombs = 0;
            while (bombs < 20)
            {
                int x = rnd.Next(0, 12);
                int y = rnd.Next(0, 12);

                if (Positions[x, y] == 0)
                {
                    Positions[x, y] = 10;
                    bombs++;
                }
            }
        }

        public void GenerateNumbers()
        {
            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    if (Positions[x, y] == 10)
                        continue;
                    byte bombCounts = 0;
                    for (int counterX = -1; counterX < 2; counterX++)
                    {
                        int checkerX = x + counterX;

                        for (int counterY = -1; counterY < 2; counterY++)
                        {
                            int checkerY = y + counterY;

                            if (checkerX == -1 || checkerY == -1 || checkerX > 11 || checkerY > 11)
                                continue;
                            if (checkerY == y && checkerX == x)
                                continue;
                            if (Positions[checkerX, checkerY] == 10)
                                bombCounts++;
                        }
                    }

                    if (bombCounts == 0)
                        Positions[x, y] = 20;
                    else
                        Positions[x, y] = bombCounts;
                }
            }
        }

        public void GenerateButtons()
        {
            int xLoc = 3;
            int yLoc = 6;
            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    Button button = new Button();
                    button.Parent = panelButtons;
                    button.Location = new Point(xLoc, yLoc);
                    button.Size = new Size(25, 25);
                    button.Tag = $"{x},{y}";
                    button.Click += BtnClick;
                    button.MouseUp += RightClickBtn;
                    xLoc += 25;
                    ButtonList[x, y] = button;
                }
                yLoc += 22;
                xLoc = 3;
            }
        }


        public void BtnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int x = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(1));
            byte value = Positions[x, y];

            if (value == 10)
            {
                button.Image = Properties.Resources.bomb;
                timer1.Stop();
                MessageBox.Show("Gameover, you lost!");
                panelButtons.Enabled = false;
            }

            else if (value == 20)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = SystemColors.ControlDark;
                button.FlatAppearance.BorderSize = 1;
                button.Enabled = false;
                OpenAdjacentEmptyTile(button);
                points++;
            }
            else
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = SystemColors.ControlDark;
                button.FlatAppearance.MouseDownBackColor = button.BackColor;
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.Text = Positions[x, y].ToString();
                points++;
            }
            button.Click -= BtnClick;
            tbScore.Text = points.ToString();

            time = 5;
            timeLeft = 0;
            progressBar.Maximum = 5;
            progressBar.Value = 0;
        }

        public void OpenAdjacentEmptyTile(Button button)
        {
            int x = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(1));

            List<Button> emptyButtons = new List<Button>();

            for (int counterX = -1; counterX < 2; counterX++)
            {
                int checkerX = x + counterX;
                for (int counterY = -1; counterY < 2; counterY++)
                {
                    int checkerY = y + counterY;
                    if (checkerX == -1 || checkerY == -1 || checkerX > 11 || checkerY > 11)
                        continue;
                    if (checkerY == y && checkerX == x)
                        continue;
                    Button buttonAdjacent = ButtonList[checkerX, checkerY];
                    int xAdjacent = Convert.ToInt32(buttonAdjacent.Tag.ToString().Split(',').GetValue(0));
                    int yAdjacent = Convert.ToInt32(buttonAdjacent.Tag.ToString().Split(',').GetValue(1));
                    byte value = Positions[xAdjacent, yAdjacent];
                    if (value == 20)
                    {
                        if (buttonAdjacent.FlatStyle != FlatStyle.Flat)
                        {
                            buttonAdjacent.FlatStyle = FlatStyle.Flat;
                            buttonAdjacent.FlatAppearance.BorderSize = 0;
                            buttonAdjacent.FlatAppearance.BorderColor = SystemColors.ControlDark;
                            buttonAdjacent.Enabled = false;
                            emptyButtons.Add(buttonAdjacent);
                            points++;
                        }
                    }
                    else if (value != 10)
                    {
                        buttonAdjacent.PerformClick();
                    }

                }
            }
            foreach (var buttonEmpty in emptyButtons)
            {
                OpenAdjacentEmptyTile(buttonEmpty);
            }
            tbScore.Text = points.ToString();
        }

        int flag = 20;

        int points = 0;

        private void RightClickBtn(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                if (btn.FlatStyle != FlatStyle.Flat)
                {
                    if (btn.Image == null)
                    {
                        btn.Click -= BtnClick;
                        btn.Image = Properties.Resources.flag;
                        flag--;
                    }
                    else
                    {
                        btn.Click += BtnClick;
                        btn.Image = null;
                        flag++;
                    }
                }
                tbFlag.Text = flag.ToString();
            }
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            points = 0;
            flag = 30;

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    ButtonList[x, y].Dispose();
                }
            }
            panelButtons.Controls.Clear();
            ButtonList = new Button[12, 12];
            Positions = new byte[12, 12];
            panelButtons.Enabled = true;
            tbScore.Text = null;

            tbFlag.Text = null;
            time = 5;
            timeLeft = 0;
            progressBar.Value = 0;
            timer1.Stop();

            GenerateMines();
            GenerateNumbers();
            GenerateButtons();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            points = 0;
            flag = 30;

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    ButtonList[x, y].Dispose();
                }
            }
            panelButtons.Controls.Clear();
            ButtonList = new Button[12, 12];
            Positions = new byte[12, 12];
            panelButtons.Enabled = true;
            tbScore.Text = null;

            tbFlag.Text = null;
            time = 5;
            timeLeft = 0;

            timer1.Start();

            GenerateMines();
            GenerateNumbers();
            GenerateButtons();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                tbFlag.Text = null;
                timer1.Stop();
                MessageBox.Show("Gameover, you lost!");
                panelButtons.Enabled = false;
            }
            if (timeLeft != progressBar.Maximum)
            {
                tbFlag.Text = time.ToString();
                timeLeft += 1;
                time -= 1;
            }
            progressBar.Value = timeLeft;
        }
    }
}
