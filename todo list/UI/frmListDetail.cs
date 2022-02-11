using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using todo_list.ControlleurList;
using todo_list.Models;

namespace todo_list.UI
{
    public partial class frmListDetail : Form
    {

        frmList frm;
        public frmListDetail(frmList frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        ControlleurListe _controlleurListe = new ControlleurListe();
        public void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void descriptionText_TextChanged(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

        public void label2_Click(object sender, EventArgs e)
        {

        }

        public void dateText_ValueChanged(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void tacheText_TextChanged(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tacheText2.Text))
            {
                MessageBox.Show("Veiller entre la tache","Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                tacheText2.Focus();
                return;

            }
            if (string.IsNullOrEmpty(dateText2.Text))
            {
                MessageBox.Show("Veiller entre la date", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateText2.Focus();
                return;
            }
          
            try
            {
                List list = new List();
                list.Id =Convert.ToInt32(idLabel.Text);
                list.Tache = tacheText2.Text;
                list.Date = dateText2.Value;
                list.Description = descriptionText2.Text;
                
                

                if(_controlleurListe.Update(list))
                {
                        MessageBox.Show("Tache enregistrer", "Successes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        LoadApp();
    }
                else
                {
                    MessageBox.Show("Tache non enregistrer", "Erreure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadApp()
        {
            var liste = _controlleurListe.GetAll();
            frm.dataGridView1.Rows.Clear();
            foreach (var lists in liste)
            {
                frm.dataGridView1.Rows.Add(
                    lists.Id,
                    lists.Tache,
                    lists.Date,
                    lists.Description
                    );
            }
        }
    }
}
