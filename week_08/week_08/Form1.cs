﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week_08.Entities;
using week_08.Abstractions;

namespace week_08
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        private Toy _nextToy;
        private IToyFactory _factory;
        private IToyFactory Factory
        {
            get { return _factory; }
            set 
            { _factory = value;
                DisplayNext();

            }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
        }
        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            panel1.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                panel1.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void createTimer_Tick_1(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;

            panel1.Controls.Add(toy);
        }

        private void conveyorTimer_Tick_1(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                panel1.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void carbutton_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void ballbutton_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = button1.BackColor
            };
        }
        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                Controls.Remove(_nextToy);
                
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Top + 20;
            _nextToy.Left = label1.Left;
            panel1.Controls.Add(_nextToy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }
    }
}
