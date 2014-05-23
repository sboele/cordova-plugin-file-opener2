using System;
using Windows.Storage;
using Windows.System;
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
				string[] args = JsonHelper.Deserialize<string[]>(options);

				string filePath = args[0];
				string contentType = args[1];

				StorageFolder folder = ApplicationData.Current.LocalFolder;

				string fileName = filePath.Substring(filePath.LastIndexOf('/') + 1);
				filePath = filePath.Replace("/" + fileName, "");
				foreach (string part in filePath.Split('/'))
				{
					if (!String.IsNullOrWhiteSpace(part))
					{
						folder = folder.GetFolderAsync(part).GetAwaiter().GetResult();
					}
				}

				StorageFile file = folder.GetFileAsync(fileName).GetAwaiter().GetResult();
				Launcher.LaunchFileAsync(file);
			}
			catch (Exception ex)
			{

			}
		}
	}
}