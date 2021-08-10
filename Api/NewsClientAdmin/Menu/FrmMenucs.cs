using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsClientAdmin.Views.Articles;
using NewsClientAdmin.Views.Authors;
using NewsClientAdmin.Views.Category;
using NewsClientAdmin.Views.Country;



namespace NewsClientAdmin.Menu
{
    public partial class FrmMenucs : Form
    {
        string url = "https://localhost:44381/api/Articles";
        public FrmMenucs()
        {
            InitializeComponent();
        }

        private async void FrmMenucs_Load(object sender, EventArgs e)
        {
            string res = await GetHttp();
            List<Model.ArticleViewModel> lst = JsonConvert.DeserializeObject<List<Model.ArticleViewModel>>(res);
            
            
            
        }

        public async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmArticleP frmArticleP = new frmArticleP();
            frmArticleP.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCategoryP frmCategoryP = new frmCategoryP();
            frmCategoryP.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSource frmSource = new frmSource();
            frmSource.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAuthorP frmAuthorP = new FrmAuthorP();
            frmAuthorP.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCountryP frmCountryP = new frmCountryP();
            frmCountryP.ShowDialog();
        }
    }
}
