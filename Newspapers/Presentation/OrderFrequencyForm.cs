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
    public partial class OrderFrequencyForm : Form
    {
        public OrderFrequencyForm()
        {
            InitializeComponent();
        }

        public void addRow(int cant, double frec, double sum, string interval)
        {
            dgvOrder.Rows.Add(cant, frec.ToString("F2"), sum.ToString("F2"), interval);
        }

        private void OrderFrequencyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
