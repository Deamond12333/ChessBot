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
        public bool IsWhite = true;
        public double PawnWeight = 0, RookWeight = 0, BishopWeight = 0, KnightWeight = 0, QueenWeight = 0, KingWeight = 0;
        public StartSettings()
        {
            InitializeComponent();
            gameStart.Click += gameStart_Click;
        }

        void gameStart_Click(object sender, EventArgs e)
        {
            IsWhite = isWhite.Checked;

            if (!double.TryParse(pawnWeight.Text, out PawnWeight))
            {
                MessageBox.Show("В поле 'Вес пешки' скорее всего не число.");
                return;
            }

            if (!double.TryParse(rookWeight.Text, out RookWeight))
            {
                MessageBox.Show("В поле 'Вес ладьи' скорее всего не число.");
                return;
            }

            if (!double.TryParse(bishopWeight.Text, out BishopWeight))
            {
                MessageBox.Show("В поле 'Вес офицера' скорее всего не число.");
                return;
            }

            if (!double.TryParse(knightWeight.Text, out KnightWeight))
            {
                MessageBox.Show("В поле 'Вес коня' скорее всего не число.");
                return;
            }

            if (!double.TryParse(queenWeight.Text, out QueenWeight))
            {
                MessageBox.Show("В поле 'Вес ферзя' скорее всего не число.");
                return;
            }

            if (!double.TryParse(kingWeight.Text, out KingWeight))
            {
                MessageBox.Show("В поле 'Вес короля' скорее всего не число.");
                return;
            }

            this.Close();
        }
    }
}
