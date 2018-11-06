using Newtonsoft.Json;
using System.Collections.Generic;

namespace jsonCreate
{
    public static class Task
    {
        public static void CreateJson(string path)
        {

            var folder = CreateFolderInfo(path);

            string jsonResult = JsonConvert.SerializeObject(folder, Formatting.Indented);

            using (var tw = new System.IO.StreamWriter("JSONResult.txt"))
            {
                tw.WriteLine(jsonResult.ToString());
                tw.Close();
            }
        }

        private static Folder CreateFolderInfo(string path)
        {
            var info = new System.IO.DirectoryInfo(path);
            var folder = new Folder
            {
                Name = info.Name.ToString(),
                DateCreated = info.CreationTimeUtc,
                Files = new List<File>(),
                Children = new List<Folder>()
            };

            foreach (var it in info.GetFiles())
            {
                var file = new File
                {
                    Name = it.Name,
                    Size = it.Length.ToString() + " B",
                    Path = it.DirectoryName
                };
                folder.Files.Add(file);
            }

            foreach (var it in info.GetDirectories())
            {
                var newFolder = CreateFolderInfo(it.FullName);
                folder.Children.Add(newFolder);
            }

            return folder;
        }
    }
}
