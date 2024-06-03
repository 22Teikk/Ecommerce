﻿using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class AddCategoryPage : System.Web.UI.Page
    {
        CategoryDataUtils data = new CategoryDataUtils();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Value;
                    data.AddCategory(name);
                    msgSuccess.Text = "Thêm danh mục thành công";
                msgSuccess.Enabled = true;
                msgFail.Enabled = false;
            }
            catch (Exception ex)
            {
                msgFail.Text = "Thêm danh mục thất bại: " + ex.Message;
                msgSuccess.Enabled = false;
                msgFail.Enabled = true;
            }
        }
    }
}