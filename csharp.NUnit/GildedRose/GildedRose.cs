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
                    AddQualityAmount(item, -1);

                if (!IsItemName(item, "Sulfuras, Hand of Ragnaros"))
                    AddSellInAmount(item, -1);
                    
                if (IsItemPropertyLessThan(item.SellIn, 0))
                {
                    if (IsItemPropertyMoreThan(item.Quality, 0))
                    {
                        if (IsItemName(item, "Sulfuras, Hand of Ragnaros"))
                            AddQualityAmount(item, -1);
                    }
                    else
                        AddQualityAmount(item, -item.Quality);
                }
            }
            else
            {
                if (IsItemPropertyLessThan(item.Quality, 50))
                {
                    AddQualityAmount(item, 1);
                    
                    if (IsItemName(item, "Backstage passes to a TAFKAL80ETC concert"))
                        AddQualityAmount(item, SellInCondition(item));
                }

                if (IsItemPropertyLessThan(item.SellIn, 0))
                {
                    if (IsItemPropertyLessThan(item.Quality, 50))
                        AddQualityAmount(item, 1);

                    
                
                }
            }   
        }
    }
    

    private bool IsItemName(Item item, string name) => item.Name == name;

    private bool IsItemPropertyLessThan(int property, int cantity) => property < cantity;
    private bool IsItemPropertyMoreThan(int property, int cantity) => property > cantity;
    
    private void AddQualityAmount (Item item, int amount) => item.Quality += amount;
    
    private void AddSellInAmount (Item item, int amount) => item.SellIn += amount;

    private int SellInCondition(Item item)
    {
        if (item.SellIn < 11 || item.SellIn < 6)
        {
            if(IsItemPropertyLessThan(item.Quality, 50))
                return 1;
        }

        return 0;
    }

}