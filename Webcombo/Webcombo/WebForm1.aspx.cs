using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Webcombo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DataAccess dataAccess = new DataAccess();

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(DropDownList1.SelectedValue);
            GridView1.DataSource = dataAccess.ObtenerDatosPorId(selectedId);
            GridView1.DataBind();

            // Cambiar a la vista de resultados
            MultiView1.ActiveViewIndex = 1;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            // Volver a la vista de búsqueda
            MultiView1.ActiveViewIndex = 0;
        }
    }
}
