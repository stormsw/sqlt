using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLt
{
    interface IConnectionStringDialog
    {
        void SaveOptions();
        void LoadOptions();
        string ConnectionString();
    }
}
