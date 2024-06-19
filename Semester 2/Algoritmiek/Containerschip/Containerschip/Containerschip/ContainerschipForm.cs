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
            containers.Clear();
            int shipWidth = (int)shipWidthInput.Value;
            int shipLength = (int)shipLengthInput.Value;

            //Normal containers
            for (int i = 0; i < 25; i++)
            {
                containers.Add(new Container(30, 1));
            }
            // Coolable containers
            for (int i = 0; i < 7; i++)
            {
                containers.Add(new Container(30, 2));
            }
            // Valuable containers
            for (int i = 0; i < 5; i++)
            {
                containers.Add(new Container(30, 3));
            }
            // Coolable and valuable containers
            for (int i = 0; i < 3; i++)
            {
                containers.Add(new Container(30, 4));
            }

            Crane Crane = new Crane(shipWidth, shipLength);

            Crane.Containers.AddRange(containers);
            Crane.Run();
        }
    }
}