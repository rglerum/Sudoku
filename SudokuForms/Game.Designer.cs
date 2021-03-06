﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuForms
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // REVIEW KirkG: This suspend/resume should go around our double-for-loops too.
            this.SuspendLayout();

            // 
            // btnReset
            // 
            this.btnReset = new Button();
            this.btnReset.Click += Reset_Click;
            this.btnReset.BackColor = Color.LightGray;
            this.btnReset.ForeColor = Color.Black;
            this.btnReset.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new Point(740, 10);
            this.btnReset.Size = new Size(100, 60);
            this.btnReset.TabIndex = 101;
            this.btnReset.Text = "Reset";
            this.Controls.Add(this.btnReset);
            // 
            // btnStep
            // 
            this.btnStep = new Button();
            this.btnStep.Click += Step_Click;
            this.btnStep.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnStep.Location = new Point(910, 130);
            this.btnStep.Size = new Size(90, 60);
            this.btnStep.TabIndex = 102;
            this.btnStep.Text = "Step";
            this.Controls.Add(this.btnStep);
            
            // 
            // Neighbor
            // 
            this.Neighbor = new RadioButton();
            this.Neighbor.AutoSize = true;
            this.Neighbor.Location = new Point(12, 12);
            this.Neighbor.Name = "Neighbor";
            this.Neighbor.Size = new Size(98, 24);
            this.Neighbor.TabIndex = 103;
            this.Neighbor.TabStop = true;
            this.Neighbor.Text = "Neighbor";
            this.Neighbor.UseVisualStyleBackColor = true;
            this.Neighbor.CheckedChanged += new EventHandler(this.Neighbor_CheckedChanged);
            // 
            // AllNeighbors
            // 
            this.AllNeighbors = new RadioButton();
            this.AllNeighbors.AutoSize = true;
            this.AllNeighbors.Location = new Point(12, 42);
            this.AllNeighbors.Name = "AllNeighbors";
            this.AllNeighbors.Size = new Size(98, 24);
            this.AllNeighbors.TabIndex = 104;
            this.AllNeighbors.TabStop = true;
            this.AllNeighbors.Text = "AllNeighbors";
            this.AllNeighbors.UseVisualStyleBackColor = true;
            this.AllNeighbors.CheckedChanged += new EventHandler(this.AllNeighbors_CheckedChanged);
            // 
            // SectorSweep
            // 
            this.SectorSweep = new RadioButton();
            this.SectorSweep.AutoSize = true;
            this.SectorSweep.Location = new Point(12, 72);
            this.SectorSweep.Name = "SectorSweep";
            this.SectorSweep.Size = new Size(130, 24);
            this.SectorSweep.TabIndex = 105;
            this.SectorSweep.TabStop = true;
            this.SectorSweep.Text = "SectorSweep";
            this.SectorSweep.UseVisualStyleBackColor = true;
            this.SectorSweep.CheckedChanged += new EventHandler(this.SectorSweep_CheckedChanged);
            // 
            // ColumnSweeps
            // 
            this.ColumnSweeps = new RadioButton();
            this.ColumnSweeps.AutoSize = true;
            this.ColumnSweeps.Location = new Point(12, 102);
            this.ColumnSweeps.Name = "ColumnSweeps";
            this.ColumnSweeps.Size = new Size(136, 24);
            this.ColumnSweeps.TabIndex = 106;
            this.ColumnSweeps.TabStop = true;
            this.ColumnSweeps.Text = "ColumnSweeps";
            this.ColumnSweeps.UseVisualStyleBackColor = true;
            this.ColumnSweeps.CheckedChanged += new EventHandler(this.ColumnSweeps_CheckedChanged);
            // 
            // RowSweeps
            // 
            this.RowSweeps = new RadioButton();
            this.RowSweeps.AutoSize = true;
            this.RowSweeps.Location = new Point(12, 132);
            this.RowSweeps.Name = "RowSweeps";
            this.RowSweeps.Size = new Size(115, 24);
            this.RowSweeps.TabIndex = 107;
            this.RowSweeps.TabStop = true;
            this.RowSweeps.Text = "RowSweeps";
            this.RowSweeps.UseVisualStyleBackColor = true;
            this.RowSweeps.CheckedChanged += new EventHandler(this.RowSweeps_CheckedChanged);
            // 
            // TwoPair
            // 
            this.TwoPair = new RadioButton();
            this.TwoPair.AutoSize = true;
            this.TwoPair.Location = new Point(12, 162);
            this.TwoPair.Name = "TwoPair";
            this.TwoPair.Size = new Size(115, 24);
            this.TwoPair.TabIndex = 108;
            this.TwoPair.TabStop = true;
            this.TwoPair.Text = "TwoPair";
            this.TwoPair.UseVisualStyleBackColor = true;
            this.TwoPair.CheckedChanged += new EventHandler(this.TwoPair_CheckedChanged);
            // 
            // ThreesomeRows
            // 
            this.ThreesomeRows = new RadioButton();
            this.ThreesomeRows.AutoSize = true;
            this.ThreesomeRows.Location = new Point(12, 192);
            this.ThreesomeRows.Name = "ThreesomeRows";
            this.ThreesomeRows.Size = new Size(115, 24);
            this.ThreesomeRows.TabIndex = 109;
            this.ThreesomeRows.TabStop = true;
            this.ThreesomeRows.Text = "ThreesomeRows";
            this.ThreesomeRows.UseVisualStyleBackColor = true;
            this.ThreesomeRows.CheckedChanged += new EventHandler(this.ThreesomeRows_CheckedChanged);
            // 
            // ThreesomeCols
            // 
            this.ThreesomeCols = new RadioButton();
            this.ThreesomeCols.AutoSize = true;
            this.ThreesomeCols.Location = new Point(12, 222);
            this.ThreesomeCols.Name = "ThreesomeCols";
            this.ThreesomeCols.Size = new Size(115, 24);
            this.ThreesomeCols.TabIndex = 110;
            this.ThreesomeCols.TabStop = true;
            this.ThreesomeCols.Text = "ThreesomeCols";
            this.ThreesomeCols.UseVisualStyleBackColor = true;
            this.ThreesomeCols.CheckedChanged += new EventHandler(this.ThreesomeCols_CheckedChanged);
            // 
            // LineFind
            // 
            this.LineFind = new RadioButton();
            this.LineFind.AutoSize = true;
            this.LineFind.Location = new Point(12, 252);
            this.LineFind.Name = "LineFind";
            this.LineFind.Size = new Size(115, 24);
            this.LineFind.TabIndex = 111;
            this.LineFind.TabStop = true;
            this.LineFind.Text = "LineFind";
            this.LineFind.UseVisualStyleBackColor = true;
            this.LineFind.CheckedChanged += new EventHandler(this.LineFind_CheckedChanged);
            // 
            // RadioPanel
            // 
            this.RadioPanel = new Panel();
            this.RadioPanel.SuspendLayout();
            this.RadioPanel.Controls.Add(this.Neighbor);
            this.RadioPanel.Controls.Add(this.AllNeighbors);
            this.RadioPanel.Controls.Add(this.SectorSweep);
            this.RadioPanel.Controls.Add(this.ColumnSweeps);
            this.RadioPanel.Controls.Add(this.RowSweeps);
            this.RadioPanel.Controls.Add(this.TwoPair);
            this.RadioPanel.Controls.Add(this.ThreesomeRows);
            this.RadioPanel.Controls.Add(this.ThreesomeCols);
            this.RadioPanel.Controls.Add(this.LineFind);
            this.RadioPanel.BorderStyle = BorderStyle.FixedSingle;
            this.RadioPanel.Location = new Point(740, 75);
            this.RadioPanel.Name = "RadioPanel";
            this.RadioPanel.Size = new Size(160, 290);
            this.RadioPanel.TabIndex = 112;

            this.Controls.Add(this.RadioPanel);
            this.RadioPanel.ResumeLayout(false);
            this.RadioPanel.PerformLayout();

            // 
            // btnLoad
            // 
            this.btnLoad = new Button();
            this.btnLoad.Click += Load_Click;
            this.btnLoad.BackColor = Color.LightGray;
            this.btnLoad.ForeColor = Color.Black;
            this.btnLoad.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new Point(740, 374);
            this.btnLoad.Size = new Size(100, 60);
            this.btnLoad.TabIndex = 113;
            this.btnLoad.Text = "Load";
            this.Controls.Add(this.btnLoad);

            // 
            // btnSave
            // 
            this.btnSave = new Button();
            this.btnSave.Click += Save_Click;
            this.btnSave.BackColor = Color.LightGray;
            this.btnSave.ForeColor = Color.Black;
            this.btnSave.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new Point(740, 436);
            this.btnSave.Size = new Size(100, 60);
            this.btnSave.TabIndex = 114;
            this.btnSave.Text = "Save";
            this.Controls.Add(this.btnSave);

            // 
            // CouldBe
            // 
            this.CouldBe = new CheckBox();
            this.CouldBe.AutoSize = true;
            this.CouldBe.Checked = true;
            this.CouldBe.Location = new Point(740, 500);
            this.CouldBe.Name = "CouldBe";
            this.CouldBe.Size = new Size(104, 24);
            this.CouldBe.TabIndex = 115;
            this.CouldBe.Text = "CouldBe";
            this.CouldBe.UseVisualStyleBackColor = true;
            this.CouldBe.CheckedChanged += new EventHandler(this.CouldBe_CheckedChanged);
            this.Controls.Add(this.CouldBe);

            //
            // LogBox
            //
            this.objLogBox = new LogBox(740, 530, 350, 440, 116);
            this.Controls.Add(this.objLogBox.objBox);

            // 
            // SudokuForms
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1100, 980);

            this.Name = "Sudokirk";
            this.Text = "Sudokirk";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // This is the KeyPress function for all 81 of our Squares.
        void sq_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button btn = sender as Button;
            int iTab = btn.TabIndex;
            char keyChar = e.KeyChar;

            // Calculate objBoard.rgSquare[col,row] location from the tabindex.
            // TabIndex is [1..81]; the array is [0..8][0..8].
            curTab = iTab;
            curCol = ((iTab - 1) % 9);  // Modulo (remainder)
            curRow = ((iTab - 1) / 9);  // Divide
            curChar = keyChar;

            objLogBox.Log("KeyPress " + keyChar);

            if (keyChar >= '1' && keyChar <= '9')
            {
                //objLogBox.Log("Set: tab " + iTab + ": [" + curCol + "," + curRow + "] key = " + keyChar);
                objBoard.rgSquare[curCol, curRow].Winner(keyChar, true, Color.DarkGreen, objBoard);
                //Techniques.Neighbor(objBoard.rgSquare, curCol, curRow, keyChar);
            }
        }

        // KeyDown for all 81 squares
        void sq_KeyDown(object sender, KeyEventArgs e)
        {
            Button btn = sender as Button;
            int iTab = btn.TabIndex;
            Keys keyCode = e.KeyCode;

            // Calculate objBoard.rgSquare[col,row] location from the tabindex.
            // TabIndex is [1..81]; the array is [0..8][0..8].
            curTab = iTab;
            curCol = ((iTab - 1) % 9);  // Modulo (remainder)
            curRow = ((iTab - 1) / 9);  // Divide

            objLogBox.Log("KeyDown " + keyCode.ToString());

            switch (keyCode)
            {
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;

                case Keys.Delete:
                    objBoard.rgSquare[curCol, curRow].Reset();
                    break;
            }
        }

        // This is the ButtonClick function for all 81 of our Squares.
        void sq_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ClickSquare(btn.TabIndex);
        }

        void Reset_Click(object sender, EventArgs e)
        {
            objLogBox.Log("------- RESET ------------------");
            foreach (Square sq in objBoard.rgSquare)
            {
                sq.Reset();
            }
        }

        void Neighbor_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.Neighbor;
            }
        }

        void AllNeighbors_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.AllNeighbors;
            }
        }

        void SectorSweep_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.SectorSweep;
            }
        }

        void ColumnSweeps_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.ColumnSweeps;
            }
        }

        void RowSweeps_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.RowSweeps;
            }
        }

        void TwoPair_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.TwoPair;
            }
        }
        void ThreesomeRows_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.ThreesomeRows;
            }
        }
        void ThreesomeCols_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.ThreesomeCols;
            }
        }
        void LineFind_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                curTechnique = Technique.LineFind;
            }
        }
        void CouldBe_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            foreach (Square objSq in objBoard.rgSquare)
            {
                if (objSq.iWinner == 0)
                {
                    if (box.Checked)
                    {
                        objSq.btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        objSq.btn.ForeColor = objSq.MyBackColor();
                    }
                }
            }
        }

        // This is the ButtonClick function for the Step button.
        void Step_Click(object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            switch (curTechnique)
            {
                case Technique.none:
                    objLogBox.Log("Step: no selection");
                    break;
                case Technique.Neighbor:
                    objLogBox.Log("Step: Neighbor");
                    if (curTab != -1)
                    {
                        Techniques.Neighbor(objBoard, curCol, curRow, curChar);
                    }
                    break;
                case Technique.AllNeighbors:
                    objLogBox.Log("Step: AllNeighbors");
                    Techniques.AllNeighbors(objBoard);
                    break;
                case Technique.SectorSweep:
                    objLogBox.Log("Step: SectorSweep");
                    Techniques.SectorSweep(objBoard);
                    break;
                case Technique.ColumnSweeps:
                    objLogBox.Log("Step: ColumnSweeps");
                    Techniques.ColumnSweeps(objBoard);
                    break;
                case Technique.RowSweeps:
                    objLogBox.Log("Step: RowSweeps");
                    Techniques.RowSweeps(objBoard);
                    break;
                case Technique.TwoPair:
                    objLogBox.Log("Step: TwoPair");
                    Techniques.TwoPair(objBoard, objLogBox);
                    break;
                case Technique.ThreesomeRows:
                    objLogBox.Log("Step: ThreesomeRows");
                    Techniques.ThreesomeRows(objBoard, objLogBox);
                    break;
                case Technique.ThreesomeCols:
                    objLogBox.Log("Step: ThreesomeCols");
                    Techniques.ThreesomeCols(objBoard, objLogBox);
                    break;
                case Technique.LineFind:
                    objLogBox.Log("Step: LineFind");
                    Techniques.FLineFind(objBoard, objLogBox);
                    break;
            }
        }

        void ClickSquare(int iTab)
        {
            {
                // Calculate objBoard.rgSquare[col,row] location from the tabindex.
                // TabIndex is [1..81]; the array is [0..8][0..8].
                curTab = iTab;
                curCol = ((iTab - 1) % 9);  // Modulo (remainder)
                curRow = ((iTab - 1) / 9);  // Divide
                Square mySquare = objBoard.rgSquare[curCol, curRow];
                if (mySquare.iWinner != 0)
                {
                    curChar = mySquare.chWinner;
                    //objLogBox.Log("Select: tab " + iTab + ": [" + curCol + "," + curRow + "], Winner=" + curChar);
                }
                else
                {
                    // I don't like this, but you can't assign null to a char.
                    curChar = ' ';
                    //objLogBox.Log("Select: tab " + iTab + ": [" + curCol + "," + curRow + "]");
                }
            }
        }

        // This is the ButtonClick function for the Save button.
        void Save_Click(object sender, EventArgs e)
        {
            FileIO f = new FileIO();
            f.SaveFile(objBoard);
        }

        // This is the ButtonClick function for the Load button.
        void Load_Click(object sender, EventArgs e)
        {
            FileIO f = new FileIO();
            f.LoadFile(this, objBoard);
        }

        Button btnReset;
        Button btnStep;
        LogBox objLogBox;
        CheckBox CouldBe;
        RadioButton Neighbor;
        RadioButton AllNeighbors;
        RadioButton SectorSweep;
        RadioButton ColumnSweeps;
        RadioButton RowSweeps;
        RadioButton TwoPair;
        RadioButton ThreesomeRows;
        RadioButton ThreesomeCols;
        RadioButton LineFind;
        Panel RadioPanel;
        Button btnLoad;
        Button btnSave;

    }
}