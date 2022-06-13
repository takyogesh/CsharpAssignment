using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    public class ReadAndWrite : Store
    {
        public FileStream FsObj1;
        public FileStream FsObj2;
        public StreamReader SrObj1;
        public StreamReader SrObj2;
        public StreamWriter SwObj1;

        public void AddnewItem(string filename, ArrayList arrayList)
        {
            try
            {
                FsObj1 = new FileStream(filename, FileMode.Append, FileAccess.Write);
                SwObj1 = new StreamWriter(FsObj1);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    SwObj1.Write(arrayList[i] + ",");
                }
                SwObj1.Write("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                SwObj1.Dispose();
                SwObj1.Close();
                FsObj1.Close();
            }
        }
        public void ListAllItem(string filename)
        {
            try
            {
                FsObj1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                SrObj1 = new StreamReader(FsObj1);
                while (SrObj1.Peek() > 0)
                {
                    string lines = SrObj1.ReadLine();
                    if (lines != "")
                    {
                        string[] data = lines.Split(',');
                        for (int i = 0; i < data.Length; i++)
                        {
                            Console.WriteLine("   " + data[i] + "  ");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                SrObj1.Dispose();
                SrObj1.Close();
                FsObj1.Close();
            }
        }
        public void UpdateExistItem(int id, string name, ArrayList arrayList, string filename)
        {
            List<string> list = new List<string>();
            try
            {
                FsObj1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                SrObj1 = new StreamReader(FsObj1);
                while (SrObj1.Peek() > 0)
                {
                    string line = SrObj1.ReadLine();
                    if (line != "")
                    {
                        list.Add(line);
                    }
                }
                SrObj1.Dispose();
                SrObj1.Close();
                FsObj1.Close();
                FsObj1 = new FileStream(filename, FileMode.Open, FileAccess.Write);
                SwObj1 = new StreamWriter(FsObj1);
                for (int i = 0; i < list.Count; i++)
                {
                    string lines = list[i].ToString();
                    Console.WriteLine(lines);

                    string[] arr = lines.Split(',');
                    if (Convert.ToInt32(arr[0]) == id && arr[1].ToString() == name)
                    {
                        for (int j = 0; j < arrayList.Count; j++)
                        {
                            SwObj1.Write(arrayList[j].ToString() + ",");
                            Console.WriteLine(arrayList[j]);
                        }
                    }
                    else
                    {
                        SwObj1.Write(lines);
                        Console.WriteLine("insise");
                    }
                }
                SwObj1.Write("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                SwObj1.Dispose();
                SwObj1.Close();
                FsObj1.Close();
            }
        }
        public void ViewDetailsOfItems(int id, string name, string filename)
        {
            try
            {
                FsObj1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                SrObj1 = new StreamReader(FsObj1);
                while (SrObj1.Peek() > 0)
                {
                    string lines = SrObj1.ReadLine();
                    if (lines != "")
                    {
                        string[] data = lines.Split(',');
                        if (data[1] == name && Convert.ToInt32(data[0]) == id)
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                Console.WriteLine("     " + data[i] + "  ");
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                SrObj1.Dispose();
                SrObj1.Close();
                FsObj1.Close();
            }
        }
        public void oldTonew(string oldname, string newname, string filename)
        {

            List<string> list = new List<string>();
            try
            {
                FsObj1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                SrObj1 = new StreamReader(FsObj1);
                while (SrObj1.Peek() > 0)
                {
                    string line = SrObj1.ReadLine();
                    if (line != "")
                    {
                        list.Add(line);
                    }
                }
                SwObj1.Dispose();
                SwObj1.Close();
                FsObj1.Close();
                FsObj1 = new FileStream(filename, FileMode.Open, FileAccess.Write);
                SwObj1 = new StreamWriter(FsObj1);
                for (int i = 0; i < list.Count; i++)
                {
                    string line = list[i];
                    if (line != "")
                    {
                        string[] arr = line.Split(',');
                        if (arr[2] == oldname)
                        {
                            arr[1] = newname;
                            for (int j = 0; j < arr.Length; j++)
                            {
                                SwObj1.Write(arr[j] + ",");
                            }
                        }
                        else
                        {
                            SwObj1.Write(line);
                        }
                    }
                    SwObj1.Write("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                SwObj1.Dispose();
                SwObj1.Close();
                FsObj1.Close();
            }
        }
    }
}
