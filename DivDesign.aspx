<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DivDesign.aspx.cs" Inherits="DivDesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        /* DivTable.com */
.divTable{
	display: table;
	width: 100%;
}
.divTableRow {
	display: table-row;
}
.divTableHeading {
	background-color: #EEE;
	display: table-header-group;
}
.divTableCell, .divTableHead {
	border: 1px solid #999999;
	display: table-cell;
	padding: 3px 10px;
}
.divTableHeading {
	background-color: #EEE;
	display: table-header-group;
	font-weight: bold;
}
.divTableFoot {
	background-color: #EEE;
	display: table-footer-group;
	font-weight: bold;
}
.divTableBody {
	display: table-row-group;
}
    </style>
    <title></title>
</head>
<body>
    <div class="divTable">
        <div class="divTableBody">
            <div class="divTableRow">
                <div class="divTableCell"><strong>%fullname%</strong></div>
            </div>
            <div class="divTableRow">
                <div class="divTableCell"><strong>%unit%</strong></div> <div class="divTableCell">%group%, Sterling Bank PLC, %address1%,%address2% </div>
            </div>
          
            
            <div class="divTableRow">
                <div class="divTableCell"><span style="box-sizing: border-box; color: #f7781f;">P:</span>&nbsp;%phone%<span style="box-sizing: border-box; color: #f7781f;">&nbsp;Ext:</span>&nbsp;%extension%<span style="box-sizing: border-box; color: #f7781f;">&nbsp;M:</span>&nbsp;%mobile%</div>
                <div class="divTableCell">&nbsp;<span style="box-sizing: border-box; color: #f7781f;">E:&nbsp;</span>%email%</div>
            </div>
            

            <div class="divTableRow">
            
                <div class="divTableCell"><strong><a style="box-sizing: border-box; color: #000000; text-decoration-line: none;" href="http://www.sterlingbankng.com/" target="_blank" data-saferedirecturl="https://www.google.com/url?hl=en&amp;q=http://www.sterlingbankng.com/&amp;source=gmail&amp;ust=1496700902779000&amp;usg=AFQjCNFJePjizWYCNpoODW9FBx-eZ2R1Ig">www.sterlingbankng.com</a>&nbsp;</strong></div>
            </div>
            <div class="divTableRow">
                <div class="divTableCell">
                    <img src="https://drive.google.com/uc?id=0B8ccZQzaOYirYU9sMm84eExPQnc" alt="ds" width="600" height="111" /></div>
            </div>
            <div class="divTableRow">
                <div class="divTableCell">&nbsp;</div>
            </div>
            <div class="divTableRow">
                <div class="divTableCell">&nbsp;</div>
            </div>
        </div>
    </div>
</body>
</html>
