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

namespace tthk_app
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_btn, box_lbl;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox pic_box;
        TabControl tabcontroll;
        TabPage tab_1, tab_2, tab_3;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;


            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            tn.Nodes.Add(new TreeNode("Sint-Label"));
            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tn.Nodes.Add(new TreeNode("Pildikast-Picturebox"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            //Button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 50;
            btn.Width = 100;
            btn.Click += Btn_Click;
            //Label
            lbl = new Label();
            lbl.Size = new Size(150, 30);
            lbl.Text = "Tarkavara arendajad";
            lbl.Location = new Point(150, 200);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Sint-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näine nupp";
                box_btn.Location = new Point(200,30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if(e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "Vasakule";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += R1_CheckedChanged;
                Controls.Add(r1);
                r2 = new RadioButton();
                r2.Text = "Paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += R1_CheckedChanged;
                Controls.Add(r2);

            }
            else if(e.Node.Text == "Tekstkast-TextBox")
            {
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 200;
                txt_box.Height = 200;
                Controls.Add(txt_box);
                string text;
                try
                {
                    text = File.ReadAllText("result.txt");
                }
                catch (FileNotFoundException exseption)
                {
                       text = "Teskt puutub";
                }
            }
            else if (e.Node.Text == "Pildikast-Picturebox")
            {
                pic_box = new PictureBox();
                pic_box.Image = new Bitmap("1.jpg");
                pic_box.Location = new Point(300, 0);
                pic_box.Size = new Size(300, 300);
                pic_box.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_box.BorderStyle = BorderStyle.Fixed3D;
                Controls.Add(pic_box);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                tabcontroll = new TabControl();
                tabcontroll.Location = new Point(300, 300);
                tabcontroll.Size = new Size(200, 100);
                tab_1 = new TabPage("Java");
                tab_2 = new TabPage("Python");
                tab_3 = new TabPage("C#");

                string tabctl = Interaction.InputBox("Millist programmeerimiskeelt näidata?", "Inputbox", "C# , Python");
                if(tabctl == "c#" || tabctl == "C#")
                {
                    Controls.Add(tabcontroll);
                    tabcontroll.Controls.Add(tab_1);
                    tab_1.BackColor = Color.Red;
                    tabcontroll.Controls.Add(tab_2);
                    tab_2.BackColor = Color.Gold;
                    tabcontroll.Controls.Add(tab_3);
                    tab_3.BackColor = Color.DarkGoldenrod;
                    tabcontroll.SelectedTab = tab_3;

                }
                else if (tabctl == "Python")
                {
                    Controls.Add(tabcontroll);
                    tabcontroll.Controls.Add(tab_1);
                    tabcontroll.Controls.Add(tab_2);
                    tabcontroll.Controls.Add(tab_3);
                    tabcontroll.SelectedTab = tab_2;
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
                            Controls.Add(lbl);
                            lbl.Text = text;
                        }
                    }
                }
            }
        }

        private void R1_CheckedChanged(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(300, 100);
            }   
            else if (r2.Checked)
            {
                btn.Location = new Point(100, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Black)
            {
                btn.BackColor = Color.DarkGray;
                btn.ForeColor = Color.White;
                lbl.BackColor = Color.DarkGray;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Black;
                btn.ForeColor = Color.White;
            }
        }
    }
}
