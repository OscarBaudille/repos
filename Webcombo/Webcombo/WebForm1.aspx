<%@ page language="C#" autoeventwireup="true" codebehind="WebForm1.aspx.cs" inherits="Webcombo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:objectdatasource id="ods_example" runat="server" typename="Webcombo.DataAccess"
                selectmethod="ObtenerDatos" dataobjecttypename="Webcombo.TuClaseInfo">
</asp:objectdatasource>


            <asp:multiview id="MultiView1" runat="server" activeviewindex="0">
    <asp:View ID="SearchView" runat="server">
        <h2>Buscar</h2>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ods_example"
            DataTextField="Nombre" DataValueField="Id" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Button ID="SearchButton" runat="server" Text="Buscar" OnClick="SearchButton_Click" />
    </asp:View>
    <asp:View ID="ResultsView" runat="server">
        <h2>Resultados</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            DataSourceID="ods_example" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="AddButton" runat="server" Text="Agregar Nuevo" OnClick="AddButton_Click" />
        <asp:Button ID="BackButton" runat="server" Text="Volver" OnClick="BackButton_Click" />
    </asp:View>
</asp:multiview>

            <asp:objectdatasource id="ObjectDataSource1" runat="server" typename="Webcombo.DataAccess"
                selectmethod="ObtenerDatos" updatemethod="ActualizarDatos" deletemethod="EliminarDatos"
                insertmethod="InsertarDatos" dataobjecttypename="Webcombo.TuClaseInfo">
</asp:objectdatasource>
    </form>
</body>
</html>
