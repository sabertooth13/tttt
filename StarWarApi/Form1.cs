using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWarApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ResultGridView.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            int MGLT = Int32.Parse(textMGLT.Text);
            GetApiResponse getApiResponse = new GetApiResponse();
            getApiResponse.GetStopsForEachShip(MGLT);
            ResultGridView.DataSource = MegalightCalc.getInstance().DisplayFlightInfo();
            ResultGridView.AutoResizeColumns();
            ResultGridView.AutoSizeColumnsMode =
         DataGridViewAutoSizeColumnsMode.AllCells;
            ResultGridView.Visible = true;
            Calc.Enabled = false;
        }

        private void ResultGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
