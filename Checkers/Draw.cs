using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Draw
    {
        static public Square[] StartDraw(Graphics g, Square[] squares, Coordinate coordinates, SizeSqr sizeSqr)
        {
            squares = new Square[(int)Numbers.SizFour];
            int counter = -1;

            coordinates.X = 0;
            coordinates.Y = 0;

            for (int i = 0; i < (int)Numbers.Eight; i++)
            {
                for (int j = 0; j < (int)Numbers.Eight; j++)
                {
                    counter++;
                    Square square = new Square { Location = new Point(coordinates.X, coordinates.Y) };
                    if ((i + j) % (int)Numbers.Two == 0)
                    {
                        square.Brush = Brushes.Bisque;
                    }
                    else
                    {
                        square.Brush = Brushes.Brown;
                    }
                    g.FillRectangle(square.Brush, square.Location.X, square.Location.Y, sizeSqr.Width, sizeSqr.Height);

                    if (!square.IsChecker)
                    {
                        if (i < 3)
                        {
                            square.CheckerColor = Color.White;
                            if (square.Brush == Brushes.Brown)
                            {
                                g.FillEllipse(Brushes.White, square.Location.X + sizeSqr.Width / (int)Numbers.Four, square.Location.Y + sizeSqr.Height / (int)Numbers.Four,
                                              sizeSqr.Width / (int)Numbers.Two, sizeSqr.Height / (int)Numbers.Two);
                                square.IsChecker = true;
                            }
                        }
                        else if (i < 9 && i > 4)
                        {
                            square.CheckerColor = Color.Black;
                            if (square.Brush == Brushes.Brown)
                            {
                                g.FillEllipse(Brushes.Black, square.Location.X + sizeSqr.Width / (int)Numbers.Four, square.Location.Y + sizeSqr.Height / (int)Numbers.Four,
                                              sizeSqr.Width / (int)Numbers.Two, sizeSqr.Height / (int)Numbers.Two);
                                square.IsChecker = true;
                            }
                        }
                    }

                    squares[counter] = square;
                    coordinates.X += sizeSqr.Width;
                }
                coordinates.X = 0;
                coordinates.Y += sizeSqr.Height;
            }

            return squares;
        }

        static public void AnotherDraw(Graphics g, Coordinate coordinates, Square[] squares, SizeSqr sizeSqr, Square checkedSquare)
        {
            coordinates.X = 0;
            coordinates.Y = 0;

            int counter = -1;

            for (int i = 0; i < (int)Numbers.Eight; i++)
            {
                for (int j = 0; j < (int)Numbers.Eight; j++)
                {
                    counter++;
                    squares[counter].Location = new Point(coordinates.X, coordinates.Y);

                    g.FillRectangle(squares[counter].Brush, squares[counter].Location.X, squares[counter].Location.Y, sizeSqr.Width, sizeSqr.Height);

                    if (squares[counter].IsChecker)
                    {
                        Brush brush = new SolidBrush(squares[counter].CheckerColor);
                        g.FillEllipse(brush, squares[counter].Location.X + sizeSqr.Width / (int)Numbers.Four, squares[counter].Location.Y + sizeSqr.Height / (int)Numbers.Four,
                                         sizeSqr.Width / (int)Numbers.Two, sizeSqr.Height / (int)Numbers.Two);
                    }

                    coordinates.X += sizeSqr.Width;
                }
                coordinates.X = 0;
                coordinates.Y += sizeSqr.Height;
            }

            if (checkedSquare != null)
            {
                g.DrawRectangle(new Pen(Color.Yellow, 5), checkedSquare.Location.X, checkedSquare.Location.Y, sizeSqr.Width, sizeSqr.Height);
            }
        }
    }
}
