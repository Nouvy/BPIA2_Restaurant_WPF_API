using System.Text;
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
        private readonly ApiMenuService _apiMenu = new ApiMenuService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Valider_Click(object sender, RoutedEventArgs e)
        {
            var selectedChoice = ((ComboBoxItem)Cbx_Choix.SelectedItem)?.Content?.ToString();
            string nom = "";
            float prixTtc = 0;
            float tauxTva = 0;
            float prixHt = 0;

            if (selectedChoice == "Menu")
            {
                nom = tbx_nom.Text;
                prixTtc = Convert.ToSingle(tbx_prix_ttc.Text);
                tauxTva = Convert.ToSingle(tbx_taux_tva.Text);
                prixHt = (float)Math.Round(prixTtc / (1 + tauxTva / 100), 2);
                List<Article> selectedArticles = new List<Article>();
                foreach (var checkbox in _checkboxArticles)
                {
                    if(checkbox.IsChecked == true)
                    {
                        selectedArticles.Add((Article)checkbox.Tag);
                    }
                }
                Models.Menu menu = new Models.Menu { 
                    Nom = nom, 
                    PrixTTC = prixTtc, 
                    PrixHT= prixHt, 
                    TauxTva = tauxTva, 
                    Articles = selectedArticles 
                };

                await _apiMenu.AddMenuAsync(menu);

                tbx_nom.Clear();
                tbx_prix_ttc.Clear();
                tbx_taux_tva.Clear();
                foreach (var checkbox in _checkboxArticles)
                { if(checkbox.IsChecked == true)
                    {
                        checkbox.IsChecked = false; 
                    }
                       
                }
                MessageBox.Show("Votre menu a bien été ajouté !");
            }
            if (selectedChoice == "Article")
            {
                nom = tbx_nom.Text;
                prixTtc = Convert.ToSingle(tbx_prix_ttc.Text);
                tauxTva = Convert.ToSingle(tbx_taux_tva.Text);
                prixHt = (float)Math.Round(prixTtc / (1 + tauxTva / 100), 2);

                Article article = new Article { Nom = nom, PrixTTC = prixTtc, PrixHT = prixHt, TauxTva = tauxTva };
                
                await _apiArticle.AddArticleAsync(article);
                tbx_nom.Text = "";
                tbx_prix_ttc.Text = "";
                tbx_taux_tva.Text = "";
            }
            
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