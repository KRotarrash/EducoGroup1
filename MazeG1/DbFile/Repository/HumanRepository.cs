using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.IO;
using System.Text.Json;

namespace DbFile
{
    public class HumanRepository : BaseRepository<DbHuman>
    {
        protected override string FileName => "DbHuman.json";
    }
}
