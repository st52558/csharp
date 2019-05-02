using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Galcon
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer cpuTimer = new DispatcherTimer();
        List<Planet> planets = new List<Planet>();
        List<SpaceShip> ships = new List<SpaceShip>();
        List<Point> currentPath = new List<Point>();
        Random random;
        Planet hoveredPlanet = null;
        Planet departurePlanet = null;
        Planet aiDeparturePlanet = null;
        int percentageOfUnits = 50;

        public MainWindow()
        {

            InitializeComponent();

        }



        private void CreatePlanets()
        {

            random = new Random(220);
            NewUserPlanet();
            NewAIPlanet();
            NewNeutralPlanets();
            //CreatePaths();
            DrawAll();
        }


        private void CreatePaths()
        {
            for (int i = 0; i < planets.Count; i++)
            {
                for (int j = i + 1; j < planets.Count; j++)
                {
                    CreatePath(planets.ElementAt(i), planets.ElementAt(j));
                }
            }
        }

        private bool Collision(Planet a, Planet b)
        {
            double distance = Math.Sqrt((a.Position.X - b.Position.X) * (a.Position.X - b.Position.X) + (a.Position.Y - b.Position.Y) * (a.Position.Y - b.Position.Y));
            double planetsSum = (a.ObjectSize + b.ObjectSize) * 1.4;
            return distance < planetsSum;
        }

        private void NewAIPlanet()
        {
            bool collision = false;
            int size, x, y;
            Planet planet;
            do
            {
                collision = false;
                size = random.Next(16, 49)*2;
                x = random.Next(0, (int)(750 - size));
                y = random.Next(0, (int)(400 - size));
                planet = new Planet(Color.FromRgb(50, 50, 220), size, new Point(x, y));
                for (int j = 0; j < planets.Count; j++)
                {
                    if (Collision(planet, planets.ElementAt(j)))
                    {
                        collision = true;
                    }
                }
            } while (collision);
            planets.Add(planet);
        }

        private void NewUserPlanet()
        {
            int size, x, y;
            size = random.Next(16, 49) * 2;
            x = random.Next(0, (int)(750 - size));
            y = random.Next(0, (int)(400 - size));
            planets.Add(new Planet(Color.FromRgb(200, 0, 0), size, new Point(x, y)));
        }

        private void NewNeutralPlanets()
        {
            Planet planet;
            bool collision = false;
            int size, x, y;
            for (int i = 0; i < 12; i++)
            {
                do
                {
                    collision = false;
                    size = random.Next(16,49)*2;
                    x = random.Next(0, (int)(750 - size));
                    y = random.Next(0, (int)(400 - size));
                    planet = new Planet(Color.FromRgb(125, 125, 125), size, new Point(x, y));
                    for (int j = 0; j < planets.Count; j++)
                    {
                        if (Collision(planet, planets.ElementAt(j)))
                        {
                            collision = true;
                        }
                    }
                } while (collision);
                planets.Add(planet);
            }

        }

        private void DrawAll()
        {
            canvas.Children.Clear();
            for (int i = 0; i < planets.Count; i++)
            {
                Ellipse myEllipse = new Ellipse();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = planets.ElementAt(i).Owner;
                if (planets.ElementAt(i) == departurePlanet || planets.ElementAt(i) == hoveredPlanet)
                {
                    mySolidColorBrush.Color = Color.FromRgb(200, 200, 20);
                }
                myEllipse.Fill = mySolidColorBrush;
                myEllipse.Stroke = Brushes.Black;
                myEllipse.StrokeThickness = 0;
                myEllipse.Width = planets.ElementAt(i).ObjectSize;
                myEllipse.Height = planets.ElementAt(i).ObjectSize;
                myEllipse.Margin = new Thickness(planets.ElementAt(i).Position.X, planets.ElementAt(i).Position.Y, 0, 0);
                myEllipse.MouseLeftButtonDown += ClickLeft;
                myEllipse.MouseRightButtonDown += ClickRight;
                myEllipse.MouseEnter += EnterMouse;
                myEllipse.MouseLeave += LeaveMouse;
                
                canvas.Children.Add(myEllipse);
                TextBlock planetLabel = new TextBlock();
                planetLabel.Text = planets.ElementAt(i).NumberOfUnits.ToString();
                planetLabel.Width = planets.ElementAt(i).ObjectSize;
                planetLabel.TextAlignment = TextAlignment.Center;
                planetLabel.Margin = new Thickness(planets.ElementAt(i).Position.X, planets.ElementAt(i).Position.Y + planets.ElementAt(i).ObjectSize / 2, 0, 0);
                planetLabel.MouseLeftButtonDown += ClickLeftLabel;
                planetLabel.MouseRightButtonDown += ClickRightLabel;
                planetLabel.MouseEnter += EnterMouseLabel;
                planetLabel.MouseLeave += LeaveMouseLabel;

                canvas.Children.Add(planetLabel);

                for (int j = 0; j < 32; j++)
                {
                    Ellipse borderPoint = new Ellipse();
                    borderPoint.Width = 1;
                    borderPoint.Height = 1;
                    borderPoint.Margin = new Thickness(planets.ElementAt(i).ContactPoints.ElementAt(j).X, planets.ElementAt(i).ContactPoints.ElementAt(j).Y, 0, 0);
                    borderPoint.StrokeThickness = 2;
                    SolidColorBrush cBrush = new SolidColorBrush();
                    cBrush.Color = Color.FromRgb(0, 0, 0);
                    borderPoint.Fill = cBrush;
                    canvas.Children.Add(borderPoint);
                    Ellipse contactPoint = new Ellipse();
                    contactPoint.Width = 1;
                    contactPoint.Height = 1;
                    contactPoint.Margin = new Thickness(planets.ElementAt(i).RoundPoints.ElementAt(j).X, planets.ElementAt(i).RoundPoints.ElementAt(j).Y, 0, 0);
                    contactPoint.StrokeThickness = 2;
                    contactPoint.Fill = cBrush;
                    canvas.Children.Add(contactPoint);
                }
            }
            for (int i = 0; i < ships.Count; i++)
            {
                Ellipse ship = new Ellipse();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = ships.ElementAt(i).Owner;
                ship.Fill = brush;
                ship.Width = 5;
                ship.Height = 5;
                ship.Margin = new Thickness(ships.ElementAt(i).Position.X, ships.ElementAt(i).Position.Y, 0, 0);
                canvas.Children.Add(ship);
            }
            currentPath.Clear();
            if (departurePlanet != null && hoveredPlanet != null)
            {
             
                        currentPath = getPath(departurePlanet,hoveredPlanet);
               
                for (int i = 0; i < currentPath.Count; i++)
                {
                    if (i % 10 == 0)
                    {
                        Ellipse pathFragment = new Ellipse();
                        pathFragment.Fill = Brushes.Black;
                        pathFragment.Width = 2;
                        pathFragment.Height = 2;
                        pathFragment.Margin = new Thickness(currentPath.ElementAt(i).X, currentPath.ElementAt(i).Y, 0, 0);
                        canvas.Children.Add(pathFragment);
                    }

                }
            }
            
            
        }

        private void LeaveMouseLabel(object sender, MouseEventArgs e)
        {
            hoveredPlanet = null;
        }

        private void EnterMouseLabel(object sender, MouseEventArgs e)
        {
            
                TextBlock l = (TextBlock)sender;
                for (int i = 0; i < planets.Count; i++)
                {
                    if (planets.ElementAt(i).Position.Y + planets.ElementAt(i).ObjectSize / 2 == l.Margin.Top && planets.ElementAt(i).Position.X == l.Margin.Left)
                    {
                        hoveredPlanet = planets.ElementAt(i);
                    }
                }
            
        }

        private void LeaveMouse(object sender, MouseEventArgs e)
        {
            hoveredPlanet = null;
        }

        private void EnterMouse(object sender, MouseEventArgs e)
        {
            Ellipse current = (Ellipse)sender;
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets.ElementAt(i).Position.Y == current.Margin.Top && planets.ElementAt(i).Position.X == current.Margin.Left)
                {
                    hoveredPlanet = planets.ElementAt(i);
                }
            }
        }

        private void ClickRightLabel(object sender, MouseButtonEventArgs e)
        {

            if (departurePlanet != null)
            {
                TextBlock l = (TextBlock)sender;
                for (int i = 0; i < planets.Count; i++)
                {
                    if (planets.ElementAt(i).Position.Y + planets.ElementAt(i).ObjectSize / 2 == l.Margin.Top && planets.ElementAt(i).Position.X == l.Margin.Left)
                    {
                        int units = departurePlanet.NumberOfUnits * percentageOfUnits / 100;
                        ships.Add(new SpaceShip(departurePlanet, planets.ElementAt(i), units, getPath(departurePlanet, planets.ElementAt(i))));
                    }
                }
            }
        }

        private void ClickLeftLabel(object sender, MouseButtonEventArgs e)
        {
            
            TextBlock l = (TextBlock)sender;
            foreach (Ellipse c in canvas.Children.OfType<Ellipse>())
            {
                if (c.Margin == l.Margin)
                {

                    for (int i = 0; i < planets.Count; i++)
                    {
                        if (planets.ElementAt(i).Position.Y + planets.ElementAt(i).ObjectSize / 2 == c.Margin.Top && planets.ElementAt(i).Position.X == c.Margin.Left && planets.ElementAt(i).Owner.Equals(Color.FromRgb(200, 0, 0)))
                        {
                            departurePlanet = planets.ElementAt(i);
                            c.StrokeThickness = 2;

                        }
                    }
                }
                else
                {
                    c.StrokeThickness = 0;
                }
            }
        }

        private void ClickRight(object sender, MouseButtonEventArgs e)
        {
            List<Point> list = new List<Point>();
            if (departurePlanet != null)
            {
                Ellipse c = (Ellipse)sender;
                for (int i = 0; i < planets.Count; i++)
                {
                    if (planets.ElementAt(i).Position.Y == c.Margin.Top && planets.ElementAt(i).Position.X == c.Margin.Left)
                    {
                        int units = departurePlanet.NumberOfUnits * percentageOfUnits / 100;
                        ships.Add(new SpaceShip(departurePlanet, planets.ElementAt(i), units, getPath(departurePlanet, planets.ElementAt(i))));
                        //list = getPath(departurePlanet, planets.ElementAt(i));
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list.ElementAt(i));
                }


            }

        }

        private List<Point> getPath(Planet departurePlanet, Planet planet)
        {
            Polyline line = new Polyline();
            List<Point> list = new List<Point>();
            list = CreatePath(departurePlanet, planet);

            line.StrokeThickness = 1;
            line.Stroke = Brushes.Black;
            canvas.Children.Add(line);
            return list;
        }

        private void ClickLeft(object sender, MouseButtonEventArgs e)
        {
            
            Ellipse current = (Ellipse)sender;
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets.ElementAt(i).Position.Y == current.Margin.Top && planets.ElementAt(i).Position.X == current.Margin.Left && planets.ElementAt(i).Owner.Equals(Color.FromRgb(200, 0, 0)))
                {
                    departurePlanet = planets.ElementAt(i);
                }
            }


        }


        private List<Point> CreatePath(Planet a, Planet b)
        {
            List<Point> path = new List<Point>();
            bool noCollision = false;
            Point[] points = new Point[2];
            Point[] fastestPoints = new Point[2];
            double distance = double.MaxValue;
            for (int i = 0; i < a.ContactPoints.Count; i++)
            {
                for (int j = 0; j < b.ContactPoints.Count; j++)
                {
                    double tempDistance = DistanceBetweenPoints(a.ContactPoints.ElementAt(i), b.ContactPoints.ElementAt(j));
                    
                    if (tempDistance < distance)
                    {
                        fastestPoints[0] = a.ContactPoints.ElementAt(i);
                        fastestPoints[1] = b.ContactPoints.ElementAt(j);
                        if (!CheckCollision(a.ContactPoints.ElementAt(i), b.ContactPoints.ElementAt(j), b))
                        {
                            distance = tempDistance;
                            points[0] = a.ContactPoints.ElementAt(i);
                            points[1] = b.ContactPoints.ElementAt(j);
                            noCollision = true;
                        }
                    }
                }
            }
            if (!noCollision)
            {
                List<Planet> collisionPlanets = GetCollisionPlanets(fastestPoints[0], fastestPoints[1],b);
                if (collisionPlanets.Count > 0)
                {
                   path = CreateCollisionPath(collisionPlanets, b);
                }
                    
                
                
            } else
            {
                Vector vec = new Vector(points[0].X - points[1].X, points[0].Y - points[1].Y);
                double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
                if (vec.Y < 0)
                {
                    angle = Math.PI + (Math.PI - angle);
                }
                for (int i = 0; i < distance; i++)
                {
                    Point p = new Point(points[0].X + i * Math.Cos(angle) * -1, points[0].Y + i * Math.Sin(angle) * -1);


                    path.Add(p);

                }
            }

            return path;

        }

        private List<Point> CreateCollisionPath(List<Planet> collisionPlanets, Planet endPlanet)
        {
            List<Point> path = new List<Point>();
            List<Point> temp = new List<Point>();
            for (int i = 0; i < collisionPlanets.Count; i++)
            {
                if (i == 0)
                {
                    temp.AddRange(PathFromDepartureToCollision(collisionPlanets.ElementAt(i)));
                    path.AddRange(temp);
                }
                Point roundPoint1 = temp.ElementAt(temp.Count - 1);
                temp.Clear();
                if (i+1 < collisionPlanets.Count)
                {
                    temp.AddRange(PathFromCollisionToCollision(collisionPlanets.ElementAt(i), collisionPlanets.ElementAt(i + 1)));
                } else
                {
                    temp.AddRange(PathFromCollisionToEnd(collisionPlanets.ElementAt(i), endPlanet));
                }

                Point roundPoint2 = temp.ElementAt(0);
                path.AddRange(CreateRoundPath(roundPoint1, roundPoint2, collisionPlanets.ElementAt(i)));
                path.AddRange(temp);
            }
            return path;
        }

        private List<Point> CreateRoundPath(Point roundPoint1, Point roundPoint2, Planet planet)
        {
            Point roundPointFrom = new Point();
            roundPointFrom.X = (int)roundPoint1.X;
            roundPointFrom.Y = (int)roundPoint1.Y;
            Point roundFromTo = new Point();
            roundFromTo.X = (int)roundPoint2.X;
            roundFromTo.Y = (int)roundPoint2.Y;
            Console.WriteLine(roundPointFrom);
            Console.WriteLine(roundFromTo);
            List<Point> listOfPoints = new List<Point>();
            int indexFrom=-1, indexTo=-1;
            for (int i = 0; i < planet.RoundPoints.Count; i++)
            {
                Console.WriteLine(planet.RoundPoints.ElementAt(i));
                
                if ((roundPointFrom.X == planet.RoundPoints.ElementAt(i).X || roundPointFrom.X+1 == planet.RoundPoints.ElementAt(i).X || roundPointFrom.X-1 == planet.RoundPoints.ElementAt(i).X)
                    && (roundPointFrom.Y == planet.RoundPoints.ElementAt(i).Y || roundPointFrom.Y + 1 == planet.RoundPoints.ElementAt(i).Y || roundPointFrom.Y - 1 == planet.RoundPoints.ElementAt(i).Y))
                {
                    indexFrom = i;
                } else if ((roundFromTo.X == planet.RoundPoints.ElementAt(i).X || roundFromTo.X + 1 == planet.RoundPoints.ElementAt(i).X || roundFromTo.X - 1 == planet.RoundPoints.ElementAt(i).X)
                    && (roundFromTo.Y == planet.RoundPoints.ElementAt(i).Y || roundFromTo.Y + 1 == planet.RoundPoints.ElementAt(i).Y || roundFromTo.Y - 1 == planet.RoundPoints.ElementAt(i).Y))
                {
                    indexTo = i;
                }
                if (indexFrom != -1 && indexTo != -1)
                {
                    
                    break; 
                }
            }
            if (indexFrom == -1 || indexTo == -1)
            {
                return listOfPoints;
            }
            
            Console.WriteLine(indexFrom + " ez " + indexTo);
            if (Math.Abs(indexFrom - indexTo) < 17)
            {
                if (indexFrom > indexTo )
                {
                    while (indexFrom != indexTo)
                    {
                        listOfPoints.AddRange(PathBetweenPoints(planet.RoundPoints.ElementAt(indexFrom), planet.RoundPoints.ElementAt(indexFrom-1)));
                        indexFrom--;
                    }
                        
                } else
                {
                    while (indexFrom != indexTo)
                    {
                        listOfPoints.AddRange(PathBetweenPoints(planet.RoundPoints.ElementAt(indexFrom), planet.RoundPoints.ElementAt(indexFrom+1)));
                        indexFrom++;
                    }
                }
            } else
            {
                bool typeOfCounting = false;
                if (indexFrom > indexTo)
                {
                    typeOfCounting = true;
                }
                
                while (indexFrom != indexTo)
                {
                    
                    if (typeOfCounting) //budu přičítat
                    {
                        
                        if (indexFrom == 31)
                        {
                            listOfPoints.AddRange(PathBetweenPoints(planet.RoundPoints.ElementAt(indexFrom), planet.RoundPoints.ElementAt(0)));
                            indexFrom = 0;
                        } else
                        {
                            listOfPoints.AddRange(PathBetweenPoints(planet.RoundPoints.ElementAt(indexFrom), planet.RoundPoints.ElementAt(indexFrom + 1)));
                            indexFrom++;
                        }

                    } else
                    {
                        if (indexFrom == 0)
                        {
                            listOfPoints.AddRange(PathBetweenPoints(planet.RoundPoints.ElementAt(indexFrom), planet.RoundPoints.ElementAt(31)));
                            indexFrom = 31;
                        }
                        else
                        {
                            listOfPoints.AddRange(PathBetweenPoints(planet.RoundPoints.ElementAt(indexFrom), planet.RoundPoints.ElementAt(indexFrom - 1)));
                            indexFrom--;
                        }
                    }
                }
            }
            return listOfPoints;
        }

        private List<Point> PathBetweenPoints(Point point1, Point point2)
        {
            List<Point> listOfPoints = new List<Point>();
            Vector vec = new Vector(point1.X - point2.X, point1.Y - point2.Y);
            double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
            int distance = (int)DistanceBetweenPoints(point1, point2);
            if (vec.Y < 0)
            {
                angle = Math.PI + (Math.PI - angle);
            }

            for (int i = 0; i < distance; i++)
            {
                Point p = new Point(point1.X + i * Math.Cos(angle) * -1, point1.Y + i * Math.Sin(angle) * -1);
                listOfPoints.Add(p);
            }
            return listOfPoints;
        }

        private List<Point> PathFromCollisionToEnd(Planet a, Planet b)
        {
            List<Point> listOfPoints = new List<Point>();
            //zjištění bodů
            Point[] points = new Point[2];
            double distance = double.MaxValue;
            for (int i = 0; i < a.RoundPoints.Count; i++)
            {
                for (int j = 0; j < b.ContactPoints.Count; j++)
                {
                    double tempDistance = DistanceBetweenPoints(a.RoundPoints.ElementAt(i), b.ContactPoints.ElementAt(j));

                    if (tempDistance < distance)
                    {

                        if (!CheckCollision(a.RoundPoints.ElementAt(i), b.ContactPoints.ElementAt(j), b))
                        {
                            distance = tempDistance;
                            points[0] = a.RoundPoints.ElementAt(i);
                            points[1] = b.ContactPoints.ElementAt(j);
                        }
                    }
                }
            }
            //přidání cesty
            Vector vec = new Vector(points[0].X - points[1].X, points[0].Y - points[1].Y);
            double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
            if (vec.Y < 0)
            {
                angle = Math.PI + (Math.PI - angle);
            }
            for (int i = 0; i < distance; i++)
            {
                Point p = new Point(points[0].X + i * Math.Cos(angle) * -1, points[0].Y + i * Math.Sin(angle) * -1);
                listOfPoints.Add(p);
            }
            return listOfPoints;
        }

        private List<Point> PathFromCollisionToCollision(Planet a, Planet b)
        {
            List<Point> listOfPoints = new List<Point>();
            //zjištění bodů
            Point[] points = new Point[2];
            double distance = double.MaxValue;
            for (int i = 0; i < a.RoundPoints.Count; i++)
            {
                for (int j = 0; j < b.RoundPoints.Count; j++)
                {
                    double tempDistance = DistanceBetweenPoints(a.RoundPoints.ElementAt(i), b.RoundPoints.ElementAt(j));

                    if (tempDistance < distance)
                    {

                        if (!CheckCollision(a.RoundPoints.ElementAt(i), b.RoundPoints.ElementAt(j), b))
                        {
                            distance = tempDistance;
                            points[0] = a.RoundPoints.ElementAt(i);
                            points[1] = b.RoundPoints.ElementAt(j);
                        }
                    }
                }
            }
            //přidání cesty
            Vector vec = new Vector(points[0].X - points[1].X, points[0].Y - points[1].Y);
            double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
            if (vec.Y < 0)
            {
                angle = Math.PI + (Math.PI - angle);
            }
            for (int i = 0; i < distance; i++)
            {
                Point p = new Point(points[0].X + i * Math.Cos(angle) * -1, points[0].Y + i * Math.Sin(angle) * -1);
                listOfPoints.Add(p);
            }
            return listOfPoints;
        }

        private List<Point> PathFromDepartureToCollision(Planet b)
        {
            List<Point> listOfPoints = new List<Point>();
            //zjištění bodů
            Point[] points = new Point[2];
            double distance = double.MaxValue;
            for (int i = 0; i < departurePlanet.ContactPoints.Count; i++)
            {
                for (int j = 0; j < b.RoundPoints.Count; j++)
                {
                    double tempDistance = DistanceBetweenPoints(departurePlanet.ContactPoints.ElementAt(i), b.RoundPoints.ElementAt(j));

                    if (tempDistance < distance)
                    {
                        
                        if (!CheckCollision(departurePlanet.ContactPoints.ElementAt(i), b.RoundPoints.ElementAt(j), b))
                        {
                            distance = tempDistance;
                            points[0] = departurePlanet.ContactPoints.ElementAt(i);
                            points[1] = b.RoundPoints.ElementAt(j);
                        }
                    }
                }
            }
            //přidání cesty
            Vector vec = new Vector(points[0].X - points[1].X, points[0].Y - points[1].Y);
            double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
            if (vec.Y < 0)
            {
                angle = Math.PI + (Math.PI - angle);
            }
            for (int i = 0; i < distance; i++)
            {
                Point p = new Point(points[0].X + i * Math.Cos(angle) * -1, points[0].Y + i * Math.Sin(angle) * -1);
                listOfPoints.Add(p);
            }
            return listOfPoints;
        }

        private List<Planet> GetCollisionPlanets(Point from, Point to, Planet endPlanet)
        {
            List<Planet> collisionPlanets = new List<Planet>();
            Vector vec = new Vector(from.X - to.X, from.Y - to.Y);
            double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
            if (vec.Y < 0)
            {
                angle = Math.PI + (Math.PI - angle);
            }
            int distance = (int)DistanceBetweenPoints(from, to);
            for (int i = 0; i < distance; i++)
            {
                Point p = new Point(from.X + i * Math.Cos(angle) * -1, from.Y + i * Math.Sin(angle) * -1);
                if (i % 10 == 0)
                {
                    for (int j = 0; j < planets.Count; j++)
                    {
                        Point center = new Point(planets.ElementAt(j).Position.X + planets.ElementAt(j).ObjectSize / 2, planets.ElementAt(j).Position.Y + planets.ElementAt(j).ObjectSize / 2);

                        if (DistanceBetweenPoints(center, p) < planets.ElementAt(j).ObjectSize * 1.4 / 2 && planets.ElementAt(j) != departurePlanet && planets.ElementAt(j) != endPlanet)
                        {
                            bool isInList = false;
                            for (int k = 0; k < collisionPlanets.Count; k++)
                            {

                                if (collisionPlanets.ElementAt(k).Equals(planets.ElementAt(j)))
                                {
                                    isInList = true;
                                }
                            }
                            if (!isInList)
                            {
                                collisionPlanets.Add(planets.ElementAt(j));
                            }
                            
                        }
                    }
                }
            }
            return collisionPlanets;
        }

        private bool CheckCollision(Point pointFrom, Point pointTo, Planet planet)
        {
            Vector vec = new Vector(pointFrom.X - pointTo.X, pointFrom.Y - pointTo.Y);
            double angle = Math.Acos(vec.X / (vec.Length * DistanceBetweenPoints(new Point(0, 0), new Point(1, 0))));
            if (vec.Y < 0)
            {
                angle = Math.PI + (Math.PI - angle);
            }
            int distance = (int)DistanceBetweenPoints(pointFrom, pointTo);
            for (int i = 0; i < distance; i++)
            {
                Point p = new Point(pointFrom.X + i * Math.Cos(angle) * -1, pointFrom.Y + i * Math.Sin(angle) * -1);
                if (i % 10 == 0)
                {
                    for (int j = 0; j < planets.Count; j++)
                    {
                        Point center = new Point(planets.ElementAt(j).Position.X + planets.ElementAt(j).ObjectSize / 2, planets.ElementAt(j).Position.Y + planets.ElementAt(j).ObjectSize / 2);
                        
                        if (DistanceBetweenPoints(center, p) < planets.ElementAt(j).ObjectSize*1.4/2 && planets.ElementAt(j) != departurePlanet && planets.ElementAt(j) != planet)
                        {
                            
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private double DistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePlanets();

            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timer.Start();
            timer.Tick += TimerTick;
            cpuTimer.Interval = new TimeSpan(0, 0, 0, 0, random.Next(300, 701));
            cpuTimer.Start();
            cpuTimer.Tick += cpuTimerTick;
        }

        private void cpuTimerTick(object sender, EventArgs e)
        {
            List<Planet> aiPlanets = new List<Planet>();
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets.ElementAt(i).Owner.Equals(Color.FromRgb(50, 50, 220)))
                {
                    aiPlanets.Add(planets.ElementAt(i));
                }
            }
            int destinationPlanet;
            int aiPlanet = random.Next(0, aiPlanets.Count);
            do
            {
                destinationPlanet = random.Next(0, planets.Count);
            } while (aiPlanets.ElementAt(aiPlanet) == planets.ElementAt(destinationPlanet));
            Planet userPlanet = departurePlanet;
            departurePlanet = aiPlanets.ElementAt(aiPlanet);
            ships.Add(new SpaceShip(aiPlanets.ElementAt(aiPlanet), planets.ElementAt(destinationPlanet), aiPlanets.ElementAt(aiPlanet).NumberOfUnits/2, getAIPath(aiPlanets.ElementAt(aiPlanet), planets.ElementAt(destinationPlanet), userPlanet)));
        }

        private List<Point> getAIPath(Planet planetFrom, Planet planet, Planet userPlanet)
        {
            List<Point> path = getPath(planetFrom, planet);
            departurePlanet = userPlanet;
            return path;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //DrawAll();
            //CreatePaths();
            //Console.WriteLine("xddddd");
            for (int i = 0; i < planets.Count; i++)
            {
                planets.ElementAt(i).Update(20);
            }
            for (int i = 0; i < ships.Count; i++)
            {
                ships.ElementAt(i).Update(20);
                if (ships.ElementAt(i).Done)
                {
                    ships.Remove(ships.ElementAt(i));
                }
            }
            DrawAll();
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (percentageOfUnits <= 5 && e.Delta < 0 || percentageOfUnits >=95 && e.Delta > 0)
            {
                return;
            }
            percentageOfUnits += e.Delta * 5 / 120;
            Console.WriteLine(percentageOfUnits);
        }
    }
}
