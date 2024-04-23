using System.Diagnostics;

namespace GUITest3 {
    public partial class Form1 : Form {
        private void scan(String name, bool kill) {
            // checks if process with name is running, and add to log
            Process[] pname = Process.GetProcessesByName(name);
            if (pname.Length == 0) {

                textBox1.Text = textBox1.Text + "\r\nProcess " + name + ".exe not running";
            }
            else {
                for (int i = 0; i < pname.Length; i++) {
                    textBox1.Text = textBox1.Text + "\r\nScanned " + pname[i];
                }

                if (kill) {
                    for (int i = 0; i < pname.Length; i++) {
                        pname[i].Kill(true);
                        textBox1.Text = textBox1.Text + "\r\nProcess killed " + pname[i];
                    }
                }
            }
        }

        public Form1() {
            InitializeComponent();
        }

        private void Scan_Click(object sender, EventArgs e) {
            // check if file running
            scan("windows", false);
            scan("njRAT", false);

            // check if file exist
            string File1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Temp\windows.exe";
            string File2 = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\ecc7c8c51c0850c1ec247c7fd3602f20.exe";
            string File3 = @"c:\njRAT.exe";
            string File4 = @"c:\njq8.exe";

            bool fileFound = false;
            if (File.Exists(File1)) {
                textBox1.Text = textBox1.Text + "\r\nFile found in appdata\\temp";
                fileFound = true;
            }
            if (File.Exists(File2)) {
                textBox1.Text = textBox1.Text + "\r\nFile found in startup";
                fileFound = true;
            }
            if (File.Exists(File3)) {
                textBox1.Text = textBox1.Text + "\r\nFile found in C root";
                fileFound = true;
            }
            if (File.Exists(File4)) {
                textBox1.Text = textBox1.Text + "\r\nFile found in C root";
                fileFound = true;
            }

            if (fileFound) {
                MessageBox.Show("File found in folder");
            }
            else {
                MessageBox.Show("File not found in folder");
            }
        }

        private void Remove_Click(object sender, EventArgs e) {
            // check if file running
            scan("windows", true);
            scan("njRAT", true);

            // check if file exist
            string File1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Temp\windows.exe";
            string File2 = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\ecc7c8c51c0850c1ec247c7fd3602f20.exe";
            string File3 = @"c:\windows.exe";
            string File4 = @"c:\njq8.exe";

            bool fileFound = false;
            if (File.Exists(File1)) {
                File.Delete(File1);
                textBox1.Text = textBox1.Text + "\r\nFile deleted in appdata\\temp";
                fileFound = true;
            }
            if (File.Exists(File2)) {
                File.Delete(File2);
                textBox1.Text = textBox1.Text + "\r\nFile deleted in startup";
                fileFound = true;
            }
            if (File.Exists(File3)) {
                File.Delete(File3);
                textBox1.Text = textBox1.Text + "\r\nFile deleted in C root";
                fileFound = true;
            }
            if (File.Exists(File4)) {
                File.Delete(File4);
                textBox1.Text = textBox1.Text + "\r\nFile deleted in C root";
                fileFound = true;
            }

            if (fileFound) {
                MessageBox.Show("File deleted");
            }
            else {
                MessageBox.Show("File not found in folder");
            }
        }
    }
}