
using Models;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Services.Excel
{
    public class Export
    {
        private Export()
        {

        }

        public static ExportResult ProtocolToXlsx(string exportPath, Protocol protocol)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            XSSFCellStyle captionCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            captionCellStyle.WrapText = true;
            captionCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            captionCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            captionCellStyle.SetFont(new XSSFFont() { IsBold = true, FontName = "Segoe UI", FontHeight = 12, Boldweight = (short)FontBoldWeight.Bold });

            IRow captionRow = sheet.CreateRow(0);
            captionRow.Height = 900;

            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 11));

            for (int i = 1; i < 11; i++)
            {
                captionRow.CreateCell(i).CellStyle = captionCellStyle;
            }

            var captionCell = captionRow.CreateCell(0);
            captionCell.SetCellValue($"Протокол №{protocol.Id}{Environment.NewLine}проверки работоспособности комплекса счётчик - LoRa-модуль{Environment.NewLine}{protocol.DateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss")}");
            captionCell.CellStyle = captionCellStyle;

            List<Header> protocolHeaders = new List<Header>()
            {
                new Header
                {
                    Name = "№ п/п",
                    Index=0,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "Зав. №",
                    Index=1,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "Версия ПО",
                    Index=2,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "DevEui",
                    Index=3,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "DevAdd/NwkSKey",
                    Index=4,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "AppSKey/AppEui/AppKey",
                    Index=5,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "Качество связи (SNR)",
                    Index=6,
                    ProtocolHeaders=null
                },
                new Header
                {
                    Name = "Отклонение по времени (сек)",
                    Index=7,
                    ProtocolHeaders=new List<Header>
                    {
                        new Header
                        {
                            Name = "до корр.",
                            Index = 0
                        },
                        new Header
                        {
                            Name = "после корр.",
                            Index = 1
                        }
                    }
                },
                new Header
                {
                    Name = "Реле",
                    Index=9,
                    ProtocolHeaders=new List<Header>
                    {
                        new Header
                        {
                            Name="откл.",
                            Index = 0
                        },
                        new Header
                        {
                            Name = "вкл.",
                            Index = 1
                        }
                    }
                },
                new Header
                {
                    Name = "Примечание",
                    Index = 11,
                    ProtocolHeaders = null
                }
            };

            var headerRow = sheet.CreateRow(1);
            var headerRow2 = sheet.CreateRow(2);

            protocolHeaders.ForEach(item =>
            {
                headerRow.CreateCell(item.Index).SetCellValue(item.Name);
                headerRow.Cells.Where(c => c.ColumnIndex == item.Index).FirstOrDefault().CellStyle = captionCellStyle;
                if (item.ProtocolHeaders != null)
                {
                    item.ProtocolHeaders.ForEach(it =>
                    {
                        headerRow2.CreateCell(item.Index + it.Index).SetCellValue(it.Name);
                        headerRow2.Cells.Where(c => c.ColumnIndex == item.Index + it.Index).FirstOrDefault().CellStyle = captionCellStyle;
                    });

                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, item.Index, item.Index + item.ProtocolHeaders.Count - 1));
                }
                else
                {
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, item.Index, item.Index));
                }
            });

            int j = 2;

            XSSFCellStyle cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            cellStyle.WrapText = true;
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cellStyle.SetFont(new XSSFFont() { IsBold = true, FontName = "Calibri", FontHeight = 10 });
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            foreach (var device in protocol.Devices)
            {
                var row = sheet.CreateRow(j + device.Index);

                var cell1 = row.CreateCell(0);
                cell1.CellStyle = cellStyle;

                cell1.SetCellType(CellType.String);
                cell1.SetCellValue(device.Index);

                var cell2 = row.CreateCell(3);
                cell2.CellStyle = cellStyle;

                cell2.SetCellType(CellType.String);
                cell2.SetCellValue(device.DevEui);

                var cell3 = row.CreateCell(4);
                cell3.CellStyle = cellStyle;

                cell3.SetCellType(CellType.String);
                cell3.SetCellValue(device.DevAdd + "/" + Environment.NewLine + device.NwkSKey);

                var cell4 = row.CreateCell(5);
                cell4.CellStyle = cellStyle;

                cell4.SetCellType(CellType.String);
                cell4.SetCellValue(device.AppSKey + "/" + Environment.NewLine + device.AppEui + "/" + Environment.NewLine + device.AppKey);

            }

            var testerRow = sheet.CreateRow(j + protocol.Devices.Count + 2);

            testerRow.CreateCell(5).SetCellValue("Испытание провёл:");
            testerRow.CreateCell(6).SetCellValue(protocol.Tester = "Тестов Тест Тестович");


            sheet.AddMergedRegion(new CellRangeAddress(j + protocol.Devices.Count + 2, j + protocol.Devices.Count + 2, 6, 11));


            for (int i = 0; i <= 11; i++)
            {
                sheet.AutoSizeColumn(i);
            }


            using (FileStream fileStream = new FileStream(Path.Combine(exportPath, $"Протокол №{protocol.Id}.xlsx"), FileMode.Create, FileAccess.ReadWrite))
            {
                workbook.Write(fileStream);
            }

            return null;
        }
    }

    internal class Header
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public List<Header> ProtocolHeaders { get; set; }
    }
}
