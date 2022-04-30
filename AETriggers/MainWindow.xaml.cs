using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using AETriggers.TriggerModel;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Trigger = AETriggers.TriggerModel.Trigger;

namespace AETriggers
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var currCulture = System.Globalization.CultureInfo.CurrentCulture;
            if (currCulture.Name.Contains("zh-CN"))
            {
                this.Load.Content = "加载Excel表";
                this.Export.Content = "导出";
            }


            Entry.Init();
        }


        private void Load_OnClick(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = new DirectoryInfo("../").FullName;
            openFile.Multiselect = false;
            var ret = openFile.ShowDialog();

            if (!ret.HasValue || !ret.Value)
                return;
            var file = openFile.FileName;
            IWorkbook workbook;
            var fileExt = Path.GetExtension(file).ToLower();
            try
            {
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read,
                    FileShare.ReadWrite))
                {
                    if (fileExt == ".xlsx")
                        workbook = new XSSFWorkbook(fs);
                    else if (fileExt == ".xls")
                        workbook = new HSSFWorkbook(fs);
                    else
                        workbook = null;

                    if (workbook == null)
                    {
                        MessageBox.Show("Load excel failed!");
                        return;
                    }

                    var sheet = workbook.GetSheetAt(0);

                    // for (int i = 0; i < sheet.LastRowNum; i++)
                    // {
                    //     var row = sheet.GetRow(i);
                    //     foreach (var v in row.Cells)
                    //     {
                    //         if (v != null && !string.IsNullOrEmpty(v.ToString()))
                    //             MessageBox.Show($"{v.RowIndex} {v.ColumnIndex} : {v.ToString()}");
                    //     }
                    // }


                    var authorName = sheet.GetRow(0).GetCell(1).ToString();
                    var version = sheet.GetRow(1).GetCell(1).ToString();
                    var targetDuty = sheet.GetRow(2).GetCell(1).ToString();
                    var job = sheet.GetRow(3).GetCell(1).ToString();

                    Entry.TriggerLine = new TriggerLine
                    {
                        Version = version,
                        Author = authorName,
                        TargetDuty = targetDuty,
                        TargetJob = job,
                        ConfigVersion = TriggerLine.CurrConfigVersion
                    };

                    var AllExcelData = Entry.AllExcelData;

                    Entry.AllExcelData.Clear();
                    for (var i = 6; i < sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        // var cell = row.GetCell(1);
                        // var notData = cell != null && cell.ToString().StartsWith("#");
                        // if (notData)
                        //     continue;
                        var groupId = row.GetCell(2)?.ToString();
                        var type = row.GetCell(3)?.ToString();
                        var valueType = row.GetCell(4)?.ToString();

                        if (groupId == null || type == null || valueType == null)
                            continue;

                        var valueParams = new string[3];
                        valueParams[0] = row.GetCell(5)?.ToString();
                        valueParams[1] = row.GetCell(6)?.ToString();
                        valueParams[2] = row.GetCell(7)?.ToString();

                        if (!AllExcelData.TryGetValue(groupId, out var list))
                        {
                            list = new List<Entry.ExcelData>();
                            AllExcelData[groupId] = list;
                        }

                        list.Add(new Entry.ExcelData
                        {
                            groupId = groupId,
                            type = type,
                            valueType = valueType,
                            valueParams = valueParams
                        });
                    }

                    var loadRet = LoadExcelData();

                    if (loadRet)
                    {
                        MessageBox.Show("Load Success!");
                    }
                    else
                    {
                        Entry.TriggerLine = null;
                        AllExcelData.Clear();
                        MessageBox.Show("Load Failed!");
                    }

                    RefreshUI();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void Export_OnClick(object sender, RoutedEventArgs e)
        {
            var TriggerLine = Entry.TriggerLine;
            if (TriggerLine == null)
                return;
            var openFile = new SaveFileDialog();
            openFile.Filter = "Json(*.json)|*.json";
            openFile.InitialDirectory = new DirectoryInfo("../").FullName;
            openFile.FileName =
                $"[{TriggerLine.Author}][{TriggerLine.Version}]{TriggerLine.TargetDuty}_{TriggerLine.TargetJob}.json";
            var ret = openFile.ShowDialog();
            if (!ret.HasValue || !ret.Value)
                return;
            TriggerHelper.SaveTriggerLine(TriggerLine, openFile.FileName);
            MessageBox.Show("Export Success!");
        }

        private bool LoadExcelData()
        {
            var TriggerLine = Entry.TriggerLine;
            var AllExcelData = Entry.AllExcelData;
            if (TriggerLine == null || AllExcelData.Count == 0)
                return false;
            foreach (var v in AllExcelData)
            {
                var trigger = new Trigger
                {
                    Id = v.Key
                };
                TriggerLine.Triggers.Add(trigger);

                foreach (var data in v.Value)
                {
                    var strs = data.valueType.Split(':');
                    var category = strs[0];
                    var typeName = strs[1];

                    //MessageBox.Show(typeName);
                    
                

                    try
                    {
                        var type = TriggerMgr.Instance.Name2Type[typeName];
                        var instance = Activator.CreateInstance(type) as ITriggerBase;
                        instance.WriteFromJson(data.valueParams);

                        if (instance is ITriggerCond)
                            trigger.TriggerConds.Add(instance as ITriggerCond);
                        else
                            trigger.TriggerActions.Add(instance as ITriggerAction);
                    }
                    catch (Exception e)
                    {
                        var pre = $"Type: {data.valueType} TypeName {typeName} Params : [{ListToString(data.valueParams)}]\n ";
                        MessageBox.Show(pre + e);
                        return false;
                    }
                }
            }

            return true;
        }

        private string ListToString(string[] pa)
        {
            var str = string.Empty;
            if (pa != null && pa.Length > 0)
                foreach (var v in pa)
                    str += v + ",";

            return $"[{str}]";
        }

        private void RefreshUI()
        {
            var TriggerLine = Entry.TriggerLine;
            var AllExcelData = Entry.AllExcelData;
            if (TriggerLine == null)
            {
                AuthorName.Content = string.Empty;
                Version.Content = string.Empty;
                TargetDuty.Content = string.Empty;
                TargetJob.Content = string.Empty;
                return;
            }

            AuthorName.Content = TriggerLine.Author;
            Version.Content = TriggerLine.Version;
            TargetDuty.Content = TriggerLine.TargetDuty;
            TargetJob.Content = TriggerLine.TargetJob;
        }

        private void LoadJson_OnClick(object sender, RoutedEventArgs e)
        {
            var TriggerLine = Entry.TriggerLine;
            var AllExcelData = Entry.AllExcelData;
            var openFile = new OpenFileDialog();
            openFile.Filter = "Json(*.json)|*.json";
            openFile.InitialDirectory = Environment.CurrentDirectory + @"\..\";
            openFile.Multiselect = false;
            var ret = openFile.ShowDialog();

            if (!ret.HasValue || !ret.Value)
                return;
            var file = openFile.FileName;
            TriggerLine = TriggerHelper.LoadTriggerLine(file);
            MessageBox.Show("Load Success!");
        }
    }
}