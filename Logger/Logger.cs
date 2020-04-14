using log4net;
using log4net.Config;

namespace Jenkins2.Logger
{
	public static class Logger
	{
		public static ILog GetLogger { get; } = LogManager.GetLogger("LOGGER");

		public static void InitLogger()
		{
			XmlConfigurator.Configure();
		}
	}
}
