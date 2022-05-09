using AdminApplication.ViewModels;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for QuestionCreatorPage.xaml
    /// </summary>
    public partial class QuestionCreatorPage : Page
    {
        QuestionViewModel QuestionVM = new QuestionViewModel();

        public QuestionCreatorPage()
        {
            InitializeComponent();
            FillCategory();
        }

        private void FillCategory()
        {
            Category_cb.ItemsSource = QuestionVM.CategoryVM;
            Category_cb.DisplayMemberPath = "CategoryName";  
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/QuestionOverviewPage.xaml", UriKind.Relative));
        }

        private void Picture_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Picture_tb.Text = openFileDialog.FileName;
                Uri newPicture = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                Picture_pt.Source = new BitmapImage(newPicture);
            }
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            string questionDescription = Title_tb.Text;
            string difficulty = Difficulty_cb.Text;
            string category = Category_cb.Text;

            QuestionVM.AddNewQuestion(questionDescription, difficulty, category);
            MessageBox.Show("Spørgsmål oprettet!", "Meddelelse", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateCategory_btn_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = Category_tb.Text;
            QuestionVM.AddCategory(categoryName);
            Category_tb.Clear();
        }

        private void CreateAnswer_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Answer_tb.Text.Length == 0)
            {
                MessageBox.Show("Du mangler en titel til svaret");
            }
            else
            {
                CheckBox chk = new CheckBox();
                AnswerList.Items.Add(Answer_tb.Text);
                Answer_tb.Clear();
            }

        }
        public byte[] ConvertToByte(System.Windows.Controls.Image x)
        {
            byte[] arr;

            using (MemoryStream ms = new MemoryStream())
            {
                var bmp = x.Source as BitmapImage;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(ms);
                arr = ms.ToArray();
            }

            return arr;
        }
    }
}
