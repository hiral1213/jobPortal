<%@ Page Title="" Language="C#" MasterPageFile="~/Js_userMaster.Master" AutoEventWireup="true" CodeBehind="Js_Post.aspx.cs" Inherits="jobPortal.Js_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="col-sm-2"></div>
        <div class="col-lg-8" style="left: 0px; top: 24px; width: 825px; height: 863px">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Post List</h3>
                </div>
                <div class="box-body">
                    Search By:<asp:DropDownList ID="dlst1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlst1_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>PostHead</asp:ListItem>
                        <asp:ListItem>JobField</asp:ListItem>
                        <asp:ListItem>Loc</asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="dlst2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlst2_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT DISTINCT [PostHead] FROM [JobPost]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT DISTINCT [JobField] FROM [JobPost]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT DISTINCT  [Loc] FROM [JobPost]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" runat="server">

                        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource4" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">

                            <Columns>
                                <asp:BoundField DataField="PostHead" HeaderText="PostHead" SortExpression="PostHead" />
                                <asp:BoundField DataField="Descr" HeaderText="Descr" SortExpression="Descr" />
                                <asp:BoundField DataField="Loc" HeaderText="Loc" SortExpression="Loc" />
                                <asp:BoundField DataField="JobField" HeaderText="JobField" SortExpression="JobField" />
                                <asp:BoundField DataField="JobType" HeaderText="JobType" SortExpression="JobType" />
                                <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
                                <asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" />
                            </Columns>

                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT [PostHead], [Descr], [Loc], [JobField], [JobType], [Salary], [Status] FROM [JobPost]"></asp:SqlDataSource>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand">
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT * FROM [JobPost] WHERE ([PostHead] = @PostHead)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="dlst2" Name="PostHead" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT * FROM [JobPost] WHERE ([JobField] = @JobField)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="dlst2" Name="JobField" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT * FROM [JobPost] WHERE ([Loc] = @Loc)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="dlst2" Name="Loc" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </asp:Panel>

                    <asp:GridView ID="gdPost" runat="server" AllowPaging="true"
                        CssClass="table table-bordered"
                        DataKeyNames="PostId"
                        AutoGenerateColumns="False"
                        OnRowCommand="gdPost_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="PostId" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide"></asp:BoundField>
                            <asp:BoundField DataField="Header" HeaderText="Header"></asp:BoundField>
                            <asp:BoundField DataField="Descr" HeaderText="Description"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnApply" runat="server" CommandName="Apply" HeaderText="Apply for job" SelectText="Apply">Apply</asp:LinkButton>
                                    <asp:LinkButton ID="btnView" runat="server" CommandName="View" HeaderText="View details" SelectText="View">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>




                </div>

                <div>
                </div>

            </div>
        </div>
        <div class="col-sm-2">
        </div>
    </form>


</asp:Content>
