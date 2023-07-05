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
    public partial class WizardSelectType : WizzardContent
    {
        public override string Title { get => "Seleccione el Horairo"; }
        public override string Description { get => "Seleccione la forma en la que se elaborara el horario"; }
        public WizardSelectType() : base()
        {
            InitializeComponent();
        }
    }
}
