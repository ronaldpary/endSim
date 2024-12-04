using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newspapers.Presentation;

namespace Newspapers.Logic
{
    public class ControllerDifferentRnd
    {
        public UserControlN1 control;

        public Row rowPrevious;
        public Row rowCurrent;

        public RowP2 rowPreviousP2;
        public RowP2 rowCurrentP2;

        public Random rndDemand = new Random();
        public Random rndOrder = new Random();

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

        public double order1 = 21;
        public double order2 = 22;
        public double order3 = 23;
        public double order4 = 24;
        public double frequencyP21 = 0.25;
        public double frequencyP22 = 0.25;
        public double frequencyP23 = 0.25;
        public double frequencyP24 = 0.25;

        public ControllerDifferentRnd(UserControlN1 control)
        {
            this.control = control;
            rowPrevious = new Row();
            rowCurrent = new Row();

            rowPreviousP2 = new RowP2();
            rowCurrentP2 = new RowP2();

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

                rowCurrent.leftoverNewspaper = Math.Max(0, rowCurrent.order - rowCurrent.demand);
                rowCurrent.lostSales = Math.Max(0, rowCurrent.demand - rowCurrent.order);

                rowCurrent.cost = cost * rowCurrent.order;
                rowCurrent.repayment = repayment * rowCurrent.leftoverNewspaper;
                rowCurrent.lostSalesCost = lostCost * rowCurrent.lostSales;

                rowCurrent.dailyNetCost = rowCurrent.cost + rowCurrent.lostSalesCost - rowCurrent.repayment;
                rowCurrent.sumDailyNetCost = rowCurrent.dailyNetCost + rowPrevious.sumDailyNetCost;
                rowCurrent.dailyAveregeCost = rowCurrent.sumDailyNetCost / rowCurrent.day;

                if (rowCurrent.day >= from && rowCurrent.day <= to)
                {
                    control.showRow(rowCurrent);
                }

                rowPrevious.demand = rowCurrent.demand;
                rowPrevious.lostSales = rowCurrent.lostSales;
                rowPrevious.sumDailyNetCost = rowCurrent.sumDailyNetCost;

            }

            if (rowCurrent.day > to)
            {
                control.showRow(rowCurrent);
            }

        }


        private void calculateOrder()
        {
            rowCurrent.order = rowPrevious.demand + rowPrevious.lostSales;
        }

        private void calculateDemand()
        {
            rowCurrent.rndDemand = double.Parse(rndDemand.NextDouble().ToString("F2"));

            if (rowCurrent.rndDemand < frequency1)
            {
                rowCurrent.demand = demand1;
            }
            else if (rowCurrent.rndDemand < frequency1 + frequency2)
            {
                rowCurrent.demand = demand2;
            }
            else if (rowCurrent.rndDemand < frequency1 + frequency2 + frequency3)
            {
                rowCurrent.demand = demand3;
            }
            else if (rowCurrent.rndDemand < frequency1 + frequency2 + frequency3 + frequency4)
            {
                rowCurrent.demand = demand4;
            }
            else if (rowCurrent.rndDemand < frequency1 + frequency2 + frequency3 + frequency4 + frequency5)
            {
                rowCurrent.demand = demand5;
            }
            else { rowCurrent.demand = demand6; }
        }

        public void startSimulationP2(Parameters parameters, int days, int from, int to)
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

            order1 = parameters.order1;
            order2 = parameters.order2;
            order3 = parameters.order3;
            order4 = parameters.order4;
            frequencyP21 = parameters.frequencyP21;
            frequencyP22 = parameters.frequencyP22;
            frequencyP23 = parameters.frequencyP23;
            frequencyP24 = parameters.frequencyP24;

            simulateP2(days, from, to);
        }

        private void simulateP2(int days, int from, int to)
        {
            for (int i = 0; i < days; i++)
            {
                rowCurrentP2.dayP2++;
                
                calculateDemandP2();

                calculateOrderP2();

                rowCurrentP2.leftoverNewspaperP2 = Math.Max(0, rowCurrentP2.orderP2 - rowCurrentP2.demandP2);
                rowCurrentP2.lostSalesP2 = Math.Max(0, rowCurrentP2.demandP2 - rowCurrentP2.orderP2);

                rowCurrentP2.costP2 = cost * rowCurrentP2.orderP2;
                rowCurrentP2.repaymentP2 = repayment * rowCurrentP2.leftoverNewspaperP2;
                rowCurrentP2.lostSalesCostP2 = lostCost * rowCurrentP2.lostSalesP2;

                rowCurrentP2.dailyNetCostP2 = rowCurrentP2.costP2 + rowCurrentP2.lostSalesCostP2 - rowCurrentP2.repaymentP2;
                rowCurrentP2.sumDailyNetCostP2 = rowCurrentP2.dailyNetCostP2 + rowPreviousP2.sumDailyNetCostP2;
                rowCurrentP2.dailyAveregeCostP2 = rowCurrentP2.sumDailyNetCostP2 / rowCurrentP2.dayP2;

                if (rowCurrentP2.dayP2 >= from && rowCurrentP2.dayP2 <= to)
                {
                    control.showRowP2(rowCurrentP2);
                }

                rowPreviousP2.sumDailyNetCostP2 = rowCurrentP2.sumDailyNetCostP2;

            }

            if (rowCurrentP2.dayP2 > to)
            {
                control.showRowP2(rowCurrentP2);
            }

        }

        private void calculateOrderP2()
        {
            rowCurrentP2.rndOrderP2 = double.Parse(rndOrder.NextDouble().ToString("F2"));

            if (rowCurrentP2.rndOrderP2 < frequencyP21)
            {
                rowCurrentP2.orderP2 = order1;
            }
            else if (rowCurrentP2.rndOrderP2 < frequencyP21 + frequencyP22)
            {
                rowCurrentP2.orderP2 = order2;
            }
            else if (rowCurrentP2.rndOrderP2 < frequencyP21 + frequencyP22 + frequencyP23)
            {
                rowCurrentP2.orderP2 = order3;
            }
            else { rowCurrentP2.orderP2 = order4; }
        }

        private void calculateDemandP2()
        {
            rowCurrentP2.rndDemandP2 = double.Parse(rndDemand.NextDouble().ToString("F2"));

            if (rowCurrentP2.rndDemandP2 < frequency1)
            {
                rowCurrentP2.demandP2 = demand1;
            }
            else if (rowCurrentP2.rndDemandP2 < frequency1 + frequency2)
            {
                rowCurrentP2.demandP2 = demand2;
            }
            else if (rowCurrentP2.rndDemandP2 < frequency1 + frequency2 + frequency3)
            {
                rowCurrentP2.demandP2 = demand3;
            }
            else if (rowCurrentP2.rndDemandP2 < frequency1 + frequency2 + frequency3 + frequency4)
            {
                rowCurrentP2.demandP2 = demand4;
            }
            else if (rowCurrentP2.rndDemandP2 < frequency1 + frequency2 + frequency3 + frequency4 + frequency5)
            {
                rowCurrentP2.demandP2 = demand5;
            }
            else { rowCurrentP2.demandP2 = demand6; }
        }
    }
}
