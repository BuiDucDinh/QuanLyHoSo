using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TreeviewDropDown
{
    //[DataContract]
    public class Items
    {
        [DataMember]
        public List<DllItem> ItemList { get; set; }
    }

    //[DataContract]
    public class DllItem
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Int32 ID { get; set; }

    }

    //[DataContract]
    public class TreeItem
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public bool expanded { get; set; }
        [DataMember]
        public List<MyItem> items { get; set; }

        [DataMember]
        public List<TreeItem> treeItems { get; set; }
        public TreeItem()
        {
            items = new List<MyItem>();
            treeItems = new List<TreeItem>();
            expanded = true;
        }
    }

    //[DataContract]
    public class MyItem
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string id { get; set; }

    }
}
