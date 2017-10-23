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
using ChessDriver.Figures;

namespace ChessBotOnline
{
    public partial class ChessBoard : Form
    {
        ChessTile tile;
        StartSettings ss;
        float BEGIN_X = 422.5f, BEGIN_Y = 57.0f, STEP = 93.5f, END_X = 422.5f + 93.5f * 8, END_Y = 57.0f + 93.5f * 8;
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
            float[] coord;
            foreach(Figure f in tile.Figures)
            {
                coord = getCoordsForDrawing(f.Coord);
                e.Graphics.DrawImage(Image.FromFile(f.ImgPath), coord[0], coord[1], 100, 100);
            }
        }
        private float[] getCoordsForDrawing(int[] chessCoord)
        {
            float[] coord = new float[2];
            coord[0] = BEGIN_X + STEP * chessCoord[0];
            coord[1] = BEGIN_Y + STEP * chessCoord[1];
            return coord;
        }

        private void ChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int[] chessCoord = new int[2];
            chessCoord[0] = (int)((e.X - BEGIN_X) % STEP);
            chessCoord[1] = (int)((e.Y - BEGIN_Y) % STEP);
            Figure f = tile.getFigureFromCoord(chessCoord);
            if (f != null)
            {
                
            }
        }
    }
}
