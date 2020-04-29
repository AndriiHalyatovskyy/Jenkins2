using Accord.Video.FFMPEG;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ScreenRecorderLib;

namespace Jenkins2
{
	public abstract class Helper
	{
		private VideoFileWriter vf;
		private Bitmap bp;
		private Graphics gr;
		private string filepath;

		private Recorder _rec;
		private Stream _outStream;

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
		//protected async void TakeVideo(string methodName)
		//{
		//	string subfolderPath = $"{TestContext.CurrentContext.TestDirectory}\\Video\\{DateTime.UtcNow:MMM'-'dd'-'yy}\\";
		//	string path = $"{subfolderPath}{methodName}_{DateTime.UtcNow.Ticks}.mp4";
		//	filepath = path;
		//	var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(subfolderPath));

		//	if (!destinationDirectory.Exists)
		//	{
		//		destinationDirectory.Create();
		//	}

		//	vf = new VideoFileWriter();
		//	vf.Open(path, 1920, 1080, 30, VideoCodec.MPEG4, 100000);

		//	await Task.Run(() =>
		//	{ 
		//		while (vf.IsOpen)
		//		{
		//			bp = new Bitmap(1920, 1080);
		//			gr = Graphics.FromImage(bp);
		//			gr.CopyFromScreen(0, 0, 0, 0, bp.Size);
		//			vf.WriteVideoFrame(bp);
		//			Thread.Sleep(30);
		//		}
		//	});
		//}

		protected void TakeVideo(string methodName)
		{
			string subfolderPath = $"{TestContext.CurrentContext.TestDirectory}\\Video\\{DateTime.UtcNow:MMM'-'dd'-'yy}\\";
			string path = $"{subfolderPath}{methodName}_{DateTime.UtcNow.Ticks}.mp4";
			filepath = path;
			var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(subfolderPath));

			if (!destinationDirectory.Exists)
			{
				destinationDirectory.Create();
			}

			_rec = Recorder.CreateRecorder();
			_rec.OnRecordingComplete += Rec_OnRecordingComplete;
			_rec.OnRecordingFailed += Rec_OnRecordingFailed;

			_rec.Record(path);
		}

		protected void EndRecording()
		{
			_rec.Stop();
		}
		private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
		{
			_outStream?.Dispose();
		}
		private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
		{
			_outStream?.Dispose();

		}

		/// <summary>
		/// Stops video recording, and delete file if test passed succesifully
		/// </summary>
		protected void StopRecording(TestContext context)
		{
			//vf.Close();
			if (context.Result.Outcome.Status != TestStatus.Failed)
			{
				File.Delete(filepath);
			}

		}
	}
}
