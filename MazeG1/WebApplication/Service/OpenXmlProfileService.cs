using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Service
{
    public class OpenXmlProfileService
    {
        private IWebHostEnvironment _hostingEnvironment;

        public OpenXmlProfileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetDefaultFile()
        {
            return "";
        }

        public string GenerateProfile(SpecialUser user)
        {
            var filepath = PathPrivate($"{user.Name}.docx");
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            using (var doc = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {
                var table = new Table();
                table.AppendChild(GetDefaultBorder());

                var row = new TableRow();

                AddCell(row, $"Id");
                AddCell(row, "Name");
                AddCell(row, "Age");
                AddCell(row, "Height");
                AddCell(row, $"AdressCount");

                table.Append(row);

                for (int i = 0; i < 10; i++)
                {
                    var userRow = new TableRow();

                    AddCell(userRow, "*" + user.Id);
                    AddCell(userRow, "*" + user.Name);
                    AddCell(userRow, "*" + user.Age);
                    AddCell(userRow, "*" + user.Height);
                    AddCell(userRow, "*" + user.Adresses.Count());
                    
                    table.Append(userRow);
                }

                // Append the table to the document.
                doc.AddMainDocumentPart();
                doc.MainDocumentPart.Document = new Document();
                doc.MainDocumentPart.Document.Body = new Body();
                doc.MainDocumentPart.Document.Body.Append(table);
            }

            return filepath;
        }

        private void AddCell(TableRow tr, string text)
        {
            var cell = new TableCell();
            cell.Append(new TableCellProperties(new TableCellWidth()
            {
                Type = TableWidthUnitValues.Dxa,
                Width = "2400"
            }));
            cell.Append(new Paragraph(new Run(new Text(text))));
            tr.Append(cell);
        }

        private TableProperties GetDefaultBorder()
        {
            return new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new BottomBorder()
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new LeftBorder()
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new RightBorder()
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new InsideHorizontalBorder()
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new InsideVerticalBorder()
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        }
                    )
                );
        }

        private string PathPrivate(string fileName)
        {
            var rootPath = _hostingEnvironment.ContentRootPath;
            return Path.Combine(rootPath,
                "wwwroot", "Download", fileName);
        }
    }
}
