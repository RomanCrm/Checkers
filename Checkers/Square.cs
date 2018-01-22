using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Square
    {
        public Brush Brush { get; set; }

        public bool IsChecker { get; set; }

        public Point Location { get; set; }

        public Color CheckerColor { get; set; }
    }
}
