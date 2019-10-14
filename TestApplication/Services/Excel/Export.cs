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
using System.Windows;

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
            ISheet sheet = workbook.CreateSheet($"Протокол №{protocol.Id}");

            XSSFCellStyle captionCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            captionCellStyle.WrapText = true;
            captionCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            captionCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //captionCellStyle.SetFont(new XSSFFont() { IsBold = true, FontName = "Segoe UI", FontHeight = 12, Boldweight = (short)FontBoldWeight.Bold });
            captionCellStyle.SetFont(new XSSFFont() { IsBold = true, FontName = "Calibri", FontHeight = 14 });
            captionCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            captionCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            captionCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            captionCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

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
                            Name = "до корр.",
                            Index = 0
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
                    Index=9,
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

                var cell_A = row.CreateCell(0);
                cell_A.CellStyle = cellStyle;

                cell_A.SetCellType(CellType.String);
                //cell_A.SetCellValue(device.Index); //номер подвеса
                
                var cell_B = row.CreateCell(0);
                cell_B.CellStyle = cellStyle;

                cell_B.SetCellType(CellType.String);
                //cell_B.SetCellValue(device.Index); //заводской номер

                var cell_C = row.CreateCell(0);
                cell_C.CellStyle = cellStyle;

                cell_C.SetCellType(CellType.String);
                //cell_C.SetCellValue(device.Index); //версия ПО

                var cell_D = row.CreateCell(3);
                cell_D.CellStyle = cellStyle;

                cell_D.SetCellType(CellType.String);
                cell_D.SetCellValue(device.DevEui);

                var cell_E = row.CreateCell(4);
                cell_E.CellStyle = cellStyle;

                cell_E.SetCellType(CellType.String);
                cell_E.SetCellValue(device.DevAdd + "/" + Environment.NewLine + device.NwkSKey);

                var cell_F = row.CreateCell(5);
                cell_F.CellStyle = cellStyle;

                cell_F.SetCellType(CellType.String);
                cell_F.SetCellValue(device.AppSKey + "/" + Environment.NewLine + device.AppEui + "/" + Environment.NewLine + device.AppKey);

                var cell_G = row.CreateCell(3);
                cell_G.CellStyle = cellStyle;

                cell_G.SetCellType(CellType.String);
                //cell_G.SetCellValue(device.DevEui); //качество связи(SNR)

                var cell_H = row.CreateCell(3);
                cell_H.CellStyle = cellStyle;

                cell_H.SetCellType(CellType.String);
                //cell_H.SetCellValue(device.DevEui); //отклонение времени до коррекции

                var cell_I = row.CreateCell(3);
                cell_I.CellStyle = cellStyle;

                cell_I.SetCellType(CellType.String);
                //cell_I.SetCellValue(device.DevEui); //отклонение времени после коррекции

                var cell_J = row.CreateCell(3);
                cell_J.CellStyle = cellStyle;

                cell_J.SetCellType(CellType.String);
                //cell_J.SetCellValue(device.DevEui); //реле откл.

                var cell_K = row.CreateCell(3);
                cell_K.CellStyle = cellStyle; 

                cell_K.SetCellType(CellType.String);
                //cell_K.SetCellValue(device.DevEui); //реле вкл.

                var cell_L = row.CreateCell(3);
                cell_L.CellStyle = cellStyle;

                cell_L.SetCellType(CellType.String);
                //cell_L.SetCellValue(device.DevEui); //примечания

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

    internal class ProtocolHeader
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public List<ProtocolHeader> ProtocolHeaders { get; set; }
    }
}