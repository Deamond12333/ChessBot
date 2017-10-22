using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ChessDriver
{
    public class Pawn
    {
        public string ImgPath = "";
        public double Weight { get; set; }
        public int[] Coord { get; set; }

        public List<int[]> getAllowedSteps(int[,] tile, int[] coord)
        {

            return null;
        }
    }
}
