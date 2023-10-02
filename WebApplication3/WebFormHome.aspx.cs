
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.UI.WebControls;
using WebApplication2.DataBase;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static int pageSize = 6;
        private static int pageIndex = 0;
        private static int totalPage = 0;
        static PagedDataSource PagedData = new PagedDataSource();

        private string sql = "";
        private static string SqlFilterGenerate = "select name, price, image, company, description from car where name like '%" + "" + "%'";
        private static string SqlFilterCompany = "";
        private static string SqlFilterColor = "";
        private static string SqlFilterClass = "";
        private static string SqlFilterFuel = "";
        private static string SqlFilterSeat = "";
        private static string SqlFilterYear = "";
        private static string SqlSortSeat = "";
        private static string SqlSortYear = "";
        private static string SqlSortPrice = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            sql = SqlFilterGenerate 
                + SqlFilterCompany 
                + SqlFilterColor 
                + SqlFilterClass 
                + SqlFilterFuel 
                + SqlFilterSeat 
                + SqlFilterYear
                + SqlSortSeat
                + SqlSortPrice
                + SqlSortYear;

            ConnectDataBase connectDataBase = new ConnectDataBase();
            SqlDataAdapter sqlDataAdapter = connectDataBase.SelectAdapterCommand(sql);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "car");
            connectDataBase.sqlConnection.Close();

            PagedData.DataSource = dataSet.Tables["car"].AsDataView();
            PagedData.PageSize = pageSize;
            PagedData.CurrentPageIndex = pageIndex;
            PagedData.AllowPaging = true;

            //if Page is firstPage, highlight btnNextPage dim the remaining 2 buttons
            if (PagedData.IsFirstPage)
            {
                ButtonFirstPage.Enabled = false;
                ButtonNextPage.Enabled = true;
                ButtonPreviousPage.Enabled = false;
            }
            //if Page is lastPage, highlight btnPreviousPage and btn FirstPage dim the remaining 1 buttons
            else if (PagedData.IsLastPage)
            {
                ButtonFirstPage.Enabled = true;
                ButtonPreviousPage.Enabled = true;
                ButtonNextPage.Enabled = false;
            }
            else
            {
                ButtonFirstPage.Enabled = true;
                ButtonNextPage.Enabled = true;
                ButtonPreviousPage.Enabled = true;
            }

            totalPage = PagedData.PageCount;
            if(pageIndex > totalPage)
            {
                pageIndex = 0;
            }
            if(totalPage <= 1)
            {
                ButtonFirstPage.Enabled = false;
                ButtonNextPage.Enabled = false;
                ButtonPreviousPage.Enabled = false;
            }

            LabelViewPageIndex.Text = "Trang " + (pageIndex + 1) + "/" + totalPage.ToString();
            DataList1.DataSource = PagedData;
            DataList1.DataBind();
        }

        protected void TextBoxnav_TextChanged(object sender, EventArgs e)
        {
            SqlFilterGenerate = "select name, price, image, company, description from car where name like '%" + textsearchnav.Text + "%'";
            pageIndex = 0;
            LoadData();
            SqlFilterGenerate = "select name, price, image, company, description from car where name like '%" + "" + "%'";
        }


        protected void Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<ListItem> listSelected = Company.Items.Cast<ListItem>()
                .Where(x => x.Selected)
                .ToList();
            if(listSelected.Count == 0)
            {
                SqlFilterCompany = "";
                LoadData();
                return;
            }

            for(int i=0; i< listSelected.Count; i++)
            {
                sb.Append("'");
                sb.Append(listSelected[i].Value.ToString());
                sb.Append("'");
                if (listSelected.Count > 1 && i != listSelected.Count - 1)
                {
                    sb.Append(",");
                }
            }
            pageIndex = 0;
            SqlFilterCompany = " and company in (" + sb.ToString() +")";
            LoadData();
        }

        protected void Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<ListItem> listSelected = Color.Items.Cast<ListItem>()
                .Where(x => x.Selected)
                .ToList();
            if (listSelected.Count == 0)
            {
                SqlFilterColor = "";
                LoadData();
                return;
            }

            for (int i = 0; i < listSelected.Count; i++)
            {
                sb.Append("'");
                sb.Append(listSelected[i].Value.ToString());
                sb.Append("'");
                if (listSelected.Count > 1 && i != listSelected.Count - 1)
                {
                    sb.Append(",");
                }
            }
            pageIndex = 0;
            SqlFilterColor = " and color in (" + sb.ToString() + ")";
            LoadData();
        }

        protected void Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<ListItem> listSelected = Class.Items.Cast<ListItem>()
                .Where(x => x.Selected)
                .ToList();
            if (listSelected.Count == 0)
            {
                SqlFilterClass = "";
                return;
            }

            for (int i = 0; i < listSelected.Count; i++)
            {
                sb.Append("'");
                sb.Append(listSelected[i].Value.ToString());
                sb.Append("'");
                if (listSelected.Count > 1 && i != listSelected.Count - 1)
                {
                    sb.Append(",");
                }
            }
            pageIndex = 0;
            SqlFilterClass = " and carclass in (" + sb.ToString() + ")";
            LoadData();
        }
        protected void Fuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<ListItem> listSelected = Fuel.Items.Cast<ListItem>()
                .Where(x => x.Selected)
                .ToList();
            if (listSelected.Count == 0)
            {
                SqlFilterFuel = "";
                return;
            }

            for (int i = 0; i < listSelected.Count; i++)
            {
                /*sb.Append("'");*/
                if (listSelected[i].Value.ToString() == "4.3")
                {
                    sb.Append("BETWEEN ");
                    sb.Append(4.3);
                    sb.Append(" and ");
                    sb.Append(6.2);
                }
                else if (listSelected[i].Value.ToString() == "4.2")
                {
                    sb.Append("<");
                    sb.Append(listSelected[i].Value.ToString());
                }
                else
                {
                    sb.Append("");
                    sb.Append(listSelected[i].Value.ToString());
                }
                /*sb.Append("'");*/
                if (listSelected.Count > 1 && i != listSelected.Count - 1)
                {
                    sb.Append(",");
                }
            }
            pageIndex = 0;
            SqlFilterFuel = " and fuel " + sb.ToString() + "";
            LoadData();

        }
        protected void Seat_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<ListItem> listSelected = Seat.Items.Cast<ListItem>()
                .Where(x => x.Selected)
                .ToList();
            if (listSelected.Count == 0)
            {
                SqlFilterSeat = "";
                return;
            }

            for (int i = 0; i < listSelected.Count; i++)
            {
                sb.Append("'");
                sb.Append(listSelected[i].Value.ToString());
                sb.Append("'");
                if (listSelected.Count > 1 && i != listSelected.Count - 1)
                {
                    sb.Append(",");
                }
            }
            pageIndex = 0;
            SqlFilterSeat = " and seat in (" + sb.ToString() + ")";
            LoadData();

        }
        protected void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<ListItem> listSelected = Year.Items.Cast<ListItem>()
                .Where(x => x.Selected)
                .ToList();
            if (listSelected.Count == 0)
            {
                SqlFilterYear = "";
                return;
            }

            for (int i = 0; i < listSelected.Count; i++)
            {
                sb.Append("'");
                sb.Append(listSelected[i].Value.ToString());
                sb.Append("'");
                if (listSelected.Count > 1 && i != listSelected.Count - 1)
                {
                    sb.Append(",");
                }
            }
            pageIndex = 0;
            SqlFilterYear = " and year in (" + sb.ToString() + ")";
            LoadData();

        }

        protected void ButtonFirstPage_Click(object sender, EventArgs e)
        {
            pageIndex = 0;
            LoadData();
        }

        protected void ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            pageIndex--;
            LoadData();
        }

        protected void ButtonNextPage_Click(object sender, EventArgs e)
        {
            pageIndex++;
            LoadData();
        }

        protected void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            foreach(ListItem item in Company.Items)
            {
                if(item.Selected)
                { item.Selected = false; }
            }
            foreach (ListItem item in Color.Items)
            {
                if (item.Selected)
                { item.Selected = false; }
            }
            foreach (ListItem item in Class.Items)
            {
                if (item.Selected)
                { item.Selected = false; }
            }
            foreach (ListItem item in Fuel.Items)
            {
                if (item.Selected)
                { item.Selected = false; }
            }
            foreach (ListItem item in Seat.Items)
            {
                if (item.Selected)
                { item.Selected = false; }
            }
            foreach (ListItem item in Year.Items)
            {
                if (item.Selected)
                { item.Selected = false; }
            }
            SqlFilterCompany = "";
            SqlFilterColor = "";
            SqlFilterClass = "";
            SqlFilterFuel = "";
            SqlFilterSeat = "";
            SqlFilterYear = "";
            pageIndex = 0;
            LoadData();
    }

        protected void DropDownListSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = 0;
            string s = DropDownListSeat.Text;
            if(s.Equals("asc") || s.Equals("desc"))
            {
                SqlSortSeat = " order by seat " + s;
                LoadData();
            }
            else
            {
                SqlSortSeat = "";
                LoadData();
            }
        }

        protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = 0;
            string s = DropDownListYear.Text;
            if (s.Equals("asc") || s.Equals("desc"))
            {
                SqlSortYear = " order by year " + s;
                LoadData();
            }
            else
            {
                SqlSortYear = "";
                LoadData();
            }
        }

        protected void DropDownListPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = 0;
            string s = DropDownListPrice.Text;
            if (s.Equals("asc") || s.Equals("desc"))
            {
                SqlSortPrice = " order by price " + s;
                LoadData();
            }
            else
            {
                SqlSortPrice = "";
                LoadData();
            }
        }

        protected void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (txtContact.Text == "")
                return;
            ConnectDataBase connectDataBase = new ConnectDataBase();
            StringBuilder sqlContactCustomer = new StringBuilder();
            sqlContactCustomer.Append("insert into ContactCustomer");
            sqlContactCustomer.Append("(email, createdate)");
            sqlContactCustomer.Append("values(@email, @createdate)");
            SqlCommand sqlCommand = connectDataBase.OtherCommand(sqlContactCustomer.ToString());

            sqlCommand.Parameters.AddWithValue("@email", txtContact.Text);
            sqlCommand.Parameters.AddWithValue("@createdate", DateTime.Now);
            sqlCommand.ExecuteNonQuery();
            connectDataBase.sqlConnection.Close();
            txtContact.Text = "";
        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "")
                return;
            ConnectDataBase connectDataBase = new ConnectDataBase();
            StringBuilder sqlContactCustomer = new StringBuilder();
            sqlContactCustomer.Append("insert into ContactCustomer");
            sqlContactCustomer.Append("(email, createdate)");
            sqlContactCustomer.Append("values(@email, @createdate)");
            SqlCommand sqlCommand = connectDataBase.OtherCommand(sqlContactCustomer.ToString());

            sqlCommand.Parameters.AddWithValue("@email", txtContact.Text);
            sqlCommand.Parameters.AddWithValue("@createdate", DateTime.Now);
            sqlCommand.ExecuteNonQuery();
            connectDataBase.sqlConnection.Close();
            txtContact.Text = "";
        }
    }
}