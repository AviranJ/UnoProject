// Decompiled with JetBrains decompiler
// Type: Uno.frmUserData
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
  public class frmUserData : Form
  {
    private IContainer components;
    private Label label1;
    private TextBox txtPlayerName;
    private Button btnStart;
    private Button btnCancel;

    public frmUserData()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.txtPlayerName = new TextBox();
      this.btnStart = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(34, 23);
      this.label1.Name = "label1";
      this.label1.Size = new Size(72, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Player name :";
      this.txtPlayerName.Location = new Point(112, 19);
      this.txtPlayerName.Name = "txtPlayerName";
      this.txtPlayerName.Size = new Size(245, 23);
      this.txtPlayerName.TabIndex = 1;
      this.btnStart.Location = new Point(88, 76);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new Size(105, 26);
      this.btnStart.TabIndex = 2;
      this.btnStart.Text = "&Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new EventHandler(this.btnStart_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(206, 76);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(105, 26);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnStart;
      this.AutoScaleDimensions = new SizeF(6f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(392, 139);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnStart);
      this.Controls.Add((Control) this.txtPlayerName);
      this.Controls.Add((Control) this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmUserData";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Please enter the details -";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      GameData.playerName = this.txtPlayerName.Text.Trim();
      if (GameData.playerName.Length == 0)
      {
        int num = (int) MessageBox.Show("Please enter assembly name.", "Uh oh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.txtPlayerName.Focus();
      }
      else
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}
