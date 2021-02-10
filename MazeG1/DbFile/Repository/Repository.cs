using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DbFile
{
    public abstract class Repository<T> where T : DbBaseModel, new()

    {
        protected abstract string FileName { get; }
        protected string PathToFile =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

        public void Save(T model)
        {
            var olddata = Get();
            olddata.Add(model);

            var json = JsonSerializer.Serialize(olddata);
            File.WriteAllText(PathToFile, json);
        }

        public List<T> Get()
        {
            if (!File.Exists(PathToFile))
            {
                return new List<T>();
                //return null;
            }
            var json = File.ReadAllText(PathToFile);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
