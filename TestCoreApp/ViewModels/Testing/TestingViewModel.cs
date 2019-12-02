﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestCoreApp.Data;
using TestCoreApp.Services.Settings;

namespace TestCoreApp.ViewModels.Testing
{
    public class TestingViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public TestingViewModel()
        {
            context = new TestDbContext();
            context.Protocols.Include(i => i.Devices).Where(p => p.IsClosed == false).Load();

            settingsService = new SettingsService();

            Protocols = context.Protocols.Local.ToObservableCollection();

            ScannedDevices = new ObservableCollection<Device>();

            IsWorking = false;

            DevicesPath = settingsService.Settings.DevicesPath;
            ResponsePath = settingsService.Settings.ResponsePath;
            ProtocolPath = settingsService.Settings.ProtocolPath;

            devicesFileWatcher = new FileSystemWatcher(Path.GetDirectoryName(DevicesPath))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(DevicesPath),
                EnableRaisingEvents = true
            };

            responseFileWatcher = new FileSystemWatcher(Path.GetDirectoryName(ResponsePath))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(ResponsePath),
                EnableRaisingEvents = true
            };

            StartOrStopCommand = new RelayCommand(StartOrStop);
            CreateProtocolCommand = new RelayCommand<object>(CreateProtocol, CreateProtocolCanExecute, true);
        }


        private readonly TestDbContext context;
        private readonly SettingsService settingsService;
        private readonly FileSystemWatcher responseFileWatcher;
        private readonly FileSystemWatcher devicesFileWatcher;

        private void StartOrStop()
        {
            if (IsWorking)
            {
                devicesFileWatcher.Changed -= AddScannedDevicesFromFile;
                responseFileWatcher.Changed -= UpdateScannedDevicesFromResponse;
            }
            else
            {
                devicesFileWatcher.Changed += AddScannedDevicesFromFile;
                responseFileWatcher.Changed += UpdateScannedDevicesFromResponse;
            }

            IsWorking = !IsWorking;
        }

        private void CreateProtocol(object selectedItems)
        {
            IList items = (IList)selectedItems;
            List<Device> devices = new List<Device>(items.Cast<Device>());

            for (int i = 0; i < devices.Count(); i++)
            {
                ScannedDevices.Remove(devices[i]);
            }
            items.Clear();

            Protocol protocol = new Protocol();

            protocol.Tester = "sdsd";
            protocol.DateTime = DateTime.Now;
            protocol.Devices = new ObservableCollection<Device>(devices);

            context.Attach(protocol);
            context.SaveChanges();

            Services.Excel.Export.ProtocolToXlsx(ProtocolPath, protocol);
        }

        private void AddScannedDevicesFromFile(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);

            MatchCollection matches;

            using (StreamReader streamReader = File.OpenText(DevicesPath))
            {
                Regex regex = new Regex(@"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAddr:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?");
                matches = regex.Matches(streamReader.ReadToEnd());
            }

            int i = 1;

            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (Match match in matches)
                {
                    ScannedDevices.Add(new Device
                    {
                        Index = i,
                        DevName = match.Groups["DevName"].Value.Trim(),
                        DevEui = match.Groups["DevEui"].Value.Trim(),
                        AppEui = match.Groups["AppEui"].Value.Trim(),
                        AppKey = match.Groups["AppKey"].Value.Trim(),
                        //DevAdd = int.Parse(match.Groups["DevAdd"].Value.Trim()).ToString("X8"),
                        DevAdd = match.Groups["DevAdd"].Value.Trim(),
                        AppSKey = match.Groups["AppSKey"].Value.Trim(),
                        NwkSKey = match.Groups["NwkSKey"].Value.Trim()
                    });

                    i++;
                }
            });
        }



        private void UpdateScannedDevicesFromResponse(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);

            string text;

            using (StreamReader sr2 = File.OpenText(ResponsePath))
            {
                text = sr2.ReadToEnd();
            }

            Regex regex = new Regex(@"(?<DevEui>\w{16})\s(?<Snr>\d+\.?\d*)\s(?<PackageType>\w{2})(?<FactoryNumber>\w{8})(?<Time>\w{8})(?<Unused>.*)");

            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Device device = ScannedDevices.Where(d => d.DevEui == match.Groups["DevEui"].Value.Trim()).FirstOrDefault();

                if (device != null)
                {
                    device.Snr = match.Groups["Snr"].Value.Trim();
                    device.FactoryNumber = Convert.ToUInt32(ReverseWord(match.Groups["FactoryNumber"].Value.Trim(), match.Groups["FactoryNumber"].Value.Trim().Length), 16).ToString();
                }
            }
        }

        public bool CreateProtocolCanExecute(object obj)
        {
            if(((IList)obj)?.Count == 0)
            {
                return false;
            }

            return true;
        }

        public ICommand StartOrStopCommand { get; private set; }
        public ICommand CreateProtocolCommand { get; private set; }

        private string responsePath;
        public string ResponsePath
        {
            get => responsePath;
            set => Notify(ref responsePath, value);
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

        private ObservableCollection<Protocol> protocols;
        public ObservableCollection<Protocol> Protocols
        {
            get => protocols;
            set => Notify(ref protocols, value);
        }

        private ObservableCollection<Device> scannedDevices;
        public ObservableCollection<Device> ScannedDevices
        {
            get => scannedDevices;
            set => Notify(ref scannedDevices, value);
        }

        private bool isWorking;
        public bool IsWorking
        {
            get => isWorking;
            set => Notify(ref isWorking, value);
        }

        public string ReverseWord(string s, int length)
        {
            string result = "";
            for (int i = 1; i < length; i += 2)
            {
                result = result + s[length - i - 1] + s[length - i];
            }
            return result;
        }

    }
}
