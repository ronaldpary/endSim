using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newspapers.Presentation
{
    public partial class DemandFrequencyForm : Form
    {
        public DemandFrequencyForm()
        {
            InitializeComponent();
        }

        public void addRow(int cant, double frec, double sum, string interval)
        {
            dgvDemand.Rows.Add(cant, frec.ToString("F2"), sum.ToString("F2"), interval);
        }

        private void DemandFrequencyForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
