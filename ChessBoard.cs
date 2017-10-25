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
        const float BEGIN_X = 421f, BEGIN_Y = 60f, STEP = 94f;
        bool isWhite, botVSbot, botsWar;
        int stepTime;
        Figure selectFigure = new Figure();
        Dictionary<string, float[]> drawCoordBuffer = new Dictionary<string, float[]>();
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
            if (drawCoordBuffer.Count > 0)
            {
                foreach(KeyValuePair<string, float[]> p in drawCoordBuffer)
                {
                    if (p.Key.Equals("rectangle"))
                    {
                        e.Graphics.DrawRectangle(new Pen(Brushes.Red, 5), p.Value[0], p.Value[1], STEP, STEP);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(Brushes.Red, p.Value[0], p.Value[1], 10, 10);
                    }
                }
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
            int[] clickCoord = new int[2];
            List<int[]> allowedSteps = new List<int[]>();
            clickCoord[0] = (int)(((e.X - BEGIN_X) - ((e.X - BEGIN_X) % STEP)) / STEP);
            clickCoord[1] = (int)(((e.Y - BEGIN_Y) - ((e.Y - BEGIN_Y) % STEP)) / STEP);
            Figure f = tile.getFigureFromCoord(clickCoord);
            if (f != null && !selectFigure.Equals(f))
            {
                drawCoordBuffer.Clear();
                selectFigure = f;
                switch (f.GetType().ToString())
                {
                    case "ChessDriver.Figures.Pawn":

                        allowedSteps = ((Pawn)f).getAllowedSteps(tile.Figures, f);
                        break;

                    case "ChessDriver.Figures.Knight":
                        allowedSteps = ((Knight)f).getAllowedSteps(tile.Figures, f);
                        break;

                    case "ChessDriver.Figures.King":
                        allowedSteps = ((King)f).getAllowedSteps(tile.Figures, f);
                        break;

                    case "ChessDriver.Figures.Bishop":
                        allowedSteps = ((Bishop)f).getAllowedSteps(tile.Figures, f);
                        break;

                    case "ChessDriver.Figures.Queen":
                        allowedSteps = ((Queen)f).getAllowedSteps(tile.Figures, f);
                        break;

                    case "ChessDriver.Figures.Rook":
                        allowedSteps = ((Rook)f).getAllowedSteps(tile.Figures, f);
                        break;
                }

                float[] coordForFigureBorder = getCoordsForDrawing(f.Coord);
                drawCoordBuffer.Add("rectangle", new float[2] { coordForFigureBorder[0] + 2, coordForFigureBorder[1] + 4 });
                foreach (int[] coord in allowedSteps)
                {
                    float[] coordForDrawSteps = getCoordsForDrawing(coord);
                    drawCoordBuffer.Add("point"+allowedSteps.IndexOf(coord), new float[2] { coordForDrawSteps[0] + STEP / 2, coordForDrawSteps[1] + STEP / 2 });
                }
            }
            else if (selectFigure.Equals(f))
            {
                drawCoordBuffer.Clear();
                selectFigure = new Figure();
            }
            else
            {
                foreach (KeyValuePair<string, float[]> p in drawCoordBuffer)
                {
                    if (!p.Key.Equals("rectangle"))
                    {
                        float[] coords = getCoordsForDrawing(clickCoord);
                        if (p.Value[0] - STEP / 2 == coords[0] && p.Value[1] - STEP / 2 == coords[1])
                        {
                            selectFigure.Coord = clickCoord;
                            selectFigure = new Figure();
                            drawCoordBuffer.Clear();
                            break;
                        }
                    }
                }
            }
            Refresh();

        }
    }
}
