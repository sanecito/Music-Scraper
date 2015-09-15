//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Music_Scraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Scrape_Click(object sender, RoutedEventArgs e)
        {
            string samplePath = @"C:\Users\scott\Music";
            string musicRegex = @".*\.mp3|.*\.flac";

            IEnumerable<string> test = GetFiles(samplePath, musicRegex);
            foreach (string file in test)
            {
                Console.WriteLine(file);
            }
        }

        // Taken from http://techmikael.blogspot.com/2010/02/directory-search-with-multiple-filters.html
        public static IEnumerable<string> GetFiles(string path, string searchPatternExpression = "", SearchOption searchOption = SearchOption.AllDirectories)
        {
            Regex reSearchPattern = new Regex(searchPatternExpression);
            return Directory.EnumerateFiles(path, "*", searchOption).Where(file => reSearchPattern.IsMatch(System.IO.Path.GetFileName(file)));
        }
    }
}
