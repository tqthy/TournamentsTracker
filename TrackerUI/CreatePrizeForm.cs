﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(model);

                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            } else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }
        }
        private bool validateForm()
        {
            bool output = true;
            int placeNumber = 0;
            if (!int.TryParse(placeNumberValue.Text, out placeNumber) || placeNumber < 1)
            {
                output = false;
            }
            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            if (!decimal.TryParse(prizeAmountValue.Text, out prizeAmount) || prizeAmount < 0)
            {
                output = false;
            }
            double prizePercentage = 0;
            if (!double.TryParse(prizePercentageValue.Text, out prizePercentage) || prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            return output;
        }
    }
}
