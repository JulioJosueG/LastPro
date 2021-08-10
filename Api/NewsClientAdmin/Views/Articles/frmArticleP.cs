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

namespace NewsClientAdmin.Views.Articles
{
    public partial class frmArticleP : Form
    {
        string url = "https://localhost:44381/api/Articles";
        public frmArticleP()
        {
            InitializeComponent();
        }

        private async void frmArticleP_Load(object sender, EventArgs e)
        {
            string res = await GetHttp();
            List<Model.ArticleViewModel> lst = JsonConvert.DeserializeObject<List<Model.ArticleViewModel>>(res);

            dataGridView1.DataSource = lst;


        }

        public async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

    }
}
