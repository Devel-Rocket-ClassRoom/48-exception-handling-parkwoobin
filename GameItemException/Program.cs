using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.



Console.WriteLine("=== 인벤토리 테스트 ===");
Inventory inventory = new Inventory(3);
try
{
    inventory.AddItem("검");
    inventory.AddItem("방패");
    inventory.AddItem("포션");
    inventory.AddItem("활"); // 용량 초과
}
catch (InventoryFullException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
inventory.ShowItems();
try
{

    inventory.RemoveItem("포션");
    inventory.RemoveItem("도끼"); // 아이템 없음

}
catch (ItemNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine();
inventory.ShowItems();




class Inventory
{
    int maxCapacity;
    List<string> items;

    public Inventory(int capacity)
    {
        maxCapacity = capacity;
        items = new List<string>();
    }

    public void AddItem(string itemName)
    {
        if (items.Count >= maxCapacity)
        {
            throw new InventoryFullException($"[인벤토리 오류] 인벤토리가 가득 찼습니다. (용량: {maxCapacity}, 아이템: {itemName})");
        }
        items.Add(itemName);
        Console.WriteLine($"아이템 '{itemName}' 추가됨");
    }

    public void RemoveItem(string itemName)
    {
        if (!items.Remove(itemName))
        {
            throw new ItemNotFoundException($"[인벤토리 오류] 아이템을 찾을 수 없습니다: {itemName}");
        }
        Console.WriteLine($"아이템 '{itemName}' 제거됨");
    }

    public void ShowItems()
    {

        Console.WriteLine($"현재 인벤토리: {string.Join(", ", items)}");

    }
}

class InventoryFullException : Exception
{
    public InventoryFullException(string message) : base(message) { }
}

class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message) : base(message) { }
}
