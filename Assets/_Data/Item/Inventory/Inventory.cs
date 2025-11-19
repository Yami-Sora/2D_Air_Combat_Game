using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quản lý kho đồ của nhân vật hoặc đối tượng.
/// </summary>
public class Inventory : YamiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;    // Số lượng ô chứa đồ tối đa.
    [SerializeField] protected List<ItemInventory> items; // Danh sách các vật phẩm hiện có trong kho.
    public List<ItemInventory> Items => items; // Thuộc tính để truy cập danh sách vật phẩm từ bên ngoài (chỉ đọc).


    // Hàm khởi tạo, thêm một vài vật phẩm mặc định vào kho đồ để test.
    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.IronOre, 11);
        this.AddItem(ItemCode.GoldOre, 11);
    }

    // Thêm vật phẩm vào kho đồ, tự động phân loại để xử lý.
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;

        if (itemType == ItemType.Equipment) return this.AddEquipment(itemInventory); // Nếu là trang bị, gọi hàm xử lý riêng.
        return this.AddItem(itemCode, addCount); // Nếu là vật phẩm khác, gọi hàm thêm theo số lượng.
    }

    // Thêm một vật phẩm trang bị, không cộng dồn, mỗi món chiếm một ô.
    protected virtual bool AddEquipment(ItemInventory itemPicked)
    {
        if (IsInventoryFull()) return false;
        ItemInventory item = itemPicked.Clone(); // Tạo một bản sao của vật phẩm để tránh tham chiếu đến đối tượng gốc.

        this.items.Add(item);
        return true;
    }

    // Thêm một số lượng vật phẩm (có thể cộng dồn) vào kho đồ.
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount; // Số lượng vật phẩm còn lại cần thêm.
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode); // Tìm một ô chứa vật phẩm cùng loại và chưa đầy.
            if (itemExist == null)
            {
                if (IsInventoryFull()) return false; // Nếu kho đầy, không thể thêm ô mới.
                itemExist = this.CreateEmptyItem(itemProfile); // Tạo một ô mới nếu cần.
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain; // Tính số lượng mới sau khi thêm.

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack) // Nếu số lượng mới vượt quá giới hạn cộng dồn của ô.
            {
                addMore = itemMaxStack - itemExist.itemCount; // Chỉ thêm cho đến khi ô đầy.
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore; // Cập nhật số lượng còn lại phải thêm.
            }
            else
            {
                addRemain = 0; // Thêm hết số lượng còn lại vào ô này, không còn gì để thêm nữa.
            }
            itemExist.itemCount = newCount; // Cập nhật số lượng vật phẩm trong ô.
            if (addRemain < 1) break; // Nếu đã thêm hết, thoát khỏi vòng lặp.
        }
        return true;
    }

    // Kiểm tra xem kho đồ đã đầy chưa.
    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }

    // Lấy thông tin (profile) của vật phẩm từ mã code.
    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO)); // Tải tài nguyên. Lưu ý: có thể không hiệu quả, nên cache lại.
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    // Tìm một ô vật phẩm trong kho chưa được lấp đầy (chưa full stack).
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue; // Bỏ qua nếu không cùng loại.
            if (this.IsFullStack(itemInventory)) continue; // Bỏ qua nếu đã đầy.
            return itemInventory;
        }
        return null;
    }

    // Kiểm tra xem một ô vật phẩm đã đầy hay chưa.
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return false;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    // Lấy giới hạn cộng dồn (max stack) của một ô vật phẩm.
    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    // Tạo ra một thực thể ItemInventory mới, rỗng, dựa trên profile của vật phẩm.
    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory()
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };
        return itemInventory;
    }

    // Kiểm tra xem trong kho có đủ số lượng vật phẩm yêu cầu không.
    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    // Tính tổng số lượng của một loại vật phẩm có trong kho (tính trên tất cả các ô).
    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        return totalCount;
    }

    // Trừ đi một số lượng vật phẩm khỏi kho đồ.
    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;

        for (int i = this.items.Count - 1; i >= 0; i--) // Lặp ngược từ cuối danh sách để trừ dần.
        {
            if (deductCount <= 0) break; // Đã trừ đủ, thoát.

            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount) // Nếu số lượng cần trừ lớn hơn số lượng trong ô hiện tại.
            {
                deduct = itemInventory.itemCount; // Trừ hết số lượng trong ô này.
                deductCount -= itemInventory.itemCount;
            }
            else // Nếu số lượng cần trừ nhỏ hơn hoặc bằng.
            {
                deduct = deductCount;
                deductCount = 0; // Đã trừ đủ.
            }
            itemInventory.itemCount -= deduct;
        }
        this.ClearEmptySlots(); // Dọn dẹp các ô đã hết vật phẩm.
    }

    // Xóa các ô vật phẩm có số lượng bằng 0 khỏi kho đồ.
    protected virtual void ClearEmptySlots()
    {
        ItemInventory itemInventory;
        for (int i = this.items.Count - 1; i >= 0; i--) // Lặp ngược để tránh lỗi khi xóa phần tử khỏi danh sách đang lặp.
        {
            itemInventory = this.items[i];
            if (itemInventory.itemCount > 0) continue;
            this.items.RemoveAt(i);
        }
    }
}
