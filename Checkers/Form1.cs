using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    enum Numbers
    {
        Eight = 8,
        Two = 2,
        Four = 4,
        SizFour = 64
    }

    public partial class Form1 : Form
    {
        Square[] squares;
        Coordinate coordinates;
        SizeSqr sizeSqr;

        Square checkedSquare;
        bool isWhite = true;

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();

            coordinates = new Coordinate();
            sizeSqr = new SizeSqr();

            sizeSqr.Width = ClientSize.Width / (int)Numbers.Eight;
            sizeSqr.Height = ClientSize.Height / (int)Numbers.Eight;

            Paint += Form1_Paint;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (ClientSize.Width > ClientSize.Height)
            {
                ClientSize = new Size(ClientSize.Width, ClientSize.Width);
            }
            else if (ClientSize.Width < ClientSize.Height)
            {
                ClientSize = new Size(ClientSize.Height, ClientSize.Height);
            }
            sizeSqr.Width = ClientSize.Width / (int)Numbers.Eight;
            sizeSqr.Height = ClientSize.Height / (int)Numbers.Eight;

            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Square square in squares)
            {
                if (e.X > square.Location.X && e.Y > square.Location.Y)
                {
                    if (e.X < square.Location.X + sizeSqr.Width && e.Y < square.Location.Y + sizeSqr.Height)
                    {
                        if (square.IsChecker)
                        {
                            if (isWhite && square.CheckerColor == Color.White)
                            {
                                checkedSquare = square;
                                Invalidate();
                                break;
                            }
                            else if (!isWhite && square.CheckerColor == Color.Black)
                            {
                                checkedSquare = square;
                                Invalidate();
                                break;
                            }
                        }
                        else if (!square.IsChecker && checkedSquare != null && square.Brush != Brushes.Bisque)
                        {
                            if (isWhite && checkedSquare.CheckerColor == Color.White)
                            {
                                foreach (Square sqr in squares)
                                {
                                    if (checkedSquare == sqr)
                                    {
                                        sqr.IsChecker = false;
                                        break;
                                    }
                                }
                                square.IsChecker = true;
                                square.CheckerColor = checkedSquare.CheckerColor;
                                Invalidate();
                                checkedSquare = null;
                                isWhite = false;
                                break;
                            }
                            else if (!isWhite && checkedSquare.CheckerColor == Color.Black)
                            {
                                foreach (Square sqr in squares)
                                {
                                    if (checkedSquare == sqr)
                                    {
                                        sqr.IsChecker = false;
                                        break;
                                    }
                                }
                                square.IsChecker = true;
                                square.CheckerColor = checkedSquare.CheckerColor;
                                Invalidate();
                                checkedSquare = null;
                                isWhite = true;
                                break;
                            }
                        }
                    }
                }
            }

        }

        bool isStart = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!isStart)
            {
                squares = Draw.StartDraw(g, squares, coordinates, sizeSqr);

                isStart = true;
            }
            else if (isStart)
            {
                Draw.AnotherDraw(g, coordinates, squares, sizeSqr, checkedSquare);
            }
        }

    }

}
