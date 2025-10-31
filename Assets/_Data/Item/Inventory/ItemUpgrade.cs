using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item Upgrade")]
    [SerializeField] protected int maxLevel = 9;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 2);
    }
    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }
    public virtual bool UpgradeItem(int itemIndex)
    {
        if(itemIndex >= this.inventory.Items.Count) return false;

        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        if(itemInventory.itemCount < 1) return false;

        List<ItemRecipe>upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if(!this.ItemUpgradeAble(upgradeLevels)) return false;
        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;
        this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel += 1;

        return true;
    }
    protected virtual bool ItemUpgradeAble(List<ItemRecipe> upgradeLevels)
    {
        if(upgradeLevels == null) return false;
        if(upgradeLevels.Count == 0) return false;
        return true;
    }
    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;
        if (currentLevel >= upgradeLevels.Count)
        {
            Debug.LogError("Item cant be upgraded more, current: " + currentLevel);
            return false;
        }
        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach(ItemRecipeIngredients ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            if(!this.inventory.ItemCheck(itemCode, itemCount))
            {
                Debug.LogError("Not enough ingredient: " + itemCode);
                return false;
            }
        }
        return true;
    }
    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;
        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach(ItemRecipeIngredients ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;
            this.inventory.DeductItem(itemCode, itemCount);
        }
    }
}
