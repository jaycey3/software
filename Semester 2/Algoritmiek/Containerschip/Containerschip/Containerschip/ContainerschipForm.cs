using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Containerschip
{
    public partial class form_1 : Form
    {
        public List<Container> containers = new List<Container>();

        public form_1()
        {
            InitializeComponent();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            int shipWidth = (int)shipWidthInput.Value;
            int shipLength = (int)shipLengthInput.Value;

            containers.Add(new Container(4, 1));
            containers.Add(new Container(30, 2));
            containers.Add(new Container(30, 3));
            containers.Add(new Container(30, 4));

            Crane Crane = new Crane(shipWidth, shipLength);

            Crane.Containers.AddRange(containers);
            Crane.Run();
        }
    }
}