# Wavelet Signal Analysis

A WinForms application for loading, visualizing, and analyzing signals using Discrete Wavelet Transform (DWT).

## Features

- Load signals from CSV files (1, 2, or 3 columns)
- Visualize selected signal channel
- Adjust display range (start, length, max samples)
- Select wavelet type: Haar, Daubechies2, Symlet2
- Perform DWT and display coefficients by level
- Set sampling rate

## Dependencies

- .NET 6.0 (or your target .NET version)
- [ScottPlot.WinForms](https://www.nuget.org/packages/ScottPlot.WinForms)
- (Optional) Accord.NET, if you use it for signal processing

Install dependencies via NuGet Package Manager: Install-Package ScottPlot.WinForms

## Usage

1. Clone the repository: git clone https://github.com/zin-ton/WaveletSignalAnalysis.git
2. Open the project in Visual Studio or Rider.
3. Build and run the application.
4. Click **Load CSV** and select a signal file.
5. Adjust analysis and visualization parameters.
6. Click **Analyze DWT** to perform wavelet analysis.

## CSV Format

- 1 column: signal values (X axis = index)
- 2 columns: time/index, signal value
- 3 columns: time/index, channel 1 value, channel 2 value

## License
MIT
