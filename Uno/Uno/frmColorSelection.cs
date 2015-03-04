// Decompiled with JetBrains decompiler
// Type: Uno.frmColorSelection
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
  public class frmColorSelection : Form
  {
    public UnoColours SelectedColor;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Button btnBlue;
    private Button btnYellow;
    private Button btnRed;
    private Button btnGreen;

    public frmColorSelection()
    {
      this.InitializeComponent();
    }

    private void btnRed_Click(object sender, EventArgs e)
    {
      this.SelectedColor = UnoColours.Red;
    }

    private void btnGreen_Click(object sender, EventArgs e)
    {
      this.SelectedColor = UnoColours.Green;
    }

    private void btnYellow_Click(object sender, EventArgs e)
    {
      this.SelectedColor = UnoColours.Yellow;
    }

    private void btnBlue_Click(object sender, EventArgs e)
    {
      this.SelectedColor = UnoColours.Blue;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.btnBlue = new Button();
      this.btnYellow = new Button();
      this.btnRed = new Button();
      this.btnGreen = new Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.btnBlue, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.btnYellow, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.btnRed, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.btnGreen, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(197, 168);
      this.tableLayoutPanel1.TabIndex = 0;
      this.btnBlue.BackColor = Color.Blue;
      this.btnBlue.DialogResult = DialogResult.OK;
      this.btnBlue.Dock = DockStyle.Fill;
      this.btnBlue.FlatAppearance.BorderSize = 0;
      this.btnBlue.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
      this.btnBlue.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.btnBlue.FlatStyle = FlatStyle.Flat;
      this.btnBlue.Location = new Point(101, 87);
      this.btnBlue.Name = "btnBlue";
      this.btnBlue.Size = new Size(93, 78);
      this.btnBlue.TabIndex = 3;
      this.btnBlue.UseVisualStyleBackColor = false;
      this.btnBlue.Click += new EventHandler(this.btnBlue_Click);
      this.btnYellow.BackColor = Color.Yellow;
      this.btnYellow.DialogResult = DialogResult.OK;
      this.btnYellow.Dock = DockStyle.Fill;
      this.btnYellow.FlatAppearance.BorderSize = 0;
      this.btnYellow.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 0);
      this.btnYellow.FlatAppearance.MouseOverBackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 128);
      this.btnYellow.FlatStyle = FlatStyle.Flat;
      this.btnYellow.Location = new Point(3, 87);
      this.btnYellow.Name = "btnYellow";
      this.btnYellow.Size = new Size(92, 78);
      this.btnYellow.TabIndex = 2;
      this.btnYellow.UseVisualStyleBackColor = false;
      this.btnYellow.Click += new EventHandler(this.btnYellow_Click);
      this.btnRed.BackColor = Color.Red;
      this.btnRed.DialogResult = DialogResult.OK;
      this.btnRed.Dock = DockStyle.Fill;
      this.btnRed.FlatAppearance.BorderSize = 0;
      this.btnRed.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
      this.btnRed.FlatAppearance.MouseOverBackColor = Color.FromArgb((int) byte.MaxValue, 128, 128);
      this.btnRed.FlatStyle = FlatStyle.Flat;
      this.btnRed.Location = new Point(3, 3);
      this.btnRed.Name = "btnRed";
      this.btnRed.Size = new Size(92, 78);
      this.btnRed.TabIndex = 0;
      this.btnRed.UseVisualStyleBackColor = false;
      this.btnRed.Click += new EventHandler(this.btnRed_Click);
      this.btnGreen.BackColor = Color.FromArgb(0, 192, 0);
      this.btnGreen.DialogResult = DialogResult.OK;
      this.btnGreen.Dock = DockStyle.Fill;
      this.btnGreen.FlatAppearance.BorderSize = 0;
      this.btnGreen.FlatAppearance.MouseDownBackColor = Color.Green;
      this.btnGreen.FlatAppearance.MouseOverBackColor = Color.Lime;
      this.btnGreen.FlatStyle = FlatStyle.Flat;
      this.btnGreen.Location = new Point(101, 3);
      this.btnGreen.Name = "btnGreen";
      this.btnGreen.Size = new Size(93, 78);
      this.btnGreen.TabIndex = 1;
      this.btnGreen.UseVisualStyleBackColor = false;
      this.btnGreen.Click += new EventHandler(this.btnGreen_Click);
      this.AutoScaleDimensions = new SizeF(6f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(197, 168);
      this.ControlBox = false;
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = "frmColorSelection";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Select assembly color";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
