using System;
using System.Collections.Generic;
using System.Text;

namespace Nightmaher.Core
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {

            if (_items.Count == 0)
                return false;

            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                    return true;
            }
            return false;
      
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach(Item i in _items)
            {
                if (i.AreYou(id) && i.CanBeTaken)
                {
                    Item itemFound = i;
                    _items.Remove(i);
                    return itemFound;
                }
            }
            return null;
        }

        public Item Fetch(String id)
        {

            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                    return i;
            }
            return null;
        }

        public int Count
        {
            get => _items.Count;
        }

        public string ItemList
        {
            get
            {

                string list = string.Empty;

                if (_items.Count == 1)
                {
                    list = list + "    a " + _items[0].FirstID + ".";
                    return list;
                }

                    for (int i = 0; i < _items.Count; i++)
                {

                    if (i == _items.Count - 1)
                    {
                        list = list + "    and a " + _items[i].FirstID + ".";
                    }
                    else
                    {
                        list = list + "    a " + _items[i].FirstID + ";\r\n";
                    }
                }

                return list;

            }

        }
    }
}
