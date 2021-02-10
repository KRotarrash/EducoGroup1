using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.Models;

namespace WebApplication.Service
{
    public class FiletoPDF
    {

        private IWebHostEnvironment _hostingEnvironment;

        public FiletoPDF(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetDefaultFile()
        {
            return "";
        }

        public string GenerateHistory(CalcViewModel calc)
        {
            var filepath = PathPrivate("CalcHistory.docx");
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            using (var doc = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {
                var table = new Table();
                table.AppendChild(GetDefaultBorder());

                var row = new TableRow();

                AddCell(row, "1е значение");
                AddCell(row, "2-е значение");
                AddCell(row, "Знак");
                AddCell(row, "Ответ");

                table.Append(row);

                foreach (var calcHistory in calc.CalcHistory)
                {
                    var userRow = new TableRow();

                    AddCell(userRow, calcHistory.Number1);
                    AddCell(userRow, calcHistory.Number2);
                    AddCell(userRow, calcHistory.Operation.ToString());
                    AddCell(userRow, calcHistory.Answer);

                    table.Append(userRow);
                }

                doc.AddMainDocumentPart();

                doc.MainDocumentPart.Document = new Document();
                Document document = doc.MainDocumentPart.Document;
                Body body = document.AppendChild(new Body());

                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                // Write some text to the file.  
                run.AppendChild(new Text("История операций, произведённых калькулятором!"));
                run.AppendChild(new Break());
                run.AppendChild(new Text("Одинец Буценко Аюков"));
                //     doc.MainDocumentPart.Document = new Document();
                //     doc.MainDocumentPart.Document.Body = new Body();

                // Append the table to the document.
                doc.MainDocumentPart.Document.Body.Append(table);

                //вопрос: как сделать под таблицей этот параграф
                Paragraph para2 = body.AppendChild(new Paragraph());
                Run run2 = para.AppendChild(new Run());
                // Write some text to the file.  
                run2.AppendChild(new Break());
                run2.AppendChild(new Text("История операций, произведённых калькулятором!"));
                run2.AppendChild(new Break());
                run2.AppendChild(new Text("Одинец Буценко Аюков"));
            }

            return filepath;
        }


        private void AddCell(TableRow tr, float number)
        {
            AddCell(tr, number.ToString());
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
