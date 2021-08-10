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

namespace NewsClientAdmin.Views.Authors
{
    public partial class FrmAuthorP : Form
    {
        string url = "https://localhost:44381/api/Authors";
        public FrmAuthorP()
        {
            InitializeComponent();
        }

        private async void FrmAuthorP_Load(object sender, EventArgs e)
        {
            string res = await GetHttp();
            List<Model.AuthorViewModel> lst = JsonConvert.DeserializeObject<List<Model.AuthorViewModel>>(res);


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
