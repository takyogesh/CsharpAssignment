using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    interface Store
    {
        void AddnewItem(string filename, ArrayList arrayList);
        void UpdateExistItem(int id, string name, ArrayList arrayList, string filename);
        void ListAllItem(string filename);
        void ViewDetailsOfItems(int id, string name, string filename);
    }
}
