
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

            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));

            for (int i = 1; i < 10; i++) // ??
            {
                captionRow.CreateCell(i).CellStyle = captionCellStyle;
            }

            var captionCell = captionRow.CreateCell(0);
            captionCell.SetCellValue($"Протокол №{protocol.Id}{Environment.NewLine}проверки работоспособности комплекса счётчик - LoRa-модуль{Environment.NewLine}{protocol.DateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss")}");
            captionCell.CellStyle = captionCellStyle;

            List<ProtocolHeader> protocolHeaders = new List<ProtocolHeader>()
            {
                new ProtocolHeader
                {
                    Name = "№ п/п",
                    Index=0,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "Зав. №",
                    Index=1,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "Версия ПО",
                    Index=2,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "DevEui",
                    Index=3,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "DevAdd/NwkSKey",
                    Index=4,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "AppSKey/AppEui/AppKey",
                    Index=5,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "Качество связи (SNR)",
                    Index=6,
                    ProtocolHeaders=null
                },
                new ProtocolHeader
                {
                    Name = "Отклонение по времени (сек)",
                    Index=7,
                    ProtocolHeaders=new List<ProtocolHeader>
                    {
                        new ProtocolHeader
                        {
                            Name="до корр.",
                            Index=0
                        },
                        new ProtocolHeader
                        {
                            Name = "после корр.",
                            Index = 1
                        }
                    }
                },
                new ProtocolHeader
                {
                    Name = "Реле",
                    Index=8,
                    ProtocolHeaders=new List<ProtocolHeader>
                    {
                        new ProtocolHeader
                        {
                            Name="откл.",
                            Index = 0
                        },
                        new ProtocolHeader
                        {
                            Name = "вкл.",
                            Index = 1
                        }
                    }
                },
                new ProtocolHeader
                {
                    Name = "Примечание",
                    Index = 9,
                    ProtocolHeaders = null
                }
            };

            var headerRow = sheet.CreateRow(2);
            var headerRow2 = sheet.CreateRow(3);

            foreach (ProtocolHeader protocolHeader in protocolHeaders)
            {
                headerRow.CreateCell(protocolHeader.Index).SetCellValue(protocolHeader.Name);
                headerRow.Cells[protocolHeader.Index].CellStyle = captionCellStyle;

                if (protocolHeader.ProtocolHeaders == null)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(2, 3, protocolHeader.Index, protocolHeader.Index));
                }
                else
                {
                    sheet.AddMergedRegion(new CellRangeAddress(2, 2, protocolHeader.Index, protocolHeader.Index + protocolHeader.ProtocolHeaders.Count - 1));
                    foreach (var item in protocolHeader.ProtocolHeaders)
                    {
                        headerRow2.CreateCell(protocolHeader.Index + item.Index).SetCellValue(item.Name);
                        //headerRow2.Cells[protocolHeader.Index + item.Index].CellStyle = captionCellStyle;
                    }
                }
            }

            for (int i = 0; i < protocolHeaders.Count; i++)
            {
                headerRow.CreateCell(protocolHeaders[i].Index).SetCellValue(protocolHeaders[i].Name);
                headerRow.Cells[protocolHeaders[i].Index].CellStyle = captionCellStyle;

                if (protocolHeaders[i].ProtocolHeaders == null)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(2, 3, protocolHeaders[i].Index, protocolHeaders[i].Index));
                }
                else
                {
                    sheet.AddMergedRegion(new CellRangeAddress(2, 2, protocolHeaders[i].Index, protocolHeaders[i].Index + protocolHeaders[i].ProtocolHeaders.Count - 1));
                    if (i + 1 < protocolHeaders.Count)
                    {
                        protocolHeaders[i + 1].Index += protocolHeaders[i].ProtocolHeaders.Count - 1;
                    }



                    foreach (var item in protocolHeaders[i].ProtocolHeaders)
                    {
                        headerRow2.CreateCell(protocolHeaders[i].Index + item.Index).SetCellValue(item.Name);
                        //headerRow2.Cells[protocolHeader.Index + item.Index].CellStyle = captionCellStyle;
                    }
                }
            }


            XSSFCellStyle cell2Style = (XSSFCellStyle)workbook.CreateCellStyle();
            cell2Style.WrapText = true;
            cell2Style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cell2Style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cell2Style.SetFont(new XSSFFont() { IsBold = true, FontName = "Calibri", FontHeight = 10 });
            cell2Style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cell2Style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cell2Style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cell2Style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            //var headerRow = sheet.CreateRow(2);

            var cell2 = headerRow.CreateCell(0);
            cell2.SetCellValue("№ подвеса");
            cell2.CellStyle = cell2Style;

            var cell3 = headerRow.CreateCell(1);
            cell3.SetCellValue("Зав.№*");
            cell3.CellStyle = cell2Style;

            var cell4 = headerRow.CreateCell(2);
            cell4.SetCellValue("Версия ПО");
            cell4.CellStyle = cell2Style;

            var cell5 = headerRow.CreateCell(3);
            cell5.SetCellValue("DevEui*");
            cell5.CellStyle = cell2Style;

            var cell6 = headerRow.CreateCell(4);
            cell6.SetCellValue("DevAdd/NwkSKey*");
            cell6.CellStyle = cell2Style;

            var cell7 = headerRow.CreateCell(5);
            cell7.SetCellValue("AppSkey/AppEui/AppKey*");
            cell7.CellStyle = cell2Style;

            var cell8 = headerRow.CreateCell(6);
            cell8.SetCellValue("Качество связи(SNR)");
            cell8.CellStyle = cell2Style;

            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 0, 0));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 1, 1));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 2, 2));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 3, 3));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 4, 4));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 5, 5));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 6, 6));
            sheet.AddMergedRegion(new CellRangeAddress(2, 3, 11, 11));

            int y = 4;

            foreach (var device in protocol.Devices)
            {
                var row = sheet.CreateRow(y + device.Index);

                var cell111 = row.CreateCell(0);
                cell111.CellStyle = cell2Style;

                cell111.SetCellType(CellType.String);
                cell111.SetCellValue(device.Index);

                var cell222 = row.CreateCell(3);
                cell222.CellStyle = cell2Style;

                cell222.SetCellType(CellType.String);
                cell222.SetCellValue(device.DevEui);

                var cell333 = row.CreateCell(4);
                cell333.CellStyle = cell2Style;

                cell333.SetCellType(CellType.String);
                cell333.SetCellValue(device.DevAdd + "/\n" + device.NwkSKey);

                var cell444 = row.CreateCell(5);
                cell444.CellStyle = cell2Style;

                cell444.SetCellType(CellType.String);
                cell444.SetCellValue(device.AppSKey + "/\n" + device.AppEui + "/\n" + device.AppKey);

            }


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

    internal class ProtocolHeader
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public List<ProtocolHeader> ProtocolHeaders { get; set; }
    }
}
