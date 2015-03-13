using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TestTiffImage
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string filename = "C:\\CVI.AIS\\TempImages\\source.tif";


			Stream imageStreamSource = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
			TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);			
			BitmapSource bitmapSource = decoder.Frames[0];
			// this piece works for 8-bit grayscale. Adjust for other formats.


			FileStream stream = new FileStream("C:\\CVI.AIS\\TempImages\\test_output2.tif", FileMode.Create);
			TiffBitmapEncoder encoder = new TiffBitmapEncoder();

			encoder.Compression = TiffCompressOption.None;
			encoder.Frames.Add(decoder.Frames[0]);
			encoder.Save(stream);




			//Bitmap bmp = new Bitmap(bitmapSource.PixelWidth, bitmapSource.PixelHeight, PixelFormat.Format24bppRgb);
			//bitmapSource.

			////BitmapData data = bmp.LockBits(new Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			////bitmapSource.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
			////bmp.UnlockBits(data);

			//pictureBox1.Image = bmp;

			//bmp.Save("C:\\CVI.AIS\\TempImages\\test_output.tif");
		}
	}
}
