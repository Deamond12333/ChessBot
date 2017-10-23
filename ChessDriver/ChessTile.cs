using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

using ChessDriver.Figures;
    
namespace ChessDriver
{
    public class ChessTile
    {
        public List<Figure> Figures { get; set; }
        public bool IsWhite;
        public ChessTile(bool isWhite, double pawnWeight, double rookWeight, double bishopWeight, double knightWeight, double queenWeight, double kingWeight)
        {
            this.IsWhite = isWhite;
            Figures = new List<Figure>();
            for (int i = 0; i < 8; i++)
            {
                Pawn p = new Pawn();
                p.ImgPath = "addons/pawn_white.png";
                p.Coord = new int[2] { i, 6 };
                p.Weight = pawnWeight;
                Figures.Add(p);
            }

            for (int i = 0; i < 8; i++)
            {
                Pawn p = new Pawn();
                p.ImgPath = "addons/pawn_black.png";
                p.Coord = new int[2] { i, 1 };
                p.Weight = pawnWeight;
                Figures.Add(p);
            }

            for (int i = 0; i < 8; i+=7)
            {
                Rook r = new Rook();
                r.ImgPath = "addons/rook_white.png";
                r.Coord = new int[2] {i , 7 };
                r.Weight = rookWeight;
                Figures.Add(r);
            }

            for (int i = 0; i < 8; i += 7)
            {
                Rook r = new Rook();
                r.ImgPath = "addons/rook_black.png";
                r.Coord = new int[2] { i, 0 };
                r.Weight = rookWeight;
                Figures.Add(r);
            }

            for (int i = 1; i < 8; i += 5)
            {
                Bishop b = new Bishop();
                b.ImgPath = "addons/bishop_white.png";
                b.Coord = new int[2] { i, 7 };
                b.Weight = bishopWeight;
                Figures.Add(b);
            }

            for (int i = 1; i < 8; i += 5)
            {
                Bishop b = new Bishop();
                b.ImgPath = "addons/bishop_black.png";
                b.Coord = new int[2] { i, 0 };
                b.Weight = bishopWeight;
                Figures.Add(b);
            }

            for (int i = 2; i < 8; i += 3)
            {
                Knight kn = new Knight();
                kn.ImgPath = "addons/knight_white.png";
                kn.Coord = new int[2] { i, 7 };
                kn.Weight = knightWeight;
                Figures.Add(kn);
            }

            for (int i = 2; i < 8; i += 3)
            {
                Knight kn = new Knight();
                kn.ImgPath = "addons/knight_black.png";
                kn.Coord = new int[2] { i, 0 };
                kn.Weight = knightWeight;
                Figures.Add(kn);
            }

            Queen q = new Queen();
            q.ImgPath = "addons/queen_white.png";
            q.Coord = new int[2] { 3, 7 };
            q.Weight = queenWeight;
            Figures.Add(q);

            q = new Queen();
            q.ImgPath = "addons/queen_black.png";
            q.Coord = new int[2] { 3, 0 };
            q.Weight = queenWeight;
            Figures.Add(q);

            King k = new King();
            k.ImgPath = "addons/king_white.png";
            k.Coord = new int[2] { 4, 7 };
            k.Weight = kingWeight;
            Figures.Add(k);

            k = new King();
            k.ImgPath = "addons/king_black.png";
            k.Coord = new int[2] { 4, 0 };
            k.Weight = kingWeight;
            Figures.Add(k);
        }
        public void DoStep()
        {

        }

        public Figure getFigureFromCoord(int[] coord)
        {
            foreach (Figure f in Figures)
            {
                if (f.Coord[0] == coord[0] && f.Coord[1] == coord[1]) return f;
            }
            return null;
        }
    }
}
