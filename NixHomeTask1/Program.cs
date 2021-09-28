using System;
using System.Collections.Generic;

namespace NixHomeTask1
{

    abstract class Point
    {
        private Single m_x;
        private Single m_y;

        protected Point(Single x, Single y)
        {
            m_x = x;
            m_y = y;
        }


        public Single X
        {
            get => m_x;
            set => m_x = value;
        }

        public Single Y
        {
            get => m_y;
            set => m_y = value;
        }



       
        public abstract void Display();
        public abstract void ScaleFigure(Single scale);

        public abstract void Move(Single x_toMove, Single y_toMove);
    }


    internal class Circle : Point
    {
        private Single m_radius;

        public Circle(Single x, Single y, Single mRadius) : base(x, y)
        {
            this.m_radius = mRadius;
        }

        public Single Radius
        {
            get => m_radius;
            set => m_radius = value;
        }


     

        public override void Display()
        {
            Console.WriteLine($"Circle with center in x-axis = {X} y-axis = {Y} and m_radius = {Radius}");
        }

        public override void ScaleFigure(float scale)
        {
            m_radius *= scale;
        }

        public override void Move(float x_toMove, float y_toMove)
        {
            X += x_toMove;
            Y += y_toMove;
        }
    }


    internal class Rectangle : Point
    {
        private Single d_x;
        private Single d_y;


        public Rectangle(Single x, Single y, Single d_x, Single d_y) : base(x, y)
        {
            this.d_x = d_x;
            this.d_y = d_y;
        }

        public float DX
        {
            get => d_x;
            set => d_x = value;
        }

        public float DY
        {
            get => d_y;
            set => d_y = value;
        }

        public override void Display()
        {
            var displayHelper = new[]
            {
                new {x = 0, y = 0},
                new {x = 0, y = 1},
                new {x = 1, y = 1},
                new {x = 1, y = 0}
            };
            Console.WriteLine("Rectangle with points: ");
            foreach (var item in displayHelper)
            {
                Console.WriteLine($"x-axis = {X + d_x*item.x} y-axis = {Y + d_y *item.y}");
            }
        }

        public override void ScaleFigure(float scale)
        {
            d_x *= scale;
            d_y *= scale;
        }


        public override void Move(float x_toMove, float y_toMove)
        {
            X += x_toMove;
            Y += y_toMove;
        }
    }

    internal class Triangle : Rectangle
    {
        private float d_x2, d_y2;
        public Triangle(float d_x2, float d_y2, float x, float y, float d_x, float d_y) : base(x, y, d_x, d_y)
        {
            this.d_x2 = d_x2;
            this.d_y2 = d_y2;
        }

        public float DX2
        {
            get => d_x2;
            set => d_x2 = value;
        }

        public float DY2
        {
            get => d_y2;
            set => d_y2 = value;
        }

        public override void Display()
        {
            Console.WriteLine($"Triangle with points ");
            Console.WriteLine($"x-axis = {X} y-axis = {Y}");
            Console.WriteLine($"x-axis = {X+DX} y-axis = {Y+DY}");
            Console.WriteLine($"x-axis = {X+d_x2} y-axis = {Y+d_y2}");
        }

        public override void ScaleFigure(float scale)
        {
            base.ScaleFigure(scale);
            d_x2 *= scale;
            d_y2 *= scale;
        }

    }


    class Image : Rectangle
    {
        private List<Point> figures;
        public Image(float x, float y, float d_x, float d_y) : base(x, y, d_x, d_y)
        {
            figures = new List<Point>();
        }

        public void AddFigure(Point p)
        {
            if(p != null) figures.Add(p);
        }

        private bool InsideImage(float x, float y)
        {
            return x >= X && y >= Y && x <= X + DX && y <= Y + DY;
        }

        public override void Display()
        {
            Console.WriteLine("Rectangular image with properties:");
            base.Display();
            foreach (var figure in figures)
            {
                figure.Display();
            }
            {
                
            }
        }

        public override void Move(float x_toMove, float y_toMove)
        {
            foreach (var figure in figures)
            {
                figure.Move(x_toMove, y_toMove);
            }
        }

        
        public override void ScaleFigure(float scale)
        {
            foreach (var figure in figures)
            {
                figure.ScaleFigure(scale);       
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var img = new Image(0, 0, 100, 100);

            img.AddFigure(new Circle(10, 10, 13));
            img.AddFigure(new Triangle(3, 4, 1, 1, 5, 6));
            img.AddFigure(new Rectangle(3, 3, 4, 4));

            img.Move(10, 23);
            img.ScaleFigure(2);

            img.Display();
        }
    }
}