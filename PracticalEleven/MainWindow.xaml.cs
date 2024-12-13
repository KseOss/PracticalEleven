using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalEleven
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст, введенный пользователем, из TextBox
            string input = INP_TB.Text;
           
            // Регулярное выражение для нахождения слов "abba" и "abea", игнорируя "adca"
            string regex1 = @"\babba\b|\babea\b";  // Используем \b для обозначения границ слов
            // Регулярное выражение для поиска букв, стоящих по краям 'a'
            string regex2 = @"\ba[a-fj-z]\b";  // Поиск слова, начинающегося и заканчивающегося на 'a'

            try
            {
                MatchCollection matches1 = Regex.Matches(input, regex1); // Находим все совпадения в введенном тексте            
                MatchCollection matches2 = Regex.Matches(input, regex2); // Находим совпадения по новому регулярному выражению

                ResultTB.Text = ""; //очищение ТБ
                foreach (Match match in matches1)
                {
                    ResultTB.Text += match.Value + Environment.NewLine; //добавляет найденное совпадение с переходом на новую стр.
                }

                ResultTB2.Text = "";
                foreach (Match match in matches2)
                {
                    ResultTB2.Text += match.Value + Environment.NewLine;
                }

                if (matches1.Count == 0 && matches2.Count == 0)
                {
                    ResultTB2.Text = "Совпадение не найдено";
                }
            }
            catch (Exception ex) 
            { 
                ResultTB.Text = "Ошибка" + ex.Message;
                ResultTB2.Text = "";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) //Создание кнопки для меню "Справка" - выход
        {
            this.Close();
        }

        // Обработчик кнопки "О программе"
        private void About_Click(object sender, RoutedEventArgs e) //Создание кнопки для меню "Справка" - о программе
        {
            MessageBox.Show("Разработчик: Сухомяткина Ксения\nНомер работы: 11\nЗадание: Дана строка 'aba aca aea abba adca abea'. Напишите регулярное " +
                "выражение, которое" +
                " найдет строки abba и abea, не захватив adca. Напишите регулярное выражение, которое найдет строки следующего вида: по краям стоят " +
                "буквы 'a', а между " +
                "ними - буква от a до f и от j до z ", "О программе");
        }
    }
}