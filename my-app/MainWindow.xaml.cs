using System;
using System.IO;
using System.Windows;
using static Structs;
using static Noises;
using static Helper;
using System.Diagnostics;
using System.Drawing;

namespace my_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random rnd = new();
        private readonly OpenSimplexNoise opSplx = new();
        private Window1 wnd = new();
        private Bitmap bitmap;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs ev)
        {
            try
            {
                DrawNoise();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
            finally
            {
              button3D.Visibility = Visibility.Visible;
              buttonSave.Visibility = Visibility.Visible;
            }
        }

        private void Save(object sender, RoutedEventArgs ev)
        {
            int n = 0;
            
            string path = Directory.GetCurrentDirectory()+"/Saved/";
            Directory.CreateDirectory(@path);
            string path_txt = path + "SavedCount.txt";
            if (!File.Exists(path_txt)) { File.WriteAllText(path_txt,"1"); } 
            else 
            {
              string dataRead = File.ReadAllText(path_txt);
              n = int.Parse(dataRead);
              File.WriteAllText(path_txt,(n+1).ToString());
            }

            path += n.ToString("D3")+"_.png";
            bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);

        }

        private void Show_3D(object sender, RoutedEventArgs ev)
        {
            try
            {
                if (wnd.IsClosed) { wnd = new(); }
                wnd.DrawMesh(bitmap);
                wnd.Show();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
        }

        private void DrawNoise()
        {
            int size = 1000;
            Vector2 point = new((float)this.rnd.NextDouble() * rnd.Next(500), (float)this.rnd.NextDouble() * rnd.Next(500));
            Vector2 point_2 = new((float)this.rnd.NextDouble() * rnd.Next(500), (float)this.rnd.NextDouble() * rnd.Next(500));
            bitmap = new Bitmap(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int alpha = 0;
                    switch (NoiseType.Text)
                    {
                        case "Basic Noise":
                            alpha = OpenSimplex(point, i, j, opSplx);
                            break;
                        case "Ridged Noise":
                            alpha = RidgedNoise(point, i, j, opSplx);
                            break;
                        case "Fractal Noise":
                            alpha = FractalNoise(point, i, j, opSplx);
                            break;
                        case "Clamped Fractal - 1":
                            alpha = ClampedFractal2C(point, i, j, opSplx);
                            break;
                        case "Clamped Fractal - 2":
                            alpha = ClampedFractal3C(point, i, j, opSplx);
                            break;
                        case "Clamped Noise":
                            alpha = ClampedSimple(point, i, j, opSplx);
                            break;
                        case "Combined Noise":
                            alpha = CombinedNoise1(point, point_2, i, j, opSplx, size);
                            break;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(alpha, alpha, alpha));
                }
            }

            imgDynamic.Source = BitmapToImageSource(bitmap);
        }
    }
}
