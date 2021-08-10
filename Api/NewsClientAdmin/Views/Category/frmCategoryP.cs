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

namespace NewsClientAdmin.Views.Category
{
    public partial class frmCategoryP : Form
    {
        string url = "https://localhost:44381/api/Categories";
        public frmCategoryP()
        {
            InitializeComponent();
        }

        private async void frmCategoryP_Load(object sender, EventArgs e)
        {
            string res = await GetHttp();
            List<Model.CategoryViewModel> lst = JsonConvert.DeserializeObject<List<Model.CategoryViewModel>>(res);

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
