using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAssignmentConsole
{
    class ItemModule
    {
        private int? ItemQuantity;
        private Double? ItemPrice;
        private string ItemName;
        private static readonly string _connectionString = @"Data Source=DESKTOP-AMR2CQS\MSSQLSERVER01;Initial Catalog=OrderAssignment;Integrated Security=True";
        private readonly SqlConnection _connection = new SqlConnection(_connectionString);
        private SqlDataAdapter sqlDataAdapter;
        private DataTable getDataItem = new DataTable();

        private void AddItem()
        {
            try
            {
                Console.WriteLine("Enter The Item name ");
                ItemName = Console.ReadLine();

                Console.WriteLine("Enter The Item Price");
                ItemPrice = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter The Item Quantity");
                ItemQuantity = Convert.ToInt32(Console.ReadLine());
                if (ItemQuantity > 0 && ItemPrice > 0 && ItemName != "")
                {
                    if (!ItemExistOrNot(ItemName))
                    {
                        string sql = "insert into OrderItem values('" + ItemName + "'," + ItemPrice + "," + ItemQuantity + ")";
                        sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                        sqlDataAdapter.Fill(getDataItem);
                        Console.WriteLine("Item Added Successfully");
                    }
                    else
                        Console.WriteLine("This Item Already Exist  Use Another...");
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
                        sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                        sqlDataAdapter.Fill(getDataItem);
                        Console.WriteLine("Item Delete SUccessfully !.");
                    }
                    else
                    {
                        Console.WriteLine("Item Does Not Exist in Record ...\n Enter Valid Name");
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
        }
        private void UpdateItem()
        {
            getDataItem = null;
            string updateItemName;
            try
            {
                Console.WriteLine("Enter The Item name That You Want to Update");
                updateItemName = Console.ReadLine();
                if (updateItemName == "")
                {
                    Console.WriteLine("Enter the Name It can't Be null");
                }
                else
                {
                    if (ItemExistOrNot(updateItemName))
                    {
                        string oldtonewname;
                        double? newPrice;
                        int? NewQuantity;
                        try
                        {
                            Console.WriteLine("Enter the New Name Of Item That you Want to Update");
                            oldtonewname = Console.ReadLine();
                            Console.WriteLine("Enter the New Price");
                            newPrice = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the New Quantity");
                            NewQuantity = Convert.ToInt32(Console.ReadLine());
                            if (oldtonewname == "" || newPrice == null || NewQuantity == null)
                            {
                                Console.WriteLine("Enter the correct data");
                            }
                            else
                            {
                                string sql = "update OrderItem set ItemName='" + oldtonewname + "',ItemPrice=" + newPrice + ",ItemQuantity=" + NewQuantity + " where ItemName='" + updateItemName + "'";
                                sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                                sqlDataAdapter.Fill(getDataItem);
                                Console.WriteLine("Item Update Successfully");
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.ToString() + "\nPlease Enter The Valid Credentials...");
                        }
                    }
                    else
                        Console.WriteLine("Item Does Not Exist in Record...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Try Latter ...");
            }
        }
        private void LisyOfAllItems()
        {
            try
            {
                string sql = "select * from OrderItem";
                sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                sqlDataAdapter.Fill(getDataItem);
                if (getDataItem.Rows.Count > 0)
                {
                    //print column
                    for (int i = 0; i < getDataItem.Columns.Count; i++)
                    {
                        Console.Write(getDataItem.Columns[i].ColumnName + "  ");
                    }
                    Console.WriteLine();
                    //print the list of all item
                    for (int i = 0; i < getDataItem.Rows.Count; i++)
                    {
                        for (int j = 0; j < getDataItem.Columns.Count; j++)
                        {
                            Console.Write(getDataItem.Rows[i][j] + "     ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            getDataItem = null;
        }
        private bool ItemExistOrNot(string ItemName)
        {
            DataTable dataTable = new DataTable();
            string sql = "select * from OrderItem where ItemName='" + ItemName + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
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