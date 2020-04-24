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

		/// <summary>
		/// Takes video and save it to current directory
		/// </summary>
		/// <param name="methodName"></param>
		protected async void TakeVideo(IWebDriver driver, string methodName)
		{
			string subfolderPath = $"{TestContext.CurrentContext.TestDirectory}\\Video\\{DateTime.UtcNow:MMM'-'dd'-'yy}\\";
			string path = $"{subfolderPath}{methodName}_{DateTime.UtcNow.Ticks}.mp4";

			var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(subfolderPath));

			if (!destinationDirectory.Exists)
			{
				destinationDirectory.Create();
			}

			vf = new VideoFileWriter();
			vf.Open(path, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 25, VideoCodec.MPEG4, 100000);

			await Task.Run(() =>
			{
				while (true)
				{
					bp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
					gr = Graphics.FromImage(bp);
					gr.CopyFromScreen(0, 0, 0, 0, bp.Size);
					bp.Save($"{TestContext.CurrentContext.TestDirectory}\\Video\\Text.png");
					vf.WriteVideoFrame(bp);
					Thread.Sleep(30);
				}
			});
		}

		/// <summary>
		/// Stops video recording, and delete file if test passed succesifully
		/// </summary>
		protected void StopRecording(TestContext context)
		{
			//if (context.Result.Outcome.Status != TestStatus.Failed)
			//{
			//	File.Delete(filepath);
			//}
			vf.Close();
		}
	}
}
