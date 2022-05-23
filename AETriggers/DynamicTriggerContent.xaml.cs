using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace AETriggers
{
    public partial class DynamicTriggerContent : UserControl
    {
        public DataBinding.Trigger Data { get; set; }

        public DynamicTriggerContent()
        {
            InitializeComponent();
        }


        public void Clear()
        {
            this.Data = null;
            this.Panel.Children.Clear();
        }

        public void Init(DataBinding.Trigger trigger)
        {
            Clear();
            if (trigger.DefaultStyle || trigger.TriggerObj==null)
                return;
            this.Data = trigger;
            var obj = trigger.TriggerObj;
            foreach (var v in obj.GetType().GetProperties())
            {
                if (v.PropertyType == typeof(bool))
                {
                    var stackPanel = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };
                    var element0 = new TextBlock();
                    element0.Text = v.Name;
                    element0.Foreground = Brushes.Aqua;

                    var element1 = new CheckBox();
                    element1.Width = 30;
                    element1.Margin = new Thickness(15, 0, 5, 0);
                    var prop = new Binding(v.Name);
                    prop.Source = obj;
                    prop.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(element1, CheckBox.IsCheckedProperty, prop);

                    stackPanel.Children.Add(element0);
                    stackPanel.Children.Add(element1);
                    
                    this.Panel.Children.Add(stackPanel);
                    continue;
                }
                
                if (v.PropertyType == typeof(string))
                {
                    var stackPanel = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };
                    var element0 = new TextBlock();
                    element0.Text = v.Name;
                    element0.Foreground = Brushes.Aqua;
                    
                    var element1 = new TextBox();
                    element1.Margin = new Thickness(15, 0, 5, 0);
                    element1.Width = 80;
                    // if(v.GetValue(obj) == null)
                    //     v.SetValue(obj,"");
                    // element1.Text = v.GetValue(obj).ToString();
                    var prop = new Binding(v.Name);
                    prop.Source = obj;
                    prop.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(element1, TextBox.TextProperty, prop);

                    stackPanel.Children.Add(element0);
                    stackPanel.Children.Add(element1);
                    
                    this.Panel.Children.Add(stackPanel);
                    
                    continue;
                }
                
                if (v.PropertyType == typeof(int)
                    || v.PropertyType == typeof(float)
                    || v.PropertyType == typeof(uint))
                {
                    
                    var stackPanel = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };
                    var element0 = new TextBlock();
                    element0.Text = v.Name;
                    element0.Foreground = Brushes.Aqua;

                    var element1 = new TextBox();
                    element1.Margin = new Thickness(15, 0, 5, 0);
                    element1.Width = 80;
                    element1.Text = v.GetValue(obj).ToString();
                    element1.TextChanged += (s, o) =>
                    {
                        object value_obj = null;
                        if (v.PropertyType == typeof(int))
                        {
                            int.TryParse(element1.Text, out var value);
                            value_obj = value;
                        }
                        else if (v.PropertyType == typeof(uint))
                        {
                            uint.TryParse(element1.Text, out var value);
                            value_obj = value;
                        }
                        else if (v.PropertyType == typeof(float))
                        {
                            float.TryParse(element1.Text, out var value);
                            value_obj = value;
                        }

                        v.SetValue(obj, value_obj);
                    };

                    stackPanel.Children.Add(element0);
                    stackPanel.Children.Add(element1);
                    
                    this.Panel.Children.Add(stackPanel);
                }
            }
        }
    }
}