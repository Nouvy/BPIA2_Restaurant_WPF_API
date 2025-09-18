using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BPIA2_Restaurant_WPF_API.Models;
using BPIA2_Restaurant_WPF_API.Services;

namespace BPIA2_Restaurant_WPF_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Article> _allArticles = new List<Article>();
        private List<CheckBox> _checkboxArticles = new List<CheckBox>();
        private readonly ApiArticleService _apiArticle = new ApiArticleService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Cbx_Choix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedChoice = ((ComboBoxItem)Cbx_Choix.SelectedItem)?.Content?.ToString();
            Lbx_Articles.Items.Clear();
            _allArticles = await _apiArticle.GetArticlesAsync();

            foreach (var article in _allArticles)
            {
                var checkbox = new CheckBox
                {
                    Content = article.Nom,
                    Tag = article,
                };
                _checkboxArticles.Add(checkbox);
                Lbx_Articles.Items.Add(checkbox);
            }

            if (selectedChoice == "Menu")
            {
                Lbx_Articles.Visibility = Visibility.Visible;
            }
            if (selectedChoice == "Article")
            {
                Lbx_Articles.Visibility = Visibility.Collapsed;
            }
        }
    }
}