using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBotOnline
{
    public partial class StartSettings : Form
    {
        public bool IsWhite, BotVSbot, BotsWar;
        public double PawnWeightOpp1 = 0, PawnWeightOpp2 = 0, RookWeightOpp1 = 0, RookWeightOpp2 = 0,
                      BishopWeightOpp1 = 0, BishopWeightOpp2 = 0, KnightWeightOpp1 = 0, KnightWeightOpp2 = 0,
                      QueenWeightOpp1 = 0, QueenWeightOpp2 = 0, KingWeightOpp1 = 0, KingWeightOpp2 = 0;
        public int StepTime;
        public StartSettings()
        {
            InitializeComponent();
            gameStart.Click += gameStart_Click;
        }

        void gameStart_Click(object sender, EventArgs e)
        {
            IsWhite = isWhite.Checked;
            BotsWar = botsWar.Checked;
            BotVSbot = botVSbot.Checked;

            if (!int.TryParse(stepTime.Text, out StepTime))
            {
                MessageBox.Show("В поле 'Время хода' скорее всего не число.");
                return;
            }
            else
            {
                if (StepTime < 30)
                {
                    MessageBox.Show("Время хода слишком мало.");
                    return;
                }
                else if (StepTime > 180)
                {
                    MessageBox.Show("Время хода слишком велико.");
                    return;
                }
            }

            if (!double.TryParse(pawnWeightOpp1.Text, out PawnWeightOpp1))
            {
                MessageBox.Show("В поле 'Вес пешки' скорее всего не число.");
                return;
            }

            if (!double.TryParse(rookWeightOpp1.Text, out RookWeightOpp1))
            {
                MessageBox.Show("В поле 'Вес ладьи' скорее всего не число.");
                return;
            }

            if (!double.TryParse(bishopWeightOpp1.Text, out BishopWeightOpp1))
            {
                MessageBox.Show("В поле 'Вес офицера' скорее всего не число.");
                return;
            }

            if (!double.TryParse(knightWeightOpp1.Text, out KnightWeightOpp1))
            {
                MessageBox.Show("В поле 'Вес коня' скорее всего не число.");
                return;
            }

            if (!double.TryParse(queenWeightOpp1.Text, out QueenWeightOpp1))
            {
                MessageBox.Show("В поле 'Вес ферзя' скорее всего не число.");
                return;
            }

            if (!double.TryParse(kingWeightOpp1.Text, out KingWeightOpp1))
            {
                MessageBox.Show("В поле 'Вес короля' скорее всего не число.");
                return;
            }

            if (BotVSbot)
            {
                if (!double.TryParse(pawnWeightOpp2.Text, out PawnWeightOpp2))
                {
                    MessageBox.Show("В поле 'Вес пешки' скорее всего не число.");
                    return;
                }

                if (!double.TryParse(rookWeightOpp2.Text, out RookWeightOpp2))
                {
                    MessageBox.Show("В поле 'Вес ладьи' скорее всего не число.");
                    return;
                }

                if (!double.TryParse(bishopWeightOpp2.Text, out BishopWeightOpp2))
                {
                    MessageBox.Show("В поле 'Вес офицера' скорее всего не число.");
                    return;
                }

                if (!double.TryParse(knightWeightOpp2.Text, out KnightWeightOpp2))
                {
                    MessageBox.Show("В поле 'Вес коня' скорее всего не число.");
                    return;
                }

                if (!double.TryParse(queenWeightOpp2.Text, out QueenWeightOpp2))
                {
                    MessageBox.Show("В поле 'Вес ферзя' скорее всего не число.");
                    return;
                }

                if (!double.TryParse(kingWeightOpp2.Text, out KingWeightOpp2))
                {
                    MessageBox.Show("В поле 'Вес короля' скорее всего не число.");
                    return;
                }
            }

            this.Close();
        }

        private void botVSbot_CheckedChanged(object sender, EventArgs e)
        {
            isWhite.Checked = !botVSbot.Checked;
            isWhite.Enabled = !botVSbot.Checked;

            botsWar.Enabled = !botVSbot.Checked;

            pawnWeightOpp2.Enabled = botVSbot.Checked;
            rookWeightOpp2.Enabled = botVSbot.Checked;
            bishopWeightOpp2.Enabled = botVSbot.Checked;
            knightWeightOpp2.Enabled = botVSbot.Checked;
            queenWeightOpp2.Enabled = botVSbot.Checked;
            kingWeightOpp2.Enabled = botVSbot.Checked;
        }

        private void botsWar_CheckedChanged(object sender, EventArgs e)
        {
            botVSbot.Enabled = !botsWar.Checked;
        }
    }
}
