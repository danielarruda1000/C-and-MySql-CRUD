using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataBaseCRUD
{
    public class userModel {
    
        public string Name { get; set; }
        public int Id { get; set; }
        public double Balance { get; set; }
    
        public userModel() { }
        public userModel(string aName, int aId, double aBalance):this() 
        {
            this.Name = aName;
            this.Id = aId;
            this.Balance = aBalance;
        }

   
    }
}
