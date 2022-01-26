//OnRowDataBound
//tooltipe from cs to gridview
    protected void gridPessoas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#f1f3f5';this.style.cursor='pointer';");
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor=this.originalstyle;");
        }
    }
