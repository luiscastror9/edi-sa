using System;
using System.Configuration;
using Utilidades;
using Entidades;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected string PathImagePerfil = ConfigurationManager.AppSettings["PathImagenesPerfil"].ToString();
    protected UsuarioAd usuario = new UsuarioAd();

    private string ReturnConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(ConfigurationManager.AppSettings["EntornoLocal"]))
        {
            usuario.Nombre = "Juan";
            usuario.Apellido = "Peréz";

            usuario.NombreMostrable = usuario.Nombre.ToUpper() + " " + usuario.Apellido.ToUpper();
        }
        else
        {
            usuario = ActiveDirectory.obtieneUsuario();
        }

        string searchTerm = Request.QueryString["search"];
        search.Value = searchTerm;

        SqlConnection con = new SqlConnection(this.ReturnConnectionString());
        con.Open();

        SqlCommand cmd = new SqlCommand("Buscar_Personal_SEL", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 50).Value = searchTerm;
        cmd.Connection = con;

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows && !String.IsNullOrEmpty(searchTerm))
        {
            results.Visible = true;
            Repeater1.DataSource = dr;
            Repeater1.DataBind();
        }
        else if (!String.IsNullOrEmpty(searchTerm))
        {
            noResults.Visible = true;
        }

        cmd.Connection = con;
        con.Close();
    }
}