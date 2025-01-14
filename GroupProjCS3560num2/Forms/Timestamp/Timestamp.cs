﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GroupProjCS3560num2.Classes;
using GroupProjCS3560num2.Classes.Handlers;
using System.Globalization;

namespace GroupProjCS3560num2.Forms
{
    public partial class Timestamp : Form
    {
        public Timestamp(TimeLog timelog)
        {
            InitializeComponent();
            empName.Text = TimestampHandler.GetEmpName(timelog);
            timelogID.Text = TimestampHandler.getTimestampID(timelog).ToString();

            clockInDate.Text = TimestampHandler.GetCheckInTime(timelog).ToShortDateString();
            clockInTime.Text = TimestampHandler.GetCheckInTime(timelog).ToShortTimeString();
            clockOutDate.Text = TimestampHandler.GetCheckOutTime(timelog).ToShortDateString();
            clockOutTime.Text = TimestampHandler.GetCheckOutTime(timelog).ToShortTimeString();

            warning.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void clockOutDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void deleteTimestamp_Click(object sender, EventArgs e)
        {
            //int delEmpID = Int32.Parse(timelogID.Text);
            TimestampHandler.DeleteTimestamp(int.Parse(timelogID.Text));
            this.Close();
        }

        private void cancelTimestamp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmTimestamp_Click(object sender, EventArgs e)
        {
            int newLogID = Int32.Parse(timelogID.Text);
            int newEmpID = TimestampHandler.GetEmpID(newLogID);

            DateTime newClockIn = DateTime.Parse(clockInDate.Value.ToShortDateString());
            string clockInTimeStr = clockInTime.Value.ToString("HH:mm");
            newClockIn += TimeSpan.Parse(clockInTimeStr);

            DateTime newClockOut = DateTime.Parse(clockOutDate.Value.ToShortDateString());
            string clockOutTimeStr = clockOutTime.Value.ToString("HH:mm");
            newClockOut += TimeSpan.Parse(clockOutTimeStr);

            if(newClockOut <= newClockIn)
            {
                warning.Show();
            }
            else
            {
                TimestampHandler.UpdateTimestamp(newLogID, newEmpID, newClockIn, newClockOut);
                this.Close();
            }
        }

        private void timestampID_Click(object sender, EventArgs e)
        {

        }

        private void empJob_Click(object sender, EventArgs e)
        {

        }

        private void clockInDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
