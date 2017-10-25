using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class King:Figure
    {
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            //обработать рокировку
            List<int[]> allowedSteps = new List<int[]>();

            //ищем ход вниз вправо
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] + 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[0] + 1 < 8 && f.Coord[1] + 1 < 8) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] + 1 });
            //ищем ход вниз влево
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] + 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[0] - 1 > -1 && f.Coord[1] + 1 < 8) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] + 1 });
            //ищем ход вверх вправо
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] - 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[0] + 1 < 8 && f.Coord[1] - 1 > -1) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] - 1 });
            //ищем ход верх влево
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] - 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[0] - 1 > -1 && f.Coord[1] - 1 > -1) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] - 1 });
            //ищем ход вправо
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[0] == f.Coord[0] + 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[0] + 1 < 8) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] });
            //ищем ход влево
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[0] == f.Coord[0] - 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[0] - 1 > -1) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] });
            //ищем ход верх
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[1] == f.Coord[1] - 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[1] - 1 > -1) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] - 1 });
            //ищем ход вниз
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[1] == f.Coord[1] + 1 && f1.IsWhite == !f.IsWhite) break;
            }
            if (f.Coord[1] + 1 < 8) //если мы не выходим за границы поля
                allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + 1 });

            return allowedSteps;
        }
    }
}
