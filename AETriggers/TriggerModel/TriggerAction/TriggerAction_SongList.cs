using System;
using System.Collections.Generic;

namespace AEAssist.TriggerAction
{
    [Trigger("SongList")]
    public class TriggerAction_SongList : ITriggerAction
    {
        public List<int> Durations = new List<int>();
        public List<int> SongIndex = new List<int>();

        public void WriteFromJson(string[] values)
        {
            if (string.IsNullOrEmpty(values[0]))
                throw new Exception("Error!");

            var strs = values[0].Split('|');
            if (strs == null || strs.Length == 0)
                throw new Exception("Error!");

            foreach (var config in strs)
            {
                var con = config.Split(':');
                if (con == null || con.Length != 2)
                    throw new Exception($"{config} params Error!");
                if (!int.TryParse(con[0], out var index)
                    || !int.TryParse(con[1], out var duration))
                    throw new Exception($"{config} format Error!");

                SongIndex.Add(index);
                Durations.Add(duration);
            }
        }
    }
}