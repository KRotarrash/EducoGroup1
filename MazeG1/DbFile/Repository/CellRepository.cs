using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.IO;
using System.Text.Json;

namespace DbFile
{
    public class CellRepository : BaseRepository<DbCell>
    {
        protected override string FileName => "DbCell.json";
    }
}
