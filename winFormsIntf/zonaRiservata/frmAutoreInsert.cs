using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmAutoreInsert : Form
    {
        public frmAutoreInsert()
        {// check login status
            bool isLoggedIn =
                winFormsIntf.CheckLogin.isLoggedIn(
                    (Entity_materie.BusinessEntities.Permesso.Patente)
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"]);
            if (!isLoggedIn)
            {
                winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("user is not Logged In"
                    , new System.Exception("Go to Login Form and access, in order to proceed.")));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
            //
            this.comboBox1.Items.Add("comboBox1_primo");
            this.comboBox1.Items.Add("comboBox1_secondo");
            //this.comboBox1.SelectedIndex = 1;// 0-based
            //
            this.domainUpDown1.Items.Add("domainUpDown1_primo");
            this.domainUpDown1.Items.Add("domainUpDown1_secondo");
            this.domainUpDown1.Items.Add("domainUpDown1_terzo");
            this.domainUpDown1.Items.Add("domainUpDown1_quarto");
            this.domainUpDown1.Items.Add("domainUpDown1_quinto");
            //this.domainUpDown1.SelectedIndex = 1;// 0-based
            //
            this.listBox1.Items.Add("listBox1_primo");
            this.listBox1.Items.Add("listBox1_secondo");
            this.listBox1.Items.Add("listBox1_terzo");
            this.listBox1.Items.Add("listBox1_quarto");
            this.listBox1.Items.Add("listBox1_quinto");
            //this.listBox1.SelectedIndex = 1;// 0-based
            string base_listBox1_String = "listBox1_testoLungoDiBase/sssssssssssss/ddddddddddddddd/fffffffffffff/";
            for (int c = 0; c < 100; c++)
            {
                this.listBox1.Items.Add(base_listBox1_String + c.ToString() + ".txt");
            }
            //
            this.listView1.Items.Add("listView1_primo");
            this.listView1.Items.Add("listView1_secondo");
            this.listView1.Items.Add("listView1_terzo");
            this.listView1.Items.Add("listView1_quarto");
            this.listView1.Items.Add("listView1_quinto");
            //string baseString = "listView1_testoLungoDiBase/sssssssssssss/ddddddddddddddd/fffffffffffff/";
            for (int c = 0; c < 100; c++)
            {
                string[] ss = new string[2];
                ss[0] = c.ToString();
                ss[1] = "__second_field_" + c.ToString();
                ListViewItem tmp = new ListViewItem( ss );
                this.listView1.Items.Add( tmp );
            }
            //bool selIndexes = this.listView1.SelectedIndices.Contains(1);// ? 
            //
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmAutoreInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.uscTimbro.removeSpecifiedWin(this);
        }






    }
}
