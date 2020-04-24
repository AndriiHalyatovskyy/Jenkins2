using Accord.Video.FFMPEG;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jenkins2
{
	public abstract class Helper
	{
		private string filepath;
		private Size area;
		private Rectangle rect;

		//private Timer timer;
		private VideoFileWriter vf;
		private Bitmap bp;
		private Graphics gr;

		/// <summary>
		/// Takes screenshot of browser and save to current directory
		/// </summary>
		/// <param name="driver"></param>
		/// <param name="methodName"></param>
		protected void TakeScreenshot(IWebDriver driver, string methodName)
		{
			string subfolderPath = $"{TestContext.CurrentContext.TestDirectory}\\Screenshots\\{DateTime.UtcNow:MMM'-'dd'-'yy}\\";
			string path = $"{subfolderPath}{methodName}_{DateTime.UtcNow.Ticks}.png";

			var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(subfolderPath));

			if (!destinationDirectory.Exists)
			{
				destinationDirectory.Create();
			}

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
		}

		protected async void Test()
		{

			//timer = new System.Windows.Forms.Timer();
			//timer.Interval = 20;
			//timer.Tick += timer_Tick;
			vf = new VideoFileWriter();
			vf.Open("D://video.mp4", Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 25, VideoCodec.MPEG4, 100000);
			await Task.Run(() =>
			{
				while (vf.IsOpen)
				{
					bp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
					gr = Graphics.FromImage(bp);
					gr.CopyFromScreen(0, 0, 0, 0, bp.Size);
					vf.WriteVideoFrame(bp);
					Thread.Sleep(50);
				}
			});
		}

		private void timer_Tick(object sender, EventArgs e)
		{

			MessageBox.Show("kek");
			vf = null;
		}

		protected void stope()
		{
			//timer.Stop();
			vf.Close();
		}

		/// <summary>
		/// Takes video and save it to current directory
		/// </summary>
		/// <param name="methodName"></param>
		protected void TakeVideo()
		{

		}

		/// <summary>
		/// Stops video recording, and delete file if test passed succesifully
		/// </summary>
		protected void StopRecording(TestContext context)
		{
			if (context.Result.Outcome.Status != TestStatus.Failed)
			{
				File.Delete(filepath);
			}
		}
	}
}
