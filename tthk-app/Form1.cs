using Microsoft.VisualBasic;
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
using System.Windows.Forms.VisualStyles;

namespace tthk_app
{
    public partial class Form1 : Form
    {
        private bool status;
        private bool status_pic;
        TreeView _tree;
        Button _btn;
        Label _lbl;
        CheckBox _box_btn, _box_lbl;
        RadioButton r1, r2;
        TextBox _txt_box;
        PictureBox _pic_box;
        TabControl _tabcontroll;
        TabPage _tab_1, _tab_2, _tab_3;
        ListBox _List1;
        DataGridView _dataGrid;
        private Color[] _Color_List;
        public Form1()
        {
            //Form
            this.Height = 900;
            this.Width = 1200;
            this.Text = "Vorm elementidega";
            
            //TreeView
            _tree = new TreeView();
            _tree.Dock = DockStyle.Left;
            _tree.AfterSelect += Tree_AfterSelect;
            _tree.Width = 160;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Menu"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("Sint-Label"));
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            tn.Nodes.Add(new TreeNode("Pildikast-Picturebox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            
            _tree.Nodes.Add(tn);
            this.Controls.Add(_tree);

            //Button
            _btn = new Button
            {
                Text = "Vajuta siia", 
                Location = new Point(170, 300), 
                Height = 50, Width = 100
            };
            _btn.Click += Btn_Click;
            
            //Label
            _lbl = new Label();
            _lbl.Size = new Size(150, 30);
            _lbl.Text = "Tarkavara arendajad";
            _lbl.Location = new Point(500, 400);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                Controls.Add(_btn);
                status = true;
            }
            else if (e.Node.Text == "Sint-Label")
            {
                Controls.Add(_lbl);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                _box_btn = new CheckBox
                {
                    Text = "Näine nupp", 
                    Location = new Point(170, 100)
                };
                _box_lbl = new CheckBox
                {
                    Text = "Näita silt", 
                    Location = new Point(170, 120)
                };
                Controls.Add(_box_btn);
                Controls.Add(_box_lbl);
                _box_btn.CheckedChanged += Box_btn_CheckedChanged;
                _box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if(e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton
                {
                    Text = "Vasakule", 
                    Location = new Point(170, 30),
                    Checked = true
                };
                r1.CheckedChanged += R1OnCheckedChanged;

                r2 = new RadioButton
                {
                    Text = "Paremale", 
                    Location = new Point(170, 50)
                };
                r2.CheckedChanged += R1OnCheckedChanged;
                Controls.Add(r1);
                Controls.Add(r2);

            }
            else if(e.Node.Text == "Tekstkast-TextBox")
            {
                _txt_box = new TextBox
                {
                    Multiline = true,
                    Text = "",
                    Location = new Point(300, 500),
                    Width = 200,
                    Height = 200
                };
                Controls.Add(_txt_box);
                string text;
                try
                {
                    text = File.ReadAllText("result.txt");
                }
                catch
                {
                    text = "Tekst puudub";
                }
            }
            else if (e.Node.Text == "Pildikast-Picturebox")
            {
                _pic_box = new PictureBox
                {
                    Image = new Bitmap("1.png"),
                    Location = new Point(300, 0),
                    Size = new Size(600, 400),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.Fixed3D
                };
                Controls.Add(_pic_box);
                status_pic = true;
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                _tabcontroll = new TabControl
                {
                    Location = new Point(300, 300), 
                    Size = new Size(200, 100)
                };
                _tab_1 = new TabPage("Java");
                _tab_2 = new TabPage("Python");
                _tab_3 = new TabPage("C#");

                string tabctl = Interaction.InputBox("Millist programmeerimiskeelt näidata?", "Inputbox", "C# , Python");
                if(tabctl == "c#" || tabctl == "C#")
                {
                    Controls.Add(_tabcontroll);
                    _tabcontroll.Controls.Add(_tab_1);
                    _tab_1.BackColor = Color.Red;
                    _tabcontroll.Controls.Add(_tab_2);
                    _tab_2.BackColor = Color.Gold;
                    _tabcontroll.Controls.Add(_tab_3);
                    _tab_3.BackColor = Color.DarkGoldenrod;
                    _tabcontroll.SelectedTab = _tab_3;

                }
                else if (tabctl == "Python")
                {
                    Controls.Add(_tabcontroll);
                    _tabcontroll.Controls.Add(_tab_1);
                    _tabcontroll.Controls.Add(_tab_2);
                    _tabcontroll.Controls.Add(_tab_3);
                    _tabcontroll.SelectedTab = _tab_2;
                }
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige listsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    var text2 = MessageBox.Show("Tahad testi salvestaga?", "Aken", MessageBoxButtons.YesNoCancel);
                    if (text2 == DialogResult.Yes)
                    {
                        var text3 = MessageBox.Show("Tahad label näga?", "Näga Label", MessageBoxButtons.YesNoCancel);
                        if(text3 == DialogResult.Yes)
                        {
                            Controls.Add(_lbl);
                            _lbl.Text = text;
                        }
                    }
                }
            }
            else if (e.Node.Text == "ListBox")
            {
                string[] _colorName = new string[] { "Kollane", "Punane", "Sinine", "Roheline" };
                _Color_List = new Color[] { Color.Yellow, Color.Red, Color.Blue, Color.Green };
                _List1 = new ListBox
                {
                    Location = new Point(550, 500),
                    Width = _colorName.OrderByDescending(n => n.Length).First().Length * 10,
                    Height = _colorName.Length * 15
                };
                foreach (var i in _Color_List)
                {
                    _List1.Items.Add(i);
                }
                
                _List1.SelectedIndexChanged += List1_SelectedIndexChanged;
                Controls.Add(_List1); 
            }
            else if ( e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml("..//..//files//simple.xml");
                _dataGrid = new DataGridView
                {
                    DataSource = dataSet,
                    AutoGenerateColumns = true,
                    DataMember = "email",
                    Location = new Point(700, 500),
                    Height = 200,
                    Width = 200
                };
                Controls.Add(_dataGrid);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuitem1 = new MenuItem("File");
                MenuItem menuItem2 = new MenuItem("My");
                
                menuitem1.MenuItems.Add("Exit", new EventHandler(menuItem1_exit));
                menuItem2.MenuItems.Add("Random Color", new EventHandler(RandomColor_Menu));
                menuItem2.MenuItems.Add("Radiobutton OFF", new EventHandler(RadioButtonOff));
                menuItem2.MenuItems.Add("Picturebox ON/OFF", new EventHandler(PictureboxONOFF));
                menu.MenuItems.Add(menuitem1);
                menu.MenuItems.Add(menuItem2);
               
                this.Menu = menu;
            }
        }

        private void R1OnCheckedChanged(object sender, EventArgs e)
        {

            if (r1.Checked)
            {
                _btn.Location = new Point(170, 300);
            }

            if (r2.Checked)
            {
                _btn.Location = new Point(950, 300);
            }
        }

        private void menuItem1_exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void RandomColor_Menu(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            this.BackColor = randomColor; 

        }
        
        private void RadioButtonOff(object sender, EventArgs e)
        {
            if (status == true)
            {
                Controls.Remove(_btn);
            }
            else
            {
                MessageBox.Show("Nupp puudub", "Nupp", MessageBoxButtons.OK);
            }
        }
        
        private void PictureboxONOFF(object sender, EventArgs e)
        {
            if (status_pic == true)
            {
                Controls.Remove(_pic_box);
                status_pic = false;
            }
            else if (status_pic == false)
            {
                Controls.Add(_pic_box);
                status_pic = true;
            }
        }
        
        private void List1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            lb.BackColor = _Color_List[_List1.SelectedIndex];
        }

   

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (_box_lbl.Checked)
            {
                Controls.Add(_lbl);
            }
            else
            {
                Controls.Remove(_lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (_box_btn.Checked)
            {
                Controls.Add(_btn);
            }
            else
            {
                Controls.Remove(_btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (_btn.BackColor == Color.Black)
            {
                _btn.BackColor = Color.DarkGray;
                _btn.ForeColor = Color.White;
                _lbl.BackColor = Color.DarkGray;
                _lbl.ForeColor = Color.White;
            }
            else
            {
                _btn.BackColor = Color.Black;
                _btn.ForeColor = Color.White;
            }
        }
    }
}
