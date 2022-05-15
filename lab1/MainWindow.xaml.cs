using System;
using System.Collections.Generic;
using System.Linq;
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

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_from_19cc_to_3cc(object sender, RoutedEventArgs e)
        {
            string x_19cc_str = tb_19cc_input.Text; // Получаем число в 19сс
            int y_10сс = 0;
            string y_3cc = "";
            string base_str = "0123456789ABCDEFGHI"; // "Алфавит" для 19сс порядковый номер соответствует значению. Например: А = 10(стоит на 10 месте),
                                                     // В = 11(стоит на 11 месте)
            bool flag = true;

            // Перевод из 19сс в 10сс:
            for (int i = 0; i < x_19cc_str.Length; i++) // Перебираем все элементы введенной строки 
            {
                for (int j = 0; j < 19; j++) // Перебираем все элементы "Алфавита"
                {
                    if (x_19cc_str[i] == base_str[j]) 
                    {
                        y_10сс += Convert.ToInt32(j * Math.Pow(19, x_19cc_str.Length - i - 1));
                        break;
                        // Если элемент алфавита совпал с введенным символом добавляем его значение
                        // и переходим к следующему
                    }

                    if (j == 18)
                    {
                        MessageBox.Show("Некорректные данные!");
                        tb_3cc_output.Text = "";
                        tb_19cc_input.Text = "";
                        flag = false;
                        // Если мы перебрали весь алфавит и не нашли совпадениий, значит введены неверные данные
                    }
                }
            }
            

            if (flag) // Если при переводе в 10сс возникла ошибка сюда не зайдет
            {
                do
                {
                    y_3cc += (y_10сс % 3).ToString(); // Ищем остаток от деления на 3 и прибавляем его
                    y_10сс = Convert.ToInt32(y_10сс / 3); // Теперь делим на 3 без остатка 

                } while (y_10сс >= 3); // Все это делаем пока число в 10сс не уменьшится до 3

                if (y_10сс != 0) // Если число в 10сс не поделилось нацело нужно добавить то что осталось
                    y_3cc += y_10сс;
                
                // Теперь получившееся число нужно перевернуть
                char[] s = y_3cc.ToArray(); // Сохраняем наше число как массив
                y_3cc = ""; // Очищаем исходную строку
                for (int j = s.Length - 1; j >= 0; j--) // Идем с конца массива и по одному элементу записываем в начало строки 
                    y_3cc += s[j];               

                tb_3cc_output.Text = y_3cc; // Выводим ответ
            }

            
        }

        private void Button_Click_from_3cc_to_19cc(object sender, RoutedEventArgs e)
        {
            string x_3cc_str = tb_3cc_input.Text; // Получаем число в 3сс
            int y_10сс = 0;
            string y_19cc = "";
            string base_str = "0123456789ABCDEFGHI"; // "Алфавит" для 19сс порядковый номер соответствует значению. Например: А = 10(стоит на 10 месте),
                                                     // В = 11(стоит на 11 месте)
            bool flag = true;

            // Перевод из 3сс в 10сс
            for (int i = 0; i < x_3cc_str.Length; i++)
            {
                if (Int32.TryParse(x_3cc_str[i].ToString(), out int x) && x <= 2)
                {
                    y_10сс += Convert.ToInt32(x * Math.Pow(3, x_3cc_str.Length - i - 1));
                }
                else
                {
                    // Если введена не цифра или цифра больше 3, значит число не принадлежит 3сс 
                    MessageBox.Show("Некорректные данные!");
                    tb_3cc_input.Text = "";
                    tb_19cc_output.Text = "";
                    flag = false;
                }
            }

            if (flag)// Если при переводе в 10сс возникла ошибка сюда не зайдет
            {
                // Все также как при переводе в 3сс
                do
                {
                    y_19cc += base_str[y_10сс % 19]; // Берем элемент из алфавита помня, что значение соответсвует порядковому номеру в строке
                    y_10сс = Convert.ToInt32(y_10сс / 19); 

                } while (y_10сс >= 19);

                if (y_10сс != 0)
                    y_19cc += base_str[y_10сс];

                // Переворачиваем строку
                char[] s = y_19cc.ToArray();
                y_19cc = "";

                for (int j = s.Length - 1; j >= 0; j--)
                    y_19cc += s[j];
                
                tb_19cc_output.Text = y_19cc; // Выводим ответ в 19сс  
            }
        }
    }
}
