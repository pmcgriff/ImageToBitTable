using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageToBitTable
{
	public class ImageToHtml
	{
		public const int DefaultPixelSize = 10;
		protected readonly Image Image;

		public ImageToHtml(Image image)
		{
			Image = image;
		}

		// source: http://stackoverflow.com/questions/249587/high-quality-image-scaling-c-sharp
		protected Bitmap ResizeImage(int width, int height)
		{
			//a holder for the result
			var result = new Bitmap(width, height);
			// set the resolutions the same to avoid cropping due to resolution differences
			result.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);

			//use a graphics object to draw the resized image into the bitmap
			using (var graphics = Graphics.FromImage(result))
			{
				//set the resize quality modes to high quality
				graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				//draw the image into the target bitmap
				graphics.DrawImage(Image, 0, 0, result.Width, result.Height);
			}

			//return the resulting bitmap
			return result;
		}

		public virtual string ToHtml(out int width, out int height)
		{
			using (var ms = new MemoryStream())
			{
				Image.Save(ms, Image.RawFormat);
				var bytes = ms.ToArray();
				width = Image.Width;
				height = Image.Height;
				return String.Format("<img src=\"data:image/png;base64,{0}\" />", Convert.ToBase64String(bytes));
			}
		}
	}

	public class ImageToTable : ImageToHtml
	{
		public ImageToTable(Image image) : base(image)
		{
			PixelSize = DefaultPixelSize;
		}

		public int PixelSize { get; set; }

		public override string ToHtml(out int width, out int height)
		{
			var resizeW = (int)Math.Ceiling((double)Image.Width / PixelSize);
			var resizeH = (int)Math.Ceiling((double)Image.Height / PixelSize);
			var bitmap = new LockBitmap(ResizeImage(resizeW, resizeH));
			bitmap.LockBits();
			width = resizeW * PixelSize;
			height = resizeH * PixelSize;
			var html = new StringBuilder(String.Format("<table width=\"{0}\" height=\"{1}\" cellpadding=0 cellspacing=0>",
													   width,
													   height));

			for (var y = 0; y < bitmap.Height; y++)
			{
				html.Append("<tr>");
				for (var x = 0; x < bitmap.Width; x++)
				{
					var color = bitmap.GetPixel(x, y);
					html.Append(String.Format("<td bgcolor=\"#{0:X2}{1:X2}{2:X2}\"><b></b></td>", color.R, color.G, color.B));
				}
				html.Append("</tr>");
			}

			return html.Append("</table>").ToString();
		}
	}

	public class ImageToDivs : ImageToHtml
	{
		public ImageToDivs(Image image) : base(image)
		{
			PixelSize = DefaultPixelSize;
		}

		public int PixelSize { get; set; }

		public override string ToHtml(out int width, out int height)
		{
			var resizeW = (int)Math.Ceiling((double)Image.Width / PixelSize);
			var resizeH = (int)Math.Ceiling((double)Image.Height / PixelSize);
			var bitmap = new LockBitmap(ResizeImage(resizeW, resizeH));
			bitmap.LockBits();
			width = resizeW * PixelSize;
			height = resizeH * PixelSize;
			var html = new StringBuilder(String.Format("<div style=\"overflow:hidden;width:{0}px;height:{1}px;\">",
													   width,
													   height));

			for (var y = 0; y < bitmap.Height; y++)
			{
				for (var x = 0; x < bitmap.Width; x++)
				{
					var color = bitmap.GetPixel(x, y);
					html.Append(String.Format("<div style=\"width:{0}px;height:{0}px;background:#{1:X2}{2:X2}{3:X2};float:left\"><b></b></div>", PixelSize, color.R, color.G, color.B));
				}
				// html.Append("<div style=\"clear:both;\"></div>");
			}

			return html.Append("</div>").ToString();
		}
	}
}
