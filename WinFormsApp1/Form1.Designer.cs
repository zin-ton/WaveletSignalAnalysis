using ScottPlot.WinForms;

namespace WinFormsApp1;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private FormsPlot formsPlot1;
    private FormsPlot formsPlot2;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.ComboBox cmbChannel;
    private System.Windows.Forms.NumericUpDown nudStart;
    private System.Windows.Forms.NumericUpDown nudLength;
    private System.Windows.Forms.NumericUpDown nudMaxSample;
    private System.Windows.Forms.ComboBox cmbWavelet;
    private System.Windows.Forms.Button btnAnalyze;
    private System.Windows.Forms.Label lblLoad;
    private System.Windows.Forms.Label lblChannel;
    private System.Windows.Forms.Label lblWavelet;
    private System.Windows.Forms.Label lblStart;
    private System.Windows.Forms.Label lblLength;
    private System.Windows.Forms.Label lblMaxSample;
    private System.Windows.Forms.Label lblAnalyze;
    private System.Windows.Forms.NumericUpDown nudSampleRate;
    private System.Windows.Forms.Label lblSampleRate;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        nudMaxSample = new NumericUpDown();
        formsPlot1 = new FormsPlot();
        formsPlot2 = new FormsPlot();
        btnLoad = new Button();
        cmbChannel = new ComboBox();
        cmbWavelet = new ComboBox();
        nudStart = new NumericUpDown();
        nudLength = new NumericUpDown();
        btnAnalyze = new Button();
        lblLoad = new Label();
        lblChannel = new Label();
        lblWavelet = new Label();
        lblStart = new Label();
        lblLength = new Label();
        lblMaxSample = new Label();
        lblAnalyze = new Label();
        nudSampleRate = new NumericUpDown();
        lblSampleRate = new Label();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)nudMaxSample).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStart).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudLength).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSampleRate).BeginInit();
        SuspendLayout();
        // 
        // nudMaxSample
        // 
        nudMaxSample.Location = new Point(460, 15);
        nudMaxSample.Name = "nudMaxSample";
        nudMaxSample.Size = new Size(60, 27);
        nudMaxSample.TabIndex = 5;
        nudMaxSample.Value = new decimal(new int[] { 0, 0, 0, 0 });
        // 
        // formsPlot1
        // 
        formsPlot1.DisplayScale = 1.25F;
        formsPlot1.Location = new Point(12, 60);
        formsPlot1.Name = "formsPlot1";
        formsPlot1.Size = new Size(760, 200);
        formsPlot1.TabIndex = 7;
        // 
        // formsPlot2
        // 
        formsPlot2.DisplayScale = 1.25F;
        formsPlot2.Location = new Point(12, 270);
        formsPlot2.Name = "formsPlot2";
        formsPlot2.Size = new Size(760, 200);
        formsPlot2.TabIndex = 8;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(12, 12);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(100, 30);
        btnLoad.TabIndex = 0;
        btnLoad.Text = "Wczytaj CSV";
        // 
        // cmbChannel
        // 
        cmbChannel.Location = new Point(120, 15);
        cmbChannel.Name = "cmbChannel";
        cmbChannel.Size = new Size(80, 28);
        cmbChannel.TabIndex = 1;
        // 
        // cmbWavelet
        // 
        cmbWavelet.Location = new Point(210, 15);
        cmbWavelet.Name = "cmbWavelet";
        cmbWavelet.Size = new Size(100, 28);
        cmbWavelet.TabIndex = 2;
        // 
        // nudStart
        // 
        nudStart.Location = new Point(320, 15);
        nudStart.Name = "nudStart";
        nudStart.Size = new Size(60, 27);
        nudStart.TabIndex = 3;
        // 
        // nudLength
        // 
        nudLength.Location = new Point(390, 15);
        nudLength.Name = "nudLength";
        nudLength.Size = new Size(60, 27);
        nudLength.TabIndex = 4;
        // 
        // btnAnalyze
        // 
        btnAnalyze.Location = new Point(530, 12);
        btnAnalyze.Name = "btnAnalyze";
        btnAnalyze.Size = new Size(100, 30);
        btnAnalyze.TabIndex = 6;
        btnAnalyze.Text = "Analizuj DWT";
        // 
        // lblLoad
        // 
        lblLoad.Location = new Point(12, 0);
        lblLoad.Name = "lblLoad";
        lblLoad.Size = new Size(100, 15);
        lblLoad.TabIndex = 11;
        lblLoad.Text = "Wczytaj plik:";
        // 
        // lblChannel
        // 
        lblChannel.Location = new Point(120, 0);
        lblChannel.Name = "lblChannel";
        lblChannel.Size = new Size(80, 15);
        lblChannel.TabIndex = 0;
        lblChannel.Text = "Kanał:";
        // 
        // lblWavelet
        // 
        lblWavelet.Location = new Point(210, 0);
        lblWavelet.Name = "lblWavelet";
        lblWavelet.Size = new Size(100, 15);
        lblWavelet.TabIndex = 0;
        lblWavelet.Text = "Falka:";
        // 
        // lblStart
        // 
        lblStart.Location = new Point(320, 0);
        lblStart.Name = "lblStart";
        lblStart.Size = new Size(60, 15);
        lblStart.TabIndex = 0;
        lblStart.Text = "Start:";
        // 
        // lblLength
        // 
        lblLength.Location = new Point(390, 0);
        lblLength.Name = "lblLength";
        lblLength.Size = new Size(60, 15);
        lblLength.TabIndex = 0;
        lblLength.Text = "Długość:";
        // 
        // lblMaxSample
        // 
        lblMaxSample.Location = new Point(460, 0);
        lblMaxSample.Name = "lblMaxSample";
        lblMaxSample.Size = new Size(60, 15);
        lblMaxSample.TabIndex = 0;
        lblMaxSample.Text = "Max próbek:";
        // 
        // lblAnalyze
        // 
        lblAnalyze.Location = new Point(530, 0);
        lblAnalyze.Name = "lblAnalyze";
        lblAnalyze.Size = new Size(100, 15);
        lblAnalyze.TabIndex = 0;
        lblAnalyze.Text = "Analiza:";
        // 
        // nudSampleRate
        // 
        nudSampleRate.Location = new Point(630, 15);
        nudSampleRate.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudSampleRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSampleRate.Name = "nudSampleRate";
        nudSampleRate.Size = new Size(80, 27);
        nudSampleRate.TabIndex = 10;
        nudSampleRate.Value = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // lblSampleRate
        // 
        lblSampleRate.Location = new Point(630, 0);
        lblSampleRate.Name = "lblSampleRate";
        lblSampleRate.Size = new Size(120, 15);
        lblSampleRate.TabIndex = 9;
        lblSampleRate.Text = "Próbkowanie [Hz]:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(428, 45);
        label1.Name = "label1";
        label1.Size = new Size(0, 20);
        label1.TabIndex = 12;
        // 
        // Form1
        // 
        ClientSize = new Size(784, 481);
        Controls.Add(label1);
        Controls.Add(btnLoad);
        Controls.Add(cmbChannel);
        Controls.Add(cmbWavelet);
        Controls.Add(nudStart);
        Controls.Add(nudLength);
        Controls.Add(nudMaxSample);
        Controls.Add(btnAnalyze);
        Controls.Add(formsPlot1);
        Controls.Add(formsPlot2);
        Controls.Add(lblSampleRate);
        Controls.Add(nudSampleRate);
        Controls.Add(lblLoad);
        Name = "Form1";
        Text = "Analiza Falkowa Sygnału";
        ((System.ComponentModel.ISupportInitialize)nudMaxSample).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStart).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudLength).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSampleRate).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    private Label label1;
}