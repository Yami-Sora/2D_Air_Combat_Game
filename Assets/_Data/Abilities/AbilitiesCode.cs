public enum AbilitiesCode
{
    NoAbilities = 0,
    Missle = 1,
    Laze = 2,
}
public class AbilitiesCodeParser
{
    public static AbilitiesCode FromString(string itemName)
    {
        if (string.IsNullOrWhiteSpace(itemName))
            return AbilitiesCode.NoAbilities;

        // TryParse tránh ngoại lệ và có thể ignore case
        if (System.Enum.TryParse<AbilitiesCode>(itemName, ignoreCase: true, out var result))
            return result;

        return AbilitiesCode.NoAbilities;
    }
}