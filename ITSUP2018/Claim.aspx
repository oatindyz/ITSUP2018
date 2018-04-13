<%@ Page Title="Claim" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Claim.aspx.cs" Inherits="ITSUP2018.Claim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/r/ju-1.11.4/jqc-1.11.3,dt-1.10.8/datatables.min.css"/>
     <link href="css/cssGridview/bootstrap-theme.css" rel="stylesheet" />
	 <script type="text/javascript" src="https://cdn.datatables.net/r/ju-1.11.4/jqc-1.11.3,dt-1.10.8/datatables.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                columnDefs: [{
                    orderable: false,
                    className: 'select-checkbox',
                    targets: 0
                }],
                select: {
                    style: 'os',
                    selector: 'td:first-child'
                },
                order: [[1, 'asc']]
            });
        });
    </script>
    <style>
        .table-striped tbody tr:nth-child(odd) td,
        .table-striped tbody tr:nth-child(odd) th {
            background-color: #d7d5d5;
        }
    </style>
    <style type="text/css">
        .paging_full_numbers span.paginate_button {
            background-color: #fff;
        }

            .paging_full_numbers span.paginate_button:hover {
                background-color: #ccc;
            }

        .paging_full_numbers span.paginate_active {
            background-color: #99B3FF;
        }

        .center {
            text-align: center;
            width: 10px;
        }
        .center1 {
            text-align: center;
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header">
            <img src="Image/Icon/Manage.png" />Search Claim
        <span style="text-align: right; float: right;"><a href="ClaimImport.aspx">
            <img src="Image/Icon/Manage.png" />Import Claim</a></span>
        </div>
        <div style="margin-top: 30px">
            <table class="table table-striped table-bordered " style="font-family: Serif;" id="example">
                <thead>
                    <tr>
                        <th class="center1"><asp:Button ID="BTNupdate" runat="server" Text="Q" OnClick="BTNupdate_Click"/></th>
                        <th class="center">Equip_Rep</th>
                        <th class="center">Equip_Name</th>
                        <th class="center">Equip_location</th>
                        <th class="center">Equip_Asset</th>
                        <th class="center">Equip_Remark</th>
                        <th class="center">Equip_Case_Claim</th>
                        <th class="center">Actions</th>
                    </tr>
                </thead>
                <tbody id="tlist" runat="server">
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
