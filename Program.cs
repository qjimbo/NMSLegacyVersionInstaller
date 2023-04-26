using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using IWshRuntimeLibrary;

namespace NMSLegacyVersionInstaller
{
    static class Program
    {
        public static string TempFileLocation;
        public static Container Container;

        public static void ExtractInstallerFiles(string prefix, string outputFolder)
        {
            // Get the assembly that contains the embedded resources.
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Extract to the specified output folder
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Loop through all the resource names and extract them to the subfolder.
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                // Only extract resources from the "InstallerFiles" folder.
                if (!resourceName.StartsWith(prefix))
                {
                    continue;
                }

                // Extract the resource to a file in the subfolder.
                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    string fileName = Path.GetFileName(resourceName.Substring(prefix.Length));
                    string filePath = Path.Combine(outputFolder, fileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }
            }
        }

        public static void CreateShortcutWithIcon(string shortcutPath, string targetPath, string iconPath = "")
        {
            // Create a new WshShell object.
            WshShell shell = new WshShell();

            // Create a new shortcut object.
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            // Set the target path and working directory for the shortcut.
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(targetPath);

            // Set the custom icon for the shortcut.
            if(!string.IsNullOrEmpty(iconPath))
                shortcut.IconLocation = iconPath;

            // Save the shortcut.
            shortcut.Save();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Container = new Container();
            Application.Run(Container);
        }
    }
}
