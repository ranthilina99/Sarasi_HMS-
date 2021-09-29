using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement.selectthings
{
    public partial class ButtonEDTeams : UserControl
    {
        public ButtonEDTeams()
        {
            InitializeComponent();
        }
        //Getters and setters -1 step-
        public string DTeamID
        {
            get { return lblDTBtnID.Text; }
            set { lblDTBtnID.Text = value; }
        }

        public string DTname
        {
            get { return lblDTeamBtnName.Text; }
            set { lblDTeamBtnName.Text = value; }
        }

        private void ButtonEDTeams_Click(object sender, EventArgs e)
        {
            String id = this.DTeamID;
            EEselectDTeam esp = EEselectDTeam.getInstance();
            esp.DisplayEventDecoTeamsCard(id);
        }
    }
}
