using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme
{
    //Form1, Windows Forms uygulamasının ana formunu temsil eden bir sınıftır. partial anahtar kelimesi tanımının ayrı dosyalarda da olabileceğini belirtir.
    public partial class Form1 : Form
    {
        //veriler ve people adında iki liste tanımlanır. veriler, metin dizilerini, people ise Person sınıfının nesnelerini içerir.
        List<string> veriler;
        List<Person> people;

        public Form1()
        {
            //formun bileşenlerini başlatmak için otomatik olarak çağrılır.
            InitializeComponent(); 
            
        }

        private void button1_Click(object sender, EventArgs e)//button1 adlı bir düğmeye tıklandığında 
        {
            //people adında bir List<Person> (Person sınıfından nesnelerin listesi) oluşturulur.
            people = new List<Person>();

            //people listesine, Name özelliği "Fatih" ve LastNAme özelliği "Genç" olan yeni bir Person nesnesi eklenir.
            people.Add(new Person() { Name = "Fatih", LastNAme = "Genç" });
            people.Add(new Person() { Name = "Ahmet", LastNAme = "Yılmaz" });
            people.Add(new Person() { Name = "Mehmet", LastNAme = "Demir" });

            /*dataGridView1 veri kaynağı olarak people listesini kullanır.
            İçeriğinin people listesindeki Person nesnelerine bağlanmasını sağlar.
            nesnelerin özellikleri, DataGridView sütunlarına eşitlenir ve görüntülenir.*/
            dataGridView1.DataSource = people;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //veriler adında bir List<string> (string türünden nesnelerin listesi) oluşturulur.
            veriler = new List<string>();
            //veriler listesine "Fatih" metni eklenir.
            veriler.Add("Fatih");
            veriler.Add("Mehmet");
            veriler.Add("Ahmet");
            //DataGridView'de sadece tek bir sütun gösterilir çünkü veriler string türünde ve tek bir sütuna yerleştirilir.
            dataGridView1.DataSource = veriler;
        }


        private void lb_Ekle_Click(object sender, EventArgs e)//lb_Ekle adlı bir düğmeye tıklandığında
        {
            //kullanıcı bir metin kutusuna bir metin girer ve ardından bu metin, listBox kontrolüne eklenir.
            listBox1.Items.Add(textBox1.Text);
        }

        private void lb_Sil_Click(object sender, EventArgs e)
        {
            //listBox1'de seçili olan öğenin dizinini bir iletişim kutusunda gösterir.
            MessageBox.Show(listBox1.SelectedIndex.ToString());

            /* listBox1 kontrolünde herhangi bir öğe seçilip seçilmediğini kontrol eder.
                Eğer seçilmiş bir öğe varsa, -1 olmayan bir değer döner ve içeriye girer.*/
            if (listBox1.SelectedIndex != -1)
            {
            /*
                listBox1.SelectedIndex ile belirlenen dizindeki öğe RemoveAt yöntemi ile listeden kaldırılır.
                 Bu, kullanıcının listBox1'den bir öğeyi silmesini sağlar.
            */
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }


        private void lb_Sil2_Click(object sender, EventArgs e)
        {
            //bir öğeyi seçtiğinde ve sonra lb_Sil2 adlı düğmeye tıkladığında, seçili öğe listBox1 kontrolünden kaldırılır.
            listBox1.Items.Remove(listBox1.SelectedItem);

        }

        private void lb_Temizle_Click(object sender, EventArgs e)
        {
            //listBox1 kontrolündeki tüm öğeleri temizlemek için kullanılır.
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            people = new List<Person>();
            //people listesine, Name özelliği "Fatih" ve LastNAme özelliği "Genç" olan yeni bir Person nesnesi eklenir.
            people.Add(new Person() { Name = "Fatih", LastNAme = "Genç" });
            people.Add(new Person() { Name = "Ahmet", LastNAme = "Yılmaz" });
            people.Add(new Person() { Name = "Mehmet", LastNAme = "Demir" });

            dataGridView1.AutoGenerateColumns = false;// sütunların otomatik olarak oluşturulmasını engeller.
           /*people listesindeki Person nesnelerine bağlanmasını sağlar. 
            nesnelerin özellikleri, DataGridView sütunlarına eşitlenir ve görüntülenir.*/
             dataGridView1.DataSource = people;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();//yeni bir sütun oluşur DataGridViewTextBoxColumn sınıfından türetilir.
            column.DataPropertyName = "Name";//"Name" adında bir sütun
            column.Name = "İsim";//sütunun başlığının "İsim" olarak görüntülenir.
            dataGridView1.Columns.Add(column);//column, dataGridView1'e  ve yeni bir sütun eklenir.

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "LastNAme";
            column.Name = "Soyisim";
            dataGridView1.Columns.Add(column);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] ogr1 = { "Fatih", "Genç" };
            string[] ogr2 = { "Ahmet", "Yılmaz" };
            string[] ogr3 = { "Mehmet", "Demir" };
            //dataGridView2 kontrolüne üç öğrencinin adını ve soyadını içeren üç satır ekler.
            dataGridView2.Rows.Add(ogr1);
            dataGridView2.Rows.Add(ogr2);
            dataGridView2.Rows.Add(ogr3);

        }


    }
}
