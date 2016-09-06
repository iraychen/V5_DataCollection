﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using V5_DataCollection._Class.PythonExt;

namespace V5_DataCollection.Forms.Tools {
    public partial class frmEditor : BaseForm {

        public string PythonFilePath { get; set; } = string.Empty;

        public object[] PythonInputParam { get; set; } = new object[] { "test" };

        public frmEditor() {
            InitializeComponent();

            this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;

            this.fastColoredTextBox1.TextChanged += FastColoredTextBox1_TextChanged;


        }

        private void FastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {

        }

        private void toolStripButton_RunScript_Click(object sender, EventArgs e) {
            this.textBox1.Clear();
           
            PythonExtHelper.RunScriptPython(this.fastColoredTextBox1.Text, PythonInputParam);
        }

        private void toolStripButton_ScriptSave_Click(object sender, EventArgs e) {
            File.WriteAllText(this.PythonFilePath, this.fastColoredTextBox1.Text);
            this.Close();
        }

        private void frmEditor_Load(object sender, EventArgs e) {
            var allText = File.ReadAllText(PythonFilePath);

            this.fastColoredTextBox1.Text = allText;

            PythonExtHelper.OutWriteHandler += (string msg) => {
                this.textBox1.AppendText(msg);
            };
        }
    }
}