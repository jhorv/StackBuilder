﻿#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class UCtrlBundle : UCtrlPackable
    {
        #region Constructor
        public UCtrlBundle()
        {
            InitializeComponent();

            uCtrlDimensions.ValueChanged += this.onPropertyChanged;
            uCtrlUnitThickness.ValueChanged += this.onPropertyChanged;
            uCtrlUnitWeight.ValueChanged += this.onPropertyChanged;
            nudNoFlats.ValueChanged += this.onPropertyChanged;
        }
        #endregion

        #region Public properties
        public double UnitThickness
        {
            get { return uCtrlUnitThickness.Value; }
            set { uCtrlUnitThickness.Value = value;}
        }
        public double[] Dimensions
        {
            get { return new double[] { uCtrlDimensions.ValueX, uCtrlDimensions.ValueY, UnitThickness }; }
            set
            {
                uCtrlDimensions.ValueX = value[0]; 
                uCtrlDimensions.ValueY = value[1]; 
                UnitThickness = value[2];
            }
        }
        public int NoFlats
        {
            get { return (int)nudNoFlats.Value; }
            set { nudNoFlats.Value = (decimal)value; }
        }
        public double UnitWeight
        {
            get { return uCtrlUnitWeight.Value; }
            set { uCtrlUnitWeight.Value = value; }
        }

        public override Packable PackableProperties
        {
            get
            {
                BundleProperties bundle = new BundleProperties(
                    null, "Bundle", "Bundle"
                    , uCtrlDimensions.ValueX, uCtrlDimensions.ValueY
                    , UnitThickness
                    , UnitWeight
                    , NoFlats
                    , Color.Gray);
                return bundle;
            }
        }
        #endregion

        #region Event handlers
        private void onPropertyChanged(object sender, EventArgs e)
        {
            if (null != ValueChanged)
                ValueChanged(this, e);
        }
        #endregion

        #region Events
        public delegate void OnValueChanged(object sender, EventArgs e);
        public event OnValueChanged ValueChanged;
        #endregion
    }
}
