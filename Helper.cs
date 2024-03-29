﻿using log4net.Appender;
using log4net.Core;
//using Microsoft.Expression.Encoder.ScreenCapture;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Jenkins2
{
	public abstract class Helper
	{
		private Size area;
		private Rectangle rect;
		//private ScreenCaptureJob recorder;
		private string filepath;

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
		protected void TakeVideo(string methodName)
		{
			//recorder = new ScreenCaptureJob();
			//var path = $"{TestContext.CurrentContext.TestDirectory}\\Videos\\{DateTime.UtcNow:MMM'-'dd'-'yy}\\";


			//var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(path));

			//if (!destinationDirectory.Exists)
			//{
			//	destinationDirectory.Create();
			//}

			//filepath = $"{path}{methodName}_{DateTime.UtcNow.Ticks}.mp4";

			//area = SystemInformation.WorkingArea.Size;
			//rect = new Rectangle(0, 0, area.Width - (area.Width % 4), area.Height - (area.Width % 4)); //Removes startup menu

			//recorder.OutputScreenCaptureFileName = filepath;
			//recorder.CaptureRectangle = rect;
			//recorder.OutputPath = path;
			//recorder.Start();
		}

		/// <summary>
		/// Stops video recording, and delete file if test passed succesifully
		/// </summary>
		protected void StopRecording(TestContext context)
		{
			//if (recorder.Status == RecordStatus.Running)
			//{
			//	recorder.Stop();
			//	recorder.Dispose();
			//}

			//if (context.Result.Outcome.Status != TestStatus.Failed)
			//{
			//	File.Delete(filepath);
			//}
		}

		public static void SetOutputLogFileName(string fileName)
		{
			foreach (FileAppender appender in LoggerManager.GetAllRepositories()[0].GetAppenders())
			{
				appender.File = $"Logs\\{fileName}.log";
				appender.ActivateOptions();
			}
		}

	}
}
