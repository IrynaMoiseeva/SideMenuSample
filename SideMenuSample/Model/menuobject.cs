using System;
using System.Collections.Generic;

namespace SideMenuSample.Model
{
    public class Child
    {
        public string id { get; set; }
        public int accLvl { get; set; }
        public string label { get; set; }
        public string linkType { get; set; }
        public string linkOpen { get; set; }
        public string linkValue { get; set; }
        public string dynamic { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public int accLvl { get; set; }
        public string label { get; set; }
        public List<Child> children { get; set; }
        public string linkType { get; set; }
        public string linkValue { get; set; }
        public int? defSel { get; set; }
        public string dynamic { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public int accLvl { get; set; }
        public string type { get; set; }
        public int dbId { get; set; }
        public List<Datum> data { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
}
