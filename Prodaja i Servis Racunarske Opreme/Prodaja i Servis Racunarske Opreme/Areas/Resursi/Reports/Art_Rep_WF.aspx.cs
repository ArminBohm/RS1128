using Microsoft.Reporting.WebForms;
using Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Reports
{
    public partial class Art_Rep_WF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Zaglavlje = Art_Rep_Model.ArtHeader();
                var Izvjestaj = Art_Rep_Model.ArtBody();

                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ArtHeader", Zaglavlje));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ArtBody", Izvjestaj));

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("") + "/Artikli_Rep.rdlc";
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();

            }
        }
    }
}