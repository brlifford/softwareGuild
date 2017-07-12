﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public abstract class Container : Item
    {
        public int Capacity { get; private set ; } //only the Container class can set values of Capacity
        public Item[] Items { get; private set; }
        public int CurrentIndex { get; private set; }

        private List<IItemRestriction> _restrictions = new List<IItemRestriction>();

        public Container(int capacity)
        {
            Capacity = capacity;
            Items = new Item[Capacity];
            CurrentIndex = 0; 
        }

        // capacity - available to container, and it's children
        //protected int _capacity;
        //protected Item[] _items;
        //protected int _currentIndex;

        //public Container(int capacity)
        //{
        //_capacity = capacity;
        //_items = new Item[capacity];
        //_currentIndex = 0;
        public void AddRestriction(IItemRestriction restriction)
        {
            _restrictions.Add(restriction);
        }

        public virtual AddItemStatus AddItem(Item itemToAdd)
        {
            foreach(var restriction in _restrictions)
            {
                AddItemStatus result = restriction.AddItem(itemToAdd, this);
                if(result != AddItemStatus.Ok)
                {
                    return result;
                }
            }

            Items[CurrentIndex] = itemToAdd;
            CurrentIndex++;
            return AddItemStatus.Ok;
        }

        //public virtual bool AddItem(Item itemToAdd)
        //{
        //    if(_capacity == _currentIndex)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        _items[_currentIndex] = itemToAdd;
        //        _currentIndex++;
        //        return true;
        //    }
        //}

        public virtual Item RemoveItem()
        {
            if (CurrentIndex == 0)
                return null;
            else
            {
                CurrentIndex--;
                Item itemToReturn = Items[CurrentIndex];
                Items[CurrentIndex] = null;
                return itemToReturn;
            }

        }

    }
}
