﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingdeeWebAPI
{
    public static class SQL
    {
		//供应商信息
		public static readonly string Supplier = @"
				select a.FSUPPLIERID,a.FNumber, a.FPRIMARYGROUP as 'FGROUPID',f.FNAME as 'FPRIMARYGROUP',  a.FCreateOrgId,c.FNAME AS 'FCreateOrgNAME', a.FUseOrgId,
				d.FNAME AS 'FUseOrgNAME',b.FNAME,b.FSHORTNAME,k.FDATAVALUE AS 'FCOUNTRY',
					l.FDATAVALUE AS 'FPROVINCIAL',e.FADDRESS,b.F_PINPAIWENBEN,h.FNAME as 'FPROVIDERID',i.FDATAVALUE as 'FSUPPLIERGR',
					a.FDOCUMENTSTATUS,a.FFORBIDSTATUS,
					a.FCREATEDATE,a.FMODIFYDATE
					from  T_BD_SUPPLIER a
				INNER JOIN T_BD_SUPPLIER_L b on a.FSUPPLIERID = b.FSUPPLIERID
				INNER JOIN T_ORG_ORGANIZATIONS_L c ON ( a.FCreateOrgId = c.FORGID AND c.FLOCALEID= '2052' )
				LEFT JOIN T_ORG_ORGANIZATIONS_L d ON ( a.FUseOrgId = d.FORGID AND d.FLOCALEID= '2052' )
				LEFT JOIN T_BD_SUPPLIERBASE e on a.FSUPPLIERID = e.FSUPPLIERID
				LEFT JOIN T_BD_SUPPLIERGROUP_L f on (a.FPRIMARYGROUP = f.FID AND f.FLOCALEID= '2052' )
				LEFT JOIN T_BD_SUPPLIERBUSINESS g on a.FSUPPLIERID = g.FSUPPLIERID
				LEFT JOIN T_BD_SUPPLIER_L h on g.FPROVIDERID = h.FSUPPLIERID
				LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L i ON (e.FSUPPLIERGRADE = i.FENTRYID AND i.FLOCALEID= '2052' )
				LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L k ON (e.FCOUNTRY = k.FENTRYID AND k.FLOCALEID= '2052' )
				LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L l ON (e.FPROVINCIAL = l.FENTRYID AND l.FLOCALEID= '2052' )
				where a.FMODIFYDATE >= '{0}'
				ORDER BY a.FMODIFYDATE desc
		";
	}
}
