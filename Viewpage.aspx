<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viewpage.aspx.cs" Inherits="nocode.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page_inputs">
        <div id="page_head">
            <asp:Label ID="page_head_label" runat="server" Text="Page Headding:" AssociatedControlID="page_head_input"></asp:Label>
            <asp:TextBox ID="page_head_input" runat="server"></asp:TextBox>
        </div>
        <div id="page_author">
            <asp:Label ID="page_author_label" runat="server" Text="Author Name:" AssociatedControlID="page_author_input"></asp:Label>
            <asp:TextBox ID="page_author_input" runat="server"></asp:TextBox>
        </div>
        <div id="page_body">
            <asp:Label ID="page_body_label" runat="server" Text="Body Area:" AssociatedControlID="page_body_input"></asp:Label>
            <asp:TextBox ID="page_body_input" runat="server" />
        </div>
        <asp:Button Text="ADD" runat="server" OnClick="Add_Submit" />
        
    </div>
    <table>
        <thead>
            <tr>
                <th>##</th>
                <th>Page Heading</th>
                <th>Author Name</th>
                <th>Page Body</th>
            </tr>
        </thead>
        <tbody runat="server" id="ListResult"></tbody>
    </table>
    <div runat="server" id="error_msg"></div>


    <asp:Button Text="UPDATE" runat="server" />
    <asp:Button Text="DELETE" runat="server" OnClick="Del_Data" />


</asp:Content>
