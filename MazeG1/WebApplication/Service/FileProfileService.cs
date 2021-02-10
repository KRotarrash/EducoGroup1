using GemBox.Document;
using GemBox.Document.Tables;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Service
{
    public class FileProfileService
    {
        private IWebHostEnvironment _hostingEnvironment;

        public FileProfileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetDefaultFile()
        {
            var fileName = "smile.rtf";
            return PathPrivate(fileName);
        }

        public string GenerateProfile(SpecialUser user)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var doc = new DocumentModel();

            var section = new Section(doc);
            doc.Sections.Add(section);

            var table = new Table(doc);
            table.TableFormat.PreferredWidth = 
                new TableWidth(80, TableWidthUnit.Percentage);

            section.Blocks.Add(table);

            var row = new TableRow(doc);
            table.Rows.Add(row);
            AddColumn(doc, row, $"Id {user.Id}");
            AddColumn(doc, row, "Name");
            AddColumn(doc, row, "Age");
            AddColumn(doc, row, "Height");
            AddColumn(doc, row, $"AdressCount {user.Adresses.Count()}");

            var userRow = new TableRow(doc);
            table.Rows.Add(userRow);
            AddColumn(doc, userRow, "*" + user.Id);
            AddColumn(doc, userRow, "*" + user.Name);
            AddColumn(doc, userRow, "*" + user.Age);
            AddColumn(doc, userRow, "*" + user.Height);
            AddColumn(doc, userRow, "*" + user.Adresses.Count());

            var path = PathPrivate($"Profile-{user.Id}.docx");
            doc.Save(path);
            
            return path;
        }

        private void AddColumn(DocumentModel doc, TableRow row, long number)
        {
            AddColumn(doc, row, number.ToString());
        }

        private void AddColumn(DocumentModel doc, TableRow row, string text)
        {
            var cell = new TableCell(doc);
            row.Cells.Add(cell);
            var paragraph = new Paragraph(doc, text);
            cell.Blocks.Add(paragraph);
        }

        private string PathPrivate(string fileName)
        {
            var rootPath = _hostingEnvironment.ContentRootPath;
            return Path.Combine(rootPath,
                "wwwroot", "Download", fileName);
        }
    }
}
