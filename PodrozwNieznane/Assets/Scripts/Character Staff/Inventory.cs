﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> OnItemRightClickedEvent;

    private void Update()
    {
        for(int i=0; i< itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
        RefreshUI();
    }

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
            //itemSlots[i].Item.Icon.
        }

        for(; i< itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if (IsFull())
            return false;
        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if(items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        if (items.Count >= itemSlots.Length)
            return true;
        return false;
    }
}
