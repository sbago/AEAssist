using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using AETriggers;
using AETriggers.TriggerModel;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Trigger = AEAssist.Trigger;

namespace AEAssist
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public class TestData
        {
            public string Name { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            /*var currCulture = CultureInfo.CurrentCulture;
            if (currCulture.Name.Contains("zh-CN"))
            {
                Load.Content = "加载Excel表";
                Export.Content = "导出";
            }*/

            var list1 = new List<TestData>()
            {
                new TestData() {Name = "AfterBattleStart"}, //todo: AutoCreate
                new TestData() {Name = "AfterOtherTrigger"},
            };
            
            var list2 = new List<TestData>()
            {
                new TestData() {Name = "SwitchBurst"},
                new TestData() {Name = "SwitchAOE"},
            };

            //
            Conds.ItemsSource = list1;
            Actions.ItemsSource = list2;

            
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


                    var authorName = sheet.GetRow(0).GetCell(1).ToString().Trim();
                    var name = sheet.GetRow(1).GetCell(1).ToString().Trim();
                    var targetZoneIdStr = sheet.GetRow(2).GetCell(1).ToString().Trim();
                    var subZoneIdStr = sheet.GetRow(2).GetCell(2).ToString().Trim();
                    var job = sheet.GetRow(3).GetCell(1).ToString().Trim();

                    if (!ushort.TryParse(targetZoneIdStr, out var targetZoneId))
                    {
                        MessageBox.Show($"Load excel failed! {targetZoneIdStr} format error");
                        return;
                    }

                    if (!ushort.TryParse(subZoneIdStr, out var subZoneId))
                    {
                        MessageBox.Show($"Load excel failed! {subZoneIdStr} format error");
                        return;
                    }


                    Entry.TriggerLine = new TriggerLine
                    {
                        Author = authorName,
                        Name = name,
                        CurrZoneId = targetZoneId,
                        SubZoneId = subZoneId,
                        TargetJob = job,
                        ConfigVersion = TriggerLine.CurrConfigVersion
                    };

                    var AllExcelData = Entry.AllExcelData;

                    Entry.AllExcelData.Clear();
                    for (var i = 6; i < sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        var cell = row.GetCell(1);
                        var notData = cell != null && cell.ToString().StartsWith("#");
                        if (notData)
                            continue;
                        var groupId = row.GetCell(2)?.ToString().Trim();
                        var type = row.GetCell(3)?.ToString().Trim();
                        var valueType = row.GetCell(4)?.ToString().Trim();

                        if (groupId == null || type == null || valueType == null)
                            continue;

                        var valueParams = new string[3];
                        valueParams[0] = row.GetCell(5)?.ToString().Trim();
                        valueParams[1] = row.GetCell(6)?.ToString().Trim();
                        valueParams[2] = row.GetCell(7)?.ToString().Trim();

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

                    /*RefreshUI();*/
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
                $"[{TriggerLine.TargetJob}] [{TriggerLine.Name}] [{TriggerLine.Author}].json";
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
                        var pre =
                            $"Type: {data.valueType} TypeName {typeName} Params : [{ListToString(data.valueParams)}]\n ";
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

        /*private void RefreshUI()
        {
            var TriggerLine = Entry.TriggerLine;
            var AllExcelData = Entry.AllExcelData;
            if (TriggerLine == null)
            {
                AuthorName.Content = string.Empty;
                Name.Content = string.Empty;
                TargetZone.Content = string.Empty;
                TargetJob.Content = string.Empty;
                return;
            }

            AuthorName.Content = TriggerLine.Author;
            Name.Content = TriggerLine.Name;
            TargetZone.Content = $"{TriggerLine.CurrZoneId} | {TriggerLine.SubZoneId}";
            TargetJob.Content = TriggerLine.TargetJob;
        }*/
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            DragMove();
        }

        private void Selector_OnSelected(object sender, EventArgs eventArgs)
        {
            var selected = JobComboBox.Text;
            MessageBox.Show(selected);
        }

        private void AddConditionOrActionBtn_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddGrouIdBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var newId = IdTextBox.Text;
            if (string.IsNullOrEmpty(newId) || DataBinding.Instance.GroupIds.Contains(newId))
            {
                MessageBox.Show("Repeat or Null!");
                return;
            }
            DataBinding.Instance.GroupIds.Add(newId);
            DataBinding.Instance.AllGroupData[newId] = new DataBinding.GroupData();
        }

        private void IdTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var newId = IdTextBox.Text;
                if (string.IsNullOrEmpty(newId) || DataBinding.Instance.GroupIds.Contains(newId))
                {
                    MessageBox.Show("Repeat or Null!");
                    return;
                }
                DataBinding.Instance.GroupIds.Add(newId);
                DataBinding.Instance.AllGroupData[newId] = new DataBinding.GroupData();
            }
        }
        

        // private void Main_OnMouseDown(object sender, MouseButtonEventArgs e)
        // {
        //     if (e.ChangedButton != MouseButton.Right)
        //     {
        //         _chooseTriggerWindow.Hide();
        //         return;
        //     }
        //
        //     var mousePos = e.GetPosition(this);
        //    var screenPos = this.PointToScreen(mousePos);
        //     _chooseTriggerWindow.Show(screenPos);
        // }

        private void AuthorTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void TriggerOnClickHandler(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem == null)
                return;
            
            if (string.IsNullOrEmpty(DataBinding.Instance.CurrChoosedId))
                return;
            if (!DataBinding.Instance.AllGroupData.TryGetValue(DataBinding.Instance.CurrChoosedId, out var group))
            {
                return;
            }

            var currTriggers = group.Triggers;
            currTriggers.Add(new DataBinding.Trigger()
            {
                TypeName = menuItem.Header.ToString(),
            });
        }

        private void GroupIdRename_EventHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var stackPanel = button.Parent as StackPanel;
                var textBlock = stackPanel.Children[0] as TextBlock;

                var oldId = textBlock.Text;
                var newId = oldId + "_1"; //todo: popup a messagebox with textbox.
                bool currChoosed = false;
                if (DataBinding.Instance.CurrChoosedId == oldId)
                {
                    DataBinding.Instance.CurrChoosedId = string.Empty;
                    TriggersListView.ItemsSource = null;
                    currChoosed = true;
                }

                DataBinding.Instance.GroupIds.Remove(oldId);
                var groupData =  DataBinding.Instance.AllGroupData[oldId];
                DataBinding.Instance.AllGroupData.Remove(oldId);
                DataBinding.Instance.GroupIds.Add(newId);
                DataBinding.Instance.AllGroupData[newId] = groupData;
                if (currChoosed)
                {
                    DataBinding.Instance.CurrChoosedId = newId;
                    TriggersListView.ItemsSource = groupData.Triggers;
                }

                //todo: get newId,
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void GroupIdDel_EventHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var stackPanel = button.Parent as StackPanel;
                var textBlock = stackPanel.Children[0] as TextBlock;

                var delId = textBlock.Text;
                if (DataBinding.Instance.CurrChoosedId == delId)
                {
                    DataBinding.Instance.CurrChoosedId = string.Empty;
                    TriggersListView.ItemsSource = null;
                }

                DataBinding.Instance.GroupIds.Remove(delId);
                DataBinding.Instance.AllGroupData.Remove(delId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void ShowGroup_EventHandler(object sender, MouseButtonEventArgs e)
        {
            var TextBlock = sender as TextBlock;
            var id = TextBlock.Text;
            DataBinding.Instance.CurrChoosedId = id;
            var groupData = DataBinding.Instance.AllGroupData[id];
            TriggersListView.ItemsSource = groupData.Triggers;
            MessageBox.Show(id);
        }
    }
}