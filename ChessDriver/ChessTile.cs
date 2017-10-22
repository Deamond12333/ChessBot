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
        public List<Pawn> WhitePawns, BlackPawns;
        public List<Rook> WhiteRooks, BlackRooks;
        public List<Bishop> WhiteBishops, BlackBishops;
        public List<Knight> WhiteKnights, BlackKnights;
        public Queen WhiteQueen, BlackQueen;
        public King WhiteKing, BlackKing;
        public bool IsWhite;
        public ChessTile(bool isWhite, double pawnWeight, double rookWeight, double bishopWeight, double knightWeight, double queenWeight, double kingWeight)
        {
            this.IsWhite = isWhite;
            WhitePawns = new List<Pawn>();
            for (int i = 0; i < 8; i++)
            {
                Pawn p = new Pawn();
                p.ImgPath = "addons/pawn_white.png";
                p.Coord = new int[2] { 6, i };
                p.Weight = pawnWeight;
                WhitePawns.Add(p);
            }

            BlackPawns = new List<Pawn>();
            for (int i = 0; i < 8; i++)
            {
                Pawn p = new Pawn();
                p.ImgPath = "addons/pawn_black.png";
                p.Coord = new int[2] { 1, i };
                p.Weight = pawnWeight;
                BlackPawns.Add(p);
            }

            WhiteRooks = new List<Rook>();
            for (int i = 0; i < 8; i+=7)
            {
                Rook r = new Rook();
                r.ImgPath = "addons/rook_white.png";
                r.Coord = new int[2] {7 , i };
                r.Weight = rookWeight;
                WhiteRooks.Add(r);
            }

            BlackRooks = new List<Rook>();
            for (int i = 0; i < 8; i += 7)
            {
                Rook r = new Rook();
                r.ImgPath = "addons/rook_black.png";
                r.Coord = new int[2] { 0, i };
                r.Weight = rookWeight;
                BlackRooks.Add(r);
            }

            WhiteBishops = new List<Bishop>();
            for (int i = 1; i < 8; i += 5)
            {
                Bishop b = new Bishop();
                b.ImgPath = "addons/bishop_white.png";
                b.Coord = new int[2] { 7, i };
                b.Weight = bishopWeight;
                WhiteBishops.Add(b);
            }

            BlackBishops = new List<Bishop>();
            for (int i = 1; i < 8; i += 5)
            {
                Bishop b = new Bishop();
                b.ImgPath = "addons/bishop_black.png";
                b.Coord = new int[2] { 0, i };
                b.Weight = bishopWeight;
                BlackBishops.Add(b);
            }

            WhiteKnights = new List<Knight>();
            for (int i = 2; i < 8; i += 3)
            {
                Knight k = new Knight();
                k.ImgPath = "addons/knight_white.png";
                k.Coord = new int[2] { 7, i };
                k.Weight = knightWeight;
                WhiteKnights.Add(k);
            }

            BlackKnights = new List<Knight>();
            for (int i = 2; i < 8; i += 3)
            {
                Knight k = new Knight();
                k.ImgPath = "addons/knight_black.png";
                k.Coord = new int[2] { 0, i };
                k.Weight = knightWeight;
                BlackKnights.Add(k);
            }

            WhiteQueen = new Queen();
            WhiteQueen.ImgPath = "addons/queen_white.png";
            WhiteQueen.Coord = new int[2] { 7, 3 };
            WhiteQueen.Weight = queenWeight;

            BlackQueen = new Queen();
            BlackQueen.ImgPath = "addons/queen_black.png";
            BlackQueen.Coord = new int[2] { 0, 3 };
            BlackQueen.Weight = queenWeight;

            WhiteKing = new King();
            WhiteKing.ImgPath = "addons/king_white.png";
            WhiteKing.Coord = new int[2] { 7, 4 };
            WhiteKing.Weight = kingWeight;

            BlackKing = new King();
            BlackKing.ImgPath = "addons/king_black.png";
            BlackKing.Coord = new int[2] { 0, 4 };
            BlackKing.Weight = kingWeight;
        }
        public void DoStep()
        {

        }
    }
}
