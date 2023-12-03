public class Shape
{
    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Shape(string color)
    {
        Color = color;
    }

    public Shape()
    {
    }

    public virtual double GetArea()
    {
        return 0; // Default implementation for the base class
    }
}


public class Square : Shape
{
    private double side;

    public double Side
    {
        get { return side; }
        set { side = value; }
    }

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side; // Area calculation specific to a square
    }
}

public class Rectangle : Shape
{
    private double length;
    private double width;

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public Rectangle(string color, double length, double width) : base(color)
    {
        Length = length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width; // Area calculation specific to a rectangle
    }
}


public class Circle : Shape
{
    private double radius;

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius; // Area calculation specific to a circle
    }
}




class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}
