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

namespace Galcon
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer();
        List<Planet> planets = new List<Planet>();
        List<SpaceShip> ships;
        Random random;
        
        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        

        private void CreatePlanets()
        {
            
            random = new Random();
            NewUserPlanet();
            NewAIPlanet();
            NewNeutralPlanets();
            CreatePaths();
            DrawAll();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
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
                size = random.Next(16, 49);
                x = random.Next(size / 2, (int)(canvas.Width - size / 2));
                y = random.Next(size / 2, (int)(canvas.Height - size / 2));
                planet = new Planet(Color.FromRgb(0, 0, 200), size, new Point(x, y));
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
            size = random.Next(16, 49);
            x = random.Next(size / 2, (int)(canvas.Width - size/2));
            y = random.Next(size / 2, (int)(canvas.Height - size / 2));
            planets.Add(new Planet(Color.FromRgb(200, 0, 0), size, new Point(x, y)));
        }

        private void NewNeutralPlanets()
        {
            Planet planet;
            bool collision = false;
            int size, x, y;
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    collision = false;
                    size = random.Next(16, 49);
                    x = random.Next(size / 2, (int)(canvas.Width - size / 2));
                    y = random.Next(size / 2, (int)(canvas.Height - size / 2));
                    planet = new Planet(Color.FromRgb(125,125,125), size, new Point(x, y));
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
            
            for (int i = 0; i < planets.Count; i++)
            {
                
                Ellipse myEllipse = new Ellipse();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = planets.ElementAt(i).Owner;
                myEllipse.Fill = mySolidColorBrush;
                myEllipse.Stroke = Brushes.Black;
                myEllipse.StrokeThickness = 0;
                myEllipse.Width = planets.ElementAt(i).ObjectSize;
                myEllipse.Height = planets.ElementAt(i).ObjectSize;
                myEllipse.Margin = new Thickness(planets.ElementAt(i).Position.X, planets.ElementAt(i).Position.Y, 0, 0);
                myEllipse.MouseLeftButtonDown += ClickLeft;
                myEllipse.MouseRightButtonDown += ClickRight;
                canvas.Children.Add(myEllipse);
                
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
        }

        private void ClickRight(object sender, MouseButtonEventArgs e)
        {
            //poslat jednotky
            
        }

        private void ClickLeft(object sender, MouseButtonEventArgs e)
        {
            foreach (var c in canvas.Children.OfType<Ellipse>())
            {
                c.StrokeThickness = 0;
            }
            Ellipse current = (Ellipse)sender;
            current.StrokeThickness = 2;
        }


        private Point[] CreatePath(Planet a, Planet b)
        {
            Point[] points = new Point[2];
            double distance = double.MaxValue;
            for (int i = 0; i < a.ContactPoints.Count; i++)
            {
                for (int j = 0; j < b.ContactPoints.Count; j++)
                {
                    double tempDistance = DistanceBetweenPoints(a.ContactPoints.ElementAt(i), b.ContactPoints.ElementAt(j));
                     if (tempDistance < distance)
                     {
                         distance = tempDistance;
                         points[0] = a.ContactPoints.ElementAt(i);
                         points[1] = b.ContactPoints.ElementAt(j);
                     }
                }
            }
            Line line = new Line();
            line.X1 = points[0].X;
            line.X2 = points[1].X;
            line.Y1 = points[0].Y;
            line.Y2 = points[1].Y;
            line.Stroke = System.Windows.Media.Brushes.Black;
            canvas.Children.Add(line);
            return points;
        }

        private double DistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePlanets();

            timer.Interval = 20;
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
        }
    }
}
