using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechCarnivalUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        readonly string PathToFile = @"MVCImageSliderFromFolder";
        readonly string FileType = "config";
        readonly string CurrentTestDirectory = "MVCImageSliderFromFolder";
        [TestMethod]
        public void TestConfigFiles()
        {
            var configFiles = new List<string>();
            var errors = new List<string>();
            var currentPath = AppDomain.CurrentDomain.BaseDirectory;
            var configPath = currentPath.Substring(0, currentPath.LastIndexOf(CurrentTestDirectory));
            var finalPath = Path.Combine(configPath, PathToFile);
            var files = Directory.GetFiles(finalPath);

            foreach (var file in files.Where(f => f.Contains(FileType)))
            {
                configFiles.Add(file);
            }

            foreach (var file in configFiles)
            {
                try
                {
                    var doc = XDocument.Load(file);
                }
                catch (Exception e)
                {
                    errors.Add($"Error loading {file}: {e.Message}");
                }

            }

            if (errors.Any())
            {
                string errorMessage = string.Empty;
                foreach (var error in errors)
                {
                    errorMessage += error;
                }
                Assert.Fail($"Check your config file: {errorMessage}");
            }
        }
    }
}
