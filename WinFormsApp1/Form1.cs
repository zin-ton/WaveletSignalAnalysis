using System.Globalization;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private List<double> time = new List<double>();
    private List<double> signalCh1 = new List<double>();
    private List<double> signalCh2 = new List<double>();
    private double sampleRate = 1000;

    public Form1()
    {
        InitializeComponent();
        btnLoad.Click += btnLoad_Click;
        btnAnalyze.Click += btnAnalyze_Click;
        cmbChannel.Items.AddRange(new string[] { "Kanal 1", "Kanal 2" });
        cmbWavelet.Items.AddRange(new string[] { "Haar", "Daubechies2", "Symlet2" });
        cmbWavelet.SelectedIndex = 0;
        cmbChannel.SelectedIndex = 0;
        nudStart.ValueChanged += nudStart_ValueChanged;
        nudLength.ValueChanged += nudLength_ValueChanged;
        cmbChannel.SelectedIndexChanged += cmbChannel_SelectedIndexChanged;
        this.Controls.Add(this.lblLoad);
        this.Controls.Add(this.lblChannel);
        this.Controls.Add(this.lblWavelet);
        this.Controls.Add(this.lblStart);
        this.Controls.Add(this.lblLength);
        this.Controls.Add(this.lblMaxSample);
        this.Controls.Add(this.lblAnalyze);
        nudSampleRate.ValueChanged += (s, e) =>
        {
            sampleRate = (double)nudSampleRate.Value;
            PlotSignal();
        };
        sampleRate = (double)nudSampleRate.Value;
    }
    
    private void nudStart_ValueChanged(object sender, EventArgs e)
    {
        PlotSignal();
    }
    private void btnLoad_Click(object sender, EventArgs e)
    {
        var ofd = new OpenFileDialog();
        ofd.Filter = "CSV files (*.csv)|*.csv";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            LoadCsv(ofd.FileName);

            if (signalCh1.Count > 0)
            {
                nudMaxSample.Maximum = signalCh1.Count;

                if (signalCh1.Count < nudMaxSample.Minimum)
                {
                    nudMaxSample.Value = nudMaxSample.Minimum;
                }
                    
                else if (signalCh1.Count > nudMaxSample.Maximum)
                    nudMaxSample.Value = nudMaxSample.Maximum;
                else
                    nudMaxSample.Value = signalCh1.Count;
                
                nudLength.Maximum = signalCh1.Count;
                if (nudLength.Value > nudLength.Maximum)
                    nudLength.Value = nudLength.Maximum;

                nudStart.Maximum = signalCh1.Count - 1;
                if (nudStart.Value > nudStart.Maximum)
                    nudStart.Value = nudStart.Maximum;
                nudMaxSample.Refresh();
                //MessageBox.Show($"Max: {nudMaxSample.Maximum}, Value: {nudMaxSample.Value}, Count: {signalCh1.Count}");
                PlotSignal();
            }
            else
            {
                MessageBox.Show("Nie udało się wczytać danych z pliku.");
            }
        }
    }
    
    private void LoadCsv(string path)
    {
        time.Clear();
        signalCh1.Clear();
        signalCh2.Clear();

        var values = new List<double[]>();

        foreach (var line in File.ReadLines(path))
        {
            var parts = line.Split(new[] { ';', ',', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var nums = parts
                .Select(p => double.TryParse(p.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double v) ? (double?)v : null)
                .Where(v => v.HasValue)
                .Select(v => v.Value)
                .ToArray();

            if (nums.Length > 0)
                values.Add(nums);
        }

        if (values.Count > 0 && values.All(v => v.Length == 1))
        {
            for (int i = 0; i < values.Count; i++)
            {
                time.Add(i);
                signalCh1.Add(values[i][0]);
            }
            while (signalCh2.Count < signalCh1.Count)
                signalCh2.Add(0);
        }
        else if (values.Count > 0 && values.All(v => v.Length == 2))
        {
            foreach (var row in values)
            {
                time.Add(row[0]);
                signalCh1.Add(row[1]);
            }
            while (signalCh2.Count < signalCh1.Count)
                signalCh2.Add(0);
        }
        else
        {
            foreach (var row in values)
            {
                if (row.Length >= 3)
                {
                    time.Add(row[0]);
                    signalCh1.Add(row[1]);
                    signalCh2.Add(row[2]);
                }
            }
        }
    }


    private void PlotSignal()
    {
        int start = (int)nudStart.Value;
        int length = (int)nudLength.Value;

        var sig = cmbChannel.SelectedIndex == 0 ? signalCh1 : signalCh2;
        var selected = sig.Skip(start).Take(length).ToArray();

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.Add.Signal(selected, sampleRate);
        formsPlot1.Plot.Title("Oscylogram");
        formsPlot1.Refresh();
    }

   private void btnAnalyze_Click(object sender, EventArgs e)
{
    int start = (int)nudStart.Value;
    int length = (int)nudLength.Value;
    var sig = cmbChannel.SelectedIndex == 0 ? signalCh1 : signalCh2;
    var selected = sig.Skip(start).Take(length).ToArray();

    string wavelet = cmbWavelet.SelectedItem.ToString();
    var levels = 5;
    var coeffs = new List<double[]>();
    var current = selected.ToArray();

    for (int i = 0; i < levels; i++)
    {
        int n = current.Length / 2;
        double[] approx = new double[n];
        double[] detail = new double[n];

        switch (wavelet)
        {
            case "Haar":
                for (int j = 0; j < n; j++)
                {
                    approx[j] = (current[2 * j] + current[2 * j + 1]) / 2.0;
                    detail[j] = (current[2 * j] - current[2 * j + 1]) / 2.0;
                }
                break;

            case "Daubechies2":
                for (int j = 0; j < n; j++)
                {
                    approx[j] = 0.48296 * current[2 * j] + 0.83648 * current[2 * j + 1];
                    detail[j] = -0.12941 * current[2 * j] + 0.22414 * current[2 * j + 1];
                }
                break;

            case "Symlet2":
                for (int j = 0; j < n; j++)
                {
                    approx[j] = 0.70711 * current[2 * j] + 0.70711 * current[2 * j + 1];
                    detail[j] = -0.70711 * current[2 * j] + 0.70711 * current[2 * j + 1];
                }
                break;

            default:
                MessageBox.Show("Nieznana funkcja falowa.");
                return;
        }

        coeffs.Add(detail);
        current = approx;
    }

    formsPlot2.Plot.Clear();
    for (int i = 0; i < coeffs.Count; i++)
    {
        var det = coeffs[i];
        double offset = i * det.Select(d => Math.Abs(d)).DefaultIfEmpty(0).Max() * 2;
        var shifted = det.Select(x => x + offset).ToArray();
        var plot = formsPlot2.Plot.Add.Signal(shifted, 1);
        plot.Label = $"Poziom {i + 1}";
    }

    formsPlot2.Plot.Title("Skalogram DWT");
    formsPlot2.Refresh();
}

    private void nudLength_ValueChanged(object sender, EventArgs e) => PlotSignal();
    private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e) => PlotSignal();
}