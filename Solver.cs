using System;
using System.Collections.Generic;
using Shapes;

namespace Solver {
    static class Solver {
        public static void Main(String[] args) {
            //tester.Tester.Test();
            //return;

            string filepath = args[0];
            double totalArea = 0;
            double totalPerimeter = 0;
            List<Shape> shapesList = new List<Shape>();

            foreach (string line in System.IO.File.ReadLines(filepath)) {
                string[] lineData = line.Split(',');
                string shapeType = lineData[0].ToLower();

                switch (shapeType) {
                    case "Triangle":
                        double sideA = double.Parse(lineData[1]);
                        double sideB = double.Parse(lineData[2]);
                        double sideC = double.Parse(lineData[3]);
                        Triangle triangle = new Triangle(sideA, sideB, sideC);
                        shapesList.Add(triangle);
                        totalArea += triangle.Area();
                        totalPerimeter += triangle.Perimeter();
                        break;

                    case "polygon":
                        double sideLength = double.Parse(lineData[1]);
                        int numFaces = int.Parse(lineData[2]);
                        Polygon polygon = new Polygon(sideLength, numFaces);
                        shapesList.Add(polygon);
                        totalArea += polygon.Area();
                        totalPerimeter += polygon.Perimeter();
                        break;

                    default:
                        Console.WriteLine($"I dont know this shape type '{shapeType}'. I will skip this line.");
                        break;
                }
            }

            Console.WriteLine($"Total area: {totalArea:F2}");
            Console.WriteLine($"Total perimeter: {totalPerimeter:F2}");
            Console.WriteLine("List of shapes:");
            foreach (Shape shape in shapesList) {
                Console.WriteLine($"- {shape.GetType().Name}: area = {shape.Area():F2}, perimeter = {shape.Perimeter():F2}");
            }
        }
    }
}
