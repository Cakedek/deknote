using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
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
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using deknote.cake_class;

namespace deknote
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Check the operating system version
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            if (vs.Major < 6 || (vs.Major == 6 && vs.Minor < 3))
            {
                // Show an error message and close the program
                this.Close();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            WebClient client = new WebClient();

            try
            {
                // download the content of the text file
                string content = client.DownloadString("https://example-files.online-convert.com/document/txt/example.txt");

                // split the content into lines
                string[] lines = content.Split('\n');

                // add each line to the ListBox
                foreach (string line in lines)
                {
                    bananalistbox.Items.Add(line);
                }
            }
            catch (WebException)
            {
                // add an error message to the ListBox
                bananalistbox.Items.Add("Error");
            }

            // set the ListBox to display items on separate lines
            bananalistbox.SelectionMode = System.Windows.Controls.SelectionMode.Single;
        }

        private void bananalistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cake_title.Text = bananalistbox.SelectedItem?.ToString();

            string selectedTitle = bananalistbox.SelectedItem?.ToString();

            if (selectedTitle != null)
            {
                try
                {
                    // Read the temporary file location from the JSON file
                    string tempJson = File.ReadAllText("cake_temporary.json");
                    var tempFile = JsonConvert.DeserializeObject<dynamic>(tempJson);
                    string filePath = tempFile.temporary_file_location;

                    // read the JSON file
                    string json = File.ReadAllText(filePath);

                    // deserialize the JSON data
                    Dictionary<string, List<Dictionary<string, object>>> data = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(json);

                    // find the item with the selected title
                    List<Dictionary<string, object>> deknote = data["deknote"];
                    foreach (Dictionary<string, object> item in deknote)
                    {
                        if (item["title"].ToString() == selectedTitle)
                        {
                            // get the subject of the selected item
                            string cake_subject = item["subject"].ToString();
                            string date_modified = item["date_modified"].ToString();

                            // display the subject in the RichTextBox
                            cake_sub.Document.Blocks.Clear();
                            cake_sub.Document.Blocks.Add(new Paragraph(new Run(cake_subject)));
                            sub_date.Text = date_modified;
                            break;
                        }
                    }
                }
                catch (IOException)
                {
                    System.Windows.MessageBox.Show("The selected file does not exist.");
                }
                catch (JsonException)
                {
                    // handle JSON parsing error
                }
            }
        }


        private void welcome_Click(object sender, RoutedEventArgs e)
        {
            welcome windowsshow_welcome = new welcome();
            windowsshow_welcome.ShowDialog();
        }





        // =======================================
        // ปุ่มเปิดไฟล์
        // =======================================

        private void cake_open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".json";
            dialog.Filter = "JSON files (*.json)|*.json";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filePath = dialog.FileName;
                cake_openfilesystem.cake_loadfile_json(filePath, bananalistbox);
            }
        }




        // =======================================
        // ปุ่มเปิดไฟล์
        // =======================================
        private void cake_open1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".json";
            dialog.Filter = "JSON files (*.json)|*.json";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filePath = dialog.FileName;
                cake_openfilesystem.cake_loadfile_json(filePath, bananalistbox);
            }
        }



        // =======================================
        // ปุ่มบันทึกโน๊ตของเรา
        // =======================================
        private void cakesave_button_Click(object sender, RoutedEventArgs e)
        {
            // รับรายการที่เลือกในปัจจุบันในกล่องรายการ
            int selectedIndex = bananalistbox.SelectedIndex;
            string selectedTitle = bananalistbox.SelectedItem?.ToString();

            // ตรวจสอบว่าได้เลือกชื่อแล้ว
            if (!string.IsNullOrEmpty(selectedTitle))
            {
                try
                {
                    // อ่านตำแหน่งไฟล์ชั่วคราวจากไฟล์ JSON
                    string tempJson = File.ReadAllText("cake_temporary.json");
                    var tempFile = JsonConvert.DeserializeObject<dynamic>(tempJson);
                    string filePath = tempFile.temporary_file_location;

                    // อ่านไฟล์ JSON
                    string json = File.ReadAllText(filePath);

                    // deserialize the JSON data
                    Dictionary<string, List<Dictionary<string, object>>> data = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(json);

                    // ค้นหารายการที่มีชื่อที่เลือก
                    List<Dictionary<string, object>> deknote = data["deknote"];
                    foreach (Dictionary<string, object> item in deknote)
                    {
                        if (item["title"].ToString() == selectedTitle)
                        {
                            // อัปเดตรายการพจนานุกรมด้วยค่าใหม่
                            item["title"] = cake_title.Text;
                            item["subject"] = new TextRange(cake_sub.Document.ContentStart, cake_sub.Document.ContentEnd).Text.Trim();
                            item["date_modified"] = DateTime.Now.ToString("yyyy-MM-dd");

                            // ทำให้ข้อมูลที่อัปเดตเป็นอนุกรมเป็น JSON และบันทึกลงในไฟล์
                            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                            File.WriteAllText(filePath, updatedJson);

                            // อัปเดตรายการกล่องรายการด้วยชื่อเรื่องใหม่
                            bananalistbox.Items[selectedIndex] = cake_title.Text;

                            // เลือกรายการที่อัปเดตในกล่องรายการ
                            bananalistbox.SelectedIndex = selectedIndex;

                            break;
                        }
                    }
                }
                catch (IOException)
                {
                    System.Windows.MessageBox.Show("The selected file does not exist.");
                }
                catch (JsonException)
                {

                }
            }
        }

        private void preference_button_Click(object sender, RoutedEventArgs e)
        {
            preference windows_pre = new preference();
            windows_pre.ShowDialog();
        }
    }

}