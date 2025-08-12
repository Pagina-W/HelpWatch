using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularioHelp.Validaciones
{
    public partial class RespuestasMV
    {
        public int Id { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Q5 { get; set; }
        public int Total { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}

