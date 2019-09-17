using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestApplication.Data;

namespace TestApplication.ViewModels.Testing
{
    public class TestingViewModel : ViewModelBase
    {
        public TestingViewModel()
        {
            context = new TestDbContext();

            SetDevicesPathCommand = new RelayCommand(SetDevicesPath);
            SetProtocolPathCommand = new RelayCommand(SetProtocolPath);
            ScanCommand = new RelayCommand(Scan);
        }

        private readonly TestDbContext context;

        public ICommand SetDevicesPathCommand { get; private set; }
        public ICommand SetProtocolPathCommand { get; private set; }
        public ICommand ScanCommand { get; private set; }

        private void SetProtocolPath()
        {

        }

        private void SetDevicesPath()
        {

        }

        private void Scan()
        {
            try
            {
                using (StreamReader sr = File.OpenText(DevicesPath))
                {
                    string s = @"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAdd:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?";
                    Regex regex = new Regex(s);

                    string text = sr.ReadToEnd();
                    MatchCollection matches = regex.Matches(text);

                    if (matches.Count > 24)
                    {
                        throw new Exception("Отсканируйте не больше 24 сканеров");
                    }
                    else if (matches.Count == 0)
                    {
                        throw new Exception("Отсканируйте хотя бы один сканер");
                    }
                    else
                    {
                        Protocol = new Protocol()
                        {
                            DateTime = DateTime.Now,
                            Devices = new ObservableCollection<Device>()
                        };

                        int i = 1;

                        foreach (Match match in matches)
                        {
                            Protocol.Devices.Add(new Device
                            {
                                Index = i,
                                DevName = match.Groups["DevName"].Value.Trim(),
                                DevEui = match.Groups["DevEui"].Value.Trim(),
                                AppEui = match.Groups["AppEui"].Value.Trim(),
                                AppKey = match.Groups["AppKey"].Value.Trim(),
                                DevAdd = match.Groups["DevAdd"].Value.Trim(),
                                AppSKey = match.Groups["AppSKey"].Value.Trim(),
                                NwkSKey = match.Groups["NwkSKey"].Value.Trim()
                            });

                            i++;
                        }

                        context.Protocols.Add(Protocol);
                        context.SaveChanges();
                    }

                    var workbook = new XSSFWorkbook();
                    var sheet = workbook.CreateSheet();



                    var row1 = sheet.CreateRow(0);
                    row1.Height = 1500;

                    var cell1 = row1.CreateCell(0);
                    cell1.SetCellValue($"Протокол №{Protocol.Id}\nпроверки работоспособности комплекса счётчик - LoRa-модуль\n{Protocol.DateTime}");

                    XSSFCellStyle cell1Style = (XSSFCellStyle)workbook.CreateCellStyle();
                    cell1Style.WrapText = true;
                    cell1Style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    cell1Style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                    cell1Style.SetFont(new XSSFFont() { IsBold = true, FontName = "Calibri", FontHeight = 12 });


                    cell1.CellStyle = cell1Style;

                    var cra1 = new CellRangeAddress(0, 0, 0, 11);
                    sheet.AddMergedRegion(cra1);

                    XSSFCellStyle cell2Style = (XSSFCellStyle)workbook.CreateCellStyle();
                    cell2Style.WrapText = true;
                    cell2Style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    cell2Style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                    cell2Style.SetFont(new XSSFFont() { IsBold = true, FontName = "Calibri", FontHeight = 10 });
                    cell2Style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    cell2Style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    cell2Style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    cell2Style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;                    

                    var row2 = sheet.CreateRow(2);

                    var cell2 = row2.CreateCell(0);
                    cell2.SetCellValue("№№места");
                    cell2.CellStyle = cell2Style;

                    var cell3 = row2.CreateCell(1);
                    cell3.SetCellValue("Зав.№*");
                    cell3.CellStyle = cell2Style;

                    var cell4 = row2.CreateCell(2);
                    cell4.SetCellValue("Версия ПО");
                    cell4.CellStyle = cell2Style;

                    var cell5 = row2.CreateCell(3);
                    cell5.SetCellValue("DevEui*");
                    cell5.CellStyle = cell2Style;

                    var cell6 = row2.CreateCell(4);
                    cell6.SetCellValue("DevAdd/NwkSKey*");
                    cell6.CellStyle = cell2Style;

                    var cell7 = row2.CreateCell(5);
                    cell7.SetCellValue("AppSkey/AppEui/AppKey*");
                    cell7.CellStyle = cell2Style;

                    var cell8 = row2.CreateCell(6);
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

                    foreach (var device in Protocol.Devices)
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
                        cell333.SetCellValue(device.DevAdd + "/" + device.NwkSKey);

                        var cell444 = row.CreateCell(5);
                        cell444.CellStyle = cell2Style;

                        cell444.SetCellType(CellType.String);
                        cell444.SetCellValue(device.AppSKey + "/" + device.AppEui + "/" + device.AppKey);
                    }


                    for (int i = 0; i <= 11; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }

                    using (FileStream fileStream = new FileStream(Path.Combine(ProtocolPath, $"Протокол№{Protocol.Id}.xlsx"), FileMode.Create, FileAccess.ReadWrite))
                    {
                        workbook.Write(fileStream);
                    }

                    MessageBox.Show("Готово");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string devicesPath;
        public string DevicesPath
        {
            get => devicesPath;
            set => Notify(ref devicesPath, value);
        }

        private string protocolPath;
        public string ProtocolPath
        {
            get => protocolPath;
            set => Notify(ref protocolPath, value);
        }

        private Protocol protocol;
        public Protocol Protocol
        {
            get => protocol;
            set => Notify(ref protocol, value);
        }
    }
}
