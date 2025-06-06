using System;
using System.Web.UI.WebControls;

namespace Webcombo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DataAccess dataAccess = new DataAccess();

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(DropDownList1.SelectedValue);
           
            GridView1.DataSourceID = null; // Asegúrate de que DataSourceID esté en null
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = dataAccess.ObtenerDatos();
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string nombre = ((TextBox)row.Cells[1].Controls[0]).Text;
            string notas = ((TextBox)row.Cells[2].Controls[0]).Text;

            TuClaseInfo datos = new TuClaseInfo { Id = id, Nombre = nombre, Notas = notas };
            dataAccess.ActualizarDatos(datos);

            GridView1.EditIndex = -1;
            GridView1.DataSource = dataAccess.ObtenerDatos();
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = dataAccess.ObtenerDatos();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            dataAccess.EliminarDatos(id);

            GridView1.DataSource = dataAccess.ObtenerDatos();
            GridView1.DataBind();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            TuClaseInfo datos = new TuClaseInfo { Nombre = "Nuevo Nombre", Notas = "Nuevas Notas" };
            dataAccess.InsertarDatos(datos);

            GridView1.DataSource = dataAccess.ObtenerDatos();
            GridView1.DataBind();
        }
    }
}
