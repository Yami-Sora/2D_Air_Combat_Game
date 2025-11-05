public enum ItemCode
{
    NoItem = 0,
    IronOre = 1,
    GoldOre = 2,
    CopperSword = 1000,
}
public class ItemCodeParser
{
    public static ItemCode FromString(string itemName)
    {
        if (string.IsNullOrWhiteSpace(itemName))
            return ItemCode.NoItem;

        // TryParse tránh ngoại lệ và có thể ignore case
        if (System.Enum.TryParse<ItemCode>(itemName, ignoreCase: true, out var result))
            return result;

        return ItemCode.NoItem;
    }
}