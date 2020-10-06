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
                catch (FileNotFoundException exception)
                {
                       text = "Teskt puutub";
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
