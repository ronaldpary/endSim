using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newspapers.Presentation;

namespace Newspapers.Logic
{
    public class Controller
    {
        public Random rndDemand = new Random();
        public UserControlN1 control;
        public Row rowPrevious;
        public Row rowCurrent;

        public double cost = 0.8;
        public double repayment = 0.20;
        public double lostCost = 0.40;
        public double previousDemand = 20;
        public double previousLostSales = 3;
        public double demand1 = 20;
        public double demand2 = 21;
        public double demand3 = 22;
        public double demand4 = 23;
        public double demand5 = 24;
        public double demand6 = 25;
        public double frequency1 = 0.30;
        public double frequency2 = 0.25;
        public double frequency3 = 0.20;
        public double frequency4 = 0.05;
        public double frequency5 = 0.10;
        public double frequency6 = 0.10;

        public Controller(UserControlN1 control) 
        {
            this.control = control;
            rowPrevious = new Row();
            rowCurrent = new Row();
        }

        public void startSimulation(Parameters parameters, int days, int from, int to)
        {
            cost = parameters.cost;
            repayment = parameters.repayment;
            lostCost = parameters.lostCost;
            previousDemand = parameters.previousDemand;
            previousLostSales = parameters.previousLostSales;

            demand1 = parameters.demand1;
            demand2 = parameters.demand2;
            demand3 = parameters.demand3;
            demand4 = parameters.demand4;
            demand5 = parameters.demand5;
            demand6 = parameters.demand6;

            frequency1 = parameters.frequency1;
            frequency2 = parameters.frequency2;
            frequency3 = parameters.frequency3;
            frequency4 = parameters.frequency4;
            frequency5 = parameters.frequency5;
            frequency6 = parameters.frequency6;

            simulate(days, from, to);
        }

        private void simulate(int days, int from, int to)
        {
            rowPrevious.demand = previousDemand;
            rowPrevious.lostSales = previousLostSales;
            control.showRow(rowPrevious);

            for (int i = 0; i < days; i++)
            {
                rowCurrent.day++;

                calculateDemand();

                calculateOrder();

                if (rowCurrent.day >= from && rowCurrent.day <= to)
                {
                    control.showRow(rowCurrent);
                }

                rowPrevious.demand = rowCurrent.demand;
                rowPrevious.lostSales = rowCurrent.lostSales;

            }
        }

        private void calculateOrder()
        {
            rowCurrent.order = rowPrevious.demand + rowPrevious.lostSales;
            rowCurrent.lostSales = rowCurrent.order - rowCurrent.demand;
        }

        private void calculateDemand()
        {
            rowCurrent.rndDemand = double.Parse(rndDemand.NextDouble().ToString("F2"));

            if (rowCurrent.rndDemand <=  frequency1)
            {
                rowCurrent.demand = demand1;
            }
            else if (rowCurrent.rndDemand <= frequency1 + frequency2)
            {
                rowCurrent.demand = demand2;
            }
            else if (rowCurrent.rndDemand <= frequency1 + frequency2 + frequency3)
            {
                rowCurrent.demand = demand3;
            }
            else if (rowCurrent.rndDemand <= frequency1 + frequency2 + frequency3 + frequency4)
            {
                rowCurrent.demand = demand4;
            }
            else if (rowCurrent.rndDemand <= frequency1 + frequency2 + frequency3 + frequency4 + frequency5)
            {
                rowCurrent.demand = demand5;
            }
            else { rowCurrent.demand = demand6;}
        }
    }
}
