using System;
using System.Windows;
using System.Windows.Media;
/*
Jiwant Singh
Nihal Ahmed Gesudraz
Apoorva Solanki
Kiranpreet Kaur
Harkirat Kaur
*/
namespace Color_Mixer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public const int max = 225;
		public const int min = 0;
		public const int trans_lvl = 200;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MixColours(object sender, RoutedEventArgs e)
		{
			try
			{
				double lred = 0, lgreen = 0, lblue = 0, rred = 0, rgreen = 0, rblue = 0, red, blue, green;
				Boolean lr = (LeftRed.IsChecked == true);
				if (lr)
					lred = LVal.Value;
				Boolean lg = (LeftGreen.IsChecked == true);
				if (lg)
					lgreen = LVal.Value;
				Boolean lb = (LeftBlue.IsChecked == true);
				if (lb)
					lblue = LVal.Value;
				Boolean rr = (RightRed.IsChecked == true);
				if (rr)
					rred = RVal.Value;
				Boolean rg = (RightGreen.IsChecked == true);
				if (rg)
					rgreen = RVal.Value;
				Boolean rb = (RightBlue.IsChecked == true);
				if (rb)
					rblue = RVal.Value;
				red = lred + rred;
				blue = lblue + rblue;
				green = lgreen + rgreen;
				if (red > 255)
					red = 255;
				if (blue > 255)
					blue = 255;
				if (green > 255)
					green = 255;
				byte redbyte = Convert.ToByte(red);
				byte greenbyte = Convert.ToByte(green);
				byte bluebyte = Convert.ToByte(blue);
				if ((lr || lg || lb) && (rr || rg || rb))
				{
					MainGrid.Background = new SolidColorBrush(Color.FromArgb(trans_lvl, redbyte, greenbyte, bluebyte));
				}
				else
					throw new Exception();
			}
			catch
			{
				MessageBox.Show("Select from Both Columns");
			}
		}

		private void Reset(object sender, RoutedEventArgs e)
		{
			LeftRed.IsChecked = false;
			LeftBlue.IsChecked = false;
			LeftGreen.IsChecked = false;
			RightRed.IsChecked = false;
			RightBlue.IsChecked = false;
			RightGreen.IsChecked = false;
			MainGrid.Background = new SolidColorBrush(Color.FromArgb(min, min, min, min));
			LVal.Value = 0;
			RVal.Value = 0;
		}
	}
}
