using deknote.cake_messageBox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;

namespace deknote.cake_class
{
    public static class cake_openfilesystem
    {
        public static void cake_loadfile_json(string filePath, System.Windows.Controls.ListBox bananalistbox,RichTextBox cake_sub)
        {
            try
            {
                bananalistbox.Items.Clear();
                cake_sub.Document.Blocks.Clear();

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
                cake_warning_messagebox cakemessageBox = new cake_warning_messagebox();
                cakemessageBox.cakemessage = "There is no information on this item.";
                cakemessageBox.ShowDialog();
            }
            catch (JsonException)
            {
                cake_warning_messagebox cakemessageBox = new cake_warning_messagebox();
                cakemessageBox.cakemessage = "Can't read the file";
                cakemessageBox.ShowDialog();
            }
        }
    }
    
    

}