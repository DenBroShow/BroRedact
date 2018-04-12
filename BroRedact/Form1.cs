using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BroRedact
{
    public partial class Form1 : Form
    {
        public string[] loadstate;
        public Form1(string[] args)
        {
            loadstate = args;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Загрузка формы
        {
            if (loadstate.Length > 0)
            {
                if (File.Exists(loadstate[0]))
                {
                    Files.LoadFile(loadstate[0]);
                    textBox1.Text = Files.GetFileName();
                    textBox2.Text = Files.GetFileContent();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // "Новый"
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Текстовый файл|*.txt|Файл BroRedact|*.bred";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.Create(dlg.FileName).Close();
                Files.LoadFile(dlg.FileName);
                textBox1.Text = Files.GetFileName();
                textBox2.Text = Files.GetFileContent();
            }
        }

        private void button1_Click(object sender, EventArgs e) // "Выбрать"
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt;*.bred|Все файлы|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    Files.LoadFile(dlg.FileName);
                    textBox1.Text = Files.GetFileName();
                    textBox2.Text = Files.GetFileContent();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // Текстовое поле
        {
            Files.NewString(textBox2.Text);
            label2.Text = "Символов: " + Files.GetSymbols();
        }

        private void button3_Click(object sender, EventArgs e) // "Сохранить"
        {
            if (!Files.AreEqual()) MessageBox.Show("Вы не внесли никаких изменений в текущий файл. Документ не был сохранён", "Ошибка", MessageBoxButtons.OK);
            else
            {
                Files.Save();
                MessageBox.Show("Файл сохранён", "Успех", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Строка с файлом
        {

        }

        private void label2_Click(object sender, EventArgs e) // Кол-во символов
        {
            
        }
    }
}
