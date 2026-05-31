using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach(Item item in Items)
        {
            if (!IsItemName(item, "Aged Brie") && !IsItemName(item, "Backstage passes to a TAFKAL80ETC concert"))
            {
                if (IsItemPropertyMoreThan(item.Quality, 0) && !IsItemName(item, "Sulfuras, Hand of Ragnaros"))
                     item.Quality = item.Quality - 1;
                
                if (!IsItemName(item, "Sulfuras, Hand of Ragnaros"))
                    item.SellIn = item.SellIn - 1;

                if (IsItemPropertyLessThan(item.SellIn, 0))
                {
                    if (IsItemPropertyMoreThan(item.Quality, 0))
                    {
                        if (IsItemName(item, "Sulfuras, Hand of Ragnaros"))
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }       
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }   
            }
            else
            {
                if (IsItemPropertyLessThan(item.Quality, 50))
                {
                    item.Quality = item.Quality + 1;

                    if (IsItemName(item, "Backstage passes to a TAFKAL80ETC concert"))
                    {
                        item.Quality = SellInCondition(item);
                    }
                }

                if (IsItemPropertyLessThan(item.SellIn, 0))
                {
                    if (IsItemPropertyLessThan(item.Quality, 50))
                    {
                        item.Quality = item.Quality + 1;
                    }
                
                }
            }   
        }
    }

    private bool IsItemName(Item item, string name) => item.Name == name;

    private bool IsItemPropertyLessThan(int property, int cantity) => property < cantity;
    

    private bool IsItemPropertyMoreThan(int property, int cantity) => property > cantity;
    
    private int SellInCondition(Item item)
    {
        if (item.SellIn < 11 || item.SellIn < 6)
        {
            if(IsItemPropertyLessThan(item.Quality, 50))
                return item.Quality + 1;
        }

        return item.Quality;
    }

}