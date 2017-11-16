using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Figure
    {
        public bool IsWhite { get; set; }
        public bool IsEaten = false, IsMoved = false;
        public string ImgPath = "";
        public double Weight { get; set; }
        public int[] Coord { get; set; }

        /*public bool Equals(Figure f)
        {
            if (this.Coord[0] != f.Coord[0] && this.Coord[1] != f.Coord[1]) return false;
            if (this.IsWhite != f.IsWhite) return false;
            if (this.IsEaten != f.IsEaten) return false;
            if (this.IsMoved != f.IsMoved) return false;
            if (this.Weight != f.Weight) return false;
            return true;
        }*/
    }
}
