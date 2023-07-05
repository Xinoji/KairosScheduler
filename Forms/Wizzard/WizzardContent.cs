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
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        protected WizzardContent()
        {
            InitializeComponent();
        }

    }
}
