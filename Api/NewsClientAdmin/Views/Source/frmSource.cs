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
using Newtonsoft.Json;

namespace NewsClientAdmin.Views.Country
{
    public partial class frmSource : Form
    {
        string url = "https://localhost:44381/api/Sources";
        public frmSource()
        {
            InitializeComponent();
        }

        private async void frmSource_Load(object sender, EventArgs e)
        {
            string res = await GetHttp();
            List<Model.SourceViewModel> lst = JsonConvert.DeserializeObject<List<Model.SourceViewModel>>(res);

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
