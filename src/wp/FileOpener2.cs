using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace Cordova.Extension.Commands
{
	public class FileOpener2 : BaseCommand
	{
		public void open(string options)
		{
			options = options.Replace("{}", ""); // empty objects screw up the Deserializer

			try
			{
				string[] args = JSON.JsonHelper.Deserialize<string[]>(options);
			}
			catch(Exception)
			{

			}
		}
	}
}