﻿<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="COMP2007_S2016_Week6.Students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conatainer">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <!-- Create -->
                <a href="StudentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"> Add Student</i></a>

                <div>
                    <label for="PageSizeDropDownList">Records per Page: </label>
                    <asp:DropDownList runat="server" ID="PageSizeDropDownList" AutoPostBack="true" 
                        CssClass="btn btn-default btn-sm dropdown-toggle" 
                        OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5"/>
                        <asp:ListItem Text="10" Value="10"/>
                        <asp:ListItem Text="All" Value="10000"/>
                    </asp:DropDownList>
                </div>

                <!-- Read -->
                <asp:GridView runat="server" ID="StudentsGridView" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="StudentID" 
                    OnRowDeleting="StudentsGridView_RowDeleting" AllowPaging="true" PageSize="3" 
                    OnPageIndexChanging="StudentsGridView_PageIndexChanging" AllowSorting="true"
                    OnSorting="StudentsGridView_Sorting" OnRowDataBound="StudentsGridView_RowDataBound" PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" Visible="true" SortExpression="StudentID"/>
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true" SortExpression="LastName"/>
                        <asp:BoundField DataField="FirstMidName" HeaderText="First Name" Visible="true" SortExpression="FirstMidName"/>
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true"
                            DataFormatString="{0:MMM dd, yyyy}" SortExpression="EnrollmentDate"/>
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/StudentDetails.aspx" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="StudentDetails.aspx?StudentID={0}" />
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" 
                            ShowDeleteButton="True" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
