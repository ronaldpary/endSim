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
            txtPrice.Text = parameters.cost.ToString();
            txtRepayment.Text = parameters.repayment.ToString();
            txtLostCost.Text = parameters.lostCost.ToString();
            txtPreviousDemand.Text = parameters.previousDemand.ToString();
            txtPreviousLostSales.Text = parameters.previousLostSales.ToString();

            txtDemand1.Text = parameters.demand1.ToString();
            txtDemand2.Text = parameters.demand2.ToString();
            txtDemand3.Text = parameters.demand3.ToString();
            txtDemand4.Text = parameters.demand4.ToString();
            txtDemand5.Text = parameters.demand5.ToString();
            txtDemand6.Text = parameters.demand6.ToString();
            txtFrequency1.Text = parameters.frequency1.ToString();
            txtFrequency2.Text = parameters.frequency2.ToString();
            txtFrequency3.Text = parameters.frequency3.ToString();
            txtFrequency4.Text = parameters.frequency4.ToString();
            txtFrequency5.Text = parameters.frequency5.ToString();
            txtFrequency6.Text = parameters.frequency6.ToString();

            txtOrder1.Text = parameters.order1.ToString();
            txtOrder2.Text = parameters.order2.ToString();
            txtOrder3.Text = parameters.order3.ToString();
            txtOrder4.Text = parameters.order4.ToString();
            txtFrequencyP21.Text = parameters.frequencyP21.ToString();
            txtFrequencyP22.Text = parameters.frequencyP22.ToString();
            txtFrequencyP23.Text = parameters.frequencyP23.ToString();
            txtFrequencyP24.Text = parameters.frequencyP24.ToString();

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
            if (txtSimulations.Text != "" && txtFrom.Text != "" && txtTo.Text != "" && txtPrice.Text != "" && txtRepayment.Text != "" && txtLostCost.Text != "" && txtPreviousDemand.Text != "" && txtPreviousLostSales.Text != ""
                && txtDemand1.Text != "" && txtDemand2.Text != "" && txtDemand3.Text != "" && txtDemand4.Text != "" && txtDemand5.Text != "" && txtDemand6.Text != ""
                && txtFrequency1.Text != "" && txtFrequency2.Text != "" && txtFrequency3.Text != "" && txtFrequency4.Text != "" && txtFrequency5.Text != "" && txtFrequency6.Text != "")
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
                else if (sum < 1)
                {
                    MessageBox.Show("The sum of the frequencies must be equal to 1.");
                }
                else if (sum < 0)
                {
                    MessageBox.Show("The sum of the frequencies must not be less than 0.");
                }
                else if (Convert.ToDouble(txtFrom.Text) > Convert.ToDouble(txtTo.Text))
                {
                    MessageBox.Show("From cannot be greater than To.");
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

            if (txtOrder1.Text != "") { parameters.order1 = Convert.ToDouble(txtOrder1.Text); }
            if (txtOrder2.Text != "") { parameters.order2 = Convert.ToDouble(txtOrder2.Text); }
            if (txtOrder3.Text != "") { parameters.order3 = Convert.ToDouble(txtOrder3.Text); }
            if (txtOrder4.Text != "") { parameters.order4 = Convert.ToDouble(txtOrder4.Text); }

            if (txtFrequencyP21.Text != "") { parameters.frequencyP21 = Convert.ToDouble(txtFrequencyP21.Text); }
            if (txtFrequencyP22.Text != "") { parameters.frequencyP22 = Convert.ToDouble(txtFrequencyP22.Text); }
            if (txtFrequencyP23.Text != "") { parameters.frequencyP23 = Convert.ToDouble(txtFrequencyP23.Text); }
            if (txtFrequencyP24.Text != "") { parameters.frequencyP24 = Convert.ToDouble(txtFrequencyP24.Text); }

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

                    if (name == "cost")
                    {
                        dgvEvents.Rows[index].Cells["cost"].Style.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    if (name == "repayment")
                    {
                        dgvEvents.Rows[index].Cells["repayment"].Style.BackColor = Color.FromArgb(128, 255, 128);

                    }
                    if (name == "lostSalesCost")
                    {
                        dgvEvents.Rows[index].Cells["lostSalesCost"].Style.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    if (name == "dailyAveregeCost")
                    {
                        dgvEvents.Rows[index].Cells["dailyAveregeCost"].Style.BackColor = Color.FromArgb(255, 255, 128);
                    }
                }
                
            }
        }

        public void showRowP2(RowP2 row)
        {
            int index = dgvEventsP2.Rows.Add();

            PropertyInfo[] properties = typeof(RowP2).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string name = property.Name;
                double worth = (double)property.GetValue(row);

                if (worth != -1)
                {
                    dgvEventsP2.Rows[index].Cells[name].Value = worth;

                    if (name == "costP2")
                    {
                        dgvEventsP2.Rows[index].Cells["costP2"].Style.BackColor = Color.FromArgb(255, 192, 192);  
                    }
                    if (name == "repaymentP2")
                    {
                        dgvEventsP2.Rows[index].Cells["repaymentP2"].Style.BackColor = Color.FromArgb(128, 255, 128);

                    }
                    if (name == "lostSalesCostP2")
                    {
                        dgvEventsP2.Rows[index].Cells["lostSalesCostP2"].Style.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    if (name == "dailyAveregeCostP2")
                    {
                        dgvEventsP2.Rows[index].Cells["dailyAveregeCostP2"].Style.BackColor = Color.FromArgb(255, 255, 128);
                    }
                }

            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDemand3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnComenzar2_Click(object sender, EventArgs e)
        {
            controller = new Controller(this);
            if (txtSimulations.Text != "" && txtFrom.Text != "" && txtTo.Text != "" && txtPrice.Text != "" && txtRepayment.Text != "" && txtLostCost.Text != "" && txtPreviousDemand.Text != "" && txtPreviousLostSales.Text != ""
                && txtDemand1.Text != "" && txtDemand2.Text != "" && txtDemand3.Text != "" && txtDemand4.Text != "" && txtDemand5.Text != "" && txtDemand6.Text != ""
                && txtFrequency1.Text != "" && txtFrequency2.Text != "" && txtFrequency3.Text != "" && txtFrequency4.Text != "" && txtFrequency5.Text != "" && txtFrequency6.Text != ""
                && txtOrder1.Text != "" && txtOrder2.Text != "" && txtOrder3.Text != "" && txtOrder4.Text != ""
                && txtFrequencyP21.Text != "" && txtFrequencyP22.Text != "" && txtFrequencyP23.Text != "" && txtFrequencyP24.Text != "")
            {
                double frequency1 = Convert.ToDouble(txtFrequency1.Text);
                double frequency2 = Convert.ToDouble(txtFrequency2.Text);
                double frequency3 = Convert.ToDouble(txtFrequency3.Text);
                double frequency4 = Convert.ToDouble(txtFrequency4.Text);
                double frequency5 = Convert.ToDouble(txtFrequency5.Text);
                double frequency6 = Convert.ToDouble(txtFrequency6.Text);
                double sum = frequency1 + frequency2 + frequency3 + frequency4 + frequency5 + frequency6;

                double frequencyP21 = Convert.ToDouble(txtFrequencyP21.Text);
                double frequencyP22 = Convert.ToDouble(txtFrequencyP22.Text);
                double frequencyP23 = Convert.ToDouble(txtFrequencyP23.Text);
                double frequencyP24 = Convert.ToDouble(txtFrequencyP24.Text);
                double sumP2 = frequencyP21 + frequencyP22 + frequencyP23 + frequencyP24;

                if (sum > 1)
                {
                    MessageBox.Show("The sum of the frequencies must not exceed 1.");
                }
                else if (sum < 1)
                {
                    MessageBox.Show("The sum of the frequencies must be equal to 1.");
                }
                else if (sum < 0)
                {
                    MessageBox.Show("The sum of the frequencies must not be less than 0.");
                }
                else if (sumP2 > 1)
                {
                    MessageBox.Show("The sum of the frequencies must not exceed 1.");
                }
                else if (sumP2 < 1)
                {
                    MessageBox.Show("The sum of the frequencies must be equal to 1.");
                }
                else if (sumP2 < 0)
                {
                    MessageBox.Show("The sum of the frequencies must not be less than 0.");
                }
                else if (Convert.ToDouble(txtFrom.Text) > Convert.ToDouble(txtTo.Text))
                {
                    MessageBox.Show("From cannot be greater than To.");
                }
                else
                {
                    dgvEventsP2.Rows.Clear();
                    validateData(parameters);
                    controller.startSimulationP2(this.parameters, Convert.ToInt32(txtSimulations.Text), Convert.ToInt32(txtFrom.Text), Convert.ToInt32(txtTo.Text));

                }
            }
            else
            {
                MessageBox.Show("Please complete all fields.");
            }
        }
    }
}
