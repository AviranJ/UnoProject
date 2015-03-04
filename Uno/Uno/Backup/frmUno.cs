// Decompiled with JetBrains decompiler
// Type: Uno.frmUno
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
  public class frmUno : Form
  {
    private IContainer components;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    public TableLayoutPanel tableLayoutPanel;
    public TableLayoutPanel outerTableLayout;
    private TableLayoutPanel tableSidePanel;
    private Label lblScore;
    private Label lblPlayerScoreHeader;
    private Label lblOpponentHeader;
    private Label lblColorRunningHeader;
    public Button btnPass;
    public Label lblOpponentScore;
    public Label lblPlayerScore;
    public Label lblColorRunning;
    private string[] _args;

    public string[] Args
    {
      get
      {
        return this._args;
      }
    }

    public frmUno(string[] Args)
    {
      this._args = Args;
      this.InitializeComponent();
      Game.Init();
      GameData.InitData(this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmUno));
      this.outerTableLayout = new TableLayoutPanel();
      this.tableLayoutPanel = new TableLayoutPanel();
      this.menuStrip = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.tableSidePanel = new TableLayoutPanel();
      this.lblColorRunningHeader = new Label();
      this.lblColorRunning = new Label();
      this.lblOpponentScore = new Label();
      this.lblPlayerScore = new Label();
      this.lblOpponentHeader = new Label();
      this.lblPlayerScoreHeader = new Label();
      this.lblScore = new Label();
      this.btnPass = new Button();
      this.outerTableLayout.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.tableSidePanel.SuspendLayout();
      this.SuspendLayout();
      this.outerTableLayout.BackColor = Color.FromArgb(0, 192, 0);
      this.outerTableLayout.ColumnCount = 2;
      this.outerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.outerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180f));
      this.outerTableLayout.Controls.Add((Control) this.tableLayoutPanel, 0, 1);
      this.outerTableLayout.Controls.Add((Control) this.menuStrip, 0, 0);
      this.outerTableLayout.Controls.Add((Control) this.tableSidePanel, 1, 1);
      this.outerTableLayout.Dock = DockStyle.Fill;
      this.outerTableLayout.Location = new Point(0, 0);
      this.outerTableLayout.Name = "outerTableLayout";
      this.outerTableLayout.RowCount = 2;
      this.outerTableLayout.RowStyles.Add(new RowStyle());
      this.outerTableLayout.RowStyles.Add(new RowStyle());
      this.outerTableLayout.Size = new Size(743, 525);
      this.outerTableLayout.TabIndex = 6;
      this.tableLayoutPanel.BackColor = Color.FromArgb(0, 192, 0);
      this.tableLayoutPanel.BackgroundImageLayout = ImageLayout.None;
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75f));
      this.tableLayoutPanel.Dock = DockStyle.Fill;
      this.tableLayoutPanel.Location = new Point(3, 24);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 3;
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel.Size = new Size(557, 498);
      this.tableLayoutPanel.TabIndex = 7;
      this.tableLayoutPanel.Paint += new PaintEventHandler(this.tableLayoutPanel_Paint);
      this.tableLayoutPanel.MouseUp += new MouseEventHandler(this.tableLayoutPanel_MouseUp);
      this.outerTableLayout.SetColumnSpan((Control) this.menuStrip, 2);
      this.menuStrip.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
      this.menuStrip.Location = new Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new Size(743, 21);
      this.menuStrip.TabIndex = 6;
      this.menuStrip.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.newToolStripMenuItem,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(35, 17);
      this.fileToolStripMenuItem.Text = "&File";
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = Keys.N | Keys.Control;
      this.newToolStripMenuItem.Size = new Size(145, 22);
      this.newToolStripMenuItem.Text = "&New";
      this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(145, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.aboutToolStripMenuItem
      });
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(40, 17);
      this.helpToolStripMenuItem.Text = "&Help";
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(114, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
      this.tableSidePanel.ColumnCount = 2;
      this.tableSidePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableSidePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableSidePanel.Controls.Add((Control) this.lblColorRunningHeader, 0, 4);
      this.tableSidePanel.Controls.Add((Control) this.lblColorRunning, 0, 4);
      this.tableSidePanel.Controls.Add((Control) this.lblOpponentScore, 1, 2);
      this.tableSidePanel.Controls.Add((Control) this.lblPlayerScore, 0, 2);
      this.tableSidePanel.Controls.Add((Control) this.lblOpponentHeader, 1, 1);
      this.tableSidePanel.Controls.Add((Control) this.lblPlayerScoreHeader, 0, 1);
      this.tableSidePanel.Controls.Add((Control) this.lblScore, 0, 0);
      this.tableSidePanel.Controls.Add((Control) this.btnPass, 0, 6);
      this.tableSidePanel.Dock = DockStyle.Fill;
      this.tableSidePanel.Location = new Point(566, 24);
      this.tableSidePanel.Name = "tableSidePanel";
      this.tableSidePanel.RowCount = 8;
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 23f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 33f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 253f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 37f));
      this.tableSidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableSidePanel.Size = new Size(174, 498);
      this.tableSidePanel.TabIndex = 8;
      this.lblColorRunningHeader.AutoSize = true;
      this.lblColorRunningHeader.Dock = DockStyle.Fill;
      this.lblColorRunningHeader.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblColorRunningHeader.ForeColor = Color.White;
      this.lblColorRunningHeader.Location = new Point(3, 107);
      this.lblColorRunningHeader.Name = "lblColorRunningHeader";
      this.lblColorRunningHeader.Size = new Size(81, 28);
      this.lblColorRunningHeader.TabIndex = 9;
      this.lblColorRunningHeader.Text = "Color";
      this.lblColorRunningHeader.TextAlign = ContentAlignment.MiddleCenter;
      this.lblColorRunning.AutoSize = true;
      this.lblColorRunning.Dock = DockStyle.Fill;
      this.lblColorRunning.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblColorRunning.ForeColor = Color.White;
      this.lblColorRunning.Location = new Point(90, 107);
      this.lblColorRunning.Name = "lblColorRunning";
      this.lblColorRunning.Size = new Size(81, 28);
      this.lblColorRunning.TabIndex = 8;
      this.lblColorRunning.TextAlign = ContentAlignment.MiddleCenter;
      this.lblOpponentScore.AutoSize = true;
      this.lblOpponentScore.BorderStyle = BorderStyle.Fixed3D;
      this.lblOpponentScore.Dock = DockStyle.Fill;
      this.lblOpponentScore.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblOpponentScore.ForeColor = Color.White;
      this.lblOpponentScore.Location = new Point(90, 49);
      this.lblOpponentScore.Name = "lblOpponentScore";
      this.lblOpponentScore.Size = new Size(81, 33);
      this.lblOpponentScore.TabIndex = 5;
      this.lblOpponentScore.Text = "0";
      this.lblOpponentScore.TextAlign = ContentAlignment.MiddleCenter;
      this.lblPlayerScore.AutoSize = true;
      this.lblPlayerScore.BorderStyle = BorderStyle.Fixed3D;
      this.lblPlayerScore.Dock = DockStyle.Fill;
      this.lblPlayerScore.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPlayerScore.ForeColor = Color.White;
      this.lblPlayerScore.Location = new Point(3, 49);
      this.lblPlayerScore.Name = "lblPlayerScore";
      this.lblPlayerScore.Size = new Size(81, 33);
      this.lblPlayerScore.TabIndex = 4;
      this.lblPlayerScore.Text = "0";
      this.lblPlayerScore.TextAlign = ContentAlignment.MiddleCenter;
      this.lblOpponentHeader.AutoSize = true;
      this.lblOpponentHeader.Dock = DockStyle.Fill;
      this.lblOpponentHeader.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblOpponentHeader.ForeColor = Color.White;
      this.lblOpponentHeader.Location = new Point(90, 23);
      this.lblOpponentHeader.Name = "lblOpponentHeader";
      this.lblOpponentHeader.Size = new Size(81, 26);
      this.lblOpponentHeader.TabIndex = 3;
      this.lblOpponentHeader.Text = "Opponent";
      this.lblOpponentHeader.TextAlign = ContentAlignment.MiddleCenter;
      this.lblPlayerScoreHeader.AutoSize = true;
      this.lblPlayerScoreHeader.Dock = DockStyle.Fill;
      this.lblPlayerScoreHeader.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPlayerScoreHeader.ForeColor = Color.White;
      this.lblPlayerScoreHeader.Location = new Point(3, 23);
      this.lblPlayerScoreHeader.Name = "lblPlayerScoreHeader";
      this.lblPlayerScoreHeader.Size = new Size(81, 26);
      this.lblPlayerScoreHeader.TabIndex = 2;
      this.lblPlayerScoreHeader.Text = "Player";
      this.lblPlayerScoreHeader.TextAlign = ContentAlignment.MiddleCenter;
      this.lblScore.AutoSize = true;
      this.tableSidePanel.SetColumnSpan((Control) this.lblScore, 2);
      this.lblScore.Dock = DockStyle.Fill;
      this.lblScore.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblScore.ForeColor = Color.White;
      this.lblScore.Location = new Point(3, 0);
      this.lblScore.Name = "lblScore";
      this.lblScore.Size = new Size(168, 23);
      this.lblScore.TabIndex = 1;
      this.lblScore.Text = "Score total";
      this.lblScore.TextAlign = ContentAlignment.MiddleCenter;
      this.btnPass.Dock = DockStyle.Fill;
      this.btnPass.Enabled = false;
      this.btnPass.Location = new Point(3, 391);
      this.btnPass.Name = "btnPass";
      this.btnPass.Size = new Size(81, 31);
      this.btnPass.TabIndex = 10;
      this.btnPass.Text = "Pass";
      this.btnPass.UseVisualStyleBackColor = true;
      this.btnPass.Click += new EventHandler(this.btnPass_Click);
      this.AcceptButton = (IButtonControl) this.btnPass;
      this.AutoScaleDimensions = new SizeF(6f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(0, 192, 0);
      this.ClientSize = new Size(743, 525);
      this.Controls.Add((Control) this.outerTableLayout);
      this.DoubleBuffered = true;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = "frmUno";
      this.Text = "Uno";
      this.WindowState = FormWindowState.Maximized;
      this.Resize += new EventHandler(this.frmUno_Resize);
      this.Load += new EventHandler(this.frmUno_Load);
      this.outerTableLayout.ResumeLayout(false);
      this.outerTableLayout.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.tableSidePanel.ResumeLayout(false);
      this.tableSidePanel.PerformLayout();
      this.ResumeLayout(false);
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!Game.Started)
      {
        Game.StartNewGame();
      }
      else
      {
        bool flag = false;
        if (!Game.Over)
        {
          if (MessageBox.Show((IWin32Window) this, "Do you want to abort this game?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            flag = true;
        }
        else
          flag = true;
        if (!flag)
          return;
        Game.StartNewGame();
      }
    }

    private void showDeckToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void tableLayoutPanel_MouseUp(object sender, MouseEventArgs e)
    {
      if (!Game.Started || Game.Over)
        return;
      Logic.Play(sender, e);
    }

    private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
    {
      if (!Game.Started)
        return;
      Painter.PaintCards(sender, e);
    }

    private void btnPass_Click(object sender, EventArgs e)
    {
      Logger.FuncInit("frmUno.btnPass_Click");
      Logic.PlayerTurn = false;
      this.btnPass.Enabled = false;
      Logger.FuncInit("frmUno.btnPass_Click");
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmAbout().ShowDialog();
    }

    private void frmUno_Load(object sender, EventArgs e)
    {
      Logger.FuncInit("frmUno.frmUno_Load");
      Tools.CalculateCardRegions();
      Logger.FuncExit("frmUno.frmUno_Load");
    }

    private void frmUno_Resize(object sender, EventArgs e)
    {
      Logger.FuncInit("frmUno.frmUno_Resize");
      Tools.CalculateCardRegions();
      Logger.FuncExit("frmUno.frmUno_Resize");
    }
  }
}
