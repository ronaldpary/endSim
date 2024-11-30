using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            controller = new Controller(this);
            if (txtSimulations.Text != "" && txtFrom.Text != "" && txtTo.Text != "")
            {
                double frequency1 = Convert.ToDouble(txtFrequency1.Text);
                double frequency2 = Convert.ToDouble(txtFrequency2.Text);
                double frequency3 = Convert.ToDouble(txtFrequency3.Text);
                double frequency4 = Convert.ToDouble(txtFrequency4.Text);
                double frequency5 = Convert.ToDouble(txtFrequency5.Text);
                double frequency6 = Convert.ToDouble(txtFrequency6.Text);

                double sum = frequency1 + frequency2 + frequency3 + frequency4 + frequency5 + frequency6;

                if (sum > 1)
                {
                    MessageBox.Show("The sum of the frequencies must not exceed 1.");
                }
                else if (sum < 0)
                {
                    MessageBox.Show("The sum of the frequencies must not be less than 0.");
                }
                else
                {
                    dgvEvents.Rows.Clear();
                    validateData(parameters);
                    controller.startSimulation(this.parameters, Convert.ToInt32(txtSimulations.Text), Convert.ToInt32(txtFrom.Text), Convert.ToInt32(txtTo.Text));

                }
            }
            else
            {
                MessageBox.Show("Please complete all fields.");
            }
        }

        private void validateData(Parameters parameters)
        {
            if (txtPrice.Text != "") { parameters.cost = Convert.ToDouble(txtPrice.Text); }
            if (txtRepayment.Text != "") { parameters.repayment = Convert.ToDouble(txtRepayment.Text ); }
            if (txtLostCost.Text != "") { parameters.lostCost = Convert.ToDouble(txtLostCost.Text); }
            if (txtPreviousDemand.Text != "") { parameters.previousDemand = Convert.ToDouble(txtPreviousDemand.Text); }
            if (txtPreviousLostSales.Text != "") { parameters.previousLostSales = Convert.ToDouble(txtPreviousLostSales.Text); }

            if (txtDemand1.Text != "") { parameters.demand1 = Convert.ToDouble(txtDemand1.Text); }
            if (txtDemand2.Text != "") { parameters.demand2 = Convert.ToDouble(txtDemand2.Text); }
            if (txtDemand3.Text != "") { parameters.demand3 = Convert.ToDouble(txtDemand3.Text); }
            if (txtDemand4.Text != "") { parameters.demand4 = Convert.ToDouble(txtDemand4.Text); }
            if (txtDemand5.Text != "") { parameters.demand5 = Convert.ToDouble(txtDemand5.Text); }
            if (txtDemand6.Text != "") { parameters.demand6 = Convert.ToDouble(txtDemand6.Text); }

            if (txtFrequency1.Text != "") { parameters.frequency1 = Convert.ToDouble(txtFrequency1.Text); }
            if (txtFrequency2.Text != "") { parameters.frequency2 = Convert.ToDouble(txtFrequency2.Text); }
            if (txtFrequency3.Text != "") { parameters.frequency3 = Convert.ToDouble(txtFrequency3.Text); }
            if (txtFrequency4.Text != "") { parameters.frequency4 = Convert.ToDouble(txtFrequency4.Text); }
            if (txtFrequency5.Text != "") { parameters.frequency5 = Convert.ToDouble(txtFrequency5.Text); }
            if (txtFrequency6.Text != "") { parameters.frequency6 = Convert.ToDouble(txtFrequency6.Text); }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void showRow(Row row)
        {
            int index = dgvEvents.Rows.Add();

            PropertyInfo[] properties = typeof(Row).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string name = property.Name;
                double worth = (double)property.GetValue(row);

                if (worth != -1)
                {
                    dgvEvents.Rows[index].Cells[name].Value = worth;
                }
                
            }
        }
    }
}
