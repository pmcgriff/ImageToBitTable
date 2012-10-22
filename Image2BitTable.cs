using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Data;

namespace ImageToBitTable
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Image2BitTable : System.Windows.Forms.Form
	{
		private PictureBox picMain;
		private Button btnOpen;
		private WebBrowser wbBitTable;
		private Label label1;
		private Label label2;
		private ComboBox cbxPixelSize;
		private Label label3;

		private string imageFileName = null;
		private Label lblMessage;
		private ComboBox cbxRenderType;
		private Label label4;
		private TextBox txtImageUrl;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Image2BitTable()
		{
			InitializeComponent();

			RenderBitTable();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.picMain = new System.Windows.Forms.PictureBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.wbBitTable = new System.Windows.Forms.WebBrowser();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxPixelSize = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.cbxRenderType = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtImageUrl = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
			this.SuspendLayout();
			// 
			// picMain
			// 
			this.picMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picMain.Location = new System.Drawing.Point(7, 69);
			this.picMain.Name = "picMain";
			this.picMain.Size = new System.Drawing.Size(284, 224);
			this.picMain.TabIndex = 0;
			this.picMain.TabStop = false;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(7, 12);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(140, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Open Image...";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// wbBitTable
			// 
			this.wbBitTable.Location = new System.Drawing.Point(297, 69);
			this.wbBitTable.Name = "wbBitTable";
			this.wbBitTable.ScrollBarsEnabled = false;
			this.wbBitTable.Size = new System.Drawing.Size(290, 224);
			this.wbBitTable.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Silver;
			this.label1.Location = new System.Drawing.Point(8, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Original Image";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Silver;
			this.label2.Location = new System.Drawing.Point(500, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Rendered HTML";
			// 
			// cbxPixelSize
			// 
			this.cbxPixelSize.FormattingEnabled = true;
			this.cbxPixelSize.Items.AddRange(new object[] {
            "2",
            "4",
            "5",
            "8",
            "10",
            "12",
            "15",
            "20",
            "24",
            "25"});
			this.cbxPixelSize.Location = new System.Drawing.Point(221, 12);
			this.cbxPixelSize.Name = "cbxPixelSize";
			this.cbxPixelSize.Size = new System.Drawing.Size(70, 21);
			this.cbxPixelSize.TabIndex = 6;
			this.cbxPixelSize.Text = "10";
			this.cbxPixelSize.SelectedIndexChanged += new System.EventHandler(this.cbxPixelSize_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(163, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Pixel Size";
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessage.AutoSize = true;
			this.lblMessage.ForeColor = System.Drawing.Color.Green;
			this.lblMessage.Location = new System.Drawing.Point(413, 15);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(174, 13);
			this.lblMessage.TabIndex = 8;
			this.lblMessage.Text = "HTML source copied to clipboard...";
			this.lblMessage.Visible = false;
			// 
			// cbxRenderType
			// 
			this.cbxRenderType.FormattingEnabled = true;
			this.cbxRenderType.Items.AddRange(new object[] {
            "base64",
            "Table",
            "Divs"});
			this.cbxRenderType.Location = new System.Drawing.Point(306, 12);
			this.cbxRenderType.Name = "cbxRenderType";
			this.cbxRenderType.Size = new System.Drawing.Size(101, 21);
			this.cbxRenderType.TabIndex = 9;
			this.cbxRenderType.Text = "Table";
			this.cbxRenderType.SelectedIndexChanged += new System.EventHandler(this.cbxRenderType_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Image URL";
			// 
			// txtImageUrl
			// 
			this.txtImageUrl.Location = new System.Drawing.Point(75, 39);
			this.txtImageUrl.Name = "txtImageUrl";
			this.txtImageUrl.Size = new System.Drawing.Size(332, 20);
			this.txtImageUrl.TabIndex = 11;
			this.txtImageUrl.Text = "http://cdn.memegenerator.net/instances/400x/9325609.jpg";
			// 
			// Image2BitTable
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(593, 296);
			this.Controls.Add(this.txtImageUrl);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbxRenderType);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbxPixelSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.wbBitTable);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.picMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Image2BitTable";
			this.Text = "Convert Image to HTML Table \"BitMap\"";
			((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Image2BitTable());
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			var objOfd = new OpenFileDialog
				{
					Filter = "Bitmap|*.bmp|JPEG|*.jpg|GIF|*.gif|PNG|*.png|All Supported Formats|*.bmp;*.jpg;*.gif;*.png",
					Title = "Open image file...",
					InitialDirectory = Application.StartupPath,
					FilterIndex = 5
				};

			if (objOfd.ShowDialog() != DialogResult.OK) return;

			imageFileName = objOfd.FileName;
			txtImageUrl.Text = String.Empty;
			RenderBitTable();
		}

		private void cbxPixelSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			RenderBitTable();
		}

		private void cbxRenderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			RenderBitTable();
		}

		private void RenderBitTable()
		{
			Image img = null;
			try
			{
				if (!String.IsNullOrEmpty(txtImageUrl.Text))
				{
					img = Image.FromStream(new MemoryStream(new WebClient().DownloadData(txtImageUrl.Text)));
				}
				else if (!String.IsNullOrEmpty(imageFileName))
				{
					img = Image.FromFile(imageFileName);
				}
			} catch
			{
				Error("Failed to Load Image.");
				return;
			}

			if (img == null) return;

			picMain.Image = img;

			picMain.Width = img.Width;
			picMain.Height = img.Height;

			int pixelSize;
			if (!Int32.TryParse(cbxPixelSize.Text, out pixelSize))
			{
				Error(String.Format("Pixel Size?? ({0})", cbxPixelSize.Text));
				return;
			}
			ImageToHtml imgConverter;
			switch(cbxRenderType.Text)
			{
				case "Table":
					imgConverter = new ImageToTable(img)
						{
							PixelSize = pixelSize,
						};
					break;
				case "Divs":
					imgConverter = new ImageToDivs(img)
						{
							PixelSize = pixelSize,
						};
					break;
				default:
					imgConverter = new ImageToHtml(img);
					break;
			}
			int w, h;
			var imageHtml = imgConverter.ToHtml(out w, out h);
			if(!String.IsNullOrEmpty(txtImageUrl.Text))
			{
				imageHtml = AddEmailImageMagic(txtImageUrl.Text, img, imageHtml);
			}

			Clipboard.SetText(imageHtml);
			Success("HTML source copied to clipboard...");

			wbBitTable.DocumentText = String.Format("<body style=\"margin:0;padding:0;\">{0}</body>", imageHtml);
			wbBitTable.Width = w;
			wbBitTable.Height = h;
			wbBitTable.Left = img.Width + 16;

			Width = img.Width + wbBitTable.Width + 48;
			Height = Math.Max(img.Height, wbBitTable.Height) + picMain.Location.Y + 48;
		}

		private static string AddEmailImageMagic(string imageUrl, Image image, string imageHtml)
		{
			/* This method creates a zero width div (overflow: visible) which wraps a table.
			 * The table contains a single cell whose background image is the image
			 * The cell contains a div which the height and width of the image
			 * It's Magic.
			 * */
			return String.Format("<div style=\"width:0px;height:0px;overflow:visible;float:left;position:absolute;\"><table cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td background=\"{0}\"><div style=\"width:{1}px;height:{2}px\"></div></td></tr></tbody></table></div>{3}", imageUrl, image.Width, image.Height, imageHtml);
		}

		private void Success(string msg)
		{
			lblMessage.Text = msg;
			lblMessage.ForeColor = Color.Green;
			lblMessage.Visible = true;
		}

		private void Error(string msg)
		{
			lblMessage.Text = msg;
			lblMessage.ForeColor = Color.DarkRed;
			lblMessage.Visible = true;
		}
	}
}
