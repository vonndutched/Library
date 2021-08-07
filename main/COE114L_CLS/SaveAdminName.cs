using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE114L_CLS
{
    class SaveAdminName
    {
        public SaveAdminName() { }

        string[] adminName;
        int index;

        public SaveAdminName(string[] a, int n)
        {
            adminName = a;
            index = n;
        }

        public string[] getAdminName()
        {
            return adminName;
        }

        public int getIndex()
        {
            return index;
        }
    }
}
