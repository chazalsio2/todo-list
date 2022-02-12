using System.Collections.Generic;
using todo_list.ControlleurList;
using todo_list.Models;
using todo_list.UI;

namespace todo_list
{
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }
        ControlleurListe _dbContext = new ControlleurListe();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tacheText.Text))
            {
                MessageBox.Show("Veiller entre la tache", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tacheText.Focus();
                return;

            }
            if (string.IsNullOrEmpty(dateText.Text))
            {
                MessageBox.Show("Veiller entre la date", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateText.Focus();
                return;
            }

            try
            {
                List list = new List();
                list.Date = dateText.Value;
                list.Tache = tacheText.Text;
                list.Description = descriptionText.Text;



                if (_dbContext.Add(list))
                {
                    MessageBox.Show("Tache enregistrer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
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
        }

        public void reset()
        {
            Console.WriteLine("je suis dedans");
            this.Refresh();
            tacheText.Text = String.Empty;
            descriptionText.Text = String.Empty;
            LoadApp();
        }

        private void dateText_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadApp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadApp()
        {
            var liste = _dbContext.GetAll();
            dataGridView1.Rows.Clear();
            foreach (var lists in liste)
            {
                dataGridView1.Rows.Add(
                    lists.Id,
                    lists.Tache,
                    lists.Date,
                    lists.Description,
                    lists.completed
                    );
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           /* try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                frmListDetail frm = new frmListDetail(this);
                frm.idLabel.Text = dr.Cells[0].Value.ToString();
                frm.tacheText2.Text = dr.Cells[1].Value.ToString();
                frm.dateText2.Text = dr.Cells[2].Value.ToString();
                frm.descriptionText2.Text = dr.Cells[3].Value.ToString();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow dre = dataGridView1.SelectedRows[0];
            List list = new List();

            DataGridViewCheckBoxColumn dr = new DataGridViewCheckBoxColumn();
            list.Id = (int)dre.Cells[0].Value;
            list.completed = (int)dre.Cells["Column1"].Value;
            if (_dbContext.UpdateCompleted(list))
            {
                LoadApp();
            }
            else
            {
                MessageBox.Show("La tache n'a pas était supprimer", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                if (MessageBox.Show("Voulez vous vraiment supprimer cette tache ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)dr.Cells[0].Value;//(int)
                    bool isDelete = _dbContext.Delete(id);
                    if (isDelete)
                    {
                        MessageBox.Show("La tache a bien était supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadApp();
                    }
                    else
                    {
                        MessageBox.Show("La tache n'a pas était supprimer", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }
        public void faux()
        {
            DataGridViewRow dre = dataGridView1.SelectedRows[0];

        }
        private void button1_Click(object sender, EventArgs e)
        {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
               
                    List list = new List();
                    bool isChecked = Convert.ToBoolean(dr.Cells["Terminer"].Value);

                 
                    
                        
                        if (isChecked == true)
                        {
                            list.Id = (int)dr.Cells["Id"].Value;
                            list.Tache = (string)dr.Cells["Tache"].Value;
                            list.Date = (DateTime)dr.Cells["Echéance"].Value;
                            list.Description = (string)dr.Cells["Description"].Value;
                            list.completed = 1;
                            _dbContext.Update(list);
                            // MessageBox.Show("Tache : " + list.Tache + " modifier");

                        }
                        if (isChecked == false)
                        {
                            list.Id = (int)dr.Cells["Id"].Value;
                            list.Tache = (string)dr.Cells["Tache"].Value;
                            list.Date = (DateTime)dr.Cells["Echéance"].Value;
                            list.Description = (string)dr.Cells["Description"].Value;
                            list.completed = 0;
                            _dbContext.Update(list);
                        }
                LoadApp();
            }
        }
    }
