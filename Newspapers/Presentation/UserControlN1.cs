using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newspapers.Logic;

namespace Newspapers.Presentation
{
    public partial class UserControlN1 : System.Windows.Forms.UserControl
    {
        Parameters parameters = new Parameters();
        Controller controller;
        public UserControlN1()
        {
            InitializeComponent();
            loadValues();
        }

        private void loadValues()
        {
            txtPrice.Text = this.parameters.cost.ToString();
            txtRepayment.Text = this.parameters.repayment.ToString();
            txtLostCost.Text = this.parameters.lostCost.ToString();
            txtPreviousDemand.Text = this.parameters.previousDemand.ToString();
            txtPreviousLostSales.Text = this.parameters.previousLostSales.ToString();
            txtDemand1.Text = this.parameters.demand1.ToString();
            txtDemand2.Text = this.parameters.demand2.ToString();
            txtDemand3.Text = this.parameters.demand3.ToString();
            txtDemand4.Text = this.parameters.demand4.ToString();
            txtDemand5.Text = this.parameters.demand5.ToString();
            txtDemand6.Text = this.parameters.demand6.ToString();
            txtFrequency1.Text = this.parameters.frequency1.ToString();
            txtFrequency2.Text = this.parameters.frequency2.ToString();
            txtFrequency3.Text = this.parameters.frequency3.ToString();
            txtFrequency4.Text = this.parameters.frequency4.ToString();
            txtFrequency5.Text = this.parameters.frequency5.ToString();
            txtFrequency6.Text = this.parameters.frequency6.ToString();
        }

        private void txtSimulaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
