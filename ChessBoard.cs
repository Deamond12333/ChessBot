using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessDriver;

namespace ChessBotOnline
{
    public partial class ChessBoard : Form
    {
        ChessTile tile;
        StartSettings ss;
        public ChessBoard()
        {
            InitializeComponent();

            ss = new StartSettings();
            ss.FormClosing += StartSettings_FormClosing;
            ss.ShowDialog();
            Refresh();
        }

        void StartSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            tile = new ChessTile(ss.IsWhite, ss.PawnWeight, ss.RookWeight, ss.BishopWeight, ss.KnightWeight, ss.QueenWeight, ss.KingWeight);
        }

        private void ChessBoard_Paint(object sender, PaintEventArgs e)
        {
            int beginPoint = 440 - 93;
            foreach(Pawn p in tile.BlackPawns)
            {
                e.Graphics.DrawImage(Image.FromFile(p.ImgPath), beginPoint += 94, 160, 60, 85);
            }
            beginPoint = 440 - 93;
            foreach (Pawn p in tile.WhitePawns)
            {
                e.Graphics.DrawImage(Image.FromFile(p.ImgPath), beginPoint += 94, 630, 60, 85);
            }
            e.Graphics.DrawImage(Image.FromFile(tile.BlackQueen.ImgPath), 720, 45, 60, 100);
            e.Graphics.DrawImage(Image.FromFile(tile.WhiteQueen.ImgPath), 720, 705, 60, 100);
        }
    }
}
