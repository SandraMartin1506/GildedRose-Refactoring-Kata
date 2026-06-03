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
            if(IsItemName(item, "Aged Brie") || IsItemName(item, "Backstage passes to a TAFKAL80ETC concert"))
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
            else 
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
        }
    }
    
    private bool IsItemName(Item item, string name) => item.Name == name; //Query
    private bool IsItemPropertyLessThan(int property, int cantity) => property < cantity; //Query
    private bool IsItemPropertyMoreThan(int property, int cantity) => property > cantity; //Query
    private void AddQualityAmount (Item item, int amount) => item.Quality += amount; //Command
    private void AddSellInAmount (Item item, int amount) => item.SellIn += amount; //Command
    private int SellInCondition(Item item) => item.SellIn < 11 ? 2 : (item.SellIn < 6 ? 3 : 0); //Query

}