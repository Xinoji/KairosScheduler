using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Wizzard
{
    public partial class WizzardContent : UserControl
    {
        
        public virtual string Title { get => Forms.Text.ProyectName; }
        public virtual string Description { get => "NoTextSet"; }
        protected WizzardContent()
        {
            InitializeComponent();
        }
        public virtual object GetData() { return null; }

    }
}
