using System;
using System.Data;
using System.Data.SqlClient;

namespace OrderAssignmentConsole
{
    class ItemModule
    {
        private static readonly string connectionString = CustomerModule.connectionString;
        private readonly SqlConnection connection = new SqlConnection(connectionString);
        private SqlDataAdapter sda;
        private DataTable dataTable;
        private int? ItemQuantity;
        private int? ItemPrice;
        private string ItemName;
        private void AddItem()
        {
            try
            {
                Console.WriteLine("Enter The Item name ");
                ItemName = Console.ReadLine();
                Console.WriteLine("Enter The Item Price");
                ItemPrice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter The Item Quantity");
                ItemQuantity = Convert.ToInt32(Console.ReadLine());
                if (ItemName != "" && ItemQuantity > 0 && ItemPrice > 0 )
                {
                    if (!ItemExistOrNot(ItemName))
                    {
                        string sql = "insert into OrderItem values('" + ItemName + "'," + ItemPrice + "," + ItemQuantity + ")";
                        sda = new SqlDataAdapter(sql, connection);
                        dataTable = new DataTable();
                        sda.Fill(dataTable);
                        Console.WriteLine("Item Added Successfully");
                    }
                    else
                        Console.WriteLine("This Item Already Exist");
                }
                else
                    Console.WriteLine(" You Have left an Item As Blank Giave Value That Item");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void DeleteItem()
        {
            try
            {
                Console.WriteLine("ENter the Item Name To be Delete");
                string deleteItemName = Console.ReadLine();
                if (deleteItemName == "")
                {
                    Console.WriteLine("Enter the Valid Name It Can't Be Null");
                }
                else
                {
                    if (ItemExistOrNot(deleteItemName))
                    {
                        string sql = "delete from OrderItem where ItemName='" + deleteItemName + "'";
                        sda = new SqlDataAdapter(sql, connection);
                        dataTable = new DataTable();
                        sda.Fill(dataTable);
                        Console.WriteLine("Item Delete SUccessfully !.");
                    }
                    else
                        Console.WriteLine("Item Does Not Exist in Record ");
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
        private void UpdateItem()
        {
                Console.WriteLine("Enter The Item name That You Want to Update");
               string itemName = Console.ReadLine();
                if (itemName != "")
                {
                    if (ItemExistOrNot(itemName))
                    {
                        string newItemName;
                        int? newPrice;
                        int? NewQuantity;
                        try
                        {
                            Console.WriteLine("Enter the New Name Of Item That you Want to Update");
                            newItemName = Console.ReadLine();
                            Console.WriteLine("Enter the New Price");
                            newPrice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the New Quantity");
                            NewQuantity = Convert.ToInt32(Console.ReadLine());
                            if (newItemName == "" && newPrice == null && NewQuantity == null)
                            {
                                Console.WriteLine("Enter the correct data");
                            }
                            else
                            {
                                string sql = "update OrderItem set ItemName='" + newItemName + "',ItemPrice=" + newPrice + ",ItemQuantity=" + NewQuantity + " where ItemName='" + itemName + "'";
                                sda = new SqlDataAdapter(sql, connection);
                                dataTable = new DataTable();
                                sda.Fill(dataTable);
                                Console.WriteLine("Item Update Successfully");
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                        Console.WriteLine("Item Does Not Exist in Record...");
                }
                else
                    Console.WriteLine("Enter the Name It can't Be null");
        }
        private void LisyOfAllItems()
        {
            try
            {
                string sql = "select * from OrderItem";
                sda = new SqlDataAdapter(sql, connection);
                dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //print column
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        Console.Write(dataTable.Columns[i].ColumnName + "  ");
                    }
                    Console.WriteLine();
                    //print the list of all item
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            Console.Write(dataTable.Rows[i][j] + "     ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("No Data Found...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataTable = null;
        }
        private bool ItemExistOrNot(string ItemName)
        {
            DataTable dt = new DataTable();
            string sql = "select * from OrderItem where ItemName='" + ItemName + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void ItemMenu()
        {
        MainMenu:
            Console.WriteLine("To Add Item      Press :1 ");
            Console.WriteLine("To Delete Item   Press :2 ");
            Console.WriteLine("To update Item   Press :3 ");
            Console.WriteLine("to Show All Item Press :4 ");
            Console.WriteLine("To Exit          Press :5 ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddItem();
                    goto MainMenu;
                case 2:
                    DeleteItem();
                    goto MainMenu;
                case 3:
                    UpdateItem();
                    goto MainMenu;
                case 4:
                    LisyOfAllItems();
                    goto MainMenu;
                case 5:
                    break;
            }
        }
    }
}