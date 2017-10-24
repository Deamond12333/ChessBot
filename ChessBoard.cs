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
        float BEGIN_X = 421f, BEGIN_Y = 60f, STEP = 94f;
        bool isWhite, botVSbot, botsWar;
        int stepTime;
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
            stepTime = ss.StepTime;
            isWhite = ss.IsWhite;
            botVSbot = ss.BotVSbot;
            botsWar = ss.BotsWar;

            tile = new ChessTile(ss.BotVSbot, ss.IsWhite, ss.PawnWeightOpp1, ss.RookWeightOpp1, ss.BishopWeightOpp1, ss.KnightWeightOpp1, ss.QueenWeightOpp1, ss.KingWeightOpp1, ss.PawnWeightOpp2, ss.RookWeightOpp2, ss.BishopWeightOpp2, ss.KnightWeightOpp2, ss.QueenWeightOpp2, ss.KingWeightOpp2);
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
            List<int[,]> allowedSteps;
            chessCoord[0] = (int)(((e.X - BEGIN_X) - ((e.X - BEGIN_X) % STEP)) / STEP);
            chessCoord[1] = (int)(((e.Y - BEGIN_Y) - ((e.Y - BEGIN_Y) % STEP)) / STEP);
            Figure f = tile.getFigureFromCoord(chessCoord);
            if (f != null)
            {
                switch (f.GetType().ToString())
                {
                    case "ChessDriver.Figures.Pawn":
                        allowedSteps = ((Pawn)f).getAllowedSteps(tile.Figures, f);
                        break;

                    case "ChessDriver.Figures.Knight":
                        f = (Knight)f; break;

                    case "ChessDriver.Figures.King":
                        f = (King)f; break;

                    case "ChessDriver.Figures.Bishop":
                        f = (Bishop)f; break;

                    case "ChessDriver.Figures.Queen":
                        f = (Queen)f; break;

                    case "ChessDriver.Figures.Rook":
                        f = (Rook)f; break;

                }
            }
        }
    }
}
