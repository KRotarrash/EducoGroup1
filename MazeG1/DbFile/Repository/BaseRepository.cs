using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DbFile
{
    public abstract class BaseRepository<T> where T : DbBaseModel, new()
    {
        protected abstract string FileName { get; }
        protected string PathToFile =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

        public void Save(T model)
        {

            var json = JsonSerializer.Serialize(model);
            File.WriteAllText(PathToFile, json);
        }

        public T Get()
        {
            if (!File.Exists(PathToFile))
            {

                return null;
            }
            var json = File.ReadAllText(PathToFile);
            return JsonSerializer.Deserialize<T>(json);
        }

    }
}
