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
        List<Step> allowedSteps = new List<Step>();
        const float BEGIN_X = 421f, BEGIN_Y = 60f, STEP = 94f;
        bool isWhite, botVSbot, botsWar;
        int stepTime;
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
                if (f.IsEaten) continue;
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
        private float[] getCoordsForDrawing(Step step)
        {
            float[] coord = new float[2];
            coord[0] = BEGIN_X + STEP * step.X;
            coord[1] = BEGIN_Y + STEP * step.Y;
            return coord;
        }

        private float[] getCoordsForDrawing(int[] c)
        {
            float[] coord = new float[2];
            coord[0] = BEGIN_X + STEP * c[0];
            coord[1] = BEGIN_Y + STEP * c[1];
            return coord;
        }

        private Step getStepFromCoord(int[] coord)
        {
            if (allowedSteps.Count == 0) return null;
            foreach(Step s in allowedSteps)
            {
                if (s.X == coord[0] && s.Y == coord[1]) return s;
            }
            return null;
        }
        private void ChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int[] clickCoord = new int[2];
            clickCoord[0] = (int)(((e.X - BEGIN_X) - ((e.X - BEGIN_X) % STEP)) / STEP);
            clickCoord[1] = (int)(((e.Y - BEGIN_Y) - ((e.Y - BEGIN_Y) % STEP)) / STEP);
            Step qurStep = getStepFromCoord(clickCoord);
            if (qurStep != null)
            {
                qurStep.doStep(tile.Figures);
                if (drawCoordBuffer.Count > 0) drawCoordBuffer.Clear();
                if (allowedSteps.Count > 0) allowedSteps.Clear();
            }
            else
            {
                if (drawCoordBuffer.Count > 0)
                {
                    drawCoordBuffer.Clear();
                    Refresh();
                    return;
                }
                Figure qurF = tile.getFigureFromCoord(clickCoord);
                if (qurF == null) return;
                // если мы щёлкнули по фигуре
                switch (qurF.GetType().ToString())
                {
                    case "ChessDriver.Figures.Pawn":
                        allowedSteps = ((Pawn)qurF).getAllowedSteps(tile.Figures);
                        break;

                    case "ChessDriver.Figures.Knight":
                        allowedSteps = ((Knight)qurF).getAllowedSteps(tile.Figures);
                        break;

                    case "ChessDriver.Figures.King":
                        allowedSteps = ((King)qurF).getAllowedSteps(tile.Figures);
                        break;

                    case "ChessDriver.Figures.Bishop":
                        allowedSteps = ((Bishop)qurF).getAllowedSteps(tile.Figures);
                        break;

                    case "ChessDriver.Figures.Queen":
                        allowedSteps = ((Queen)qurF).getAllowedSteps(tile.Figures);
                        break;

                    case "ChessDriver.Figures.Rook":
                        allowedSteps = ((Rook)qurF).getAllowedSteps(tile.Figures);
                        break;
                }
                float[] coordForFigureBorder = getCoordsForDrawing(qurF.Coord);
                drawCoordBuffer.Add("rectangle", new float[2] { coordForFigureBorder[0] + 2, coordForFigureBorder[1] + 4 });
                foreach (Step step in allowedSteps)
                {
                    float[] coordForDrawSteps = getCoordsForDrawing(step);
                    drawCoordBuffer.Add("point" + allowedSteps.IndexOf(step), new float[2] { coordForDrawSteps[0] + STEP / 2, coordForDrawSteps[1] + STEP / 2 });
                }
            }
            Refresh();
        }
    }
}
