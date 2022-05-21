using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using PropertyChanged;

namespace AETriggers
{
    [AddINotifyPropertyChangedInterface]
    public class DataBinding
    {
        public static DataBinding Instance = new DataBinding();

        
        public class Trigger
        {
            public string TypeName { get; set; }
            public string Param1 { get; set; }
            public string Param2 { get; set; }
            public string Param3 { get; set; }
        }

        public class GroupData
        {
            public ObservableCollection<Trigger> Triggers { get; set; } = new ObservableCollection<Trigger>();
        }

        

        public void Reset()
        {
            Author = string.Empty;
            Name = string.Empty;
            GroupIds = new ObservableCollection<string>();
            AllGroupData = new Dictionary<string, GroupData>();
            CurrChoosedId = string.Empty;
        }


        public string Author { get; set; }
        public string Name { get; set; }

        public ObservableCollection<string> GroupIds { get; set; } = new ObservableCollection<string>();
        public Dictionary<string, GroupData> AllGroupData { get; set; } = new Dictionary<string, GroupData>();

        public string CurrChoosedId { get; set; }

    }
}