using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Drawing;


namespace my_app
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool IsClosed { get; private set; }
        public Window1()
        {
            IsClosed = false;
            InitializeComponent();
        }

        public void DrawMesh(Bitmap bitmap)
        {
            float height = 150f;
            meshMain.Positions = new Point3DCollection();
            meshMain.TriangleIndices = new Int32Collection();
            int bW = bitmap.Width;
            int bH = bitmap.Height;
            float w = (bW-1) / 2f;
            float h = (bH-1) / 2f;
            for (int i=0; i<bW; i++)
            {
                for (int j=0; j<bH; j++)
                {
                    meshMain.Positions.Add(new Point3D(i-w, height*(1f - 1f*bitmap.GetPixel(i,j).R/255f), j-h));
                    
                    if (i<bW-1 && j < bH - 1)
                    {
                        int p1 = j + i * (bW);
                        int p2 = j + 1 + i * (bW);
                        int p3 = j + (i + 1) * (bW);
                        int p4 = j + 1 + (i + 1) * (bW);

                        meshMain.TriangleIndices.Add(p1);
                        meshMain.TriangleIndices.Add(p2);
                        meshMain.TriangleIndices.Add(p3);

                        meshMain.TriangleIndices.Add(p3);
                        meshMain.TriangleIndices.Add(p2);
                        meshMain.TriangleIndices.Add(p4);

                    }
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            IsClosed = true;
        }
    }
}
