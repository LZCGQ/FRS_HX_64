using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAngineSet.Model;

namespace DataAngineSet.BLL
{
    public partial class statistics
    {
        private readonly DataAngineSet.DAL.statistics st = new DataAngineSet.DAL.statistics();
        public bool Update(DataAngineSet.Model.statistics model)
        {
            return st.Update(model);
        }

    }
}
