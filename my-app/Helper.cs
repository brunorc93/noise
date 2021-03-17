using System.Collections.Generic;
using System;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;

public static class Helper{


    public static BitmapImage BitmapToImageSource(Bitmap bmp)
    {
        using (MemoryStream memory = new())
        {
            bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            BitmapImage bmpImg = new();
            bmpImg.BeginInit();
            bmpImg.StreamSource = memory;
            bmpImg.CacheOption = BitmapCacheOption.OnLoad;
            bmpImg.EndInit();

            return bmpImg;
        }
    }
    public static T[] Shuffle<T>(this T[] array, Random rnd)
    {
      int n = array.Length;
      while (n>1)
      {
        int k = rnd.Next(0,n--);
        T temp = array[n];
        array[n] = array[k];
        array[k] = temp;
      }
      return array;
    }
    public static List<T> Shuffle<T>(this List<T> list, Random rnd)
    {
      int n = list.Count;
      while (n>1)
      {
        int k = rnd.Next(0,n--);
        T temp = list[n];
        list[n] = list[k];
        list[k] = temp;
      }
      return list;
    }
}
