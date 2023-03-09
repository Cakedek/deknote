using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace deknote.cake_class
{
    public static class cake_openfilesystem
    {
        public static void cake_loadfile_json(string filePath, System.Windows.Controls.ListBox bananalistbox)
        {
            try
            {
                bananalistbox.Items.Clear();

                // อ่านไฟล์ .json
                string json = File.ReadAllText(filePath);
                Dictionary<string, List<Dictionary<string, object>>> cakedata = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(json);

                // เติมรายการข้อมูลจากไฟล์ .json ลงบน bananalist
                List<Dictionary<string, object>> deknote = cakedata["deknote"];
                foreach (Dictionary<string, object> item in deknote)
                {
                    string title = item["title"].ToString();
                    bananalistbox.Items.Add(title);
                }

                // เก็บค่าตำแหน่งไฟล์ชั่วคราว
                var tempFile = new { temporary_file_location = filePath };
                string tempJson = JsonConvert.SerializeObject(tempFile);
                File.WriteAllText("cake_temporary.json", tempJson);
            }
            catch (IOException)
            {
                System.Windows.MessageBox.Show("There is no information on this item.");
            }
            catch (JsonException)
            {
                System.Windows.MessageBox.Show("Can't read the file");
            }
        }
    }
}